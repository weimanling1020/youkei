﻿'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ4010.vb
'*
'*　　②　機能概要　　　　　互助金申請情報一覧
'*
'*　　③　作成日　　　　　　2015/01/22　BY JBD
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
Imports System.IO
Imports System.Text

Public Class frmGJ4010

#Region "変数定義"

    ''' <summary>
    ''' グリッドキー項目構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Class T_KEY

        ''' <summary>
        ''' 契約者コード
        ''' </summary>
        ''' <remarks></remarks>
        Public KEIYAKUSYA_CD As String = String.Empty

        ''' <summary>
        ''' 契約者名
        ''' </summary>
        ''' <remarks></remarks>
        Public KEIYAKUSYA_NAME As String = String.Empty

        ''' <summary>
        ''' 契約区分コード
        ''' </summary>
        ''' <remarks></remarks>
        Public KEIYAKU_KBN As String = String.Empty

        ''' <summary>
        ''' 契約区分名
        ''' </summary>
        ''' <remarks></remarks>
        Public KEIYAKU_KBN_NM As String = String.Empty

        ''' <summary>
        ''' 互助金単価マスタ　参照日
        ''' </summary>
        ''' <remarks></remarks>
        Public TANKA_MST_DATE As String = String.Empty


    End Class

    ''' <summary>
    ''' 結果一覧セット用データセット
    ''' </summary>
    ''' <remarks></remarks>
    Private pDataSet As New DataSet

    ''' <summary>
    ''' グリッドキーリスト
    ''' </summary>
    ''' <remarks></remarks>
    Public paryKEY_4010 As New List(Of T_KEY)

    ''' <summary>
    ''' 変更時、該当データ選択行
    ''' </summary>
    ''' <remarks></remarks>
    Public pSel_POS As Integer

    ''' <summary>
    ''' プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True         '処理ジャンプ
    Private pInitKi As String               '期(初期値)
    Private pEnterKi As String              '期(入力値)

#End Region

#Region "画面制御関連"

#Region "frmEMXXXX_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmEMXXXX_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmXXXLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean
        Try

            pInitKi = New Obj_TM_SYORI_NENDO_KI().pKI
            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            ret = f_ObjectClear("C")

            '県コードFROMにフォーカスセット
            txt_KI.Focus()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        End Try

    End Sub
#End Region

#End Region

#Region "画面ボタンクリック関連"

#Region "cmdSearch_Click 検索ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSearch_Click
    '説明            :検索ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs, Optional ByVal wkAlertFlag As Boolean = True) Handles cmdSearch.Click
        Dim sSql As String = String.Empty

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '画面入力チェック
            If Not f_Input_Check(wkAlertFlag) Then
                Exit Try
            End If

            'データセットクリア
            If Not pDataSet Is Nothing Then
                pDataSet.Clear()
            End If

            'SQL作成
            If Not f_Search_SQLMake(0, sSql) Then
                Exit Try
            End If

            'SQL実行
            If Not f_Select_ODP(pDataSet, sSql) Then
                Exit Try
            End If

            'グリッドセット
            If pDataSet.Tables(0).Rows.Count > 0 Then
                '画面に該当データを表示
                dgv_Search.DataSource = pDataSet.Tables(0)
                lblCOUNT.Text = pDataSet.Tables(0).Rows.Count.ToString("#,##0")
            Else
                lblCOUNT.Text = "0"
                pDataSet.Clear()
                If wkAlertFlag Then
                    'データ存在なし
                    Show_MessageBox("I003", "")       '指定された条件に一致するデータは存在しません。
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#End Region

