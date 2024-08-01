﻿' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 名称マスタEnum定義
'             
' 作成日　　: 2024.07.17
' 作成者　　: AIPlus
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db

    ''' <summary>
    ''' メインコード
    ''' </summary>
    Public Enum EnumMainCd
        ''' <summary>システムAF</summary>
        systemAF = 1000
    End Enum

    ''' <summary>
    ''' 名称マスタ
    ''' </summary>
    Public Enum EnumNmKbn As Long
        メニュー = 1000 * 100000000L + 1
        名称マスタメインコード = 1000 * 100000000L + 2
        汎用マスタメインコード = 1000 * 100000000L + 3
        コントロールマスタメインコード = 1000 * 100000000L + 4
        データ型 = 1000 * 100000000L + 6
        連携処理区分 = 1000 * 100000000L + 7
        DB変更区分 = 1000 * 100000000L + 8
        メッセージ切替区分 = 1000 * 100000000L + 9
        ファイルタイプ = 1000 * 100000000L + 10
        性別_システム = 1000 * 100000000L + 11
        処理結果コード = 1000 * 100000000L + 12
        表示色コード = 1000 * 100000000L + 13
        フリー項目データタイプ = 1000 * 100000000L + 14
        独自施策項目パターン = 1000 * 100000000L + 15
        ファイルマスタ使用区分 = 1000 * 100000000L + 16
        事業集約コード = 1000 * 100000000L + 17
        文字コード = 1000 * 100000000L + 18
        引用符_CSV出力用 = 1000 * 100000000L + 19
        共通バー番号_共通機能 = 1000 * 100000000L + 20
        共通バー表示 = 1000 * 100000000L + 21
        処理一覧_ログ画面用 = 1000 * 100000000L + 22
        指定コード長さ = 1000 * 100000000L + 24
        詳細条件コントローラー = 1000 * 100000000L + 26
        一覧テーブル区分 = 1000 * 100000000L + 27
        画面項目入力コントローラー = 1000 * 100000000L + 28
        住登区分 = 1000 * 100000000L + 29
        連携方式 = 1000 * 100000000L + 30
        連絡先タブ区分 = 1000 * 100000000L + 31
        年号情報 = 1000 * 100000000L + 32
        ログ区分 = 1000 * 100000000L + 38
        連携方向区分 = 1000 * 100000000L + 39
        操作処理区分 = 1000 * 100000000L + 40
        住民区分 = 1000 * 100000000L + 41
        住民区分設定 = 1000 * 100000000L + 42
        停止フラグ = 1000 * 100000000L + 44
        最新フラグ = 1000 * 100000000L + 45
        拡事業業務 = 1000 * 100000000L + 46
        拡事業種類 = 1000 * 100000000L + 47
        事業区分 = 1000 * 100000000L + 48
        項目区分 = 1000 * 100000000L + 49
        項目配置区分 = 1000 * 100000000L + 50
        各種事業コード設定対象 = 1000 * 100000000L + 51
        前回処理結果 = 1000 * 100000000L + 52
        モジュール = 1000 * 100000000L + 53
        月 = 1000 * 100000000L + 54
        日 = 1000 * 100000000L + 55
        週目 = 1000 * 100000000L + 56
        曜日 = 1000 * 100000000L + 57
        繰り返し間隔 = 1000 * 100000000L + 58
        継続時間 = 1000 * 100000000L + 59
        頻度区分 = 1000 * 100000000L + 61
        状態_バッチ = 1000 * 100000000L + 62
        使用停止フラグ_バッチ = 1000 * 100000000L + 63
        連携区分 = 1000 * 100000000L + 64
        システム区分 = 1000 * 100000000L + 65
        入出力区分 = 1000 * 100000000L + 66
        連携先 = 1000 * 100000000L + 67
        チェック区分 = 1000 * 100000000L + 68
        変換区分 = 1000 * 100000000L + 69
        エラーレベル_連携 = 1000 * 100000000L + 70
        ジョブステータス = 1000 * 100000000L + 71
        性別_システム共有 = 1000 * 100000000L + 72
        フリー項目特定区分 = 1000 * 100000000L + 73
        年度範囲区分 = 1000 * 100000000L + 74
        計算区分 = 1000 * 100000000L + 75
        計算関数_内部 = 1000 * 100000000L + 76
        グループ_基本データリスト = 1000 * 100000000L + 77
        保険区分_共通管理 = 1001 * 100000000L + 1
        申込結果区分 = 1001 * 100000000L + 5
        指導区分 = 1001 * 100000000L + 6
        フリー項目用途区分 = 1001 * 100000000L + 7
        コース区分 = 1001 * 100000000L + 12
        取込区分 = 1001 * 100000000L + 14
        登録区分 = 1001 * 100000000L + 15
        ファイル形式 = 1001 * 100000000L + 16
        エンコード = 1001 * 100000000L + 17
        データ形式 = 1001 * 100000000L + 18
        コード管理テーブル = 1001 * 100000000L + 19
        区切り記号 = 1001 * 100000000L + 20
        フォーマット_日付 = 1001 * 100000000L + 21
        項目特定区分 = 1001 * 100000000L + 22
        マッピング区分 = 1001 * 100000000L + 23
        マッピング方法 = 1001 * 100000000L + 24
        入力区分 = 1001 * 100000000L + 25
        入力方法 = 1001 * 100000000L + 26
        フォーマット_画面定義 = 1001 * 100000000L + 27
        エラーレベル = 1001 * 100000000L + 28
        表示入力設定 = 1001 * 100000000L + 29
        演算子 = 1001 * 100000000L + 30
        処理区分 = 1001 * 100000000L + 31
        処理種別 = 1001 * 100000000L + 32
        削除条件指定 = 1001 * 100000000L + 33
        地域保健集計区分 = 1001 * 100000000L + 34
        フォーマットチェック関数 = 1001 * 100000000L + 35
        フォーマット変換関数 = 1001 * 100000000L + 36
        地区区分 = 1001 * 100000000L + 37
        引数区分_マッピング = 1001 * 100000000L + 38
        全体個別区分 = 1001 * 100000000L + 39
        項目管理区分 = 1001 * 100000000L + 40
        抽出条件区分 = 1001 * 100000000L + 41
        通知サイクル = 1001 * 100000000L + 42
        引数区分_項目定義 = 1001 * 100000000L + 43
        医療機関_事業従事者業務区分 = 1001 * 100000000L + 100
        拡_予約_保健指導業務区分 = 1001 * 100000000L + 101
        基準値業務区分 = 1001 * 100000000L + 102
        EUC業務区分 = 1001 * 100000000L + 103
        取込業務区分 = 1001 * 100000000L + 104
        システム業務区分 = 1001 * 100000000L + 105
        _バッファ_画面業務区分106 = 1001 * 100000000L + 106
        基本データリストデータ型 = 1001 * 100000000L + 107
        _バッファ_画面業務区分199 = 1001 * 100000000L + 199
        成人保健フリー項目グループ１ = 1002 * 100000000L + 1
        計算関数_内部_成人 = 1002 * 100000000L + 3
        計算関数_DB_成人 = 1002 * 100000000L + 4
        対象サイン = 1002 * 100000000L + 7
        精密検査実施区分 = 1002 * 100000000L + 8
        クーポン券表示区分 = 1002 * 100000000L + 9
        減免区分種別 = 1002 * 100000000L + 10
        年齢基準日区分 = 1002 * 100000000L + 11
        対象サイン引継ぎフラグ = 1002 * 100000000L + 12
        健_検_診対象者特殊条件 = 1002 * 100000000L + 13
        計算区分_成人 = 1002 * 100000000L + 14
        生涯一回フラグ = 1002 * 100000000L + 15
        出力形式 = 1006 * 100000000L + 1
        帳票状態区分 = 1006 * 100000000L + 2
        帳票分類 = 1006 * 100000000L + 3
        様式種別 = 1006 * 100000000L + 4
        集計種別 = 1006 * 100000000L + 5
        専用様式 = 1006 * 100000000L + 6
        文字形式 = 1006 * 100000000L + 10
        数値形式 = 1006 * 100000000L + 11
        年形式 = 1006 * 100000000L + 12
        日付形式 = 1006 * 100000000L + 13
        日時形式 = 1006 * 100000000L + 14
        時間形式 = 1006 * 100000000L + 15
        論理形式 = 1006 * 100000000L + 16
        バーコード形式 = 1006 * 100000000L + 17
        出力方式 = 1006 * 100000000L + 18
        除票者除外区分 = 1006 * 100000000L + 19
        検索区分 = 1006 * 100000000L + 20
        性別_住民基本台帳 = 2001 * 100000000L + 1
        住民種別_住民基本台帳 = 2001 * 100000000L + 4
        住民状態_住民基本台帳 = 2001 * 100000000L + 5
        第30条45規定区分 = 2001 * 100000000L + 8
        在留資格等 = 2001 * 100000000L + 10
        在留期間等コード年 = 2001 * 100000000L + 11
        在留期間等コード月 = 2001 * 100000000L + 12
        在留期間等コード日 = 2001 * 100000000L + 13
        氏名優先区分 = 2001 * 100000000L + 14
        続柄 = 2001 * 100000000L + 18
        記載の事由 = 2001 * 100000000L + 20
        消除の事由 = 2001 * 100000000L + 21
        修正の事由 = 2001 * 100000000L + 22
        支援措置区分 = 2001 * 100000000L + 32
        未申告区分 = 2010 * 100000000L + 2
        課税非課税区分 = 2010 * 100000000L + 5
        税額_税額控除 = 2010 * 100000000L + 28
        他団体課税対象者区分 = 2010 * 100000000L + 900001
        職種 = 2019 * 100000000L + 2
        活動区分 = 2019 * 100000000L + 3
        登録事由 = 2019 * 100000000L + 4
        金額区分 = 2019 * 100000000L + 5
        発行区分 = 2019 * 100000000L + 7
        重要度 = 2019 * 100000000L + 8
        訪問種別_訪問結果情報 = 2019 * 100000000L + 9
        訪問対象 = 2019 * 100000000L + 10
        栄養_運動等指導内容 = 2019 * 100000000L + 12
        実施区分_個別_集団 = 2019 * 100000000L + 20
        出欠区分 = 2019 * 100000000L + 21
        相談内容 = 2019 * 100000000L + 22
        個別健康教育対象者区分 = 2019 * 100000000L + 25
        個別健康教育内容 = 2019 * 100000000L + 26
        個別健康教育状態区分 = 2019 * 100000000L + 27
        個別健康教育実施形態 = 2019 * 100000000L + 28
        集団健康教育内容 = 2019 * 100000000L + 29
        把握経路_フォロー状況情報 = 2019 * 100000000L + 32
        フォロー方法 = 2019 * 100000000L + 33
        フォロー状況 = 2019 * 100000000L + 34
        成人保健の受診希望 = 2019 * 100000000L + 35
        過去の受診歴 = 2019 * 100000000L + 37
        自治体検診の問診における有無の回答_三択 = 2019 * 100000000L + 38
        がん検診による偶発症の有無 = 2019 * 100000000L + 39
        がん検診の精密検査による偶発症の有無 = 2019 * 100000000L + 40
        血液判断 = 2019 * 100000000L + 41
        胃がん検診の精密検査の対象有無 = 2019 * 100000000L + 45
        胃がん検診の検査方法 = 2019 * 100000000L + 46
        所見有無 = 2019 * 100000000L + 47
        胃がん検診の精密検査結果 = 2019 * 100000000L + 48
        肺がん検診の精密検査対象有無 = 2019 * 100000000L + 49
        肺がん検診の胸部エックス線検査判定 = 2019 * 100000000L + 51
        肺がん検診の喀痰検査判定 = 2019 * 100000000L + 52
        肺がん検診の精密検査判定 = 2019 * 100000000L + 53
        子宮頸がん検診の精密検査判定 = 2019 * 100000000L + 55
        子宮頸がん検診の頸部細胞診検査判定 = 2019 * 100000000L + 56
        子宮頸がん検診の精密検査の対象有無 = 2019 * 100000000L + 57
        初回検体の適否 = 2019 * 100000000L + 58
        骨粗鬆症検診の精密検査判定 = 2019 * 100000000L + 59
        過去の検査判定 = 2019 * 100000000L + 60
        過去の精密検査の対象有無 = 2019 * 100000000L + 61
        喫煙習慣 = 2019 * 100000000L + 62
        ステロイド内服 = 2019 * 100000000L + 63
        活動量_運動頻度 = 2019 * 100000000L + 64
        月経の有無 = 2019 * 100000000L + 65
        閉経の理由 = 2019 * 100000000L + 66
        骨粗鬆症検診の検査判定 = 2019 * 100000000L + 67
        歯周疾患検診の精密検査判定 = 2019 * 100000000L + 68
        歯周疾患検診の精密検査の対象有無 = 2019 * 100000000L + 69
        歯をみがく頻度 = 2019 * 100000000L + 70
        歯間ブラシやフロスの使用頻度 = 2019 * 100000000L + 71
        喫煙歴 = 2019 * 100000000L + 72
        歯肉出血ＢＯＰ = 2019 * 100000000L + 73
        歯周ポケットＰＤ = 2019 * 100000000L + 74
        歯石の付着 = 2019 * 100000000L + 75
        口腔清掃状態 = 2019 * 100000000L + 76
        便潜血検査判定 = 2019 * 100000000L + 77
        大腸がん検診の精密検査の対象有無 = 2019 * 100000000L + 78
        大腸がん検診の精密検査判定 = 2019 * 100000000L + 79
        乳がん検診のマンモグラフィー検査判定 = 2019 * 100000000L + 80
        乳がん検診の精密検査対象有無 = 2019 * 100000000L + 81
        乳がん検診_マンモグラフィー検査一次読影 = 2019 * 100000000L + 82
        乳がん検診_マンモグラフィー検査二次読影 = 2019 * 100000000L + 83
        乳がん検診の精密検査結果 = 2019 * 100000000L + 84
        肝炎ウイルス検診のB_型肝炎ウイルス検査判定 = 2019 * 100000000L + 85
        肝炎ウイルス検診のC_型肝炎ウイルス検査判定 = 2019 * 100000000L + 86
        肝炎ウイルス検診の精密検査判定 = 2019 * 100000000L + 87
        C型判定理由 = 2019 * 100000000L + 88
        届出事由 = 2019 * 100000000L + 89
        届出時期_不詳含む = 2019 * 100000000L + 90
        交付事由 = 2019 * 100000000L + 91
        受診区分_妊婦健診結果 = 2019 * 100000000L + 92
        境界区分 = 2019 * 100000000L + 93
        ABO型 = 2019 * 100000000L + 94
        RH型 = 2019 * 100000000L + 95
        境界区分４ = 2019 * 100000000L + 96
        境界区分２ = 2019 * 100000000L + 97
        風疹抗体 = 2019 * 100000000L + 98
        子宮頸がん検診 = 2019 * 100000000L + 99
        承認区分 = 2019 * 100000000L + 100
        訪問理由 = 2019 * 100000000L + 101
        妊産婦区分 = 2019 * 100000000L + 102
        歯科判定 = 2019 * 100000000L + 103
        妊婦歯科歯肉の炎症 = 2019 * 100000000L + 104
        精密検査判定 = 2019 * 100000000L + 105
        精密検査結果 = 2019 * 100000000L + 106
        産婦健診判定 = 2019 * 100000000L + 107
        利用サービス = 2019 * 100000000L + 108
        栄養方法_新生児期 = 2019 * 100000000L + 109
        先天性代謝異常等検査 = 2019 * 100000000L + 110
        聴覚検査方式 = 2019 * 100000000L + 111
        聴覚検査結果 = 2019 * 100000000L + 112
        聴覚検査判定 = 2019 * 100000000L + 113
        助成券種類 = 2019 * 100000000L + 114
        実施区分 = 2019 * 100000000L + 115
        歳児別健診判定 = 2019 * 100000000L + 116
        眼科の判定 = 2019 * 100000000L + 117
        耳鼻科の判定 = 2019 * 100000000L + 118
        栄養 = 2019 * 100000000L + 119
        母乳 = 2019 * 100000000L + 120
        離乳 = 2019 * 100000000L + 121
        乳幼児健診アンケート回答_仕上げ磨き = 2019 * 100000000L + 122
        乳幼児健診アンケート回答_はい_いいえ_無回答 = 2019 * 100000000L + 123
        乳幼児健診アンケート回答_子育て = 2019 * 100000000L + 124
        乳幼児健診アンケート回答_父親育児 = 2019 * 100000000L + 125
        乳幼児健診アンケート回答_浴室ドア = 2019 * 100000000L + 126
        乳幼児健診アンケート回答_はい_いいえ_何ともいえない_無回答 = 2019 * 100000000L + 127
        乳幼児健診アンケート回答_育てにくさ = 2019 * 100000000L + 128
        罹患型１ = 2019 * 100000000L + 129
        むし歯の状態_3歳児健診結果 = 2019 * 100000000L + 130
        不正咬合 = 2019 * 100000000L + 134
        産後ケア = 2019 * 100000000L + 136
        栄養法_3から4か月児健診結果 = 2019 * 100000000L + 137
        罹患型２ = 2019 * 100000000L + 139
        所見または今後の処置 = 2019 * 100000000L + 141
        勧奨方法 = 2019 * 100000000L + 142
        訪問種別_訪問情報 = 2019 * 100000000L + 143
        笑うことができたし_物事の面白い面もわかった = 2019 * 100000000L + 144
        物事を楽しみにして待った = 2019 * 100000000L + 145
        物事がうまくいかない時_自分を不必要に責めた = 2019 * 100000000L + 146
        はっきりとした理由もないのに不安になったり_心配したりした = 2019 * 100000000L + 147
        はっきりとした理由もないのに恐怖に襲われた = 2019 * 100000000L + 148
        することがたくさんあって大変だった = 2019 * 100000000L + 149
        不幸せな気分なので_眠りにくかった = 2019 * 100000000L + 150
        悲しくなったり_惨めになったりした = 2019 * 100000000L + 151
        不幸せな気分だったので_泣いていた = 2019 * 100000000L + 152
        自分自身を傷つけるという考えが浮かんできた = 2019 * 100000000L + 153
        保健指導_対象者区分 = 2019 * 100000000L + 154
        健康増進_実施対象者 = 2019 * 100000000L + 155
        同伴者 = 2019 * 100000000L + 156
        階層区分 = 2019 * 100000000L + 157
        加算対象 = 2019 * 100000000L + 158
        申請区分 = 2019 * 100000000L + 159
        申請変更理由 = 2019 * 100000000L + 160
        保険区分 = 2019 * 100000000L + 161
        課税区分_養育医療申請情報 = 2019 * 100000000L + 162
        申請者_扶養義務者_続柄 = 2019 * 100000000L + 163
        判定結果 = 2019 * 100000000L + 164
        レセプト区分 = 2019 * 100000000L + 167
        予防接種の実施方式 = 2019 * 100000000L + 170
        接種区分 = 2019 * 100000000L + 171
        特別の事情 = 2019 * 100000000L + 172
        単位 = 2019 * 100000000L + 173
        接種判定 = 2019 * 100000000L + 174
        抗体検査方法 = 2019 * 100000000L + 175
        抗体検査番号 = 2019 * 100000000L + 176
        認定区分 = 2019 * 100000000L + 177
        給付の種類 = 2019 * 100000000L + 179
        住民種別 = 2019 * 100000000L + 180
        住民状態 = 2019 * 100000000L + 181
        骨粗鬆症検診の一次検診判定 = 2019 * 100000000L + 187
        大腿骨近位部骨折の家族歴 = 2019 * 100000000L + 188
        予防接種区分 = 2019 * 100000000L + 189
        健やか親子21アンケート回答_心身の調子 = 2019 * 100000000L + 190
        健やか親子21アンケート回答_経済的状況 = 2019 * 100000000L + 191
        健やか親子21アンケート回答_朝起きる時間 = 2019 * 100000000L + 192
        健やか親子21アンケート回答_夜寝る時間 = 2019 * 100000000L + 193
        健やか親子21アンケート回答_なし_あり_無回答 = 2019 * 100000000L + 194
        健やか親子21アンケート回答_あり_なし_無回答 = 2019 * 100000000L + 195
        健やか親子21アンケート回答_働いていたことがある = 2019 * 100000000L + 196
        健やか親子21アンケート回答_利用したことがある = 2019 * 100000000L + 197
        マタニティマークアンケート回答_知らなかった_知っていた = 2019 * 100000000L + 198
        乳幼児歯科健診判定 = 2019 * 100000000L + 199
        育児支援チェックリスト回答1から3_4_3_また5から9 = 2019 * 100000000L + 200
        育児支援チェックリスト回答4_1 = 2019 * 100000000L + 201
        育児支援チェックリスト回答4_2 = 2019 * 100000000L + 202
        赤ちゃんへの気持ち質問票回答１ = 2019 * 100000000L + 203
        赤ちゃんへの気持ち質問票回答２ = 2019 * 100000000L + 204
        点数表コード = 2019 * 100000000L + 205
        療養_食事コード = 2019 * 100000000L + 206
        歯式コード_妊産婦 = 2019 * 100000000L + 207
        歯式コード_子供 = 2019 * 100000000L + 208
        住登外者異動事由 = 2019 * 100000000L + 209
        妊婦健診判定 = 2019 * 100000000L + 210
        パーセンタイル値の範囲 = 2019 * 100000000L + 211
        屈折検査判定結果 = 2019 * 100000000L + 212
        食事をかんで食べる時の状態 = 2019 * 100000000L + 213
        冷たいものや熱いものが歯にしみますか = 2019 * 100000000L + 214
        ゆっくりよくかんで食事をしますか = 2019 * 100000000L + 215
        歯科医院にいつ頃行きましたか = 2019 * 100000000L + 216
        歯は何本ありますか = 2019 * 100000000L + 217
        歯式コード_成人 = 2019 * 100000000L + 218
        診察所見の判定 = 2019 * 100000000L + 219
        はい_いいえ = 2019 * 100000000L + 220
        健診種別 = 2019 * 100000000L + 221
        子宮復古状況 = 2019 * 100000000L + 222
        悪露 = 2019 * 100000000L + 223
        分娩経過 = 2019 * 100000000L + 224
        分娩方法 = 2019 * 100000000L + 225
        出血量_区分 = 2019 * 100000000L + 226
        出産時の児の状態_性別 = 2019 * 100000000L + 227
        歯周病 = 2019 * 100000000L + 228
        歯周病の治療の必要 = 2019 * 100000000L + 229
        特別な所見_処置 = 2019 * 100000000L + 230
        異常 = 2019 * 100000000L + 231
        歯の汚れ = 2019 * 100000000L + 232
        本人性別 = 2019 * 100000000L + 233
        キャンセル待ち = 2019 * 100000000L + 234
        有無 = 2019 * 100000000L + 235
        実施 = 2019 * 100000000L + 236
        該当 = 2019 * 100000000L + 237
        輸血の有無 = 2019 * 100000000L + 238
        歯の形態_色調 = 2019 * 100000000L + 239
        いいえ_はい = 2019 * 100000000L + 240
        妊娠歴 = 2019 * 100000000L + 241
        出産歴 = 2019 * 100000000L + 242
        むし歯の状態_1歳6か月児健診結果 = 2019 * 100000000L + 243
        軟組織異常有無 = 2019 * 100000000L + 244
        栄養法_3から4か月児健診アンケート = 2019 * 100000000L + 245
        要否 = 2019 * 100000000L + 246
        可_否 = 2019 * 100000000L + 247
        有無区分 = 2019 * 100000000L + 900001
        単併給区分 = 2021 * 100000000L + 19
        認定有無 = 2021 * 100000000L + 900001
        資格状態 = 2022 * 100000000L + 8
        身体障害者手帳障害種別 = 2022 * 100000000L + 15
        身体障害者手帳総合等級 = 2022 * 100000000L + 16
        身体障害者手帳障害部位 = 2022 * 100000000L + 17
        要介護状態区分コード = 2023 * 100000000L + 35
        被保険者区分コード = 2023 * 100000000L + 49
        要介護認定状況コード = 2023 * 100000000L + 63
        国保資格区分 = 2024 * 100000000L + 1
        マル学マル遠区分 = 2024 * 100000000L + 7
        国保資格取得事由_集約システム = 2024 * 100000000L + 131
        国保資格喪失事由_集約システム = 2024 * 100000000L + 132
        証区分 = 2024 * 100000000L + 900001
        個人区分コード = 2025 * 100000000L + 1
        資格取得事由コード = 2025 * 100000000L + 11
        資格喪失事由コード = 2025 * 100000000L + 12
        名寄せ元フラグ = 2031 * 100000000L + 2
        他業務参照不可フラグ = 2031 * 100000000L + 3
        性別_団体内統合宛名 = 2032 * 100000000L + 1
        統合宛名フラグ = 2032 * 100000000L + 3
        国名コード = 3019 * 100000000L + 100002
        指定都市_行政区等コード = 3019 * 100000000L + 100004
    End Enum

    ''' <summary>
    ''' コントロールマスタ
    ''' </summary>
    Public Enum EnumCtrlKbn As Long
        パスワード = 1000 * 100000000L + 1
        config情報 = 1000 * 100000000L + 2
        画面確認件数 = 1000 * 100000000L + 3
        画面上限件数 = 1000 * 100000000L + 4
        検診事業の年齢基準指定 = 1000 * 100000000L + 5
        検診事業の複数回数指定 = 1000 * 100000000L + 6
        拡事業関連上限件数 = 1000 * 100000000L + 7
        同一世帯員更新フラグ = 1001 * 100000000L + 2
        付番開始番号 = 1001 * 100000000L + 3
        一次結果チェック区分 = 1002 * 100000000L + 2
        テンプレート名 = 1006 * 100000000L + 1
        アドレスシールの設定 = 1006 * 100000000L + 2
        バーコードシールの設定 = 1006 * 100000000L + 3
        はがきの設定 = 1006 * 100000000L + 4
        フォント表示の設定 = 1006 * 100000000L + 5
    End Enum

    ''' <summary>
    ''' 汎用マスタ
    ''' </summary>
    Public Enum EnumHanyoKbn As Long
        メモ事業コード管理 = 1000 * 100000000L + 1
        電子ファイル事業コード管理 = 1000 * 100000000L + 2
        医療機関事業コード管理 = 1000 * 100000000L + 3
        事業従事者事業コード管理 = 1000 * 100000000L + 4
        連絡先事業コード管理 = 1000 * 100000000L + 5
        フォロー事業コード管理 = 1000 * 100000000L + 6
        祝日管理 = 1000 * 100000000L + 8
        計算関数_DB = 1000 * 100000000L + 9
        自治体情報 = 1001 * 100000000L + 1
        課 = 1001 * 100000000L + 2
        係 = 1001 * 100000000L + 3
        問い合わせ内容コード = 1001 * 100000000L + 4
        クーポン券発番順 = 1001 * 100000000L + 5
        受診拒否理由 = 1002 * 100000000L + 1
        成人健_検_診予約日程事業名 = 1002 * 100000000L + 2
        料金パターン = 1002 * 100000000L + 3
        減免区分_がん検診 = 1002 * 100000000L + 4
        減免区分_特定健診 = 1002 * 100000000L + 5
        基本健診予約分類 = 1002 * 100000000L + 101
        肝炎予約分類 = 1002 * 100000000L + 102
        胃がん予約分類 = 1002 * 100000000L + 103
        大腸がん予約分類 = 1002 * 100000000L + 104
        肺がん予約分類 = 1002 * 100000000L + 105
        子宮頸がん予約分類 = 1002 * 100000000L + 106
        乳がん予約分類 = 1002 * 100000000L + 107
        骨粗鬆症予約分類 = 1002 * 100000000L + 108
        歯周疾患予約分類 = 1002 * 100000000L + 109
        検診種別１０_予備_予約分類 = 1002 * 100000000L + 110
        拡事業１予約分類 = 1002 * 100000000L + 151
        基本検診フリー項目グループ2 = 1002 * 100000000L + 201
        肝炎フリー項目グループ2 = 1002 * 100000000L + 202
        胃がんフリー項目グループ2 = 1002 * 100000000L + 203
        大腸がんフリー項目グループ2 = 1002 * 100000000L + 204
        肺がんフリー項目グループ2 = 1002 * 100000000L + 205
        子宮頸がんフリー項目グループ2 = 1002 * 100000000L + 206
        乳がんフリー項目グループ2 = 1002 * 100000000L + 207
        骨粗鬆症フリー項目グループ2 = 1002 * 100000000L + 208
        歯周疾患フリー項目グループ2 = 1002 * 100000000L + 209
        検診種別１０_予備_フリー項目グループ2 = 1002 * 100000000L + 210
        拡事業１_予備_フリー項目グループ2 = 1002 * 100000000L + 251

        母子保健事業コード = 1003 * 100000000L + 1
        妊婦健診名 = 1003 * 100000000L + 2
        産婦健診名 = 1003 * 100000000L + 3
        妊婦歯科健診名 = 1003 * 100000000L + 4
        妊産婦グループID = 1003 * 100000000L + 101
        乳幼児グループID = 1003 * 100000000L + 102
        妊産婦グループID2 = 1003 * 100000000L + 201
        乳幼児グループID2 = 1003 * 100000000L + 202

        予防接種抽出対象コード = 1004 * 100000000L + 1
        接種種類詳細コード = 1004 * 100000000L + 2
        ワクチンメーカー = 1004 * 100000000L + 3
        罹患項目 = 1004 * 100000000L + 5
        ワクチン種類コード = 1004 * 100000000L + 6
        接種種類フィルター区分 = 1004 * 100000000L + 8
        その他情報グループ1 = 1004 * 100000000L + 10
        その他情報グループ2 = 1004 * 100000000L + 11
        接種情報生涯1回グループ1 = 1004 * 100000000L + 12
        接種情報生涯1回グループ2 = 1004 * 100000000L + 13
        接種情報複数回グループ1 = 1004 * 100000000L + 14
        接種情報複数回グループ2 = 1004 * 100000000L + 15
        風しん抗体検査情報グループ1 = 1004 * 100000000L + 16
        風しん抗体検査情報グループ2 = 1004 * 100000000L + 17
        接種依頼情報グループ1 = 1004 * 100000000L + 18
        接種依頼情報グループ2 = 1004 * 100000000L + 19
        予防接種済証接種種類コード = 1004 * 100000000L + 20
        予防接種済証タイトル = 1004 * 100000000L + 21

        業務区分_帳票 = 1006 * 100000000L + 1
        帳票グループ = 1006 * 100000000L + 2
        帳票発行履歴区分 = 1006 * 100000000L + 3
        帳票出力区分紐づけ = 1006 * 100000000L + 100
        帳票出力区分一覧 = 1006 * 100000000L + 101
        出力区分管理様式一覧 = 1006 * 100000000L + 201
        部署_支所 = 3019 * 100000000L + 1
        メモ事業コード = 3019 * 100000000L + 2
        電子ファイル事業コード = 3019 * 100000000L + 3
        連絡先用事業コード = 3019 * 100000000L + 4
        医師会 = 3019 * 100000000L + 100001
        保健指導_集団指導項目グループ = 3019 * 100000000L + 100002
        医療機関_事業従事者_担当者_事業コード = 3019 * 100000000L + 100003
        実施報告事業コード = 3019 * 100000000L + 100004
        利用目的 = 3019 * 100000000L + 100005
        フォロー把握事業コード = 3019 * 100000000L + 100006
        フォロー事業コード = 3019 * 100000000L + 100007
        集団指導事業コード = 3019 * 100000000L + 100008
        独自施策システム等ID = 3019 * 100000000L + 100009
        業務ID = 3019 * 100000000L + 100010
        登録部署 = 3019 * 100000000L + 100011
        検診種別 = 3019 * 100000000L + 200001
        基本健診一次検査方法 = 3019 * 100000000L + 210001
        基本健診用一次検診コード = 3019 * 100000000L + 210002
        肝炎検診一次検査方法 = 3019 * 100000000L + 210201
        肝炎検診用一次検診コード = 3019 * 100000000L + 210202
        胃がん一次検査方法 = 3019 * 100000000L + 210401
        胃がん検診用一次検診コード = 3019 * 100000000L + 210402
        大腸がん一次検査方法 = 3019 * 100000000L + 210601
        大腸がん検診用一次検診コード = 3019 * 100000000L + 210602
        肺がん一次検査方法 = 3019 * 100000000L + 210801
        肺がん検診用一次検診コード = 3019 * 100000000L + 210802
        子宮頸がん一次検査方法 = 3019 * 100000000L + 211001
        子宮頸がん検診用一次検診コード = 3019 * 100000000L + 211002
        乳がん一次検査方法 = 3019 * 100000000L + 211201
        乳がん検診用一次検診コード = 3019 * 100000000L + 211202
        骨粗鬆症一次検査方法 = 3019 * 100000000L + 211401
        骨粗鬆症検診用一次検診コード = 3019 * 100000000L + 211402
        歯周疾患一次検査方法 = 3019 * 100000000L + 211601
        歯周疾患検診用一次検診コード = 3019 * 100000000L + 211602
        検診種別10_予備_用一次検診コード = 3019 * 100000000L + 211801
        PKG用精密検査コード = 3019 * 100000000L + 220001
        市区町村用一次検診コード = 3019 * 100000000L + 230001
        市区町村用精密検診コード = 3019 * 100000000L + 240001
        拡事業１検査方法 = 3019 * 100000000L + 250001
        拡事業１用一次検診コード = 3019 * 100000000L + 250002
        拡事業２検査方法 = 3019 * 100000000L + 250201
        拡事業２用一次検診コード = 3019 * 100000000L + 250202
        拡事業３検査方法 = 3019 * 100000000L + 250401
        拡事業３用一次検診コード = 3019 * 100000000L + 250402
        拡事業４検査方法 = 3019 * 100000000L + 250601
        拡事業４用一次検診コード = 3019 * 100000000L + 250602
        拡事業５検査方法 = 3019 * 100000000L + 250801
        拡事業５用一次検診コード = 3019 * 100000000L + 250802
        拡事業６検査方法 = 3019 * 100000000L + 251001
        拡事業６用一次検診コード = 3019 * 100000000L + 251002
        拡事業７検査方法 = 3019 * 100000000L + 251201
        拡事業７用一次検診コード = 3019 * 100000000L + 251202
        拡事業８検査方法 = 3019 * 100000000L + 251401
        拡事業８用一次検診コード = 3019 * 100000000L + 251402
        拡事業９検査方法 = 3019 * 100000000L + 251601
        拡事業９用一次検診コード = 3019 * 100000000L + 251602
        拡事業１０検査方法 = 3019 * 100000000L + 251801
        拡事業１０用一次検診コード = 3019 * 100000000L + 251802
        拡事業１１検査方法 = 3019 * 100000000L + 252001
        拡事業１１用一次検診コード = 3019 * 100000000L + 252002
        拡事業１２検査方法 = 3019 * 100000000L + 252201
        拡事業１２用一次検診コード = 3019 * 100000000L + 252202
        拡事業１３検査方法 = 3019 * 100000000L + 252401
        拡事業１３用一次検診コード = 3019 * 100000000L + 252402
        拡事業１４検査方法 = 3019 * 100000000L + 252601
        拡事業１４用一次検診コード = 3019 * 100000000L + 252602
        拡事業１５検査方法 = 3019 * 100000000L + 252801
        拡事業１５用一次検診コード = 3019 * 100000000L + 252802
        拡事業１６検査方法 = 3019 * 100000000L + 253001
        拡事業１６用一次検診コード = 3019 * 100000000L + 253002
        拡事業１７検査方法 = 3019 * 100000000L + 253201
        拡事業１７用一次検診コード = 3019 * 100000000L + 253202
        拡事業１８検査方法 = 3019 * 100000000L + 253401
        拡事業１８用一次検診コード = 3019 * 100000000L + 253402
        拡事業１９検査方法 = 3019 * 100000000L + 253601
        拡事業１９用一次検診コード = 3019 * 100000000L + 253602
        拡事業２０検査方法 = 3019 * 100000000L + 253801
        拡事業２０用一次検診コード = 3019 * 100000000L + 253802
        拡事業２１検査方法 = 3019 * 100000000L + 254001
        拡事業２１用一次検診コード = 3019 * 100000000L + 254002
        拡事業２２検査方法 = 3019 * 100000000L + 254201
        拡事業２２用一次検診コード = 3019 * 100000000L + 254202
        拡事業２３検査方法 = 3019 * 100000000L + 254401
        拡事業２３用一次検診コード = 3019 * 100000000L + 254402
        拡事業２４検査方法 = 3019 * 100000000L + 254601
        拡事業２４用一次検診コード = 3019 * 100000000L + 254602
        拡事業２５検査方法 = 3019 * 100000000L + 254801
        拡事業２５用一次検診コード = 3019 * 100000000L + 254802
        拡事業２６検査方法 = 3019 * 100000000L + 255001
        拡事業２６用一次検診コード = 3019 * 100000000L + 255002
        拡事業２７検査方法 = 3019 * 100000000L + 255201
        拡事業２７用一次検診コード = 3019 * 100000000L + 255202
        拡事業２８検査方法 = 3019 * 100000000L + 255401
        拡事業２８用一次検診コード = 3019 * 100000000L + 255402
        拡事業２９検査方法 = 3019 * 100000000L + 255601
        拡事業２９用一次検診コード = 3019 * 100000000L + 255602
        拡事業３０検査方法 = 3019 * 100000000L + 255801
        拡事業３０用一次検診コード = 3019 * 100000000L + 255802
        拡事業３１検査方法 = 3019 * 100000000L + 256001
        拡事業３１用一次検診コード = 3019 * 100000000L + 256002
        拡事業３２検査方法 = 3019 * 100000000L + 256201
        拡事業３２用一次検診コード = 3019 * 100000000L + 256202
        拡事業３３検査方法 = 3019 * 100000000L + 256401
        拡事業３３用一次検診コード = 3019 * 100000000L + 256402
        拡事業３４検査方法 = 3019 * 100000000L + 256601
        拡事業３４用一次検診コード = 3019 * 100000000L + 256602
        拡事業３５検査方法 = 3019 * 100000000L + 256801
        拡事業３５用一次検診コード = 3019 * 100000000L + 256802
        拡事業３６検査方法 = 3019 * 100000000L + 257001
        拡事業３６用一次検診コード = 3019 * 100000000L + 257002
        拡事業３７検査方法 = 3019 * 100000000L + 257201
        拡事業３７用一次検診コード = 3019 * 100000000L + 257202
        拡事業３８検査方法 = 3019 * 100000000L + 257401
        拡事業３８用一次検診コード = 3019 * 100000000L + 257402
        拡事業３９検査方法 = 3019 * 100000000L + 257601
        拡事業３９用一次検診コード = 3019 * 100000000L + 257602
        拡事業４０検査方法 = 3019 * 100000000L + 257801
        拡事業４０用一次検診コード = 3019 * 100000000L + 257802
        拡事業４１検査方法 = 3019 * 100000000L + 258001
        拡事業４１用一次検診コード = 3019 * 100000000L + 258002
        拡事業４２検査方法 = 3019 * 100000000L + 258201
        拡事業４２用一次検診コード = 3019 * 100000000L + 258202
        拡事業４３検査方法 = 3019 * 100000000L + 258401
        拡事業４３用一次検診コード = 3019 * 100000000L + 258402
        拡事業４４検査方法 = 3019 * 100000000L + 258601
        拡事業４４用一次検診コード = 3019 * 100000000L + 258602
        拡事業４５検査方法 = 3019 * 100000000L + 258801
        拡事業４５用一次検診コード = 3019 * 100000000L + 258802
        拡事業４６検査方法 = 3019 * 100000000L + 259001
        拡事業４６用一次検診コード = 3019 * 100000000L + 259002
        拡事業４７検査方法 = 3019 * 100000000L + 259201
        拡事業４７用一次検診コード = 3019 * 100000000L + 259202
        拡事業４８検査方法 = 3019 * 100000000L + 259401
        拡事業４８用一次検診コード = 3019 * 100000000L + 259402
        拡事業４９検査方法 = 3019 * 100000000L + 259601
        拡事業４９用一次検診コード = 3019 * 100000000L + 259602
        拡事業５０検査方法 = 3019 * 100000000L + 259801
        拡事業５０用一次検診コード = 3019 * 100000000L + 259802
        拡事業１用精密検査コード = 3019 * 100000000L + 260001
        予防接種の帳票様式一覧 = 3019 * 100000000L + 400001

        ワクチン = 3019 * 100000000L + 400002
    End Enum

End Namespace
