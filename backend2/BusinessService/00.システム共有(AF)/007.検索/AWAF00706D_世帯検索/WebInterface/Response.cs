﻿// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 世帯検索
// 　　　　　　レスポンスインターフェースベース
// 作成日　　: 2023.11.24
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00706D
{
    public class SearchResponse : CmSearchResponseBase
    {
        public List<SearchVM> kekkalist { get; set; }     //世帯情報
    }
}