﻿// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             妊婦健診費用助成（固定）サブテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnsninpukensinhiyojosei_subDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_bhnsninpukensinhiyojosei_sub";
        public string jigyocd { get; set; }                       //母子保健事業コード
        public string atenano { get; set; }                       //宛名番号
		public long torokuno { get; set; }                        //登録番号
		public int sinseiedano { get; set; }                      //申請枝番
		public int edano { get; set; }                            //枝番
		public string joseikensyurui { get; set; }				  //助成券種類
		public string jusinymd { get; set; }                      //受診年月日
		public int siharaikingaku { get; set; }                   //支払金額
		public int joseikingaku { get; set; }                     //助成金額
    }
}