#Region "cmdKeieisien_Click 経営支援登録ボタンクリック時処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSav_Click
    '説明            :経営支援登録ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdKeieisien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKeieisien.Click
        Dim tKEY As New T_KEY
        Dim strtNowKEY As T_KEY = Nothing
        Dim ret As Boolean = False

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '画面入力チェック(エラー表示あり)
            If Not f_Input_Check() Then
                Exit Try
            End If


            '一覧より選択されていなければエラー
            If dgv_Search.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")       'データが選択されていません。
                Exit Try
            End If

            'グリッドのKey情報を構造体に格納
            paryKEY_4010 = New List(Of T_KEY)
            For i As Integer = 0 To dgv_Search.RowCount - 1
                tKEY = New T_KEY
                tKEY.KEIYAKUSYA_CD = WordHenkan("N", "Z", dgv_Search.Item("KEIYAKUSYA_CD", i).Value)
                tKEY.KEIYAKUSYA_NAME = WordHenkan("N", "S", dgv_Search.Item("KEIYAKUSYA_NAME", i).Value)
                tKEY.KEIYAKU_KBN = WordHenkan("N", "Z", dgv_Search.Item("KEIYAKU_KBN", i).Value)
                tKEY.KEIYAKU_KBN_NM = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_KBN_NM", i).Value)
                tKEY.TANKA_MST_DATE = Format(dateTANKA_MST_DATE.Value, "yyyy/MM/dd")

                If dgv_Search.Rows(i).Selected Then
                    strtNowKEY = tKEY
                    pSel_POS = i + 1
                End If
                paryKEY_4010.Add(tKEY)
            Next

            '契約済確認
            If dgv_Search.Item("KEIYAKU_DATE", pSel_POS - 1).Value Is DBNull.Value Then
                Show_MessageBox_Add("W019", "契約が完了していない契約者です。")       '契約が完了していない契約者です。
                Exit Try
            End If
            '2021/07/13 JBD9020 新契約日追加 ADD START
            If dgv_Search.Item("NYU_HEN_DATE", pSel_POS - 1).Value Is DBNull.Value Then
                Show_MessageBox_Add("W019", "契約が完了していない契約者です。")       '契約が完了していない契約者です。
                Exit Try
            End If
            '2021/07/13 JBD9020 新契約日追加 ADD END

            '廃業確認
            If Not dgv_Search.Item("HAIGYO_DATE", pSel_POS - 1).Value Is DBNull.Value Then
                Show_MessageBox_Add("W019", "廃業されている契約者です。")            '廃業されている契約者です。
                Exit Try
            End If

            '互助金単価マスタ参照日が事業対象年度範囲外チェック
            If Not f_TM_TANKA_Check() Then
                Exit Try
            End If

            '経営支援登録画面表示
            Using wkForm As New frmGJ4011
                wkForm.Owner = Me
                wkForm.pCurrentKey = strtNowKEY     '現在選択されている行のキーを渡します
                wkForm.p4010_KI = txt_KI.Text.Trim  '期を渡しますす

                wkForm.ShowDialog()

                'グリッド　再表示
                ret = f_GridReDisp(wkForm.pCurrentKey.KEIYAKUSYA_CD)

            End Using

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#End Region

#Region "cmdSyoukyaku_Click 焼却・埋却登録ボタンクリック時処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSyoukyaku_Click
    '説明            :焼却・埋却登録ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdSyoukyaku_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSyoukyaku.Click
        Dim tKEY As New T_KEY
        Dim strtNowKEY As T_KEY = Nothing
        Dim ret As Boolean = False


        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '画面入力チェック(エラー表示あり)
            If Not f_Input_Check() Then
                Exit Try
            End If


            '一覧より選択されていなければエラー
            If dgv_Search.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")       'データが選択されていません。
                Exit Try
            End If

            'グリッドのKey情報を構造体に格納
            paryKEY_4010 = New List(Of T_KEY)
            For i As Integer = 0 To dgv_Search.RowCount - 1
                tKEY = New T_KEY
                tKEY.KEIYAKUSYA_CD = WordHenkan("N", "Z", dgv_Search.Item("KEIYAKUSYA_CD", i).Value)
                tKEY.KEIYAKUSYA_NAME = WordHenkan("N", "S", dgv_Search.Item("KEIYAKUSYA_NAME", i).Value)
                tKEY.KEIYAKU_KBN = WordHenkan("N", "Z", dgv_Search.Item("KEIYAKU_KBN", i).Value)
                tKEY.KEIYAKU_KBN_NM = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_KBN_NM", i).Value)
                tKEY.TANKA_MST_DATE = Format(dateTANKA_MST_DATE.Value, "yyyy/MM/dd")

                If dgv_Search.Rows(i).Selected Then
                    strtNowKEY = tKEY
                    pSel_POS = i + 1
                End If
                paryKEY_4010.Add(tKEY)
            Next

            '契約済確認
            If dgv_Search.Item("KEIYAKU_DATE", pSel_POS - 1).Value Is DBNull.Value Then
                Show_MessageBox_Add("W019", "契約が完了していない契約者です。")       '契約が完了していない契約者です。
                Exit Try
            End If
            '2021/07/13 JBD9020 新契約日追加 ADD START
            If dgv_Search.Item("NYU_HEN_DATE", pSel_POS - 1).Value Is DBNull.Value Then
                Show_MessageBox_Add("W019", "契約が完了していない契約者です。")       '契約が完了していない契約者です。
                Exit Try
            End If
            '2021/07/13 JBD9020 新契約日追加 ADD END
            '廃業確認
            If Not dgv_Search.Item("HAIGYO_DATE", pSel_POS - 1).Value Is DBNull.Value Then
                Show_MessageBox_Add("W019", "廃業されている契約者です。")            '廃業されている契約者です。
                Exit Try
            End If

            '互助金単価マスタ参照日が事業対象年度範囲外チェック
            If Not f_TM_TANKA_Check() Then
                Exit Try
            End If

            '焼却・埋却登録画面表示
            Using wkForm As New frmGJ4013
                wkForm.Owner = Me
                wkForm.pCurrentKey = strtNowKEY     '現在選択されている行のキーを渡します
                wkForm.p4010_KI = txt_KI.Text.Trim  '期を渡しますす

                wkForm.ShowDialog()

                'グリッド　再表示
                ret = f_GridReDisp(wkForm.pCurrentKey.KEIYAKUSYA_CD)

            End Using

            dgv_Search.Refresh()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#Region "cmdCan_Click キャンセルボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdCan_Click
    '説明            :キャンセルボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdCan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCan.Click

        Dim ret As Boolean

        ret = f_ObjectClear("")

        'データ区分にフォーカスセット
        txt_KI.Focus()

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
                Exit Try
            End If

            Me.AutoValidate = AutoValidate.Disable
            'フォームクローズ
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

