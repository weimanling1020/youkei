﻿// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　ファイルマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_affileDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_affile";

        public tm_affileDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_affileDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_affileDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_affileDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_affileDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_affileDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_affileDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_affileDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_affileDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_affileDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_affileDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_affileDto GetDtoByKey(string siyokbn)
        {
            return SELECT.WHERE.ByKey(siyokbn).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string siyokbn)
        {
            //物理削除
            DELETE.WHERE.ByKey(siyokbn).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_affileDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
