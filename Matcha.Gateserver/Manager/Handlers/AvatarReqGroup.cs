namespace Matcha.Gateserver.Manager.Handlers
{
    using Matcha.Gateserver.Manager.Handlers.Core;
    using Matcha.Gateserver.Network;
    using Matcha.Proto;

    internal static class AvatarReqGroup
    {
        [Handler(CmdType.CmdGetAvatarDataCsReq)]
        public static void OnGetAvatarDataCsReq(NetSession session, int cmdId, object data)
        {
            var request = data as Fbblgdmmacj;

            var response = new Ckhcednnbbn
            {
                Nfhbjlibabk = 0,
                Ggnflobikdh = request.Mjhfpehcbkh
            };

            uint[] characters = new uint[] { 1001, 8001,
                                            1002, 1003, 1004, 1005, 1006, 1008, 1009, 1013, 1101, 1102, 1103, 1104, 1105, 1106, 1107, 1108, 1109,
                                            1110, 1111, 1112, 1201, 1202, 1203, 1204, 1205, 1206, 1207, 1208, 1209, 1210, 1211, 1212, 1213, 1214,
                                            1215, 1217, 1301, 1302, 1303, 1304, 1305, 1306, 1307, 1308, 1309, 1310, 1312, 1314, 1315, 1221, 1218,
                                            1220, 1222, 1223};

            foreach (uint id in characters)
            {
                var avatarData = new Opegifpofeb
                {
                    Ffadhpadgdc = id,
                    Fopfhgjhebm = 80,
                    Nnhagahgeng = 6,
                    Ahdiecalkae = 6,
                    Fbieckfjhid = 0,
                };

                response.Ddnmlnmelons.Add(avatarData);
            }

            session.Send(CmdType.CmdGetAvatarDataScRsp, response);
        }

        // rogue = hunt, shaman = harmony, knight = preservation
        public static Dictionary<uint, Mjiecoljkip> pathMap = new Dictionary<uint, Mjiecoljkip>
        {
            { 1001, Mjiecoljkip.Mar7thRogueType },
            { 8001, Mjiecoljkip.BoyShamanType },
            // { 8002, Mjiecoljkip.GirlShamanType }
        };

        [Handler(CmdType.CmdGetMultiPathAvatarInfoCsReq)]
        public static void OnGetMultiPathAvatarInfoCsReq(NetSession session, int cmdId, object data)
        {
            var response = new Lgolgjbcmpl
            {
                Nfhbjlibabk = 0,
            };

            foreach (var entry in pathMap)
            {
                response.Dicpnabknmhs[entry.Key] = entry.Value;
            };

            session.Send(CmdType.CmdGetMultiPathAvatarInfoScRsp, response);
        }
    }
}
