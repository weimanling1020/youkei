﻿// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             対象者抽出情報項目コントロールマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktaisyosya_tyusyutufreeitemDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_kktaisyosya_tyusyutufreeitem";
		public string tyusyututaisyocd { get; set; }              //抽出対象コード
		public string itemkanrikbn { get; set; }                  //項目管理区分
		public string itemcd { get; set; }                        //項目コード
		public string itemnm { get; set; }                        //項目名
		public string tyusyutujyokenkbn { get; set; }             //抽出条件区分
		public string itemkbn { get; set; }                       //項目区分
		public int inputtype { get; set; }                        //入力タイプ
		public string? codejoken1 { get; set; }                   //コード条件1
		public string? codejoken2 { get; set; }                   //コード条件2
		public string? codejoken3 { get; set; }                   //コード条件3
		public string? keta { get; set; }                         //入力桁
		public bool hissuflg { get; set; }                        //必須フラグ
		public string? hanif { get; set; }                        //入力範囲（開始）
		public string? hanit { get; set; }                        //入力範囲（終了）
		public bool inputflg { get; set; }                        //入力フラグ
		public int msgkbn { get; set; }                           //メッセージ区分
		public string? tani { get; set; }                         //単位
		public int orderseq { get; set; }                         //並びシーケンス
		public string? biko { get; set; }                         //備考
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
