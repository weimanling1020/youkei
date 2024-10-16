﻿' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 互助基金契約者マスタメンテナンス（農場情報入力）
'            サービス処理
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Imports JbdGjsService.JBD.GJS.Service.GJ1013

Namespace JBD.GJS.Service.GJ1013

    ''' <summary>
    ''' 初期化処理_詳細画面
    ''' </summary>
    <DisplayName("初期化処理_詳細画面")>
    Public Class Service
        Inherits CmServiceBase

        <DisplayName("検索処理_一覧画面")>
        Public Shared Function Search(req As SearchRequest) As SearchResponse
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
                    '検索結果出力用ＳＱＬ作成
                    Dim sql = FrmGJ1013Service.f_Search_SQLMake(req)

                    'データSelect 
                    Dim dt = FrmService.f_Select_ODP(db, sql).Tables(0)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------
                    If dt.Rows.Count = 0 Then
                        Return New SearchResponse("該当データが存在しませんでした。")
                    End If
                    Dim res = Wraper.SearchResponse(dt)

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function

        <DisplayName("初期化処理_詳細画面")>
        Public Shared Function InitDetail(req As InitDetailRequest) As InitDetailResponse
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
                    '都道府県情報処理
                    Dim sql = f_Ken_Data_Select()
                    Dim ds = FrmService.f_Select_ODP(db, sql)
                    ds.Tables(0).TableName = "t1"

                    '契約者農場情報処理
                    Select Case req.EDIT_KBN
                        Case EnumEditKbn.Edit       '変更入力
                            '検索結果出力用ＳＱＬ作成
                            sql = FrmGJ1013Service.f_SetForm_Data(req)

                            'データSelect 
                            Dim dt = FrmService.f_Select_ODP(db, sql).Tables(0)

                            'データ結果判定
                            If dt.Rows.Count = 0 Then
                                Return New InitDetailResponse("該当データが存在しませんでした。")
                            End If
                            Dim cdt As DataTable = dt.Copy()
                            ds.Tables.Add(cdt)
                    End Select

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------
                    Dim res = Wraper.InitDetailResponse(ds, req.EDIT_KBN)

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
                    Dim sReq As New InitDetailRequest()
                    sReq.KI = req.NOJO_JOHO.KI
                    sReq.KEIYAKUSYA_CD = req.NOJO_JOHO.KEIYAKUSYA_CD
                    sReq.NOJO_CD = req.NOJO_JOHO.NOJO_CD
                    Dim sql = FrmGJ1013Service.f_SetForm_Data(sReq)

                    'データSelect 
                    Dim dt = FrmService.f_Select_ODP(db, sql).Tables(0)

                    'データの独占性
                    Select Case req.EDIT_KBN
                        Case EnumEditKbn.Edit       '変更入力
                            If dt.Rows.Count = 0 Then
                                Return New DaResponseBase("データが存在しないため、データを変更できません。")
                            Else
                                If CDate(dt.Rows(0)("UP_DATE")) > req.NOJO_JOHO.UP_DATE Then
                                    Return New DaResponseBase("データを更新できません。他のユーザーによって変更された可能性があります。")
                                End If
                            End If
                        Case EnumEditKbn.Add       '新規入力
                            If dt.Rows.Count > 0 Then
                                Return New DaResponseBase("データは既に登録されています。")
                            End If
                    End Select

                    '保存処理
                    Dim res = FrmGJ1013Service.f_Data_Update(db, req)

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
