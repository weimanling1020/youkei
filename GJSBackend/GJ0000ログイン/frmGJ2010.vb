﻿'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ2010.vb
'*
'*　　②　機能概要　　　　　契約者積立金・互助単価マスタ一覧
'*
'*　　③　作成日　　　　　　2015/02/06  BY JBD 999
'*
'*　　④　更新日            
'*
'*******************************************************************************
Option Strict Off
Option Explicit On

'------------------------------------------------------------------
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
'------------------------------------------------------------------

Imports JbdGjsCommon
Imports JbdGjsControl
Imports System.Data
Imports System.Windows.Forms
Imports System.Collections

Imports GrapeCity.ActiveReports.SectionReportModel
Imports GrapeCity.ActiveReports.Export
Imports GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport

Imports System.IO

Public Class frmGJ2010

#Region "*** 変数定義 ***"

    Private pDataSet As New DataSet                     '検索結果一覧セット用データセット


    Private Const C_TAISYO_DATE_FROM As Integer = 0     '年月日(自)
    Private Const C_TAISYO_DATE_TO As Integer = 1       '年月日(至)

    'グリッドキー項目構造体
    Public Class T_KEY
        Public strTAISYO_DATE_FROM As String = String.Empty
        Public strTAISYO_DATE_TO As String = String.Empty
        Public blnCHG_FLG As Boolean = False

    End Class
    Public paryKEY_2010 As New ArrayList
    Public pSaveFlg As Boolean = False
    Public pSaveTAISYO_DATE_FROM As String = String.Empty

#End Region

#Region "*** 画面制御関連 ***"

#Region "frmGJ2010_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ2010Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmGJ2010_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean

        Try
            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            ret = f_ObjectClear()

            ''コンピュータ名取得
            'pPCNAME = System.Net.Dns.GetHostName

            'グリッドビューセット
            If Not f_GridView_Set() Then
                Exit Try
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        End Try

    End Sub

#End Region
#Region "frmGJ2010_Disposed Form_Disposedイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ2010_Disposed
    '説明            :Form_Disposedイベント
    '------------------------------------------------------------------
    Private Sub frmGJ2010_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        pDataSet.Clear()
        pDataSet.Dispose()

    End Sub

#End Region
#Region "frmGJ2010_Activated Form_Activatedイベント"

    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ2010_Activated
    '説明            :Form_Activatedイベント
    '------------------------------------------------------------------
    Private Sub frmGJ2010_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Try

            If dgv_Search.Rows.Count = 0 Then
                cmdUpd.Enabled = False
                cmdDel.Enabled = False
                'データなしの時、新規登録ボタンへ
                dgv_Search.Enabled = False
                dgv_Search.Enabled = True
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub
#End Region
#Region "f_ObjectClear 画面クリア処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ObjectClear
    '説明            :画面クリア処理
    '引数            :rKbn(処理区分)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ObjectClear() As Boolean

        f_ObjectClear = False
        Try

            f_ObjectClear = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            paryKEY_2010 = New ArrayList

            pDataSet.Clear()

            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Function
#End Region

#End Region

#Region "*** 画面ボタンクリック関連 ***"

