/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ヘルプ
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.03.03
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** ダウンロード処理 */
export interface DownloadRequest extends DaRequestBase {
  /** 機能ID */
  kinoid: string
}
