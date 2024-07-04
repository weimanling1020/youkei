﻿// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ログイン
//             ビューモデル定義
// 作成日　　: 2022.12.12
// 作成者　　: 韓
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00101G
{
    /// <summary>
    /// ユーザー共通
    /// </summary>
    public class UserInfoVM
    {
        public string userid { get; set; }      //ユーザID
        public string usernm { get; set; }      //ユーザー名
        public string syozokunm { get; set; }   //所属名
        public bool kanrisyaflg { get; set; }   //管理者フラグ
        
    }
}