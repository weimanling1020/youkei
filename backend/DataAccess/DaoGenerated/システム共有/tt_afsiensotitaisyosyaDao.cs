﻿// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　【住民基本台帳】支援措置対象者情報テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afsiensotitaisyosyaDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afsiensotitaisyosya";

        public tt_afsiensotitaisyosyaDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afsiensotitaisyosyaDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afsiensotitaisyosyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afsiensotitaisyosyaDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afsiensotitaisyosyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afsiensotitaisyosyaDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afsiensotitaisyosyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afsiensotitaisyosyaDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afsiensotitaisyosyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afsiensotitaisyosyaDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afsiensotitaisyosyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afsiensotitaisyosyaDto GetDtoByKey(string atenano)
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
        public void UpdateDto(tt_afsiensotitaisyosyaDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
