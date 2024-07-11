/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 宛名検索履歴
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.03.17
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchRequest extends CmSearchRequestBase {
  /** 機能ID */
  kinoid: string
}
/** 保存処理 */
export interface SaveRequest extends DaRequestBase {
  /** 機能ID */
  kinoid: string
  /** 宛名番号 */
  atenano: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchResponse extends CmSearchResponseBase {
  /** 宛名番号 */
  kekkalist: SearchVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchVM {
  /** 宛名番号 */
  atenano: string
  /** 氏名 */
  name: string
  /** カナ氏名 */
  kname: string
  /** 生年月日 */
  bymd: string
  /** 性別 */
  sex: string
}
