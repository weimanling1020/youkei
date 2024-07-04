/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 事業コード管理
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.01.26
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitRequest extends DaRequestBase {
  /** 設定対象コード(キー) */
  cd: string
}
/** 保存処理 */
export interface SaveRequest extends InitRequest {
  /** 集約コード情報 */
  detailinfo: SaveVM
  /** 更新日時(排他用：個人連絡先) */
  upddttm1?: Date | string
  /** 更新日時(排他用：メモ情報) */
  upddttm2?: Date | string
  /** 更新日時(排他用：電子ファイル情報) */
  upddttm3?: Date | string
  /** 更新日時(排他用：フォロー管理) */
  upddttm4?: Date | string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /** 設定対象表示名称 */
  nm: string
  /** 集約コード情報 */
  detailinfo: SaveVM
  /** 集約コード一覧 */
  selectorlist: DaSelectorModel[]
  /** 更新日時(排他用：個人連絡先) */
  upddttm1?: Date | string
  /** 更新日時(排他用：メモ情報) */
  upddttm2?: Date | string
  /** 更新日時(排他用：電子ファイル情報) */
  upddttm3?: Date | string
  /** 更新日時(排他用：フォロー管理) */
  upddttm4?: Date | string
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 集約コード情報 */
export interface SaveVM {
  /** 個人連絡先集約コード(コード：名称) */
  cdnm1: string
  /** 集約コードリスト(メモ情報) */
  cdnmlist2: string[]
  /** 集約コードリスト(電子ファイル情報) */
  cdnmlist3: string[]
  /** 集約コードリスト(フォロー管理) */
  cdnmlist4: string[]
  /** 設定不要フラグ(個人連絡先) */
  flg1: boolean
  /** 設定不要フラグ(メモ情報) */
  flg2: boolean
  /** 設定不要フラグ(電子ファイル情報) */
  flg3: boolean
  /** 設定不要フラグ(フォロー管理) */
  flg4: boolean
}
