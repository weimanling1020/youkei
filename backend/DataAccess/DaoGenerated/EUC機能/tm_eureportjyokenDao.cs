﻿// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　EUC帳票検索条件マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eureportjyokenDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_eureportjyoken";

        public tm_eureportjyokenDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_eureportjyokenDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_eureportjyokenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_eureportjyokenDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_eureportjyokenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_eureportjyokenDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_eureportjyokenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_eureportjyokenDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_eureportjyokenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_eureportjyokenDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_eureportjyokenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_eureportjyokenDto GetDtoByKey(int reportid, int groupid, int jyokenid)
        {
            return SELECT.WHERE.ByKey(reportid, groupid, jyokenid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int reportid, int groupid, int jyokenid, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(reportid, groupid, jyokenid).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_eureportjyokenDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
