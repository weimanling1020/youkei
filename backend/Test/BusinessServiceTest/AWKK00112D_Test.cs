﻿namespace BCC.Affect.Service.AWKK00112D
{
    [TestClass]
    public class AWKK00112D_Test
    {
        private readonly Service _service = new();

        [TestMethod]
        //住登外者情報履歴照会テスト用
        public void SearchListTest()
        {
            var req = new SearchRequest
            {
                userid = "0000000003",                          //ユーザーID
                atenano = "800000000000009",                    //宛名番号
            };

            var res = _service.Search(req);

            var str = res.ToString();
        }

    }
}