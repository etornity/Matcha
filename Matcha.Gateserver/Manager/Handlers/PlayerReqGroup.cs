namespace Matcha.Gateserver.Manager.Handlers
{
    using Matcha.Gateserver.Manager.Handlers.Core;
    using Matcha.Gateserver.Network;
    using Matcha.Proto;
    using NLog;

    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using Newtonsoft.Json;

    internal static class PlayerReqGroup
    {
        private static readonly Logger s_log = LogManager.GetCurrentClassLogger();

        [Handler(CmdType.CmdPlayerHeartBeatCsReq)]
        public static void OnPlayerHeartBeatCsReq(NetSession session, int cmdId, object data)
        {
            var heartbeatReq = data as Ecfcegjlpkd;
            var curTime = (ulong)DateTimeOffset.Now.ToUnixTimeMilliseconds();
            var curTimeData = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            session.Send(CmdType.CmdPlayerHeartBeatScRsp, new Acmkdedpkaf
            {
                Nfhbjlibabk = 0,

                Ddobibdjgba = new Jfdegkkcbln
                {
                    Dfmcmafingl = 51,
                    Hlnehicbpai = curTimeData,
                    Cpiogbbagop = Convert.FromBase64String("Q1MuVW5pdHlFbmdpbmUuR2FtZU9iamVjdC5GaW5kKCJWZXJzaW9uVGV4dCIpOkdldENvbXBvbmVudEluQ2hpbGRyZW4odHlwZW9mKENTLlJQRy5DbGllbnQuTG9jYWxpemVkVGV4dCkpLnRleHQgPSAiIg0KQ1MuVW5pdHlFbmdpbmUuR2FtZU9iamVjdC5GaW5kKCJVSVJvb3QvQWJvdmVEaWFsb2cvQmV0YUhpbnREaWFsb2coQ2xvbmUpIik6R2V0Q29tcG9uZW50SW5DaGlsZHJlbih0eXBlb2YoQ1MuUlBHLkNsaWVudC5Mb2NhbGl6ZWRUZXh0KSkudGV4dCA9ICJodHRwczovL2dpdGh1Yi5jb20vZXRvcm5pdHkvTWF0Y2hhIg==")
                },
                Mfjchlolioj = heartbeatReq.Mfjchlolioj,
                Mpjdnddmnlg = curTime
            });
        }

        [Handler(CmdType.CmdGetBasicInfoCsReq)]
        public static void OnGetBasicInfoCsReq(NetSession session, int cmdId, object _)
        {
            session.Send(CmdType.CmdGetBasicInfoScRsp, new GetBasicInfoScRsp
            {
                CurDay = 1,
                ExchangeTimes = 0,
                Retcode = 0,
                NextRecoverTime = 2281337,
                WeekCocoonFinishedCount = 0
            });
        }

        [Handler(CmdType.CmdPlayerLoginCsReq)]
        public static void OnPlayerLoginCsReq(NetSession session, int cmdId, object data)
        {
            var request = data as Aojnbenkgjd;

            session.Send(CmdType.CmdPlayerLoginScRsp, new Opeaihfkjhd
            {
                Nfhbjlibabk = 0,
                Pdidijddcno = request.Pdidijddcno,
                Ealdladenig = 240,
                Mciakkehiaa = (ulong)DateTimeOffset.Now.ToUnixTimeSeconds() * 1000,
                Ljomfcomdnp = new Odpllpebkjc
                {
                    Nilnmfaokkg = "Eto",
                    Fopfhgjhebm = 70,
                    Ealdladenig = 100,
                    Nfbchlgdjfm = 6
                }
            });
        }

        [Handler(CmdType.CmdPlayerGetTokenCsReq)]
        public static void OnPlayerGetTokenCsReq(NetSession session, int cmdId, object data)
        {
            session.Send(CmdType.CmdPlayerGetTokenScRsp, new Hlhcjbljkng
            {
                Nfhbjlibabk = 0,
                Mgmaepjlghb = 1008,
                Fpglgbgjmjc = "OK",
                Knmmjicjamg = 0
            });
        }
    }
}
