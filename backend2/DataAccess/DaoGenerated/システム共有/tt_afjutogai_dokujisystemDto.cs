﻿// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             住登外者独自施策システム等情報テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afjutogai_dokujisystemDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afjutogai_dokujisystem";
		public string atenano { get; set; }                       //宛名番号
		public int rirekino { get; set; }                         //履歴番号
		public string dokujisystemid { get; set; }                //独自施策システム等ID
    }
}
