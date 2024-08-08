﻿'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ9020.vb
'*
'*　　②　機能概要　　　　　ワーク振込データ作成
'*
'*　　③　作成日　　　　　　2022/06/20  BY JBD9020　新規作成
'*
'*　　④　更新日            
'*
'*******************************************************************************
Option Strict Off
Option Explicit On


Imports JbdGjsCommon
Imports JbdGjsControl

Public Class frmGJ9020

#Region "*** 変数定義 ***"

    Public pKi As Integer

#End Region

#Region "*** 画面制御関連 ***"

#Region "frmGJ9020_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ9020_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmGJ9020_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean
        Try

            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            ret = f_ObjectClear()

            '出力ファイル名にフォーカスセット
            txt_Path.Select()
            txt_Path.Focus()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        End Try

    End Sub

#End Region

#Region "f_ObjectClear コントロールクリア処理"
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

            '期
            Dim objTM_SYORI_NENDO_KI As Obj_TM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI
            pKi = objTM_SYORI_NENDO_KI.pKI

            f_ClearFormALL(Me, "")

            '初期値設定
            txt_TAISYO_KI.Text = pKi

            'パスをセット
            txt_Path.Text = myTXT_FURIKOMI_ENTRY        '出力ファイル名

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

#Region "cmdReference_Click 参照ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdReference_Click
    '説明            :参照ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdReference_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReference.Click
        'OpenFileDialogクラスのインスタンスを作成
        Dim ofdForm As New OpenFileDialog()

        'はじめのファイル名を指定する
        'はじめに「ファイル名」で表示される文字列を指定する
        'ofdForm.FileName = "default.html"
        ofdForm.FileName = System.IO.Path.GetFileName(txt_Path.Text.TrimEnd)

        'はじめに表示されるフォルダを指定する
        '指定しない（空の文字列）の時は、現在のディレクトリが表示される
        'ofdForm.InitialDirectory = "C:\"
        If txt_Path.Text.TrimEnd = "" Then
            ofdForm.InitialDirectory = ""
        Else
            '現在指定のフォルダ存在チェック
            If System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txt_Path.Text.TrimEnd)) Then
                ofdForm.InitialDirectory = System.IO.Path.GetDirectoryName(txt_Path.Text.TrimEnd)
            Else
                ofdForm.InitialDirectory = ""
            End If
        End If

        '[ファイルの種類]に表示される選択肢を指定する
        '指定しないとすべてのファイルが表示される
        'ofdForm.Filter = _
        ofdForm.Filter = "TXTファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*"

        '[ファイルの種類]ではじめに
        '「すべてのファイル」が選択されているようにする
        ofdForm.FilterIndex = 1

        'タイトルを設定する
        ofdForm.Title = "名前を付けて保存"

        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        ofdForm.RestoreDirectory = True

        '存在しないファイルの名前が指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        ofdForm.CheckFileExists = False

        '存在しないパスが指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        ofdForm.CheckPathExists = True

        'ダイアログを表示する
        If ofdForm.ShowDialog() = DialogResult.OK Then
            'OKボタンがクリックされたとき
            '選択されたファイル名を表示する
            Console.WriteLine(ofdForm.FileName)
            txt_Path.Text = ofdForm.FileName
        End If

    End Sub
#End Region

#Region "cmdUpd_Click 実行ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdExec_Click
    '説明            :実行ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdExec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExec.Click
        Dim strMsg As String = String.Empty

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '必須チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            '保存処理確認
            If Show_MessageBox_Add("Q012", "振込データを作成します。よろしいですか？") = DialogResult.No Then    '振込データを作成します。よろしいですか？
                '「キャンセル」を選択
                Exit Try
            End If

            'データ保存処理
            If Not f_Data_Make() Then
                Exit Try
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

#Region "cmdEnd_Click 終了ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdEnd_Click
    '説明            :終了ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        Try
            If Show_MessageBox("Q001", "") = DialogResult.No Then   '終了します。よろしいですか？
                '処理を終了しますか？
                Exit Try
            End If

            'フォームクローズ
            Me.AutoValidate = AutoValidate.Disable
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

