/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約者農場マスタメンテナンス
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.07.29
 * 作成者　　: 高 弘昆
 * 変更履歴　:
 * -----------------------------------------------------------------*/

import { CodeNameModel, DaRequestBase, DaResponseBase } from '@/typings/Base'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/**初期化処理(プレビュー画面) */
export interface InitRequest extends DaRequestBase {
  /**対象期 */
  KI: number
}

/**プレビュー処理(プレビュー画面) */
export interface PreviewRequest extends DaRequestBase {
  /**対象期 */
  KI: number
  /**対象日(現在) */
  TAISYOBI_YMD: string
  /**契約者区分コード */
  KeiyakuKbnCd?: {
    VALUE_FM?: number
    VALUE_TO?: number
  }
  /**契約状況 */
  KeiyakuJyokyo: {
    SHINKI: boolean
    KEIZOKU: boolean
    CHUSHI: boolean
    HAIGYO: boolean
  }
  /**事務委託先番号コード */
  ItakuCd?: {
    VALUE_FM?: number
    VALUE_TO?: number
  }
  /**契約者番号コード */
  KeiyakusyaCd?: {
    VALUE_FM?: number
    VALUE_TO?: number
  }
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/**初期化処理(プレビュー画面) */
export interface InitResponse extends DaResponseBase {
  /**対象期 */
  KI: number
  /**契約区分情報プルダウンリスト */
  KEIYAKU_KBN_CD_NAME_LIST: CodeNameModel[]
  /**事務委託先情報プルダウンリスト */
  ITAKU_CD_NAME_LIST: CodeNameModel[]
  /**契約者番号情報プルダウンリスト */
  KEIYAKUSYA_CD_NAME_LIST: CodeNameModel[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
