/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 各種事業コード設定
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.01.26
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchResponse extends DaResponseBase {
  /** 設定対象一覧 */
  kekkalist: RowVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 行モデル */
export interface RowVM {
  /** 設定対象コード(キー) */
  cd: string
  /** 設定対象表示名称 */
  nm: string
  /** 集約コード名称(個人連絡先) */
  cdnm1: string
  /** 集約コード名称(メモ情報) */
  cdnm2: string
  /** 集約コード名称(電子ファイル情報) */
  cdnm3: string
  /** 集約コード名称(フォロー管理) */
  cdnm4: string
  /** 設定不要フラグ(個人連絡先) */
  flg1: boolean
  /** 設定不要フラグ(メモ情報) */
  flg2: boolean
  /** 設定不要フラグ(電子ファイル情報) */
  flg3: boolean
  /** 設定不要フラグ(フォロー管理) */
  flg4: boolean
}
