﻿// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             【障害者福祉】身体障害者手帳等情報テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afsyogaitetyoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afsyogaitetyo";
		public string atenano { get; set; }                       //宛名番号
		public string? henkanymd { get; set; }                    //返還日
		public string sikakujotaicd { get; set; }                 //資格状態コード
		public string? syokaikofuymd { get; set; }                //初回交付日
		public string? tetyono { get; set; }                      //手帳番号
		public string? tokeibuicd { get; set; }                   //統計部位コード
		public string? syogainm { get; set; }                     //障害名
		public string? syogaisyubetucd { get; set; }              //障害種別コード
		public string? sogotokyucd { get; set; }                  //総合等級コード
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