#Region "画面コントロール制御関連 "

#Region "期"
    '------------------------------------------------------------------
    'プロシージャ名  :txt_KI_Enter
    '説明            :期Enterイベント
    '------------------------------------------------------------------
    Private Sub txt_KI_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txt_KI.Enter

        pEnterKi = txt_KI.Text

    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :txt_KI_Validated
    '説明            :期Validatedベント
    '------------------------------------------------------------------
    Private Sub txt_KI_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles txt_KI.Validated
        Dim ret As Boolean = False

        Try

            '未入力のとき、事務委託先コンボクリア
            If txt_KI.Text = "" Then
                cob_JIMUITAKU_CD_F.DataSource = Nothing
                cob_JIMUITAKU_CD_F.Clear()
                cob_JIMUITAKU_NM_F.DataSource = Nothing
                cob_JIMUITAKU_NM_F.Clear()

                cob_JIMUITAKU_CD_T.DataSource = Nothing
                cob_JIMUITAKU_CD_T.Clear()
                cob_JIMUITAKU_NM_T.DataSource = Nothing
                cob_JIMUITAKU_NM_T.Clear()
                Exit Try
            End If

            '期に変更無し
            'If CInt(txt_KI.Text) = CInt(pEnterKi) Then
            If txt_KI.Text = pEnterKi Then
                Exit Try
            End If

            '期が変更になった場合、事務委託先コンボ再セット
            ret = f_ComboBox_Set("", txt_KI.Text.Trim.ToString)


        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

#End Region

#Region "発生回数関連"
    '------------------------------------------------------------------
    'プロシージャ名  :txt_HASSEI_KAISU_Fm_Validating
    '説明            :発生回数FROM Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub txt_HASSEI_KAISU_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_HASSEI_KAISU_Fm.Validating
        If txt_HASSEI_KAISU_Fm.Text = "0" Then
            txt_HASSEI_KAISU_Fm.Text = ""
        End If

        Call s_From_Validating(txt_HASSEI_KAISU_Fm, txt_HASSEI_KAISU_To)
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :txt_HASSEI_KAISU_To_Validating
    '説明            :発生回数TO Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub txt_HASSEI_KAISU_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_HASSEI_KAISU_To.Validating
        If txt_HASSEI_KAISU_To.Text = "0" Then
            txt_HASSEI_KAISU_To.Text = ""
        End If
        Call s_To_Validating(txt_HASSEI_KAISU_To, txt_HASSEI_KAISU_Fm)
    End Sub

#End Region

#Region "計算回数関連"
    '------------------------------------------------------------------
    'プロシージャ名  :txt_KEISAN_KAISU_Fm_Validating
    '説明            :計算回数FROM Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub txt_KEISAN_KAISU_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_KEISAN_KAISU_Fm.Validating
        Call s_From_Validating(txt_KEISAN_KAISU_Fm, txt_KEISAN_KAISU_To)
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :txt_KEISAN_KAISU_To_Validating
    '説明            :計算回数TO Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub txt_KEISAN_KAISU_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_KEISAN_KAISU_To.Validating
        Call s_From_Validating(txt_KEISAN_KAISU_To, txt_KEISAN_KAISU_Fm)
    End Sub
#End Region

