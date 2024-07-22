﻿// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 使用履歴
//             レスポンスインターフェース
// 作成日　　: 2024.07.15
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00202S
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public List<SiyorirekiVM> kekkalist { get; set; }    //使用履歴リスト
    }
}