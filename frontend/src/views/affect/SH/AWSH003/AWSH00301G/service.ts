/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 健（検）診対象者設定
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.01.31
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { InitResponse, SearchResponse, SearchRequest, SaveRequest } from './type'
const servicename = 'AWSH00301G'

/** 初期化処理 */
export const Init = (): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, {})
}

/** 検索処理 */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params)
}

/** 保存処理 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}

/** バッチ実行処理 */
export const DoBatch = (params: SearchRequest): Promise<DaResponseBase> => {
  const methodname = 'DoBatch'
  return api(servicename, methodname, params)
}
