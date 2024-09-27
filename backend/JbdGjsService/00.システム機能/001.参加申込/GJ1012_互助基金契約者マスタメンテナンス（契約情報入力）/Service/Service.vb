﻿' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 互助基金契約者マスタメンテナンス（契約情報入力）
'            サービス処理
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Imports System.Runtime
Imports JbdGjsService.JBD.GJS.Service.GJ1010
Imports JbdGjsService.JBD.GJS.Service.GJ1011
Imports OracleInternal
Imports OracleInternal.Json

Namespace JBD.GJS.Service.GJ1012

    ''' <summary>
    ''' 互助基金契約者マスタメンテナンス（契約情報入力）画面
    ''' </summary>
    <DisplayName("互助基金契約者マスタメンテナンス（契約情報入力）画面")>
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
                    Dim sqlchk = FrmGJ1012Service.f_SetForm_Data(req)
                    Dim dtchk = FrmService.f_Select_ODP(db, sqlchk).Tables(0)
                    If dtchk.Rows.Count = 0 Then
                        Return New SearchResponse("該当契約者が存在しませんでした。")
                    End If

                    'データセーブ
                    With dtchk
                        '契約区分
                        If .Rows(0)("KEIYAKU_KBN").ToString = "" Then
                            Return New SearchResponse("契約区分が設定されていません。")
                        End If

                        '入力状況  
                        If .Rows(0)("NYURYOKU_JYOKYO").ToString = "" Then
                            Return New SearchResponse("入力確認有無が設定されていません。")
                        End If

                    End With

                    '-------------------------------------------------------------
                    '4.ビジネスロジック処理
                    '-------------------------------------------------------------
                    '検索結果出力用ＳＱＬ作成
                    Dim sql1 = FrmGJ1012Service.f_KeiyakuNojo_Data_Select(req)
                    Dim sql3 = FrmGJ1012Service.f_Hasu_SQLMake(req)
                    Dim sql4 = FrmGJ1012Service.f_Search_SQLMake(req)

                    'データSelect 
                    Dim dt1 = FrmService.f_Select_ODP(db, sql1).Tables(0)
                    Dim dt2 = f_CodeMaster_Data_Select(7, 1)
                    Dim dt3 = FrmService.f_Select_ODP(db, sql3).Tables(0)
                    Dim dt4 = FrmService.f_Select_ODP(db, sql4).Tables(0)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------
                    If dt1.Rows.Count = 0 Or dt2.Rows.Count = 0 Or dt3.Rows.Count = 0 Or dt4.Rows.Count = 0 Then
                        Return New SearchResponse("該当データが存在しませんでした。")
                    End If
                    Dim res = Wraper.SearchResponse(dt1, dt2, dt3, dt4)
                    res.KEIYAKU_KBN = DaConvertUtil.CInt(dtchk.Rows(0)("KEIYAKU_KBN"))

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function

        <DisplayName("農場住所情報初期化処理_詳細画面処理")>
        Public Shared Function InitNojo(req As InitNojoRequest) As InitNojoResponse
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
                    Dim sql = FrmGJ1012Service.f_NojoAddr_Dsp(req)

                    'データSelect 
                    Dim dt = FrmService.f_Select_ODP(db, sql).Tables(0)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------

                    Dim res = Wraper.InitNojoResponse(dt)

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function

        <DisplayName("前期データコピー処理_詳細画面処理")>
        Public Shared Function Copy(req As CopyRequest) As DaResponseBase
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

                    '保存処理
                    Dim res = FrmGJ1012Service.f_Data_Copy(db, req)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------

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

                    '保存処理
                    Dim res = FrmGJ1012Service.f_Data_Update(db, req)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function

        <DisplayName("削除処理_詳細画面処理")>
        Public Shared Function Delete(req As DeleteRequest) As DaResponseBase
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
                    '削除結果出力用ＳＱＬ作成
                    Dim res = FrmGJ1012Service.f_Data_Deleate(db, req)

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
