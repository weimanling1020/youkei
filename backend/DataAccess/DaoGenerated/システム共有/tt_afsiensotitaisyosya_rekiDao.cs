﻿// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　【住民基本台帳】支援措置対象者情報履歴テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afsiensotitaisyosya_rekiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afsiensotitaisyosya_reki";

        public tt_afsiensotitaisyosya_rekiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afsiensotitaisyosya_rekiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afsiensotitaisyosya_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afsiensotitaisyosya_rekiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afsiensotitaisyosya_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afsiensotitaisyosya_rekiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afsiensotitaisyosya_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afsiensotitaisyosya_rekiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afsiensotitaisyosya_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afsiensotitaisyosya_rekiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afsiensotitaisyosya_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afsiensotitaisyosya_rekiDto GetDtoByKey(string atenano, int rirekino, string siensotiymdf)
        {
            return SELECT.WHERE.ByKey(atenano, rirekino, siensotiymdf).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, int rirekino, string siensotiymdf, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, rirekino, siensotiymdf).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afsiensotitaisyosya_rekiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