#Region "cmdDel_Click 削除ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdDel_Click
    '説明            :削除ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '一覧より選択されていなければエラー
            If dgv_Search.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")     'データが選択されていません。
                'Show_MessageBox("データが選択されていません。", C_MSGICON_INFORMATION)
                Exit Try
            End If

            '削除処理確認
            If Show_MessageBox_Add("Q006", "指定されたデータ") = DialogResult.No Then    '指定されたデータを削除します。よろしいですか？
                'If Show_MessageBox("指定されたデータを削除します。よろしいですか？", C_MSGICON_QUESTION) = DialogResult.No Then    '指定されたデータを削除します。よろしいですか？
                '「いいえ」を選択
                Exit Try
            End If

            Dim intRow As Integer = 0       '行番号

            For Each gRow As DataGridViewRow In dgv_Search.SelectedRows
                intRow = gRow.Index
            Next

            '該当データ削除処理
            If Not f_TM_TANKA_Deleate(intRow) Then
                Exit Try
            End If

            ' ''ArrayList対応--▼
            ' ''最終行削除のとき、最終行へ
            ' ''上記以外のときは、削除した行へ
            ''If intRow <> 0 Then
            ''    If intRow < dgv_Search.Rows.Count - 1 Then
            ''        dgv_Search.CurrentCell = dgv_Search.Rows(intRow).Cells(0)
            ''    Else
            ''        dgv_Search.CurrentCell = dgv_Search.Rows(intRow - 1).Cells(0)
            ''    End If
            ''End If

            ' ''画面グリッドの更新
            ' ''抽出件数の更新(1件減らす)
            ''dgv_Search.AllowUserToDeleteRows = True
            ''dgv_Search.Rows.RemoveAt(intRow)

            ' ''件数０件の時、新規登録ボタンへ
            ''If dgv_Search.Rows.Count = 0 Then
            ''    cmdUpd.Enabled = False
            ''    cmdDel.Enabled = False
            ''    cmdIns.Focus()
            ''Else
            ''    dgv_Search.Focus()
            ''End If
            ' ''ArrayList対応--▲

            ' ''GlidView対応--▼
            '削除した年月日
            pSaveTAISYO_DATE_FROM = dgv_Search.Item(C_TAISYO_DATE_FROM, intRow).Value
            'グリッドビューセット
            If Not f_GridView_Set() Then
                Exit Try
            End If
            ' ''GlidView対応--▲

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#Region "cmdIns_Click 新規入力ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdIns_Click
    '説明            :新規入力ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdIns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIns.Click
        Dim tKEY As New T_KEY
        Dim intNo As Integer = 0

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            ' ''GlidView対応--▼
            'カレント年月日セーブ
            If dgv_Search.RowCount = 0 Then
                pSaveTAISYO_DATE_FROM = String.Empty
            Else
                pSaveTAISYO_DATE_FROM = dgv_Search.Item(C_TAISYO_DATE_FROM, dgv_Search.CurrentRow.Index).Value
            End If
            ' ''GlidView対応--▲

            '登録データ格納用の構造体を作成
            paryKEY_2010 = New ArrayList
            tKEY = New T_KEY
            pSaveFlg = False
            paryKEY_2010.Add(tKEY)

            'メンテナンス画面　表示
            Dim form As New frmGJ2011
            form.Owner = Me
            form.pSyoriKbn = frmGJ2011.C_INSERT
            form.paryKEY_2011 = paryKEY_2010

            form.ShowDialog()

            ' ''ArrayList対応--▼
            ' ''登録データを、構造体よりグリッド（最終行）に格納
            ''If pSaveFlg Then
            ''    Dim row1 As String() = New String() _
            ''    {tKEY.strUSER_ID, tKEY.strUSER_NAME, tKEY.strSIYO_KBN_NAME, tKEY.strTEISI_DATE, tKEY.strTEISI_RIYU}
            ''    pDataSet.Tables(0).Rows.Add(row1)
            ''     '登録データ　表示
            ''    dgv_Search.DataSource = pDataSet.Tables(0)
            ''    intNo = dgv_Search.RowCount - 1
            ''    dgv_Search.CurrentCell = dgv_Search.Rows(intNo).Cells(0)
            ''    dgv_Search.Focus()
            ''    cmdUpd.Enabled = True
            ''    cmdDel.Enabled = True
            ''End If
            ' ''ArrayList対応--▲

            ' ''GlidView対応--▼
            'グリッドビューセット
            If Not f_GridView_Set() Then
                Exit Try
            End If
            ' ''GlidView対応--▲

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#Region "cmdUpd_Click 変更ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdUpd_Click
    '説明            :変更ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdUpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpd.Click

        Dim tKEY As New T_KEY
        Dim strTAISYO_DATE_FROM As String = String.Empty
        Dim intNo As Integer = 0


        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '一覧より選択されていなければエラー
            If dgv_Search.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")     'データが選択されていません。
                'Show_MessageBox("データが選択されていません。", C_MSGICON_INFORMATION)       'データが選択されていません。
                Exit Try
            End If

            ' ''GlidView対応--▼
            'カレントセーブ
            If dgv_Search.RowCount = 0 Then
                pSaveTAISYO_DATE_FROM = String.Empty
            Else
                pSaveTAISYO_DATE_FROM = dgv_Search.Item(C_TAISYO_DATE_FROM, dgv_Search.CurrentRow.Index).Value
            End If
            ' ''GlidView対応--▲

            'グリッドの構造体に格納
            paryKEY_2010 = New ArrayList
            For i As Integer = 0 To dgv_Search.RowCount - 1
                tKEY = New T_KEY
                tKEY.strTAISYO_DATE_FROM = WordHenkan("N", "S", dgv_Search.Item(C_TAISYO_DATE_FROM, i).Value)
                tKEY.strTAISYO_DATE_TO = WordHenkan("N", "S", dgv_Search.Item(C_TAISYO_DATE_TO, i).Value)
                tKEY.blnCHG_FLG = False
                If dgv_Search.Rows(i).Selected Then
                    strTAISYO_DATE_FROM = tKEY.strTAISYO_DATE_FROM    '現在選択されている行のキー
                    intNo = i + 1                   '現在選択されている行の位置
                End If
                paryKEY_2010.Add(tKEY)
            Next

            'メンテナンス画面へ
            Dim form As New frmGJ2011
            form.Owner = Me                             '2010/10/16 ADD JBD200
            form.pSel_TAISYO_DATE_FROM = strTAISYO_DATE_FROM     '現在選択されている行のキーを渡します
            form.pSel_NO = intNo                        '現在選択されている行の位置を渡します
            form.pSyoriKbn = frmGJ2011.C_UPDATE
            form.paryKEY_2011 = paryKEY_2010

            form.ShowDialog()

            ' ''ArrayList対応--▼
            '変更後のデータを、構造体よりグリッドに格納
            ''If pSaveFlg Then
            ''    For i As Integer = 0 To dgv_Search.RowCount - 1
            ''        tKEY = New T_KEY
            ''        tKEY = paryKEY_201(i)
            ''        If tKEY.blnCHG_FLG Then
            ''            dgv_Search.Item(C_USER_ID, i).Value = tKEY.strUSER_ID
            ''            dgv_Search.Item(C_USER_NAME, i).Value = tKEY.strUSER_NAME
            ''            dgv_Search.Item(C_SIYO_KBN_NAME, i).Value = tKEY.strSIYO_KBN_NAME
            ''            dgv_Search.Item(C_TEISI_DATE, i).Value = tKEY.strTEISI_DATE
            ''            dgv_Search.Item(C_TEISI_RIYU, i).Value = tKEY.strTEISI_RIYU
            ''        End If
            ''    Next
            ''End If

            ' ''変更後のデータを、表示
            ''dgv_Search.Refresh()
            ''dgv_Search.CurrentCell = dgv_Search.Rows(form.pSel_NO - 1).Cells(0)
            ''dgv_Search.Focus()
            ' ''ArrayList対応--▲

            ' ''GlidView対応--▼
            'グリッドビューセット
            If Not f_GridView_Set() Then
                Exit Try
            End If
            ' ''GlidView対応--▲

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#Region "cmdEnd_Click 終了ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdEnd_Click
    '説明            :終了ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        Try
            If Show_MessageBox("Q001", "") = DialogResult.No Then   '終了します。よろしいですか？
                'If Show_MessageBox("処理を終了しますか？", C_MSGICON_QUESTION) = Windows.Forms.DialogResult.Yes Then
                '処理を終了しますか？
                Exit Try
            End If

            'フォームクローズ
            Me.AutoValidate = AutoValidate.Disable      '2010/10/16 ADD JBD200
            Me.Close()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            'データベースへの接断
            Cnn.Close()
            'フォームクローズ
            Me.Close()
        End Try
    End Sub
