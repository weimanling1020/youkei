/** ----------------------------------------------------------------
 * 業務名称　: 互助防疫システム
 * 機能概要　: 契約者農場マスタメンテナンス
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.07.24
 * 作成者　　: 高 弘昆
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api, api2 } from '@/service/request/common-service'

import {
  DeleteRequest,
  InitDetailResponse,
  InitResponse,
  SaveRequest,
  SearchDetailRequest,
  SearchDetailResponse,
  SearchRequest,
  SearchResponse,
} from './type'

const servicename = 'GJ8090'
const servicename2 = 'GJ8091'

/** 初期化処理(一覧画面) */
export const Init = (): Promise<InitResponse> => {
  const methodname = 'Init'
  return api2(servicename, methodname)
}

/** 検索処理(一覧画面) */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api2(servicename, methodname, params, undefined, { loading: true })
}

/** 削除処理(一覧画面) */
export const Delete = (params: DeleteRequest): Promise<DaResponseBase> => {
  const methodname = 'Search'
  return api(servicename, methodname, params)
}

/** 初期化処理(詳細画面) */
export const InitDetail = (): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api2(servicename2, methodname)
}

/** 検索処理(詳細画面) */
export const SearchDetail = (
  params: SearchDetailRequest
): Promise<SearchDetailResponse> => {
  const methodname = 'SearchDetail'
  return api2(servicename2, methodname, params)
}

/** 保存処理(詳細画面) */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename2, methodname, params)
}
