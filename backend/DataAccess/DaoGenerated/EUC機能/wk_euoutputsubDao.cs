﻿// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　workテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class wk_euoutputsubDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "wk_euoutputsub";

        public wk_euoutputsubDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<wk_euoutputsubDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<wk_euoutputsubDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<wk_euoutputsubDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<wk_euoutputsubDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<wk_euoutputsubDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<wk_euoutputsubDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<wk_euoutputsubDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<wk_euoutputsubDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<wk_euoutputsubDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<wk_euoutputsubDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public wk_euoutputsubDto GetDtoByKey(long workseq, string atenano)
        {
            return SELECT.WHERE.ByKey(workseq, atenano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long workseq, string atenano)
        {
            //物理削除
            DELETE.WHERE.ByKey(workseq, atenano).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(wk_euoutputsubDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
