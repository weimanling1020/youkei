﻿' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 契約者農場マスタメンテナンス
'             サービス処理
' 作成日　　: 2024.07.21
' 作成者　　: 宋
' 変更履歴　:
' *******************************************************************

Imports JbdGjsCommon.JBD.GJS.Common.JbdGjsCommon

Namespace JBD.GJS.Service.GJ8090

    ''' <summary>
    ''' 初期化処理_一覧画面
    ''' </summary>
    <DisplayName("初期化処理_一覧画面")>
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
                    'チェックトークン
                    Dim uid = CheckToken(req.token)
                    If String.IsNullOrEmpty(uid) Then Return New InitResponse("トークンが正しくありません。")

                    '-------------------------------------------------------------
                    '4.ビジネスロジック処理
                    '-------------------------------------------------------------
                    'データ結果判定
                    If req.KI = 0 Then
                        Dim ki =Cint(New Obj_TM_SYORI_NENDO_KI().pKI)
                        Dim ret As New InitResponse With {
                            .KI = ki
                        }
                        Return ret
                    End If

                    'データクエリ
                    Dim dt = f_Keiyaku_Data_Select_New(req.KI, True, String.Empty)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------
                    Dim res = Wraper.GetInitResponse(dt)
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
                    'チェックトークン
                    Dim uid = CheckToken(req.token)
                    If String.IsNullOrEmpty(uid) Then Return New SearchResponse("トークンが正しくありません。")
                    
                    '-------------------------------------------------------------
                    '4.ビジネスロジック処理
                    '-------------------------------------------------------------
                    '検索結果出力用ＳＱＬ作成
                    Dim sql = f_Search_SQLMakeNew(req)

                    '元の SQL をページ分割されたデータ出力に変換する
                    Dim psql = f_Search_SQLMakePage(req.PAGE_SIZE, req.PAGE_NUM, sql)

                    'データSelect 
                    Dim ds = f_Select_ODP(db, psql)
                    Dim dt = ds.Tables(0)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------
                    Dim res = Wraper.SearchResponse(dt)
                    res.KI = req.KI
                    res.KEIYAKUSYA_CD = req.KEIYAKUSYA_CD

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function

    End Class
End Namespace
