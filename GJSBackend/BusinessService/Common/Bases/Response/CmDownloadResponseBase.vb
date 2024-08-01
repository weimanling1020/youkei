﻿' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ダウンロード処理
' 　　　　　　レスポンスインターフェースベース
' 作成日　　: 2024.07.14
' 作成者　　: 蔣
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Service
    Public Class CmDownloadResponseBase
        Inherits CmPreviewResponseBase
        Public Property downloadtype As EnumDownloadType = EnumDownloadType.Data 'ファイルタイプ
        Public Property filefullnm As String                                      'ファイル名(パス含む)
    End Class
End Namespace
