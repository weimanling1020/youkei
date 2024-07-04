﻿// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             予防接種依頼（フリー項目）テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_yssessyuiraifreeDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_yssessyuiraifree";
		public string atenano { get; set; }                       //宛名番号
		public int edano { get; set; }                            //枝番
		public string itemcd { get; set; }                        //項目コード
		public bool? fusyoflg { get; set; }                       //不詳フラグ
		public double? numvalue { get; set; }                     //数値項目
		public string? strvalue { get; set; }                     //文字項目
    }
}
