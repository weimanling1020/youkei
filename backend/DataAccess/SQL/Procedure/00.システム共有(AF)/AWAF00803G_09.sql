﻿/*******************************************************************
業務名称　: 健康管理システム
機能概要　: ログ情報管理(ログ通信)
　　　　　　CSV出力
作成日　　: 2023.11.21
作成者　　: 劉
変更履歴　:
*******************************************************************/
create or replace function sp_awaf00803g_09(logkbn_in integer, status_in character varying, 
											syoridttmf_in character varying, syoridttmt_in character varying, 
											service_in character varying, method_in character varying, 
											user_in character varying,
											atenano_in character varying, personalno_in character varying, 
											pnokbn_in boolean)
 returns table
 (セッションシーケンス bigint,
  "処理日時（開始）" text,
  "処理日時（終了）" text,
  処理時間 integer,
  処理結果コード text,
  "機能ID" character varying,
  サービス名 character varying,
  メソッド character varying,
  メソッド名 character varying,
  "登録ユーザーID" character varying,
  登録日時 text,
  通信_通信ログシーケンス bigint,
  通信_セッションシーケンス bigint,
  "通信_処理日時（開始）" text,
  "通信_処理日時（終了）" text,
  通信_メッセージ character varying,
  通信_リクエスト character varying,
  通信_レスポンス character varying,
  "通信_IPアドレス" character varying,
  "通信_OS" character varying,
  通信_ブラウザー情報 character varying,
  "通信_登録ユーザーID" character varying,
  通信_登録日時 text)
 language plpgsql
as $function$
declare
    syoridttmf_in2 timestamp without time zone;
    syoridttmt_in2 timestamp without time zone;
