﻿// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             使用履歴テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afsiyorirekiDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afsiyorireki";
		public string userid { get; set; }                        //ユーザーID
		public string kinoid { get; set; }                        //機能ID
		public DateTime syoridttm { get; set; }                   //処理日時
    }
}
