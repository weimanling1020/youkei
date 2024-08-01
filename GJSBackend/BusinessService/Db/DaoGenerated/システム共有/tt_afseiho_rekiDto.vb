﻿' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             【生活保護】生活保護受給情報履歴テーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tt_afseiho_rekiDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afseiho_reki"
        Public Property fukusijimusyocd As String               '福祉事務所コード
        Public Property caseno As String                        'ケース番号
        Public Property sinseirirekino As Integer                   '申請履歴番号
        Public Property ketteirirekino As Integer                   '決定履歴番号
        Public Property inno As Integer                             '員番号
        Public Property atenano As String                       '宛名番号
        Public Property seihoymdf As String                     '生活保護開始年月日
        Public Property teisiymd As String                      '停止年月日
        Public Property teisikaijoymd As String                '停止解除年月日
        Public Property tanheikyukbn As String                 '単併給区分
        Public Property seikatufujoflg As Boolean                 '生活扶助フラグ
        Public Property jutakufujoflg As Boolean                  '住宅扶助フラグ
        Public Property kyoikufujoflg As Boolean                  '教育扶助フラグ
        Public Property iryofujoflg As Boolean                    '医療扶助フラグ
        Public Property syussanfujoflg As Boolean                 '出産扶助フラグ
        Public Property seigyofujoflg As Boolean                  '生業扶助フラグ
        Public Property sosaifujoflg As Boolean                   '葬祭扶助フラグ
        Public Property haisiymd As String                     '廃止年月日
        Public Property renkeimotosousauserid As String         '連携元操作者ID
        Public Property renkeimotosousadttm As Date         '連携元操作日時
        Public Property saisinflg As Boolean                       '最新フラグ
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
