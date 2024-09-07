namespace Matcha.Gateserver.Manager.Handlers
{
    using Matcha.Gateserver.Manager.Handlers.Core;
    using Matcha.Gateserver.Network;
    using Matcha.Proto;

    internal static class LineupReqGroup
    {
        public static uint Avatar1 = 1222; // Free
        public static uint Avatar2 = 1220; // Feixiao
        public static uint Avatar3 = 1223; // Moze
        public static uint Avatar4 = 1304; // Aventurine
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

            foreach (uint id in characters)
            {
                response.Fbgdffphahg.Ddnmlnmelons.Add(new Lekfnlnebbj
                {
                    Dilejkdjnfg = Chegccaonce.AvatarFormalType,
                    Pnomimanndn = 10000,
                    Ldjnpfpfjfd = new Giclniikjng { Dheffcdjldb = 10000, Nmnbhaopedn = 10000},
                    Kmacfpdejcb = 100,
                    Pfikmpgfecj = id,
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

            foreach (uint id in characters)
            {
                response.Kbognlnlcles[0].Ddnmlnmelons.Add(new Lekfnlnebbj
                {
                    Dilejkdjnfg = Chegccaonce.AvatarFormalType,
                    Pnomimanndn = 10000,
                    Ldjnpfpfjfd = new Giclniikjng { Dheffcdjldb = 10000, Nmnbhaopedn = 10000 },
                    Kmacfpdejcb = 100,
                    Pfikmpgfecj = id,
                    Pokheegbefh = (uint)response.Kbognlnlcles[0].Ddnmlnmelons.Count,
                });
            }

            session.Send(CmdType.CmdGetAllLineupDataScRsp, response);
        }
    }
}
