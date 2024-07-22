﻿// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票出力(帳票出力設定)
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWEU00303D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// バッチ処理
        /// </summary>
        public static tm_aftaskscheduleDto GetTaskScheduleDto(string taskId, string hangfireJobId, DateTime jpExecutionTime)
        {
            var dto = new tm_aftaskscheduleDto();
            dto.taskid = taskId;                                    //タスクID
            dto.tasknm = "帳票出力バッチ処理";                      //todo タスク名
            dto.renkeiid = hangfireJobId;                           //HangFire連携ID
            dto.biko = "帳票出力バッチ処理";                        //todo 説明
            dto.zenjikkodttmf = null;                               //前回の実行日時（開始）
            dto.zenjikkodttmt = null;                               //前回の実行日時（終了）
            dto.jikaijikkodttmt = jpExecutionTime;                  //次回実行日時
            dto.syorikbn = "1";                                     //todo 処理区分
            dto.gyomukbn = "1";                                     //業務区分
            dto.modulecd = "4";                                     //モジュールコード
            dto.hikisu = null;                                      //引数
            dto.yukoymdf = jpExecutionTime.ToString("yyyy-MM-dd");  //有効年月日（開始）
            dto.yukotmf = jpExecutionTime.ToString("HHmm");         //有効時間（開始）
            dto.hindokbn = "0";                                     //頻度区分
            dto.syukustopflg = false;                               //祝日停止フラグ
            dto.yobi = null;                                        //曜日
            dto.maitukihiyobikbn = null;                            //毎月の日・曜日区分
            dto.maitukituki = null;                                 //毎月の月
            dto.maitukihi = null;                                   //毎月の日
            dto.maitukisyu = null;                                  //毎月の週
            dto.statuscd = null;                                    //処理結果コード
            dto.kurikaesikanflg = false;                            //繰り返し間隔フラグ
            dto.kurikaesikankbn = null;                             //繰り返し間隔区分
            dto.jikantaif = null;                                   //時間帯開始_時
            dto.jikantait = null;                                   //時間帯終了_時
            dto.jikannaif = null;                                   //時間内開始_分
            dto.jikannait = null;                                   //時間内終了_分
            dto.stopflg = false;                                    //使用停止フラグ
            return dto;
        }
    }
}