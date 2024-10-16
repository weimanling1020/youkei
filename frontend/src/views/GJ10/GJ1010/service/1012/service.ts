/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　:互助基金契約者マスタ
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.08.27
 * 作成者　　:魏星
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'
import {
  CopyRequest,
  DeleteRequest,
  InitNojoRequest,
  InitNojoResponse,
  SaveRequest,
  SearchRequest,
  SearchResponse,
} from './type'

const servicename = 'GJ1012'

/** 検索処理_詳細画面 */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params, undefined, { loading: true })
}

/** 初期化処理_詳細画面*/
export const InitNojo = (
  params: InitNojoRequest
): Promise<InitNojoResponse> => {
  const methodname = 'InitNojo'
  return api(servicename, methodname, params)
}

/** 前期データコピー処理_詳細画面Copy*/
export const Copy = (params: CopyRequest): Promise<DaResponseBase> => {
  const methodname = 'Copy'
  return api(servicename, methodname, params)
}

/** 保存処理_詳細画面 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}

/** 削除処理_詳細画面 */
export const Delete = (params: DeleteRequest): Promise<DaResponseBase> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}
