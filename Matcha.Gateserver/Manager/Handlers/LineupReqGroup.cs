namespace Matcha.Gateserver.Manager.Handlers
{
    using Matcha.Gateserver.Manager.Handlers.Core;
    using Matcha.Gateserver.Network;
    using Matcha.Proto;

    internal static class LineupReqGroup
    {
        public static uint Avatar1 = 1222; // Lingsha
        public static uint Avatar2 = 8001; // Caelus
        public static uint Avatar3 = 1001; // March
        public static uint Avatar4 = 1304; // Aventurine

        public static List<Giclniikjng> AvatarSpList = new List<Giclniikjng>
        {
            new Giclniikjng { Dheffcdjldb = 10000, Nmnbhaopedn = 10000 }, // Avatar1's energy
            new Giclniikjng { Dheffcdjldb = 2000, Nmnbhaopedn = 10000 }, // and so on..
            new Giclniikjng { Dheffcdjldb = 8000, Nmnbhaopedn = 10000 }, // ...
            new Giclniikjng { Dheffcdjldb = 10000, Nmnbhaopedn = 10000 }, // ....
        };

        [Handler(CmdType.CmdGetCurLineupDataCsReq)]
        public static void OnGetCurLineupDataCsReq(NetSession session, int cmdId, object _)
        {
            var response = new Klkjglkmilp
            {
                Nfhbjlibabk = 0
            };

            response.Fbgdffphahg = new Gcpepiecdkd
            {
                Bhpbmeigfib = Fiidffipjin.LineupNone,
                Heldbkcbibb = "Squad 1",
                Kclnaimofdl = 0,
            };

            var characters = new uint[] { Avatar1, Avatar2, Avatar3, Avatar4 };

            for (int i = 0; i < characters.Length; i++)
            {
                response.Fbgdffphahg.Ddnmlnmelons.Add(new Lekfnlnebbj
                {
                    Dilejkdjnfg = Chegccaonce.AvatarFormalType,
                    Pnomimanndn = 10000,
                    Ldjnpfpfjfd = AvatarSpList[i],
                    Kmacfpdejcb = 100,
                    Pfikmpgfecj = characters[i],
                    Pokheegbefh = (uint)response.Fbgdffphahg.Ddnmlnmelons.Count
                });
            }

            session.Send(CmdType.CmdGetCurLineupDataScRsp, response);
        }

        [Handler(CmdType.CmdGetAllLineupDataCsReq)]
        public static void OnGetAllLineupDataCsReq(NetSession session, int cmdId, object data)
        {
            var response = new Aclgjhedfaa
            {
                Nfhbjlibabk = 0,
                Hifmklongnc = 0,
            };

            response.Kbognlnlcles.Add(new Gcpepiecdkd
            {
                Bhpbmeigfib = Fiidffipjin.LineupNone,
                Heldbkcbibb = "Squad 1",
                Kclnaimofdl = 0,
            });

            var characters = new uint[] { Avatar1, Avatar2, Avatar3, Avatar4 };

            for (int i = 1; i < characters.Length; i++) 
            {
                response.Kbognlnlcles[0].Ddnmlnmelons.Add(new Lekfnlnebbj
                {
                    Dilejkdjnfg = Chegccaonce.AvatarFormalType,
                    Pnomimanndn = 10000,
                    Ldjnpfpfjfd = AvatarSpList[i],
                    Kmacfpdejcb = 100,
                    Pfikmpgfecj = characters[i],
                    Pokheegbefh = (uint)response.Kbognlnlcles[0].Ddnmlnmelons.Count,
                });
            }

            session.Send(CmdType.CmdGetAllLineupDataScRsp, response);
        }
    }
}
