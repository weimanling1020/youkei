﻿// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 登録処理
// 　　　　　　リクエストインターフェースベース
// 作成日　　: 2024.04.08
// 作成者　　: 魏
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service
{
    public class CmSaveRequestBase : DaRequestBase
    {
        public bool checkflg { get; set; } = false;         //チェックフラグ
    }
}