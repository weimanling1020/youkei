﻿// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　トークンテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_aftokenDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_aftoken";

        public tt_aftokenDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_aftokenDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_aftokenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_aftokenDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_aftokenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_aftokenDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_aftokenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_aftokenDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_aftokenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_aftokenDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_aftokenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_aftokenDto GetDtoByKey(long tokenseq)
        {
            return SELECT.WHERE.ByKey(tokenseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long tokenseq)
        {
            //物理削除
            DELETE.WHERE.ByKey(tokenseq).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_aftokenDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