#Region "都道府県関連"

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_CD_F_SelectedIndexChanged
    '説明            :都道府県コード(FROM)項目変更時
    '------------------------------------------------------------------
    Private Sub cob_KEN_CD_F_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEN_CD_F.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEN_NM_F.SelectedIndex = cob_KEN_CD_F.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KenNm_F_SelectedIndexChanged
    '説明            :都道府県名(FROM)項目変更時
    '------------------------------------------------------------------
    Private Sub cob_KenNm_F_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEN_NM_F.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        s_CboMeiFrom_SelectedIndexChanged(cob_KEN_NM_F, cob_KEN_CD_F, cob_KEN_NM_T, cob_KEN_CD_T)


    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_CD_F_Validating
    '説明            :都道府県コード(FROM)確定中処理
    '------------------------------------------------------------------
    Private Sub cob_KEN_CD_F_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_KEN_CD_F.Validating

        Call s_CboFrom_Validating(cob_KEN_CD_F, cob_KEN_NM_F, cob_KEN_CD_T, cob_KEN_NM_T)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_CD_T_SelectedIndexChanged
    '説明            :都道府県コード(TO)項目変更時
    '------------------------------------------------------------------
    Private Sub cob_KEN_CD_T_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEN_CD_T.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEN_NM_T.SelectedIndex = cob_KEN_CD_T.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KenNm_F_SelectedIndexChanged
    '説明            :都道府県名(TO)項目変更時
    '------------------------------------------------------------------
    Private Sub cob_KenNm_T_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEN_NM_T.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        s_CboMeiTo_Validating(cob_KEN_NM_T, cob_KEN_CD_T, cob_KEN_NM_F, cob_KEN_CD_F)

    End Sub


    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_CD_T_Validating
    '説明            :都道府県コード(TO)確定中処理
    '------------------------------------------------------------------
    Private Sub cob_KEN_CD_T_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_KEN_CD_T.Validating

        Call s_CboTo_Validating(cob_KEN_CD_T, cob_KEN_NM_T, cob_KEN_CD_F, cob_KEN_NM_F)

    End Sub

#End Region

#Region "契約区分関連"

    ''' <summary>
    ''' 契約区分コード項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KEIYAKU_KBN_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEIYAKU_KBN.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEIYAKU_KBN_NM.SelectedIndex = cob_KEIYAKU_KBN.SelectedIndex

    End Sub

    ''' <summary>
    ''' 契約区分名項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KeiyakusyaKbnNm_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEIYAKU_KBN_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEIYAKU_KBN.SelectedIndex = cob_KEIYAKU_KBN_NM.SelectedIndex

    End Sub

    ''' <summary>
    ''' 契約区分コード確定時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KEIYAKU_KBN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_KEIYAKU_KBN.Validating

        If cob_KEIYAKU_KBN.Text = "" Then
            Exit Sub
        End If


        '先頭ゼロを削除
        DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text = CInt(DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text).ToString

        cob_KEIYAKU_KBN.SelectedValue = cob_KEIYAKU_KBN.Text
        If cob_KEIYAKU_KBN.SelectedValue Is Nothing Then
            cob_KEIYAKU_KBN.SelectedIndex = -1
            cob_KEIYAKU_KBN_NM.SelectedIndex = -1
            Show_MessageBox_Add("W012", "契約区分") '指定された@0が正しくありません。
            cob_KEIYAKU_KBN.Focus()
        End If

    End Sub

#End Region

#Region "契約状況"

    ''' <summary>
    ''' 契約状況コード項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KEIYAKU_JYOKYO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEIYAKU_JYOKYO.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEIYAKU_JYOKYO_NM.SelectedIndex = cob_KEIYAKU_JYOKYO.SelectedIndex

    End Sub

    ''' <summary>
    ''' 契約状況名項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KEIYAKU_JYOKYO_NM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEIYAKU_JYOKYO_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEIYAKU_JYOKYO.SelectedIndex = cob_KEIYAKU_JYOKYO_NM.SelectedIndex

    End Sub

    ''' <summary>
    ''' 契約状況コード確定時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KEIYAKU_JYOKYO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_KEIYAKU_JYOKYO.Validating

        If cob_KEIYAKU_JYOKYO.Text = "" Then
            Exit Sub
        End If


        '先頭ゼロを削除
        DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text = CInt(DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text).ToString

        cob_KEIYAKU_JYOKYO.SelectedValue = cob_KEIYAKU_JYOKYO.Text
        If cob_KEIYAKU_JYOKYO.SelectedValue Is Nothing Then
            cob_KEIYAKU_JYOKYO.SelectedIndex = -1
            cob_KEIYAKU_JYOKYO_NM.SelectedIndex = -1
            Show_MessageBox_Add("W012", "契約状況") '指定された@0が正しくありません。
            cob_KEIYAKU_JYOKYO.Focus()
        End If

    End Sub

#End Region

