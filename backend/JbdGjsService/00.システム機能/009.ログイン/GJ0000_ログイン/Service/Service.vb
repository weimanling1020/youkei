﻿' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ログイン
'            サービス処理
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ0000
    
    ''' <summary>
    ''' ログイン
    ''' </summary>
    <DisplayName("ログイン")>
    Public Class Service
        Inherits CmServiceBase

        <DisplayName("ログイン処理")>
        Public Shared Function Login(req As LoginRequest) As LoginResponse
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
                    Dim sql = FrmGJ0000Service.f_Search_SQLMake(req.USER_ID)

                    'データSelect 
                    Dim ds = FrmService.f_Select_ODP(db, sql)
                    Dim dt = ds.Tables(0)

                    'データ結果判定
                    If dt.Rows.Count > 0 Then
                        Dim ret = FrmGJ0000Service.f_User_Check(dt, req.PASS, req.USER_ID)
                        If Not String.IsNullOrEmpty(ret) Then
                            Return New LoginResponse(ret)
                        End If
                    Else
                        'データ存在なし
                        Return New LoginResponse("ユーザーＩＤ、パスワードが正しくありません。")
                    End If

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------
                    Dim res = Wraper.GetLoginResponse(dt)

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function

        <DisplayName("ユーザー情報を取得する")>
        Public Shared Function GetUserInfo(req As DaRequestBase) As UserInfoResponse
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
                    Dim sql = FrmGJ0000Service.f_Search_SQLMake(pLOGINUSERID)

                    'データSelect 
                    Dim ds = FrmService.f_Select_ODP(db, sql)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------
                    Dim dt = ds.Tables(0)
                    Dim res = Wraper.GetUserResponse(dt)

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function

        <DisplayName("ホーム情報を取得する")>
        Public Shared Function Home(req As DaRequestBase) As HomeInfoResponse
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
                    Dim sql = FrmGJ0000Service.f_Search_SQLHome()

                    'データSelect 
                    Dim ds = FrmService.f_Select_ODP(db, sql)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------
                    Dim dt = ds.Tables(0)
                    Dim res = Wraper.GetHomeResponse(dt)

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

        End Function
    End Class
End Namespace
