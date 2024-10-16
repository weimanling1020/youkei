﻿' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 事務委託先一覧表
'             サービス処理
' 作成日　　: 2024.09.27
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8060

    ''' <summary>
    ''' 検索処理_一覧画面処理
    ''' </summary>
    <DisplayName("検索処理_一覧画面処理")>
    Public Class Service
        Inherits CmServiceBase

        <DisplayName("初期化処理_一覧画面処理")>
        Public Shared Function Init(req As InitRequest) As InitResponse
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
                    'データ結果判定
                    If req.KI = -1 Then
                        req.KI =Cint(New Obj_TM_SYORI_NENDO_KI().pKI)
                    End If

                    '都道府県情報処理
                    Dim sql = f_Ken_Data_Select()
                    Dim ds = FrmService.f_Select_ODP(db, sql)
                    Dim dt = ds.Tables(0)
                    
                    'データ結果判定
                    If dt.Rows.Count = 0 Then
                        Return New InitResponse("コントロールマスタが設定されていません。")
                    End If

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------
                    Dim res = Wraper.InitResponse(dt)
                    res.KI =  req.KI

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function

        <DisplayName("検索処理_一覧画面処理")>
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
                    Dim sql = FrmGJ8060Service.f_Search_SQLMake(0, req)
                    Dim rSql = FrmService.f_Search_SQLMakePage(req.PAGE_SIZE,req.PAGE_NUM, sql)

                    'データSelect 
                    Dim ds = FrmService.f_Select_ODP(db, rSql)

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

        <DisplayName("CSV出力処理_一覧画面処理")>
        Public Shared Function CsvExport(req As SearchRequest) As CmDownloadResponseBase
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
                    Dim sql = FrmGJ8060Service.f_Search_SQLMake(1, req)

                    'データSelect 
                    Dim ds = FrmService.f_Select_ODP(db, sql)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------
                    Dim dt = ds.Tables(0)
                    If dt.Rows.Count = 0 Then
                        Return New CmDownloadResponseBase(EnumServiceResult.ServiceAlert2, "指定された条件に一致するデータは存在しません。")
                    End If
                    Dim res = Wraper.CsvExportResponse(dt)

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function

    End Class
End Namespace
