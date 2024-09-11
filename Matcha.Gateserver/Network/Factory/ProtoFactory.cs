namespace Matcha.Gateserver.Network.Factory
{
    using Matcha.Proto;
    using ProtoBuf;
    using System.Collections.Immutable;

    internal static class ProtoFactory
    {
        private static readonly ImmutableDictionary<CmdType, Type> s_types;

        static ProtoFactory()
        {
            var builder = ImmutableDictionary.CreateBuilder<CmdType, Type>();
            builder.AddRange(new Dictionary<CmdType, Type>()
            {
                {CmdType.CmdPlayerGetTokenCsReq, typeof(Hphmmnaenpm)},
                {CmdType.CmdPlayerLoginCsReq, typeof(Aojnbenkgjd)},

                {CmdType.CmdGetAvatarDataCsReq, typeof(Fbblgdmmacj)},
                {CmdType.CmdGetMultiPathAvatarInfoCsReq, typeof(Fjkpeabkggl)},

                {CmdType.CmdGetAllLineupDataCsReq, typeof(Jablakijdea)},
                {CmdType.CmdGetCurLineupDataCsReq, typeof(Mfochmockmo)},

                {CmdType.CmdGetMissionStatusCsReq, typeof(Kipdgbpeche)},
                {CmdType.CmdGetCurSceneInfoCsReq, typeof(Fpjkmmkpnge)},

                {CmdType.CmdGetBasicInfoCsReq, typeof(Icmibhcnkll)},
                {CmdType.CmdPlayerHeartBeatCsReq, typeof(Ecfcegjlpkd)},

                {CmdType.CmdGetTutorialCsReq, typeof(Apikgighdgc)},
                {CmdType.CmdGetTutorialGuideCsReq, typeof(Ojofgmhapgh)},

                {CmdType.CmdStartCocoonStageCsReq, typeof(Dbmkkjjaage)},
                {CmdType.CmdPVEBattleResultCsReq, typeof(Pbhfknkdnna)},

            });

            s_types = builder.ToImmutable();
        }

        public static object Deserialize(int id, byte[] rawData)
        {
            if (s_types.TryGetValue((CmdType)id, out var type))
                return Serializer.Deserialize(type, new MemoryStream(rawData));

            return null;
        }
    }
}
