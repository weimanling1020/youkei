﻿' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ログイン
'            レスポンスインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ0000

    ''' <summary>
    ''' ログイン処理(成功)
    ''' </summary>
    Public Class LoginResponse
        Inherits DaResponseBase

        ''' <summary>
        ''' トークン(ベースロジック)
        ''' </summary>
        Public Property TOKEN As String = String.Empty

        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

    End Class

    ''' <summary>
    ''' ユーザ情報処理(成功)
    ''' </summary>
    Public Class UserInfoResponse
        Inherits DaResponseBase

        'Public UserInfo As UserInfoVM
        ''' <summary>
        ''' ユーザID
        ''' </summary>
        Public Property USER_ID As String = String.Empty

        ''' <summary>
        ''' ユーザー名
        ''' </summary>
        Public Property USER_NAME As String = String.Empty

        ''' <summary>
        ''' 权限
        ''' </summary>
        Public Property ROLES As List(Of String) = New List(Of String)


        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

    End Class
End Namespace
