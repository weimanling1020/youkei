﻿// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　対象者抽出情報項目コントロールマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktaisyosya_tyusyutufreeitemDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_kktaisyosya_tyusyutufreeitem";

        public tm_kktaisyosya_tyusyutufreeitemDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_kktaisyosya_tyusyutufreeitemDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_kktaisyosya_tyusyutufreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_kktaisyosya_tyusyutufreeitemDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_kktaisyosya_tyusyutufreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_kktaisyosya_tyusyutufreeitemDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_kktaisyosya_tyusyutufreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_kktaisyosya_tyusyutufreeitemDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_kktaisyosya_tyusyutufreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_kktaisyosya_tyusyutufreeitemDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_kktaisyosya_tyusyutufreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_kktaisyosya_tyusyutufreeitemDto GetDtoByKey(string tyusyututaisyocd, string itemkanrikbn, string itemcd)
        {
            return SELECT.WHERE.ByKey(tyusyututaisyocd, itemkanrikbn, itemcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string tyusyututaisyocd, string itemkanrikbn, string itemcd, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(tyusyututaisyocd, itemkanrikbn, itemcd).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_kktaisyosya_tyusyutufreeitemDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
