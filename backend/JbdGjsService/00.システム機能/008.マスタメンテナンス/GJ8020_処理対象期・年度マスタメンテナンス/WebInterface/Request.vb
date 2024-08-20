﻿' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 処理対象期・年度マスタメンテナンス
'             リクエストインターフェース
' 作成日　　: 2024.08.20
' 作成者　　: 唐
' 変更履歴　:
' *******************************************************************

Imports JbdGjsService.JBD.GJS.Service.GJ8091

Namespace JBD.GJS.Service.GJ8020

    ''' <summary>
    ''' 初期化処理_一覧画面処理
    ''' </summary>
    Public Class InitRequest
        Inherits DaRequestBase

    End Class

    ''' <summary>
    ''' 保存処理_詳細画面処理
    ''' </summary>
    Public Class SaveRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 契約者農場情報
        ''' </summary>
        Public Property SYORI_KI As DetailVM = New DetailVM

        Public Property EDIT_KBN As Enum編集区分 = Enum編集区分.新規


    End Class
End Namespace
