﻿' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 処理対象期・年度マスタメンテナンス
'             サービス処理
' 作成日　　: 2024.08.20
' 作成者　　: 唐
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8020

    ''' <summary>
    ''' 初期化処理_詳細画面
    ''' </summary>
    <DisplayName("初期化処理_詳細画面")>
    Public Class Service
        Inherits CmServiceBase

        <DisplayName("初期化処理_詳細画面処理")>
        Public Shared Function InitDetail(req As DaRequestBase) As InitDetailResponse
            Return Nolock(req,
                Function(db)

                    '-------------------------------------------------------------
                    '1.初期化
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '2.データ取得
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '3.チェック処理
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '4.ビジネスロジック処理
                    '-------------------------------------------------------------
                    'データクエリ
                    Dim sReq = New DaRequestBase
                    Dim sql = f_SetForm_Data(sReq)

                    'データSelect 
                    Dim ds = f_Select_ODP(db, sql)
                    Dim dt = ds.Tables(0)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------
                    If dt.Rows.Count = 0 Then
                        Return New InitDetailResponse()
                    End If
                    Dim res = Wraper.GetInitDetailResponse(dt)

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function

        <DisplayName("保存処理_詳細画面処理")>
        Public Shared Function Save(req As SaveRequest) As DaResponseBase
            Return Transction(req,
                Function(db)

                    '-------------------------------------------------------------
                    '1.初期化
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '2.データ取得
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '3.チェック処理
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '4.ビジネスロジック処理
                    '-------------------------------------------------------------
                    '検索結果出力用ＳＱＬ作成
                    Dim sReq = New DaRequestBase
                    Dim sql = f_SetForm_Data(sReq)

                    'データSelect 
                    Dim ds = f_Select_ODP(db, sql)
                    Dim dt = ds.Tables(0)

                    'データの独占性
                    Select Case req.EDIT_KBN
                        Case EnumEditKbn.Edit       '変更入力
                            If dt.Rows.Count = 0 Then
                                Return New DaResponseBase("変更したデータはありません。")
                            Else
                                If CDate(dt.Rows(0)("UP_DATE")) > req.SYORI_KI.UP_DATE Then
                                    Return New DaResponseBase("データを更新できません。他のユーザーによって変更された可能性があります。")
                                End If
                            End If
                        Case EnumEditKbn.Add       '新規入力
                            If dt.Rows.Count > 0 Then
                                Return New DaResponseBase("データは既に登録されています。")
                            End If
                    End Select

                    '保存処理
                    Dim res = f_Data_Update(db, req)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function

    End Class
End Namespace