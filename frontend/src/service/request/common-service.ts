/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: ベースロジック
 * 　　　　　  API定義
 * 作成日　　: 2023.03.03
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { AxiosRequestHeaders } from 'axios'
import { request, downloadReq } from './index'

/** ログイン処理 */
export async function login(
  SERVICE_NAME: string,
  METHOD_NAME: string,
  data: any
): Promise<any> {
  const body = {
    SERVICE_NAME,
    METHOD_NAME,
    BIZ_REQUEST: {
      DATA: JSON.stringify(data),
    },
  }
  return request({
    url: '/GJS/Login',
    method: 'post',
    data: body,
  })
}

/** Web共通 */
export function api(
  SERVICE_NAME: string,
  METHOD_NAME: string,
  data?: any,
  headers?: AxiosRequestHeaders,
  extra?: Api.Common.RequestConfigExtra
): Promise<any> {
  const body = {
    SERVICE_NAME,
    METHOD_NAME,
    BIZ_REQUEST: {
      DATA: JSON.stringify(data) || '',
    },
  }
  return request({
    url: '/GJS/WebRequest',
    method: 'post',
    data: body,
    headers,
    extra,
  })
}

/** Web共通 */
export function papi(
  SERVICE_NAME: string,
  METHOD_NAME: string,
  data?: any,
  headers?: AxiosRequestHeaders,
  extra?: Api.Common.RequestConfigExtra
): Promise<any> {
  const body = {
    SERVICE_NAME,
    METHOD_NAME,
    BIZ_REQUEST: {
      DATA: JSON.stringify(data) || '',
    },
  }
  return request({
    url: '/GJS/Preview',
    method: 'post',
    data: body,
    headers,
    extra,
  })
}

/** Web共通モック */
export function api2(
  SERVICE_NAME: string,
  METHOD_NAME: string,
  data?: any,
  headers?: AxiosRequestHeaders,
  extra?: Api.Common.RequestConfigExtra
): Promise<any> {
  const body = {
    SERVICE_NAME,
    METHOD_NAME,
    BIZ_REQUEST: {
      DATA: JSON.stringify(data) || '',
    },
  }
  return request({
    url: '/youkei/WebRequest/' + SERVICE_NAME + '/' + METHOD_NAME,
    method: 'post',
    data: body,
    headers,
    extra,
  })
}

// /** プレビュー処理 */
// export function preview(
//   servicename: string,
//   methodname: string,
//   data?: unknown,
//   headers?: RawAxiosRequestHeaders & { loading?: boolean }
// ): Promise<any> {
//   const params = {
//     signal: controller.signal,
//     servicename,
//     methodname,
//     bizrequest: {
//       data: JSON.stringify(data) || '',
//     },
//   }

//   return http.preview({
//     url: '/AFCT/Preview',
//     method: RequestEnum.POST,
//     params,
//     headers,
//   })
// }

/** ダウンロード処理 */
export function download(
  SERVICE_NAME: string,
  METHOD_NAME: string,
  data?: any,
  headers?: AxiosRequestHeaders,
  extra?: Api.Common.RequestConfigExtra
): Promise<any> {
  const body = {
    SERVICE_NAME,
    METHOD_NAME,
    BIZ_REQUEST: {
      DATA: JSON.stringify(data) || '',
    },
  }
  return downloadReq({
    url: '/GJS/WebRequest',
    method: 'post',
    data: body,
    headers,
    extra,
  })
}

// /** アップロード処理 */
// export function upload(
//   servicename: string,
//   methodname: string,
//   data: any,
//   headers?: RawAxiosRequestHeaders & { loading?: boolean }
// ): Promise<any> {
//   const formData = new FormData()
//   const { files, ...obj } = data

//   formData.append('servicename', servicename)
//   formData.append('methodname', methodname)
//   if (obj.filerequired !== undefined)
//     formData.append('filerequired', obj.filerequired)
//   formData.append(
//     'bizrequest.data',
//     JSON.stringify(files.length === 0 ? data : obj)
//   )
//   for (const file of files) {
//     formData.append('files', file)
//   }

//   return http.request({
//     url: '/AFCT/Upload',
//     method: RequestEnum.POST,
//     params: formData,
//     headers: { ...headers, 'Content-Type': ContentTypeEnum.FORM_DATA },
//   })
// }

// /** アップロード ダウンロード処理 */
// export function uploadDownload(
//   servicename: string,
//   methodname: string,
//   data: any,
//   headers?: RawAxiosRequestHeaders & { loading?: boolean }
// ): Promise<any> {
//   const formData = new FormData()
//   const { files, ...obj } = data

//   formData.append('servicename', servicename)
//   formData.append('methodname', methodname)
//   if (obj.filerequired !== undefined)
//     formData.append('filerequired', obj.filerequired)
//   formData.append(
//     'bizrequest.data',
//     JSON.stringify(files.length === 0 ? data : obj)
//   )
//   for (const file of files) {
//     formData.append('files', file)
//   }

//   return http.download({
//     url: '/AFCT/Download/UploadDownload',
//     method: RequestEnum.POST,
//     params: formData,
//     headers: { ...headers, 'Content-Type': ContentTypeEnum.FORM_DATA },
//   })
// }
