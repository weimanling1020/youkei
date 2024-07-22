﻿// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: プレビュー処理
// 　　　　　　レスポンスインターフェースベース
// 作成日　　: 2024.07.09
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using Newtonsoft.Json;

namespace BCC.Affect.Service
{
    public class CmPreviewResponseBase : DaResponseBase
    {
        public string filenm { get; set; }                                          //ファイル名
        [JsonIgnore]
        public byte[] data { get; set; }                                            //データ
        public string contenttype { get; set; }                                     //コンテンツタイプ
    }
}