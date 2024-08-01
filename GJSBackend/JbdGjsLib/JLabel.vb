﻿
Imports System.ComponentModel
Public Class JLabel
    Inherits System.Windows.Forms.Label

    Public Sub New()
        Me.New(Nothing)
    End Sub


    Public Sub New(ByVal component As System.ComponentModel.IContainer)
        MyBase.New()
        ' この呼び出しは、コンポーネント デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        Me.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.Standard
    End Sub

    'Control は、コンポーネント一覧に後処理を実行するために、dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'コントロール デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ : 以下のプロシージャはコンポーネント デザイナで必要です。
    ' コンポーネント デザイナを使って変更できます。
    ' コード エディタを使って変更しないでください。  
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'JLabel
        '
        '背景色設定
        Me.BackColor = GjsDefaultColor.LabelBackColor
        'フォント設定
        Me.Font = New System.Drawing.Font(GjsDefaultFont.Name.Default.ToString, GjsDefaultFont.Size.Default, System.Drawing.FontStyle.Regular)

        Me.ResumeLayout(False)

    End Sub


End Class