#Region "事務委託先関連"

    '------------------------------------------------------------------
    'プロシージャ名  :cob_JIMUITAKU_CD_F_SelectedIndexChanged
    '説明            :事務委託先コード(FROM)項目変更時
    '------------------------------------------------------------------
    Private Sub cob_JIMUITAKU_CD_F_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_JIMUITAKU_CD_F.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_JIMUITAKU_NM_F.SelectedIndex = cob_JIMUITAKU_CD_F.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_JIMUITAKU_NM_F_SelectedIndexChanged
    '説明            :事務委託先名(FROM)項目変更時
    '------------------------------------------------------------------
    Private Sub cob_JIMUITAKU_NM_F_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_JIMUITAKU_NM_F.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        s_CboMeiFrom_SelectedIndexChanged(cob_JIMUITAKU_NM_F, cob_JIMUITAKU_CD_F, cob_JIMUITAKU_NM_T, cob_JIMUITAKU_CD_T)


    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_JIMUITAKU_CD_F_Validating
    '説明            :事務委託先コード(FROM)確定中処理
    '------------------------------------------------------------------
    Private Sub cob_JIMUITAKU_CD_F_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_JIMUITAKU_CD_F.Validating

        Call s_CboFrom_Validating(cob_JIMUITAKU_CD_F, cob_JIMUITAKU_NM_F, cob_JIMUITAKU_CD_T, cob_JIMUITAKU_NM_T, "2")

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_JIMUITAKU_CD_T_SelectedIndexChanged
    '説明            :事務委託先コード(TO)項目変更時
    '------------------------------------------------------------------
    Private Sub cob_JIMUITAKU_CD_T_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_JIMUITAKU_CD_T.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_JIMUITAKU_NM_T.SelectedIndex = cob_JIMUITAKU_CD_T.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_JIMUITAKU_NM_F_SelectedIndexChanged
    '説明            :事務委託先名(TO)項目変更時
    '------------------------------------------------------------------
    Private Sub cob_JIMUITAKU_NM_T_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_JIMUITAKU_NM_T.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        s_CboMeiTo_Validating(cob_JIMUITAKU_NM_T, cob_JIMUITAKU_CD_T, cob_JIMUITAKU_NM_F, cob_JIMUITAKU_CD_F)

    End Sub


    '------------------------------------------------------------------
    'プロシージャ名  :cob_JIMUITAKU_CD_T_Validating
    '説明            :事務委託先コード(TO)確定中処理
    '------------------------------------------------------------------
    Private Sub cob_JIMUITAKU_CD_T_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_JIMUITAKU_CD_T.Validating

        Call s_CboTo_Validating(cob_JIMUITAKU_CD_T, cob_JIMUITAKU_NM_T, cob_JIMUITAKU_CD_F, cob_JIMUITAKU_NM_F, "2")

    End Sub

#End Region


#End Region

#Region "ローカル関数"

#Region "f_ObjectClear 画面クリア処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ObjectClear
    '説明            :画面クリア処理
    '引数            :rKbn(処理区分)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ObjectClear(ByVal wKbn As String) As Boolean
        Dim ret As Boolean = False
        Dim clsNENDO_KI As Obj_TM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI

        f_ObjectClear = False
        Try

            f_ObjectClear = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '画面初期化
            pJump = True
            f_ClearFormALL(Me, wKbn)
            txt_KI.Text = pInitKi   '期
            If clsNENDO_KI.pHASSEI_KAISU = 0 Then
                txt_HASSEI_KAISU_Fm.Text = Nothing
                txt_HASSEI_KAISU_To.Text = Nothing
            Else
                '#42 UPD START
                'txt_HASSEI_KAISU_Fm.Text = clsNENDO_KI.pHASSEI_KAISU
                'txt_HASSEI_KAISU_To.Text = clsNENDO_KI.pHASSEI_KAISU
                txt_HASSEI_KAISU_Fm.Text = Nothing
                txt_HASSEI_KAISU_To.Text = Nothing
                '#42 UPD END
            End If
            lblCOUNT.Text = "0"     '抽出
            dateTANKA_MST_DATE.Value = Now

            'コンボボックスセット
            ret = f_ComboBox_Set(wKbn, txt_KI.Text)

            pJump = False

            '変数クリア
            paryKEY_4010 = New List(Of T_KEY)

            If Not pDataSet Is Nothing Then
                pDataSet.Clear()
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            clsNENDO_KI = Nothing
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Function
#End Region

