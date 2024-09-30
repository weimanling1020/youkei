﻿' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: コードマスタメンテナンス
'            サービス処理
' 作成日　　: 2024.09.18
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8011

    ''' <summary>
    ''' 初期化処理_詳細画面
    ''' </summary>
    <DisplayName("初期化処理_詳細画面")>
    Public Class Service
        Inherits CmServiceBase

        <DisplayName("初期化処理_詳細画面")>
        Public Shared Function InitDetail(req As InitDetailRequest) As InitDetailResponse
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
                    '新規の場合
                    If Not req.MEISYO_CD.HasValue Then
                        Return New InitDetailResponse()
                    Else　'変更の場合
                        '検索結果出力用ＳＱＬ作成
                        Dim sql = FrmGJ8011Service.f_SetForm_Data(req.SYURUI_KBN, req.MEISYO_CD)

                        'データSelect 
                        Dim dt = FrmService.f_Select_ODP(db, sql).Tables(0)

                        'データ結果判定
                        If dt.Rows.Count ＝ 0 Then
                            Return New InitDetailResponse("該当データが存在しませんでした。")
                        End If
                    
                        '-------------------------------------------------------------
                        '5.データ加工処理
                        '-------------------------------------------------------------
                        Dim res = Wraper.InitDetailResponse(dt)

                        '-------------------------------------------------------------
                        '6.正常返し
                        '-------------------------------------------------------------
                        Return res
                    End If

                End Function)

        End Function

       <DisplayName("削除処理_詳細画面処理")>
        Public Shared Function Delete(req As DeleteRequest) As DaResponseBase
            Return Transction(req,
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
                    '削除結果出力用ＳＱＬ作成
                    Dim res = FrmGJ8011Service.f_Data_Deleate(db, req)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

       End Function

      <DisplayName("保存処理_詳細画面処理")>
        Public Shared Function Save(req As SaveRequest) As DaResponseBase
            Return Transction(req,
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
                    Dim sql = FrmGJ8011Service.f_SetForm_Data(req.CODE.SYURUI_KBN, req.CODE.MEISYO_CD)

                    'データSelect 
                    Dim dt = FrmService.f_Select_ODP(db, sql).Tables(0)

                    'データ結果判定
                    '新規の場合
                    Dim bNew As Boolean = True
                    'データの独占性
                    Select Case req.EDIT_KBN
                        Case EnumEditKbn.Edit       '変更入力
                            bNew = False
                            If dt.Rows.Count ＝ 0 Then
                                Return New DaResponseBase("データが存在しないため、データを変更できません。")
                            Else If dt.Rows.Count > 0 Then
                                'データの独占性
                                If CDate(dt.Rows(0)("UP_DATE")) > req.CODE.UP_DATE
                                    Return New DaResponseBase("データを更新できません。他のユーザーによって変更された可能性があります。")
                                End If
                            End If
                    End Select 

                    '保存処理
                    Dim res = FrmGJ8011Service.f_TM_CODE_Update(db, req, bNew)

                    '-------------------------------------------------------------
                    '5.データ加工処理
                    '-------------------------------------------------------------

                    '-------------------------------------------------------------
                    '6.正常返し
                    '-------------------------------------------------------------
                    Return res

                End Function)

       End Function

    End Class
End Namespace