#End Region

#End Region

#Region "*** ローカル関数 ***"

#Region "f_GridView_Set グリッドビューセット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_GridView_Set
    '説明            :グリッドビューセット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_GridView_Set() As Boolean
        Dim sSql As String = String.Empty
        Dim ret As Boolean = False

        Try
            '契約者積立金・互助単価マスタ一覧セット
            '検索処理
            pDataSet.Clear()
            'dgv_Search.Height = 655

            sSql = f_Search_SQLMake(0)
            If Not f_Select_ODP(pDataSet, sSql) Then
                Exit Try
            End If

            If pDataSet.Tables(0).Rows.Count > 0 Then
                '画面に該当データを表示
                dgv_Search.DataSource = pDataSet.Tables(0)
            Else
                'データ存在なし
                pDataSet.Clear()
            End If

            ' ''GlidView対応--▼
            'カーソルセット
            If Not f_GridRow_Set(pSaveTAISYO_DATE_FROM) Then
                Exit Try
            End If
            ' ''GlidView対応--▲

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_GridRow_Set グリッドビュー現在行セット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_GridRow_Set
    '説明            :グリッドビュー現在行セット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_GridRow_Set(ByVal wTAISYO_DATE_FROM As String) As Boolean
        Dim ret As Boolean = False
        Dim wIdx As Integer = 0

        Try

            If dgv_Search.RowCount = 0 Then
                '表示データなし
                cmdUpd.Enabled = False
                cmdDel.Enabled = False
                'データなしの時、新規登録ボタンへ
                dgv_Search.Enabled = False
                dgv_Search.Enabled = True

            ElseIf wTAISYO_DATE_FROM = "" Then
                '初期処理＆表示データあり
                wIdx = 0
                '変更、削除ボタン　有効
                cmdUpd.Enabled = True
                cmdDel.Enabled = True

            Else
                '初期処理以外＆表示データあり
                '登録のとき、登録した年月日に位置づけ
                '変更のとき、変更した年月日に位置づけ
                '削除のとき、削除した年月日の次の年月日に位置づけ
                '　　　　　　削除した年月日が最終行の場合は、最終行に位置づけ
                For i As Integer = 0 To dgv_Search.RowCount - 1
                    wIdx = i
                    If dgv_Search.Item(C_TAISYO_DATE_FROM, i).Value >= wTAISYO_DATE_FROM Then
                        Exit For
                    End If
                Next

                '変更、削除ボタン　有効
                cmdUpd.Enabled = True
                cmdDel.Enabled = True
                'カーソルセット(和暦年月日は2カラム)
                dgv_Search.CurrentCell = dgv_Search.Rows(wIdx).Cells(2)
                dgv_Search.Focus()

            End If


            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_Search_SQLMake 検索結果出力用ＳＱＬ作成"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :検索結果出力用ＳＱＬ作成
    '引数            :iKbn 0:検索 1:チェックリスト 2:チェックリスト2
    '戻り値          :String(SQL文)
    '更新日          :2009/01/27 jbd368 チェックリスト2を追加
    '------------------------------------------------------------------
    '2008/12/10 チェックリスト対応
    'Private Function f_Search_SQLMake() As String
    Private Function f_Search_SQLMake(ByVal iKbn As Integer) As String
        Dim sSql As String = String.Empty
        Dim sWhere As String = String.Empty
        Dim strER As String = String.Empty
        Dim strW1 As String = String.Empty
        Dim strW2 As String = String.Empty

        Try

            Select Case iKbn
                Case 0
                    '検索
                    sSql = " SELECT " & vbCrLf
                    sSql += "  TO_CHAR(TAN.TAISYO_DATE_FROM,'YYYY/MM/DD') TAISYO_DATE_FROM," & vbCrLf
                    sSql += "  TO_CHAR(TAN.TAISYO_DATE_TO,'YYYY/MM/DD') TAISYO_DATE_TO, " & vbCrLf
                    sSql += "  TO_CHAR(TAN.TAISYO_DATE_FROM,'EEYY/MM/DD','NLS_CALENDAR=''Japanese Imperial''') TAISYO_DATE_FROM_W," & vbCrLf
                    sSql += "  TO_CHAR(TAN.TAISYO_DATE_TO,'EEYY/MM/DD','NLS_CALENDAR=''Japanese Imperial''') TAISYO_DATE_TO_W " & vbCrLf
                    sSql += " FROM" & vbCrLf
                    sSql += "  TM_TANKA TAN" & vbCrLf
                Case 1
                    'チェックリスト
                Case 2
                    'チェックリスト2
            End Select


            'WHERE条件句を作成
            sSql += " WHERE 1=1 " & vbCrLf
            '2009/01/27 チェックリスト2対応
            '2008/12/10 チェックリスト対応
            Select Case iKbn
                Case 0
                    '検索
                Case 1
                    'チェックリスト
                Case 2
                    'チェックリスト2

            End Select

            '2009/01/27 JBD368 UPD チェックリスト2対応
            '2008/12/10 チェックリスト対応
            Select Case iKbn
                Case 0
                    '検索
                    sSql += "GROUP BY" & vbCrLf
                    sSql += "  TAN.TAISYO_DATE_FROM," & vbCrLf
                    sSql += "  TAN.TAISYO_DATE_TO" & vbCrLf
                    sSql += "ORDER BY" & vbCrLf
                    sSql += "  TAN.TAISYO_DATE_FROM" & vbCrLf

                Case 1
                    'チェックリスト
                Case 2
                    'チェックリスト2
            End Select

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return sSql

    End Function
