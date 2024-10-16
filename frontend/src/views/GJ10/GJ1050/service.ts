/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 事務委託先別·: 契約者別生產者積立金等一覧表
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.08.30
 * 作成者　　: wx
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'
import { InitRequest, InitResponse, PreviewRequest } from './type'

const servicename = 'GJ1050'
/** 初期化処理_プレビュー画面 */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, params, undefined, { loading: true })
}

/** プレビュー処理_プレビュー画面 */
export const Preview = (params: PreviewRequest): Promise<DaResponseBase> => {
  const methodName = 'Preview'
  return api(servicename, methodName, params)
}
