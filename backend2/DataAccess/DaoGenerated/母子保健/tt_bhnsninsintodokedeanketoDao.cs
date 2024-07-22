﻿// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　妊娠届出アンケート（固定）テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnsninsintodokedeanketoDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_bhnsninsintodokedeanketo";

        public tt_bhnsninsintodokedeanketoDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_bhnsninsintodokedeanketoDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_bhnsninsintodokedeanketoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_bhnsninsintodokedeanketoDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_bhnsninsintodokedeanketoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_bhnsninsintodokedeanketoDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_bhnsninsintodokedeanketoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_bhnsninsintodokedeanketoDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_bhnsninsintodokedeanketoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_bhnsninsintodokedeanketoDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_bhnsninsintodokedeanketoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_bhnsninsintodokedeanketoDto GetDtoByKey(string atenano, long torokuno)
        {
            return SELECT.WHERE.ByKey(atenano, torokuno).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, long torokuno, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, torokuno).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_bhnsninsintodokedeanketoDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
