﻿// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　風しん抗体検査（フリー項目）テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_ysfusinkotaifreeDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_ysfusinkotaifree";

        public tt_ysfusinkotaifreeDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_ysfusinkotaifreeDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_ysfusinkotaifreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_ysfusinkotaifreeDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_ysfusinkotaifreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_ysfusinkotaifreeDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_ysfusinkotaifreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_ysfusinkotaifreeDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_ysfusinkotaifreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_ysfusinkotaifreeDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_ysfusinkotaifreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_ysfusinkotaifreeDto GetDtoByKey(string atenano, string itemcd)
        {
            return SELECT.WHERE.ByKey(atenano, itemcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, string itemcd)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, itemcd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_ysfusinkotaifreeDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
