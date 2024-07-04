﻿// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　集団指導参加者（フリー項目）入力情報テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kksyudansido_sankasyafreeDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kksyudansido_sankasyafree";

        public tt_kksyudansido_sankasyafreeDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kksyudansido_sankasyafreeDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kksyudansido_sankasyafreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kksyudansido_sankasyafreeDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kksyudansido_sankasyafreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kksyudansido_sankasyafreeDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kksyudansido_sankasyafreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kksyudansido_sankasyafreeDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kksyudansido_sankasyafreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kksyudansido_sankasyafreeDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kksyudansido_sankasyafreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kksyudansido_sankasyafreeDto GetDtoByKey(string gyomukbn, int edano, string mosikomikekkakbn, string itemcd, string atenano)
        {
            return SELECT.WHERE.ByKey(gyomukbn, edano, mosikomikekkakbn, itemcd, atenano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string gyomukbn, int edano, string mosikomikekkakbn, string itemcd, string atenano)
        {
            //物理削除
            DELETE.WHERE.ByKey(gyomukbn, edano, mosikomikekkakbn, itemcd, atenano).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kksyudansido_sankasyafreeDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
