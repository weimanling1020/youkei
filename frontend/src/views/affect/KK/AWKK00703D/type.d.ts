/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 取込設定.エラー一覧(行のエラー明細）
 * 　　　　　  リクエストインターフェース
 * 作成日　　: 2023.10.10
 * 作成者　　: 韋
 * 変更履歴　:
 * -----------------------------------------------------------------*/

/** アップロード処理 */
export interface InitListRequest extends DaRequestBase {
  /** 取込実行ID */
  impexeid: number
  /** 行番号 */
  rowno: number
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期処理 */
export interface InitListResponse extends DaResponseBase {
  /** 行番号 */
  rowno: number
  /** 宛名番号 */
  atenano?: string
  /** 氏名 */
  shimei?: string
  /** 取込データエラー情報リスト */
  kimpErrList: KimpErrRowVM[]
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 取込データエラー情報モデル(エラー一覧(行のエラー明細）) */
export interface KimpErrRowVM {
  /** 項目名 */
  itemnm?: string
  /** 項目値 */
  val?: string
  /** メッセージ(エラー内容) */
  msg?: string
}
