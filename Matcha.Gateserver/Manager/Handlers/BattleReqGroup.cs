using Matcha.Gateserver.Manager.Handlers.Core;
using static Matcha.Gateserver.Manager.Handlers.LineupReqGroup;
using Matcha.Gateserver.Network;
using Matcha.Proto;

namespace Matcha.Gateserver.Manager.Handlers
{
    internal static class BattleReqGroup
    {
        [Handler(CmdType.CmdStartCocoonStageCsReq)]
        public static void OnStartCocoonStageCsReq(NetSession session, int cmdId, object data)
        {
            var request = data as Dbmkkjjaage;

            Dictionary<uint, List<uint>> monsterIds = new Dictionary<uint, List<uint>>
            {
                { 1, new List<uint> { 3013010, 3012010, 3013010, 3001010 } },
                { 2, new List<uint> { 8034010 } },
                { 3, new List<uint> { 3014022 } },
            };

            Dictionary<uint, uint> monsterLevels = new Dictionary<uint, uint>
            {
                {1,70},{2,70},{3,60}
            };

            //basic
            var battleInfo = new Bnoodbcahio
            {
                Jifgjofbkah = 201012311,
                Hdolnojokcd = 639771447,
                Nfbchlgdjfm = 6
            };

            // avatar
            List<uint> SkillIdEnds = new List<uint> { 1, 2, 3, 4, 7, 101, 102, 103, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210 };
            List<uint> teamMembers = GetTeamMembers();
            foreach (uint avatarId in teamMembers)
            {
                var avatarData = new Cnlnlmnaheh
                {
                    Pfikmpgfecj = avatarId, // ID
                    Fopfhgjhebm = 80, // Level
                    Nnhagahgeng = 6, // Promotion
                    Ahdiecalkae = 0, // Rank
                    Pnomimanndn = 10000, // Hp
                    Dilejkdjnfg = Chegccaonce.AvatarFormalType, // AvatarType
                    Nfbchlgdjfm = 6, // World Level
                    Ldjnpfpfjfd = new Giclniikjng { Dheffcdjldb = 10000, Nmnbhaopedn = 10000 }, // Sp
                };

                avatarData.Gacbpcphhons.AddRange(RelicReqGroup.CreateTestEquipment(avatarId));
                avatarData.Oljfbmbjkhks.AddRange(RelicReqGroup.CreateTestRelics(avatarId));


                foreach (uint end in SkillIdEnds)
                {
                    uint level = 1;
                    if (end == 1) level = 6;
                    else if (end < 4 || end == 4) level = 10;
                    if (end > 4) level = 1;
                    avatarData.Dicnklkcemns.Add(new Hfklipobidn
                    {
                        Oponkpbacmn = avatarId * 1000 + end,
                        Fopfhgjhebm = level
                    });
                }

                battleInfo.Ibibbdigejls.Add(avatarData);
            };

            //monster
            for (uint i = 1; i <= monsterIds.Count; i++)
            {
                Hhaepdmfebg monsterInfo = new Hhaepdmfebg
                {
                    Comggjmfjao = i, // Wave ??
                    Djicbhlfoga = new Aekldeeeepn
                    {
                        Fopfhgjhebm = monsterLevels[i],
                    }
                };

                if (monsterIds.ContainsKey(i))
                {
                    List<uint> monsterIdList = monsterIds[i];

                    foreach (uint monsterId in monsterIdList)
                    {
                        monsterInfo.Gojhgccipnps.Add(new Gjebfekkbac
                        {
                            Njkjocjpdji = monsterId
                        });
                    }

                }
                battleInfo.Gdeppmjahjbs.Add(monsterInfo);
            }

            var response = new StartCocoonStageScRsp
            {
                Retcode = 0,
                CocoonId = request.Opicolmfbak,
                Wave = request.Enngkaflgmc,
                PropEntityId = request.Gpkddlobdgp,
                BattleInfo = battleInfo
            };

            session.Send(CmdType.CmdStartCocoonStageScRsp, response);
        }

        [Handler(CmdType.CmdPVEBattleResultCsReq)]
        public static void OnPVEBattleResultCsReq(NetSession session, int cmdId, object data)
        {
            var request = data as Pbhfknkdnna;
            session.Send(CmdType.CmdPVEBattleResultScRsp, new Jjpalhocbkb
            {
                Nfhbjlibabk = 0,
                Npeikdaecin = request.Npeikdaecin,
            });
        }
        private static List<uint> GetTeamMembers()
        {
            List<uint> teamMembers = new List<uint>{Avatar1,Avatar2,Avatar3,Avatar4};
            teamMembers = teamMembers.Where(avatarId => avatarId != 0).ToList();
            return teamMembers;
        }
    }
}

