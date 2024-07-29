/** ----------------------------------------------------------------
 * 業務名称　: 互助防疫システム
 * 機能概要　: 契約者農場マスタメンテナンス
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.07.29
 * 作成者　　: 高 弘昆
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'
import { InitResponse, PreviewRequest } from './type'

const servicename = 'GJ1030'

/** 初期化処理(プレビュー画面) */
export const Init = (): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname)
}

/** プレビュー処理(プレビュー画面) */
export const Search = (params: PreviewRequest): Promise<DaResponseBase> => {
  const methodname = 'Preview'
  return api(servicename, methodname, params)
}
