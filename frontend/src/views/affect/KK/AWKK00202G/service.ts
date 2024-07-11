/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 会場保守
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.11.09
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  InitListResponse,
  SearchListResponse,
  SearchListRequest,
  InitDetailResponse,
  SearchDetailResponse,
  SearchDetailRequest,
  SaveRequest
} from './type'
const servicename = 'AWKK00202G'

/** 初期化処理(一覧画面) */
export const InitList = (): Promise<InitListResponse> => {
  const methodname = 'InitList'
  return api(servicename, methodname, {})
}

/** 検索処理(一覧画面) */
export const SearchList = (params: SearchListRequest): Promise<SearchListResponse> => {
  const methodname = 'SearchList'
  return api(servicename, methodname, params)
}

/** 初期化処理(詳細画面) */
export const InitDetail = (): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, {})
}

/** 検索処理(詳細画面) */
export const SearchDetail = (params: SearchDetailRequest): Promise<SearchDetailResponse> => {
  const methodname = 'SearchDetail'
  return api(servicename, methodname, params)
}

/** 保存処理 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}