#Region "*** データ登録関連 ***"

#Region "f_Data_Save 積立金返還金融機関振込ワーク作成処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Make
    '説明            :積立金返還金融機関振込ワーク作成処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Make() As Boolean
        Dim ret As Boolean = False

        Try

            '金融データチェック
            Call f_TT_FURI_WORK_Data_Select()

            'CSV出力
            If Not f_FURIKOMI_FD_DATA_Make() Then
                Exit Try
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

#Region "*** ローカル関数 ***"

#Region "f_Input_Check 画面入力チェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check
    '説明            :画面入力チェック処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check() As Boolean
        Dim ret As Boolean = False

        Try

            '--------------------------------------------------
            '必須入力チェック
            '--------------------------------------------------
            '出力ファイル名
            If txt_Path.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W019", "出力ファイル名を指定してください。")      '@0
                txt_Path.Focus()
                Exit Try
            End If

            '出力ファイルPATHの存在チェック
            If System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txt_Path.Text.TrimEnd)) Then
            Else
                Show_MessageBox_Add("W019", "ファイル名が不正です。")
                txt_Path.Focus()
                Exit Try
            End If

            '出力ファイル名のチェック
            If System.IO.Path.GetFileName(txt_Path.Text.TrimEnd) = "" Then
                Show_MessageBox_Add("W019", "ファイル名が不正です。")
                txt_Path.Focus()
                Exit Try
            End If

            '出力ファイルの存在チェック
            If System.IO.File.Exists(txt_Path.Text.TrimEnd) Then
                'ファイルが既に存在する
                'ファイル上書き確認
                If Show_MessageBox_Add("Q012", "ファイルが既に存在します。上書きしますか？") = DialogResult.No Then    'ファイルが既に存在します。上書きしますか？
                    '「キャンセル」を選択
                    txt_Path.Focus()
                    Exit Try
                End If
            End If
            '対象年度
            If txt_TAISYO_KI.Text = String.Empty Then
                Show_MessageBox_Add("W008", "対象期")      '@0は必須入力項目です。
                txt_TAISYO_KI.Focus()
                Exit Try
            End If
            '振込予定日
            If date_FURIKOMIYMD.Value Is Nothing Then
                Show_MessageBox_Add("W008", "振込予定日")      '@0は必須入力項目です。
                date_FURIKOMIYMD.Focus()
                Exit Try
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region

