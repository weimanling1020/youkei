﻿// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             母子保健詳細メニューマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_bhkksyosaimenyuDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_bhkksyosaimenyu";
		public string bosikbn { get; set; }                       //母子区分
		public string bhsyosaimenyucd { get; set; }               //母子保健詳細メニューコード
		public string bhsyosaimenyunm { get; set; }               //母子保健詳細メニュー名称
		public string bhsyosaimenyushortnm { get; set; }          //母子保健詳細メニュー略称
		public int orderseq { get; set; }                         //並びシーケンス
    }
}
