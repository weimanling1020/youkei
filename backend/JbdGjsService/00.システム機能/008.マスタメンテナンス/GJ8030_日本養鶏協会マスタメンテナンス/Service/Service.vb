﻿' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 日本養鶏協会マスタメンテナンス
'             サービス処理
' 作成日　　: 2024.08.20
' 作成者　　: 唐
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8030

    ''' <summary>
    ''' 初期化処理_詳細画面
    ''' </summary>
    <DisplayName("初期化処理_詳細画面")>
    Public Class Service
        Inherits CmServiceBase

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
                    'データクエリ
                    Dim sql1 = f_Bank_Data_Select()
                    Dim sql2 = f_BankShop_Data_Select(req.BANK_CD)

                    'データSelect 
                    Dim ds1 = FrmService.f_Select_ODP(db, sql1)
                    Dim dt1 = ds1.Tables(0)

                    Dim ds2 = FrmService.f_Select_ODP(db, sql2)
                    Dim dt2 = ds2.Tables(0)

                    Dim dt3 = f_CodeMaster_Data_Select(4, 0)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------
                    Dim res = Wraper.GetInitDetailResponse(dt1, dt2, dt3)

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function



        <DisplayName("検索処理_詳細画面")>
        Public Shared Function SearchDetail(req As DaRequestBase) As SearchDetailResponse
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
                    Dim sql = FrmGJ8030Service.f_SetForm_Data(sReq)

                    'データSelect 
                    Dim ds = FrmService.f_Select_ODP(db, sql)
                    Dim dt = ds.Tables(0)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------
                    If dt.Rows.Count = 0 Then
                        Return New SearchDetailResponse()
                    End If
                    Dim res = Wraper.GetSearchDetailResponse(dt)

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function

        <DisplayName("保存処理_詳細画面")>
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
                    Dim sql = FrmGJ8030Service.f_SetForm_Data(sReq)

                    'データSelect 
                    Dim ds = FrmService.f_Select_ODP(db, sql)
                    Dim dt = ds.Tables(0)

                    ''データの独占性
                    If req.EDIT_KBN = EnumEditKbn.Add Then
                        If dt.Rows.Count > 0 Then
                            Return New DaResponseBase("既に登録されています。")
                        End If
                    Else
                        If dt.Rows.Count = 0 Then
                            Return New DaResponseBase("既に削除されています。")
                        End If

                        If CDate(dt.Rows(0)("UP_DATE")) > req.KYOKAI.UP_DATE Then
                            Return New DaResponseBase("データを更新できません。他のユーザーによって変更された可能性があります。")
                        End If
                    End If
                    'If dt.Rows.Count = 0 Then
                    '    req.EDIT_KBN = EnumEditKbn.Add
                    'Else

                    '    req.EDIT_KBN = EnumEditKbn.Edit
                    'End If

                    '保存処理
                    Dim res = FrmGJ8030Service.f_Data_Update(db, req)

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