#Region "f_TT_FURI_WORK_Data_Select 振込情報確認"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TT_FURI_WORK_Data_Select
    '説明            :振込情報確認
    '引数            :Boolean(データ有りTrue/データ無しFalse)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_TT_FURI_WORK_Data_Select() As Boolean

        Dim sSql As String = String.Empty
        Dim dstDataControl As New DataSet
        Dim ret As Boolean = False

        Try

            '積立金返還金融機関振込ワーク 読込
            sSql = ""
            sSql += " SELECT " & vbCrLf
            sSql += "   SEIKYU_KAISU " & vbCrLf
            sSql += " FROM " & vbCrLf
            sSql += "   TT_FURI_WORK " & vbCrLf
            sSql += " WHERE BANK_CD IS NULL " & vbCrLf
            sSql += "    OR SITEN_CD IS NULL " & vbCrLf
            'sSql += "    OR BANK_KANA IS NULL " & vbCrLf
            'sSql += "    OR SITEN_KANA IS NULL " & vbCrLf
            sSql += "    OR KOZA_SYUBETU IS NULL " & vbCrLf
            sSql += "    OR KOZA_NO IS NULL " & vbCrLf
            sSql += "    OR KOZA_MEIGI_KANA IS NULL " & vbCrLf

            Call f_Select_ODP(dstDataControl, sSql)

            With dstDataControl.Tables(0)
                If .Rows.Count <> 0 Then
                    Show_MessageBox_Add("I007", "振込情報が存在しないデータがありました。")
                End If
            End With

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_FURIKOMI_FD_DATA_Make 振込ＦＤデータ作成"
    '------------------------------------------------------------------
    'プロシージャ名  :f_FURIKOMI_FD_DATA_Make
    '説明            :振込ＦＤデータ作成
    '引数            :無し
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_FURIKOMI_FD_DATA_Make() As Boolean
        Dim sSql As String = String.Empty
        Dim dstDataSet1 As New DataSet
        Dim dstDataSet2 As New DataSet
        Dim strRecBuf As String = String.Empty
        Dim intRecCnt As Integer = 0
        Dim decKingakuKei As Decimal = 0
        Dim i As Integer
        Dim strMsg As String = String.Empty

        '書き込むファイルが既に存在している場合は、上書きする
        Dim swFile As New System.IO.StreamWriter(txt_Path.Text.TrimEnd, False, System.Text.Encoding.GetEncoding("shift_jis"))
        Dim ret As Boolean = False

        Try

            '--------------------------------------------------
            'ヘッダレコード作成
            '--------------------------------------------------
            sSql = " SELECT " & vbCrLf
            sSql += "     KYO.KOFU_KAISYA_CD " & vbCrLf                                 '振込依頼人コード
            sSql += "   , KYO.KOFU_KAISYA_NAME " & vbCrLf                              '振込口座名義カナ
            sSql += "   , KYO.KOFU_BANK_CD " & vbCrLf                                      '振込銀行コード
            sSql += "   , BAN.BANK_KANA " & vbCrLf                                         '振込銀行名カナ
            sSql += "   , KYO.KOFU_BANK_SITEN_CD " & vbCrLf                                '振込支店コード
            sSql += "   , SIT.SITEN_KANA " & vbCrLf                                        '振込支店名カナ
            sSql += "   , KYO.KOFU_KOZA_SYUBETU " & vbCrLf                                 '振込口座種別
            sSql += "   , KYO.KOFU_KOZA_NO " & vbCrLf                                      '振込口座番号
            sSql += " FROM " & vbCrLf
            sSql += "   TM_KYOKAI KYO " & vbCrLf
            sSql += " LEFT OUTER JOIN TM_BANK BAN " & vbCrLf
            sSql += "   ON BAN.BANK_CD = KYO.KOFU_BANK_CD " & vbCrLf
            sSql += " LEFT OUTER JOIN TM_SITEN SIT " & vbCrLf
            sSql += "   ON SIT.BANK_CD = KYO.KOFU_BANK_CD " & vbCrLf
            sSql += "   AND SIT.SITEN_CD = KYO.KOFU_BANK_SITEN_CD " & vbCrLf

            Call f_Select_ODP(dstDataSet1, sSql)

            With dstDataSet1.Tables(0)
                If .Rows.Count > 0 Then

                    strRecBuf = ""

                    'データ区分(1)、種別コード(21)、コード区分(0)
                    strRecBuf += "1210"

                    '会社コード
                    If .Rows(0)("KOFU_KAISYA_CD") Is DBNull.Value Then
                        strRecBuf += "0000000000"
                    Else
                        strRecBuf += Format(CDec(.Rows(0)("KOFU_KAISYA_CD")), "0000000000")
                    End If

                    '会社名
                    strRecBuf += .Rows(0)("KOFU_KAISYA_NAME").ToString.PadRight(40)

                    '振込月／引落月
                    strRecBuf += Format(Microsoft.VisualBasic.DateAndTime.Month(date_FURIKOMIYMD.Value), "00")

                    '振込日／引落日
                    strRecBuf += Format(Microsoft.VisualBasic.DateAndTime.Day(date_FURIKOMIYMD.Value), "00")

                    '仕向銀行コード
                    If .Rows(0)("KOFU_BANK_CD") Is DBNull.Value Then
                        strRecBuf += "0000"
                    Else
                        strRecBuf += Format(CInt(.Rows(0)("KOFU_BANK_CD")), "0000")
                    End If

                    '仕向銀行名
                    'If .Rows(0)("BANK_KANA").ToString.Length > 15 Then
                    '    strRecBuf += .Rows(0)("BANK_KANA").ToString.Substring(0, 15)
                    'Else
                    '    strRecBuf += .Rows(0)("BANK_KANA").ToString.PadRight(15)
                    'End If
                    strRecBuf += "".PadRight(15)

                    '仕向支店コード
                    If .Rows(0)("KOFU_BANK_SITEN_CD") Is DBNull.Value Then
                        strRecBuf += "000"
                    Else
                        strRecBuf += Format(CInt(.Rows(0)("KOFU_BANK_SITEN_CD")), "000")
                    End If

                    '仕向支店名
                    'If .Rows(0)("SITEN_KANA").ToString.Length > 15 Then
                    '    strRecBuf += .Rows(0)("SITEN_KANA").ToString.Substring(0, 15)
                    'Else
                    '    strRecBuf += .Rows(0)("SITEN_KANA").ToString.PadRight(15)
                    'End If
                    strRecBuf += "".PadRight(15)

                    '口座種目
                    If .Rows(0)("KOFU_KOZA_SYUBETU") Is DBNull.Value Then
                        strRecBuf += "0"
                    Else
                        strRecBuf += Format(CInt(.Rows(0)("KOFU_KOZA_SYUBETU")), "0")
                    End If

                    '口座番号
                    If .Rows(0)("KOFU_KOZA_NO") Is DBNull.Value Then
                        strRecBuf += "0000000"
                    Else
                        strRecBuf += Format(CDec(.Rows(0)("KOFU_KOZA_NO")), "0000000")
                    End If

                    '予備
                    strRecBuf += Space(17)

                    'テキスト出力
                    swFile.WriteLine(strRecBuf)

                Else
                    'レコードなし
                    swFile.Close()
                    Show_MessageBox_Add("W019", "協会マスタデータが存在しません。") '@0
                    Exit Try
                End If
            End With

            '--------------------------------------------------
            'データレコード作成
            '--------------------------------------------------
            sSql = " SELECT " & vbCrLf
            sSql += "   KEI.FURI_BANK_CD " & vbCrLf
            sSql += "   ,'' AS BANK_KANA" & vbCrLf
            sSql += "   ,KEI.FURI_BANK_SITEN_CD " & vbCrLf
            sSql += "   ,'' AS SITEN_KANA" & vbCrLf
            sSql += "   ,KEI.FURI_KOZA_SYUBETU " & vbCrLf
            sSql += "   ,KEI.FURI_KOZA_NO " & vbCrLf
            sSql += "   ,KEI.FURI_KOZA_MEIGI_KANA " & vbCrLf
            sSql += "   ,HEN.KINGAKU " & vbCrLf
            sSql += "   ,LPAD(" & CInt(txt_TAISYO_KI.Text) & ",2,0)  || LPAD(HEN.KEIYAKUSYA_CD,5,0) AS KOKYAKU_NO " & vbCrLf
            sSql += "FROM TW_HENKAN HEN LEFT JOIN TM_KEIYAKU KEI " & vbCrLf
            sSql += "    ON HEN.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD " & vbCrLf
            sSql += "    AND KEI.KI = " & CInt(txt_TAISYO_KI.Text) & vbCrLf
            sSql += "ORDER BY HEN.KEIYAKUSYA_CD " & vbCrLf

            Call f_Select_ODP(dstDataSet2, sSql)

            With dstDataSet2.Tables(0)

                intRecCnt = .Rows.Count
                decKingakuKei = 0

                If .Rows.Count > 0 Then

                    For i = 0 To (.Rows.Count - 1)

                        strRecBuf = ""

                        'データ区分
                        strRecBuf += "2"

                        '被仕向銀行コード
                        If .Rows(i)("FURI_BANK_CD") Is DBNull.Value Then
                            strRecBuf += "0000"
                        Else
                            strRecBuf += Format(CInt(.Rows(i)("FURI_BANK_CD")), "0000")
                        End If

                        '被仕向銀行名
                        If .Rows(i)("BANK_KANA").ToString.Length > 15 Then
                            strRecBuf += .Rows(i)("BANK_KANA").ToString.Substring(0, 15)
                        Else
                            strRecBuf += .Rows(i)("BANK_KANA").ToString.PadRight(15)
                        End If

                        '被仕向支店コード
                        If .Rows(i)("FURI_BANK_SITEN_CD") Is DBNull.Value Then
                            strRecBuf += "000"
                        Else
                            strRecBuf += Format(CInt(.Rows(i)("FURI_BANK_SITEN_CD")), "000")
                        End If

                        '被仕向支店名
                        If .Rows(i)("SITEN_KANA").ToString.Length > 15 Then
                            strRecBuf += .Rows(i)("SITEN_KANA").ToString.Substring(0, 15)
                        Else
                            strRecBuf += .Rows(i)("SITEN_KANA").ToString.PadRight(15)
                        End If

                        '手形交換所番号
                        strRecBuf += Space(4)

                        '口座種目
                        If .Rows(i)("FURI_KOZA_SYUBETU") Is DBNull.Value Then
                            strRecBuf += "0"
                        Else
                            strRecBuf += Format(CInt(.Rows(i)("FURI_KOZA_SYUBETU")), "0")
                        End If

                        '口座番号
                        If .Rows(i)("FURI_KOZA_NO") Is DBNull.Value Then
                            strRecBuf += "0000000"
                        Else
                            strRecBuf += Format(CDec(.Rows(i)("FURI_KOZA_NO")), "0000000")
                        End If

                        '預金者名
                        If .Rows(i)("FURI_KOZA_MEIGI_KANA").ToString.Length > 30 Then
                            strRecBuf += .Rows(i)("FURI_KOZA_MEIGI_KANA").ToString.Substring(0, 30)
                        Else
                            strRecBuf += .Rows(i)("FURI_KOZA_MEIGI_KANA").ToString.PadRight(30)
                        End If

                        '振込金額／引落金額
                        If .Rows(i)("KINGAKU") Is DBNull.Value Then
                            strRecBuf += "0000000000"
                        Else
                            strRecBuf += Format(CDec(.Rows(i)("KINGAKU")), "0000000000")
                            decKingakuKei += CDec(.Rows(i)("KINGAKU"))
                        End If

                        '新規コード
                        strRecBuf += "0"

                        '顧客番号
                        If .Rows(i)("KOKYAKU_NO") Is DBNull.Value Then
                            strRecBuf += "00000000000000000000"
                        Else
                            strRecBuf += "0000000000000" & .Rows(i)("KOKYAKU_NO").ToString.TrimEnd
                        End If

                        '引落フラグ
                        strRecBuf += Space(1)

                        '予備
                        strRecBuf += Space(8)

                        'テキスト出力
                        swFile.WriteLine(strRecBuf)

                    Next

                Else
                    'レコードなし
                    swFile.Close()
                    Show_MessageBox_Add("W019", "返還ワークデータが存在しません。") '@0
                    Exit Try
                End If

            End With

            '--------------------------------------------------
            'トレーラレコード作成
            '--------------------------------------------------
            strRecBuf = ""

            'データ区分
            strRecBuf += "8"

            '合計件数
            strRecBuf += Format(intRecCnt, "000000")

            '合計金額
            strRecBuf += Format(decKingakuKei, "000000000000")

            '予備
            strRecBuf += Space(101)

            'テキスト出力
            swFile.WriteLine(strRecBuf)

            '--------------------------------------------------
            'エンドレコード作成
            '--------------------------------------------------
            strRecBuf = ""

            'データ区分
            strRecBuf += "9"

            '予備
            strRecBuf += Space(119)

            'テキスト出力
            swFile.WriteLine(strRecBuf)

            swFile.Close()

            '終了メッセージ
            strMsg += "振込データ作成が終了しました。" & vbCrLf
            strMsg += "対象人数：" & Format(intRecCnt, "#,##0") & " 人" & vbCrLf
            strMsg += "積立金返還金額：" & Format(decKingakuKei, "#,##0") & " 円"
            Show_MessageBox_Add("I007", strMsg)

            ret = True

        Catch ex As Exception
            '共通例外処理
            If ex.Message <> "Err" Then
                Show_MessageBox("", ex.Message)
            End If
        Finally
            swFile.Close()
        End Try

        Return ret

    End Function
#End Region

#End Region

End Class
