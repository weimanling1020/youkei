﻿// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: データグループ新規作成
//             ビューモデル定義
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00102D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class TableVM
    {
        public string tablealias { get; set; }                 //テーブル·別名
        public string tablenm { get; set; }                    //テーブル物理名
        public string tablehyojinm { get; set; }               //テーブル名称
        public int orderseq { get; set; }                      //並びシーケンス
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class TableItemVM
    {
        public string sqlcolumn { get; set; }                 //SQLカラム
        public string itemid { get; set; }                    //項目ID
        public string itemhyojinm { get; set; }               //表示名称
        public string daibunrui { get; set; }                //大分類
        public string tyubunrui { get; set; }                //中分類
        public string syobunrui { get; set; }                //小分類
        public string tablealias { get; set; }               //テーブル·別名
    }
}