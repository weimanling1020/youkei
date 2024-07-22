﻿// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　事業従事者（担当者）サブマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afstaff_subDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_afstaff_sub";

        public tm_afstaff_subDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_afstaff_subDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_afstaff_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_afstaff_subDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_afstaff_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_afstaff_subDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_afstaff_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_afstaff_subDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_afstaff_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_afstaff_subDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_afstaff_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_afstaff_subDto GetDtoByKey(string staffid, string jissijigyo)
        {
            return SELECT.WHERE.ByKey(staffid, jissijigyo).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string staffid, string jissijigyo)
        {
            //物理削除
            DELETE.WHERE.ByKey(staffid, jissijigyo).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_afstaff_subDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