#End Region

#Region "f_TM_TANKA_Deleate 契約者積立金・互助単価マスタデータ削除"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TM_TANKA_Deleate
    '説明            :契約者積立金・互助単価マスタデータ削除
    '引数            :1.intRow      Integer     選択されている行番号
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_TM_TANKA_Deleate(ByVal intRow As Integer) As Boolean
        Dim Cmd As New OracleCommand
        Dim sSql As String = String.Empty
        Dim myTrans As Oracle.ManagedDataAccess.Client.OracleTransaction = Nothing
        Dim blnIsTran As Boolean = False

        Dim ret As Boolean = False

        Dim sTAISYO_DATE_FROM As String = String.Empty

        Dim dstDataSet As New DataSet

        Try

            '条件キーの取得
            sTAISYO_DATE_FROM = dgv_Search.Item(C_TAISYO_DATE_FROM, intRow).Value

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            '
            Cmd.CommandText = "PKG_GJ2011.GJ2011_TANKA_DEL"
            '引き渡し
            '年月日FROM
            Dim paraTAISYO_DATE_FROM As OracleParameter = Cmd.Parameters.Add("IN_TAISYO_DATE_FROM", sTAISYO_DATE_FROM)

            'データ登録日
            Dim paraREG_DATE As OracleParameter = Cmd.Parameters.Add("IN_REG_DATE", Now)
            'データ登録ＩＤ
            Dim paraREG_ID As OracleParameter = Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
            'データ更新日
            Dim paraUP_DATE As OracleParameter = Cmd.Parameters.Add("IN_UP_DATE", Now)
            'データ更新ＩＤ
            Dim paraUP_ID As OracleParameter = Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)
            'コンピュータ名
            Dim paraCOM_NAME As OracleParameter = Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)

            '戻り
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            Cmd.ExecuteNonQuery()
            Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())
            If Cmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                Show_MessageBox("", Cmd.Parameters("OU_MSGNM").Value.ToString())
            End If

            'データベースへの接続を閉じる
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            If ex.Message <> "Err" Then
                Show_MessageBox("", ex.Message)
            End If
            'RollBack
            If blnIsTran = True Then
                myTrans.Rollback()
            End If
        End Try

        Return ret


    End Function
#End Region

#End Region

End Class