#Region "f_ComboBox_Set コンボボックスセット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ComboBox_Set
    '説明            :コンボボックスセット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ComboBox_Set(ByVal wKbn As String, ByVal wKI As String) As Boolean
        Dim ret As Boolean = False
        Dim wWhere As String = String.Empty

        Try
            pJump = True
            '初期処理
            If wKbn = "C" Then

                '県マスタコンボセット
                If Not f_Ken_Data_Select(cob_KEN_CD_F, cob_KEN_NM_F, True) Then
                    Exit Try
                End If
                If Not f_Ken_Data_Select(cob_KEN_CD_T, cob_KEN_NM_T, True) Then
                    Exit Try
                End If

                '契約区分コンボセット
                'If Not f_CodeMaster_Data_Select(cob_KEIYAKU_KBN, cob_KEIYAKU_KBN_NM, 1, True, 1) Then '2017/07/11 修正
                If Not f_CodeMaster_Data_Select(cob_KEIYAKU_KBN, cob_KEIYAKU_KBN_NM, 1, True, 0) Then  '2017/07/11 修正
                    Exit Try
                End If

                '契約状況コードコンボセット
                If Not f_CodeMaster_Data_Select(cob_KEIYAKU_JYOKYO, cob_KEIYAKU_JYOKYO_NM, 2, True, 1) Then
                    Exit Try
                End If

                'コンボボックス初期化
                cob_KEN_CD_F.Text = ""
                cob_KEN_CD_T.Text = ""
                cob_KEIYAKU_KBN.Text = ""
                cob_KEIYAKU_JYOKYO.Text = ""

            End If

            '期が未入力のとき
            If wKI = "" OrElse wKI = String.Empty Then
                cob_JIMUITAKU_CD_F.DataSource = Nothing
                cob_JIMUITAKU_CD_F.Clear()
                cob_JIMUITAKU_NM_F.DataSource = Nothing
                cob_JIMUITAKU_NM_F.Clear()

                cob_JIMUITAKU_CD_T.DataSource = Nothing
                cob_JIMUITAKU_CD_T.Clear()
                cob_JIMUITAKU_NM_T.DataSource = Nothing
                cob_JIMUITAKU_NM_T.Clear()
                Exit Try
            End If

            '契約者マスタコンボセット
            wWhere = "KI = " & wKI
            If Not f_JimuItaku_Data_Select(cob_JIMUITAKU_CD_F, cob_JIMUITAKU_NM_F, wWhere, True) Then
                Exit Try
            End If
            If Not f_JimuItaku_Data_Select(cob_JIMUITAKU_CD_T, cob_JIMUITAKU_NM_T, wWhere, True) Then
                Exit Try
            End If

            'コンボボックス初期化
            cob_JIMUITAKU_CD_F.Text = ""
            cob_JIMUITAKU_CD_T.Text = ""

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try
        pJump = False

        Return ret

    End Function


#End Region

