﻿' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ログイン
'             レスポンスインターフェース
' 作成日　　: 
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Imports System.Text.Json.Serialization
Imports BusinessService.JBD.GJS.Service.Common

Namespace JBD.GJS.Service.GJ0000
    ''' <summary>
    ''' ログイン処理(成功)
    ''' </summary>
    Public Class LoginResponse
        Inherits Db.DaResponseBase
        <JsonPropertyName("TOKEN")>
        Public Property token As String               'トークン(ベースロジック)
        'Public Property userinfo As UserInfoVM        'ユーザー情報(共通)
        'Public Property sisyolist As List(Of CmSisyoVM)  '支所リスト(登録支所選択用)
        'Public Property pwdmsgflg As Boolean             '警告フラグ true:警告メッセージが出る(通知範囲以内の場合)
    End Class

    Public Class UserInfoResponse
        Inherits Db.DaResponseBase
        <JsonPropertyName("USER_ID")>
        Public Property userid As String      'ユーザID
        <JsonPropertyName("USER_NAME")>
        Public Property usernm As String      'ユーザー名
        <JsonPropertyName("ROLES")>
        Public Property Roles As List(Of String)
    End Class
End Namespace
