import { Enum様式作成方法, Enum検索条件区分, Enumコントロール, EnumDataType } from '#/Enums'

export const specialItems = [
  {
    label: '基準日',
    jyokenlabel: '基準日',
    controlkbn: Enumコントロール.日付入力,
    selectlist: [],
    hissuflg: false,
    datatype: EnumDataType.日付,
    value: '',
    sql: '',
    tableid: '',
    itemnm: '',
    daibunrui: '',
    itemid: '',
    tablealias: '',
    nendohanikbn: '',
    nendo: '',
    jyokenseq: 0,
    datasourceid: '-1',
    sqlcolumn: '',
    jyokenid: -1,
    jyokenkbn: String(Enum検索条件区分.通常条件),
    orderseq: 1000
  },
  {
    label: '発行日',
    jyokenlabel: '発行日',
    controlkbn: Enumコントロール.日付入力,
    selectlist: [],
    hissuflg: false,
    datatype: EnumDataType.日付,
    value: '',
    sql: '',
    tableid: '',
    itemnm: '',
    daibunrui: '',
    itemid: '',
    tablealias: '',
    nendohanikbn: '',
    syokiti: 'today',
    nendo: '',
    jyokenseq: 0,
    datasourceid: '-4',
    sqlcolumn: '',
    jyokenid: -4,
    jyokenkbn: String(Enum検索条件区分.通常条件),
    orderseq: 1001
  },
  {
    label: '送付先利用目的',
    jyokenlabel: '送付先利用目的',
    controlkbn: Enumコントロール.選択,
    selectlist: [],
    hissuflg: false,
    datatype: EnumDataType.文字列,
    value: '',
    tableid: '',
    sql: 'tt_afsofusaki.riyomokuteki = ＠送付先利用目的',
    itemnm: 'tt_afsofusaki.riyomokuteki',
    mastercd: '121',
    masterpara: '3019,100005',
    daibunrui: '',
    itemid: '001_tokusyu_riyomokuteki_003',
    tablealias: 'tt_afsofusaki',
    nendohanikbn: '',
    nendo: '',
    jyokenseq: 0,
    datasourceid: '-5',
    sqlcolumn: '',
    jyokenid: -5,
    jyokenkbn: String(Enum検索条件区分.通常条件),
    variables: '001_tokusyu_riyomokuteki_003',
    orderseq: 1002
  }
]