#Region "f_Input_Check 画面入力チェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check
    '説明            :画面入力チェック処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check(Optional ByVal wkAlertFlag As Boolean = True) As Boolean
        Dim ret As Boolean = False

        Try


            '==必須チェック================== 

            '期入力なし
            If txt_KI.Text.Trim = "" Then
                Show_MessageBox_Add("W008", "期")
                txt_KI.Focus()
                Exit Try
            End If

            '互助金単価マスタ　参照日
            If dateTANKA_MST_DATE.Value Is Nothing Then
                Show_MessageBox_Add("W008", "互助金単価マスタ　参照日")
                dateTANKA_MST_DATE.Focus()
                Exit Try
            End If


            '==FromToチェック==================
            '発生回数
            '2022/01/24 JBD9020 発生回数→認定回数に変更 UPD START
            'If f_Daisyo_Check(txt_HASSEI_KAISU_Fm, txt_HASSEI_KAISU_To, "発生回数", True) = False Then
            If f_Daisyo_Check(txt_HASSEI_KAISU_Fm, txt_HASSEI_KAISU_To, "認定回数", True) = False Then
                '2022/01/24 JBD9020 発生回数→認定回数に変更 UPD END
                Exit Try
            End If

            '計算回数
            If f_Daisyo_Check(txt_KEISAN_KAISU_Fm, txt_KEISAN_KAISU_To, "計算回数", True) = False Then
                Exit Try
            End If

            '都道府県
            If f_Daisyo_Check(cob_KEN_CD_F, cob_KEN_CD_T, "都道府県", True) = False Then
                Exit Try
            End If

            '事務委託先
            If f_Daisyo_Check(cob_JIMUITAKU_CD_F, cob_JIMUITAKU_CD_T, "事務委託先", True) = False Then
                Exit Try
            End If




            '==いろいろチェック==================



            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_Search_SQLMake ＳＱＬ作成処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :ＳＱＬ作成処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Search_SQLMake(ByVal wKbn As Integer, ByRef wSql As String) As Boolean
        Dim ret As Boolean = False
        Dim wANDorOR As String = String.Empty
        Dim wWhere As String = String.Empty

        Try

            'ＳＱＬ
            wSql = ""

            If rbtn_SearchAnd.Checked Then
                '検索方法で[すべてを含む]を選択
                wANDorOR = " AND "
            Else
                '検索方法で[いずれかを含む]を選択
                wANDorOR = " OR "
            End If

            '==オプション条件====================
            ' 以下は省略可能な条件なので指定されていた場合にのみ編集
            ' 但し、検索方法が全てを含むなのかいずれかを含むなのかによりwkANDorORの内容がANDかORに変わる
            wWhere = " 1 = 1 "

            '都道府県FROM
            If cob_KEN_CD_F.Text.Trim <> "" AndAlso cob_KEN_CD_T.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= "(" & " KYK.KEN_CD BETWEEN " & cob_KEN_CD_F.Text.Trim & " and " & cob_KEN_CD_T.Text.Trim & ")"
            End If

            '発生回数
            If txt_HASSEI_KAISU_Fm.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= "(" & " SIN.HASSEI_KAISU BETWEEN " & txt_HASSEI_KAISU_Fm.Text.Trim & " and " & txt_HASSEI_KAISU_To.Text.Trim & ")"
            End If

            '計算回数
            If txt_KEISAN_KAISU_Fm.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= "(" & " SIN.KEISAN_KAISU BETWEEN " & txt_KEISAN_KAISU_Fm.Text.Trim & " and " & txt_KEISAN_KAISU_To.Text.Trim & ")"
            End If

            '契約者番号
            If txt_KEIYAKUSYA_CD.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= " KYK.KEIYAKUSYA_CD = " & txt_KEIYAKUSYA_CD.Text.Trim
            End If

            '契約区分
            If cob_KEIYAKU_KBN.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= " KYK.KEIYAKU_KBN = " & cob_KEIYAKU_KBN.Text.Trim
            End If

            '契約状況
            If cob_KEIYAKU_JYOKYO.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= " KYK.KEIYAKU_JYOKYO = " & cob_KEIYAKU_JYOKYO.Text.Trim
            End If

            '契約者名
            If txt_KEIYAKUSYA_NAME.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= " KYK.KEIYAKUSYA_NAME LIKE '%" & f_SqlEdit(txt_KEIYAKUSYA_NAME.Text) & "%'"
            End If

            '契約者名(フリガナ)
            If txt_KEIYAKUSYA_KANA.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= " KYK.KEIYAKUSYA_KANA LIKE '%" & f_SqlEdit(txt_KEIYAKUSYA_KANA.Text) & "%'"
            End If

            '住所
            If txt_ADDR.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= " KYK.ADDR_1||KYK.ADDR_2||KYK.ADDR_3||KYK.ADDR_4 LIKE '%" & f_SqlEdit(txt_ADDR.Text) & "%'"
            End If

            '電話番号
            If txt_ADDR_TEL1.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                'wWhere &= " regexp_replace(KYK.ADDR_TEL1,'[^0-9]','') = '" & txt_ADDR_TEL1.Text.Trim & "'"
                wWhere &= " (( regexp_replace(KYK.ADDR_TEL1,'[^0-9]','') = '" & txt_ADDR_TEL1.Text.Trim & "')"
                wWhere &= " OR (regexp_replace(KYK.ADDR_TEL2,'[^0-9]','') = '" & txt_ADDR_TEL1.Text.Trim & "'))"
            End If

            '事務委託先
            If cob_JIMUITAKU_CD_F.Text.Trim <> "" AndAlso cob_JIMUITAKU_CD_T.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= "(" & " KYK.JIMUITAKU_CD BETWEEN " & cob_JIMUITAKU_CD_F.Text.Trim & " and " & cob_JIMUITAKU_CD_T.Text.Trim & ")"
            End If

            '条件編集
            If wWhere <> "" Then
                wWhere = "  AND (" & wWhere & ")"
            End If

            '==SQL作成====================
            wSql &= "SELECT"
            wSql &= "  KYK.KEIYAKUSYA_CD,"
            wSql &= "  KYK.KEIYAKUSYA_NAME,"
            wSql &= "  KYK.ADDR_1 || KYK.ADDR_2 || KYK.ADDR_3 || KYK.ADDR_4 AS ADDR,"
            wSql &= "  KYK.KEIYAKU_KBN,"
            '↓2017/07/12 修正
            'wSql &= "  M01.RYAKUSYO KEIYAKU_KBN_NM,"
            wSql &= "  M01.MEISYO KEIYAKU_KBN_NM,"
            '↑2017/07/12 修正
            wSql &= "  KYK.ADDR_TEL1,"
            wSql &= "  KYK.KEN_CD,"
            wSql &= "  LPAD(KYK.KEN_CD,2) || M05.RYAKUSYO KEN_NM,"
            wSql &= "  KYK.JIMUITAKU_CD,"
            wSql &= "  ITK.ITAKU_RYAKU ITAKU_RYAKU,"
            wSql &= "  KYK.KEIYAKU_DATE KEIYAKU_DATE,"
            wSql &= "  KYK.HAIGYO_DATE HAIGYO_DATE "
            wSql &= "  ,KYK.NYU_HEN_DATE NYU_HEN_DATE " '2021/07/13 JBD9020 新契約日追加 ADD 
            wSql &= "FROM"
            wSql &= "  TM_KEIYAKU KYK,"
            wSql &= "  TM_CODE M01,"
            wSql &= "  TM_CODE M05,"
            wSql &= "  TM_JIMUITAKU ITK,"
            wSql &= "  ("
            wSql &= "  SELECT"
            wSql &= "     KYK.KI,"
            wSql &= "     KYK.KEIYAKUSYA_CD"
            wSql &= "  FROM"
            wSql &= "     TM_KEIYAKU KYK,"
            wSql &= "     TT_KOFU_SINSEI SIN"
            wSql &= "  WHERE KYK.KI =" & txt_KI.Text.Trim
            wSql &= "    AND KYK.KI = SIN.KI(+)"
            wSql &= "    AND KYK.KEIYAKUSYA_CD = SIN.KEIYAKUSYA_CD(+) "
            wSql &= wWhere & " "
            wSql &= "  GROUP BY"
            wSql &= "    KYK.KI,"
            wSql &= "    KYK.KEIYAKUSYA_CD"
            wSql &= "  ORDER BY"
            wSql &= "    KYK.KI,"
            wSql &= "    KYK.KEIYAKUSYA_CD"
            wSql &= "  ) SINSEI "

            wSql &= "WHERE KYK.KI = " & txt_KI.Text.Trim
            wSql &= "  AND 01 = M01.SYURUI_KBN(+)"
            wSql &= "  AND KYK.KEIYAKU_KBN = M01.MEISYO_CD(+)"
            wSql &= "  AND 05 = M05.SYURUI_KBN(+)"
            wSql &= "  AND KYK.KEN_CD = M05.MEISYO_CD(+)"
            wSql &= "  AND KYK.KI = ITK.KI(+)"
            wSql &= "  AND KYK.JIMUITAKU_CD = ITK.ITAKU_CD(+)"
            wSql &= "  AND KYK.KI = SINSEI.KI"
            wSql &= "  AND KYK.KEIYAKUSYA_CD = SINSEI.KEIYAKUSYA_CD "
            wSql &= "ORDER BY"
            wSql &= "  KYK.KEIYAKUSYA_CD"

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region

