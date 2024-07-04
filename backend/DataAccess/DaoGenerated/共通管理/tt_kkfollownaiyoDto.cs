﻿// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             フォロー内容情報テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkfollownaiyoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kkfollownaiyo";
		public string atenano { get; set; }                       //宛名番号
		public int follownaiyoedano { get; set; }                 //フォロー内容枝番
		public string? follownaiyo { get; set; }                  //フォロー内容
		public string followstatus { get; set; }                  //フォロー状況
		public string haakukeiro { get; set; }                    //把握経路
		public string haakujigyocd { get; set; }                  //フォロー把握事業コード
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
