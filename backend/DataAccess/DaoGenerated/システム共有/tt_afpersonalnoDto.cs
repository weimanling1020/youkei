﻿// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             個人番号管理テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afpersonalnoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afpersonalno";
		public string atenano { get; set; }                       //宛名番号
		public int rirekino { get; set; }                         //履歴番号
		public string? personalno { get; set; }                   //個人番号（マイナンバー）
		public string renkeimotosousauserid { get; set; }         //連携元操作者ID
		public DateTime renkeimotosousadttm { get; set; }         //連携元操作日時
		public bool saisinflg { get; set; }                       //最新フラグ
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