#Region "f_GridReDisp グリッド再表示"
    '------------------------------------------------------------------
    'プロシージャ名  :f_GridReDisp
    '説明            :グリッド再表示
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_GridReDisp(ByVal wKeiyakusyaCd As Integer) As Boolean
        Dim ret As Boolean = False
        Dim blnHit As Boolean = False

        Try

            '再抽出
            cmdSearch_Click(cmdSearch, New EventArgs, False)

            'グリッドに有効データあり
            If dgv_Search.RowCount <> 0 Then
                '契約者農場が指定されたとき
                If wKeiyakusyaCd <> -1 Then
                    For i As Integer = 0 To dgv_Search.RowCount - 1
                        '選択行
                        If dgv_Search.Item("KEIYAKUSYA_CD", i).Value >= wKeiyakusyaCd Then
                            '現在セル　セットdgv_Search.CurrentCell
                            dgv_Search.CurrentCell = dgv_Search(0, i)
                            blnHit = True
                            Exit For
                        End If
                    Next
                    '最後まで該当データがなかった場合、最終行
                    If Not blnHit Then
                        dgv_Search.CurrentCell = dgv_Search(0, dgv_Search.RowCount - 1)
                    End If
                End If
            End If

            ret = True

        Catch ex As Exception
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_TM_TANKA_Check 互助金単価マスタ参照日が事業対象年度範囲外チェック"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TM_TANKA_Check
    '説明            :互助金単価マスタ参照日が事業対象年度範囲外チェック
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_TM_TANKA_Check() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty


        Try

            'ＳＱＬ
            wSql = ""

            '==SQL作成====================
            wSql &= "SELECT "
            wSql &= "       TAN.TAISYO_DATE_FROM"
            wSql &= "      ,TAN.TAISYO_DATE_TO"
            wSql &= " FROM  TM_TANKA TAN"
            wSql &= " WHERE TAN.TAISYO_DATE_FROM <= TO_DATE('" & Format(dateTANKA_MST_DATE.Value, "yyyy/MM/dd") & "','yyyy/mm/dd')"
            wSql &= "   AND TAN.TAISYO_DATE_TO >=  TO_DATE('" & Format(dateTANKA_MST_DATE.Value, "yyyy/MM/dd") & "','yyyy/mm/dd')"

            'SQL実行
            If Not f_Select_ODP(wkDS, wSql) Then
                Exit Try
            End If

            'グリッドセット
            If wkDS.Tables(0).Rows.Count > 0 Then
                '単価マスタ有
            Else
                '単価マスタ無
                '確認
                If Show_MessageBox_Add("Q012", "互助金単価マスタ参照日が事業対象年度範囲外ですが" & vbCrLf & "よろしいですか？") = DialogResult.No Then    '保存します。よろしいですか？
                    Exit Try
                End If
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region

#End Region

End Class
