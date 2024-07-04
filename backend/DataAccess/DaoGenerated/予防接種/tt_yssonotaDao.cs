﻿// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　予防接種その他テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_yssonotaDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_yssonota";

        public tt_yssonotaDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_yssonotaDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_yssonotaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_yssonotaDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_yssonotaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_yssonotaDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_yssonotaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_yssonotaDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_yssonotaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_yssonotaDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_yssonotaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_yssonotaDto GetDtoByKey(string atenano)
        {
            return SELECT.WHERE.ByKey(atenano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_yssonotaDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