begin
    syoridttmf_in2 := to_timestamp(syoridttmf_in, 'YYYY-MM-DD HH24:MI:SS');
    syoridttmt_in2 := to_timestamp(syoridttmt_in, 'YYYY-MM-DD HH24:MI:SS');
    return query
    select 
		t.seq1 as セッションシーケンス
		,to_char(t.syoridttmf1, 'YYYY/MM/DD HH24:MI:SS') as "処理日時（開始）"
		,to_char(t.syoridttmt1, 'YYYY/MM/DD HH24:MI:SS') as "処理日時（終了）"
		,t.syoritime as 処理時間
		,t.statuscd || ' : ' || t.statusnm as 処理結果コード
		,t.kinoid as "機能ID"
		,t.servicenm as サービス名
        ,t.method as メソッド
		,t.methodnm as メソッド名
		,t.reguserid1 as "登録ユーザーID"
	    ,to_char(t.regdttm1, 'YYYY/MM/DD HH24:MI:SS') as 登録日時
        ,t.tusinlogseq as 通信_通信ログシーケンス
        ,t.seq2 as 通信_セッションシーケンス
        ,to_char(t.syoridttmf2, 'YYYY/MM/DD HH24:MI:SS') as "通信_処理日時（開始）"
		,to_char(t.syoridttmt2, 'YYYY/MM/DD HH24:MI:SS') as "通信_処理日時（終了）"
        ,t.msg as 通信_メッセージ
        ,t.request as 通信_リクエスト
        ,t.response as 通信_レスポンス
        ,t.ipadrs as "通信_IPアドレス"
        ,t.os as "通信_OS"
        ,t.browser as 通信_ブラウザー情報
	    ,t.reguserid2 as "通信_登録ユーザーID"
        ,to_char(t.regdttm2, 'YYYY/MM/DD HH24:MI:SS') as 通信_登録日時
    from (
        select
            t0.sessionseq as seq1           --セッションシーケンス
            ,t0.syoridttmf as syoridttmf1   --処理日時（開始）
	    	,t0.syoridttmt as syoridttmt1	--処理日時（終了）
	    	,t0.milisec as syoritime	    --処理時間
            ,t0.statuscd				    --処理結果コード
            ,m1.nm statusnm                 --処理結果名称
	    	,t0.kinoid				    --機能ID
	    	,t0.service as servicenm	    --サービス名
	    	,t0.method					    --メソッド
	    	,t0.methodnm				    --メソッド名
	    	,t0.reguserid as reguserid1		--登録ユーザーID
	    	,t0.regdttm as regdttm1			--登録日時
	    	,t9.tusinlogseq				    --通信ログシーケンス
            ,t9.sessionseq as seq2          --セッションシーケンス
            ,t9.syoridttmf as syoridttmf2	--処理日時（開始）
	    	,t9.syoridttmt as syoridttmt2	--処理日時（終了）
            ,t9.msg                         --メッセージ
            ,t9.request                     --リクエスト
            ,t9.response                    --レスポンス
            ,t9.ipadrs                      --IPアドレス
            ,t9.os                          --OS
            ,t9.browser                     --ブラウザー情報
	    	,t9.reguserid as reguserid2		--登録ユーザーID
	    	,t9.regdttm as regdttm2			--登録日時
        from 
            tt_aflog t0                     --メインログテーブル
        left join 
            (select sessionseq, true as existflg 
	    		from tt_aftusinlog					--通信ログテーブル
	    		group by sessionseq) t1 
	    		on t0.sessionseq = t1.sessionseq 
        left join 
            (select sessionseq, true as existflg 
	    		from tt_afbatchlog 
	    		group by sessionseq) t2				--バッチログテーブル
	    		on t0.sessionseq = t2.sessionseq
        left join 
            (select sessionseq, true as existflg 
	    		from tt_afgaibulog 
	    		group by sessionseq) t3				--外部連携処理結果履歴テーブル
	    		on t0.sessionseq = t3.sessionseq
        left join 
            (select sessionseq, true as existflg 
	    		from tt_aflogdb 
	    		group by sessionseq) t4				--DB操作ログテーブル
	    		on t0.sessionseq = t4.sessionseq
        left join 
            (select sessionseq, true as existflg 
	    		from tt_aflogcolumn 
	    		group by sessionseq) t5				--テーブル項目値変更ログテーブル
	    		on t0.sessionseq = t5.sessionseq
        left join 
            (select sessionseq, true as existflg
	    		from tt_aflogatena 
	    		group by sessionseq) t6				--宛名番号ログテーブル
	    		on t0.sessionseq = t6.sessionseq
        left join 
            (select sessionseq, atenano
			    from tt_aflogatena) t7				--宛名番号ログテーブル
			    on t0.sessionseq = t7.sessionseq
        left join
            (select atenano, personalno
			    from tt_afatena) t8                 --宛名テーブル
            on t7.atenano = t8.atenano
        left join
            (select nmcd, nm 
                from tm_afmeisyo  
                where nmmaincd = '1000'
                and nmsubcd = 12) m1                --名称マスタ
                on t0.statuscd = m1.nmcd
        inner join tt_aftusinlog t9                 --通信ログテーブル
            on t0.sessionseq = t9.sessionseq
        where 
            (logkbn_in is null or
             (logkbn_in = 1 and t1.existflg = true) or
             (logkbn_in = 2 and t2.existflg = true) or
             (logkbn_in = 3 and t3.existflg = true) or
             (logkbn_in = 4 and t4.existflg = true) or
             (logkbn_in = 5 and t5.existflg = true) or
             (logkbn_in = 6 and t6.existflg = true))									    --ログ区分
            and (status_in is null or t0.statuscd = status_in)							    --処理結果
            and (syoridttmf_in is null or t0.syoridttmf >= syoridttmf_in2)				    --処理日時（開始）
            and (syoridttmt_in is null or t0.syoridttmt <= syoridttmt_in2)				    --処理日時（終了）
            and (service_in is null or t0.kinoid = service_in)						    --機能
            and (method_in is null or t0.method = method_in)							    --処理
            and (user_in is null or t0.reguserid = user_in)								    --登録者
            and (atenano_in is null or (t6.existflg = true and t7.atenano = atenano_in))    --宛名番号
		    and (personalno_in is null or 
			    (t6.existflg = true and t8.personalno = personalno_in))                     --個人番号
            and (pnokbn_in = false or (pnokbn_in = true and t6.existflg = true))		    --個人番号操作区分
            and (t0.kinoid != 'AWAF00803G')
    ) t
    order by t.seq1 desc;     --セッションシーケンス		降順
end;
$function$