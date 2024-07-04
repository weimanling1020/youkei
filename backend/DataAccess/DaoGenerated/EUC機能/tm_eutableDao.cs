﻿// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　EUCテーブルマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eutableDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_eutable";

        public tm_eutableDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_eutableDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_eutableDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_eutableDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_eutableDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_eutableDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_eutableDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_eutableDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_eutableDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_eutableDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_eutableDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_eutableDto GetDtoByKey(string tablealias)
        {
            return SELECT.WHERE.ByKey(tablealias).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string tablealias)
        {
            //物理削除
            DELETE.WHERE.ByKey(tablealias).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_eutableDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
