﻿// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　町字マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_aftyoazaDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_aftyoaza";

        public tm_aftyoazaDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_aftyoazaDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_aftyoazaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_aftyoazaDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_aftyoazaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_aftyoazaDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_aftyoazaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_aftyoazaDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_aftyoazaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_aftyoazaDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_aftyoazaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_aftyoazaDto GetDtoByKey(string sikucd, string tyoazaid)
        {
            return SELECT.WHERE.ByKey(sikucd, tyoazaid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string sikucd, string tyoazaid, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(sikucd, tyoazaid).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_aftyoazaDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
