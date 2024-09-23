/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 生産者積立金返還金計算処理
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.09.23
 * 作成者　　: 阎格
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'

import { InitRequest, PreviewRequest } from './type'

const servicename = 'GJ6010'

/** 初期化処理(プレビュー画面) */
export const Init = (params: InitRequest): Promise<PreviewRequest> => {
  const methodname = 'Init'
  return api(servicename, methodname, params, undefined, { loading: true })
}

/** プレビュー処理(プレビュー画面) */
export const Preview = (params: PreviewRequest): Promise<DaResponseBase> => {
  const methodname = 'Preview'
  return api(servicename, methodname, params)
}
