﻿' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 金融機関マスタ一覧
'             サービス処理
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8050

    ''' <summary>
    ''' 金融機関マスタ一覧
    ''' </summary>
    <DisplayName("金融機関マスタ一覧")>
    Public Class Service
        Inherits CmServiceBase

        <DisplayName("検索処理_一覧画面処理")>
        Public Shared Function SearchBank(req As SearchBankRequest) As SearchBankResponse
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
                    Dim sql = FrmGJ8050Service.f_Search_SQLMake(req)

                    '元の SQL をページ分割されたデータ出力に変換する
                    Dim psql = FrmGJ8050Service.f_Search_SQLMakePage(req.PAGE_SIZE, req.PAGE_NUM, sql)

                    'データSelect 
                    Dim ds = FrmService.f_Select_ODP(db, psql)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------
                    Dim dt = ds.Tables(0)
                    If dt.Rows.Count = 0 Then
                        Return New SearchBankResponse(EnumServiceResult.OK, "指定された条件に一致するデータは存在しません。")
                    End If
                    Dim res = Wraper.SearchBankResponse(dt)

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function

        <DisplayName("検索処理_支店一覧画面処理")>
        Public Shared Function SearchSiten(req As SearchSitenRequest) As SearchSitenResponse
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
                    Dim sql = FrmGJ8050Service.f_Search_SQLMake2(req)

                    '元の SQL をページ分割されたデータ出力に変換する
                    Dim psql = FrmGJ8050Service.f_Search_SQLMakePage2(req.PAGE_SIZE, req.PAGE_NUM,  sql)

                    'データSelect 
                    Dim ds = FrmService.f_Select_ODP(db, psql)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------
                    Dim dt = ds.Tables(0)
                    If dt.Rows.Count = 0 Then
                        Return New SearchSitenResponse(EnumServiceResult.OK, "指定された条件に一致するデータは存在しません。")
                    End If
                    Dim res = Wraper.SearchSitenResponse(dt)

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function

        <DisplayName("プレビュー処理_金融機関プレビュー画面")>
        Public Shared Function PreviewBank(req As PreviewBankRequest) As CmPreviewResponseBase
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
                    Dim sql = FrmGJ8050Service.f_make_SQL(req)

                    'データSelect 
                    Dim ds = FrmService.f_Select_ODP(db, sql)

                    'データ結果判定
                    Dim dt = ds.Tables(0)
                    If dt.Rows.Count > 0 Then
                        Return New CmPreviewResponseBase
                    Else
                        Return New CmPreviewResponseBase(EnumServiceResult.ServiceAlert2, "該当データが存在しませんでした。")
                    End If

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------

                End Function)

        End Function

        <DisplayName("プレビュー処理_支店プレビュー画面")>
        Public Shared Function PreviewSiten(req As PreviewSitenRequest) As CmPreviewResponseBase
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
                    Dim sql = FrmGJ8050Service.f_make_SQL2(req)

                    'データSelect 
                    Dim ds = FrmService.f_Select_ODP(db, sql)

                    'データ結果判定
                    Dim dt = ds.Tables(0)
                    If dt.Rows.Count > 0 Then
                        Return New CmPreviewResponseBase
                    Else
                        Return New CmPreviewResponseBase(EnumServiceResult.ServiceAlert2, "該当データが存在しませんでした。")
                    End If

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------

                End Function)

        End Function
    End Class
End Namespace
