﻿// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             集団指導事業（フリー項目）コントロールマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kksdfreeitemDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_kksdfreeitem";
		public string itemyotokbn { get; set; }                   //項目用途区分
		public string gyomukbn { get; set; }                      //業務区分
		public string mosikomikekkakbn { get; set; }              //申込結果区分
		public string itemcd { get; set; }                        //項目コード
		public string itemnm { get; set; }                        //項目名
		public string? groupid { get; set; }                      //グループID
		public string? groupid2 { get; set; }                     //グループID2
		public int inputtype { get; set; }                        //入力タイプ
		public string? codejoken1 { get; set; }                   //コード条件1
		public string? codejoken2 { get; set; }                   //コード条件2
		public string? codejoken3 { get; set; }                   //コード条件3
		public string? keta { get; set; }                         //入力桁
		public bool hissuflg { get; set; }                        //必須フラグ
		public string? hanif { get; set; }                        //入力範囲（開始）
		public string? hanit { get; set; }                        //入力範囲（終了）
		public bool hyojiflg { get; set; }                        //表示フラグ
		public bool inputflg { get; set; }                        //入力フラグ
		public int msgkbn { get; set; }                           //メッセージ区分
		public string? tani { get; set; }                         //単位
		public string? syokiti { get; set; }                      //初期値
		public int orderseq { get; set; }                         //並びシーケンス
		public string? syukeikbn { get; set; }                    //利用地域保健集計区分
		public string? biko { get; set; }                         //備考
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
