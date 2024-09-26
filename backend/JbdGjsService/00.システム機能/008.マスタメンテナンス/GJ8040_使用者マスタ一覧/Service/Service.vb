﻿' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 使用者マスタ一覧
'             サービス処理
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8040

    ''' <summary>
    ''' 検索処理_一覧画面処理
    ''' </summary>
    <DisplayName("検索処理_一覧画面処理")>
    Public Class Service
        Inherits CmServiceBase

        <DisplayName("検索処理_一覧画面処理")>
        Public Shared Function Search(req As DaRequestBase) As SearchResponse
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
                    Dim sql = FrmGJ8040Service.f_Search_SQLMake()

                    'データSelect 
                    Dim ds = FrmService.f_Select_ODP(db, sql)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------
                    Dim dt = ds.Tables(0)
                    If dt.Rows.Count = 0 Then
                        Return New SearchResponse(EnumServiceResult.ServiceAlert2, "指定された条件に一致するデータは存在しません。")
                    End If
                    Dim res = Wraper.SearchResponse(dt)

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function

    End Class
End Namespace
