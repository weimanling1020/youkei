//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

export interface ListRowVM {
  /**契約者番号 */
  KEIYAKUSYA_CD: number
  /**契約者名 */
  KEIYAKUSYA_NAME: string
  /**フリガナ */
  KEIYAKUSYA_KANA: string
  /**契約区分 */
  KEIYAKU_KBN: string
  /**契約状況 */
  KEIYAKU_JYOKYO: string
  /**電話番号 */
  ADDR_TEL: string
  /**都道府県 */
  KEN_CD: string
  /**事務委託先 */
  JIMUITAKU_CD1: string
}

export interface DetailRowVM {
  /**明細番号 */
  MEISAI_NO: number
  /**農場名 */
  NOJO_NAME: string
  /**農場住所 */
  NOJO_ADDR: string
  /**鳥の種類 */
  TORISYURUI: string
  /**契約羽数 */
  KEIYAKUHASU: string
  /**備考 */
  BIKO: string
}
