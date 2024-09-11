using Matcha.Gateserver.Manager.Handlers.Core;
using static Matcha.Gateserver.Manager.Handlers.LineupReqGroup;
using static Matcha.Gateserver.Manager.Handlers.AvatarReqGroup;
using Matcha.Gateserver.Network;
using Matcha.Proto;

namespace Matcha.Gateserver.Manager.Handlers
{
    internal static class BattleReqGroup
    {
        private static bool a1_tech = true;
        private static bool a2_tech = true;
        private static bool a3_tech = false;
        private static bool a4_tech = true;

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

            List<uint> SkillIdEnds = new List<uint> { 1, 2, 3, 4, 7, 101, 102, 103, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210 };
            var teamMembers = GetTeamMembers();

            // loop through team members
            for (int i = 0; i < teamMembers.Length; i++)
            {
                uint avatarId = teamMembers[i];

                // automatically assign multi path id for battle
                if (avatarId == 1001 || avatarId == 8001 || avatarId == 8002)
                {
                    if (AvatarReqGroup.pathMap.TryGetValue(avatarId, out var avatarType))
                    {
                        switch (avatarType)
                        {
                            case Mjiecoljkip.Mar7thRogueType:
                                avatarId = (uint)Mjiecoljkip.Mar7thRogueType;
                                break;

                            case Mjiecoljkip.BoyShamanType:
                                avatarId = (uint)Mjiecoljkip.BoyShamanType;
                                break;

                            case Mjiecoljkip.GirlShamanType:
                                avatarId = (uint)Mjiecoljkip.GirlShamanType;
                                break;

                            case Mjiecoljkip.Mar7thKnightType:
                                avatarId = (uint)Mjiecoljkip.Mar7thKnightType;
                                break;

                            case Mjiecoljkip.BoyWarriorType:
                                avatarId = (uint)Mjiecoljkip.BoyWarriorType;
                                break;

                            case Mjiecoljkip.GirlWarriorType:
                                avatarId = (uint)Mjiecoljkip.GirlWarriorType;
                                break;

                            case Mjiecoljkip.BoyKnightType:
                                avatarId = (uint)Mjiecoljkip.BoyKnightType;
                                break;

                            case Mjiecoljkip.GirlKnightType:
                                avatarId = (uint)Mjiecoljkip.GirlKnightType;
                                break;

                            default:
                                // return original id when 0 match
                                avatarId = teamMembers[i];
                                break;
                        }
                    }
                }

                Giclniikjng spValues = LineupReqGroup.AvatarSpList[i]; // get energy from lineup

                var avatarData = new Cnlnlmnaheh
                {
                    Pfikmpgfecj = avatarId, // ID
                    Fopfhgjhebm = 80, // Level
                    Nnhagahgeng = 6, // Promotion
                    Ahdiecalkae = 0, // Rank
                    Pnomimanndn = 10000, // Hp
                    Dilejkdjnfg = Chegccaonce.AvatarFormalType, // AvatarType
                    Nfbchlgdjfm = 6, // World Level
                    Ldjnpfpfjfd = spValues, // Sp
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

                // Add the avatar data to the battle info
                battleInfo.Ibibbdigejls.Add(avatarData);

                // Apply buffs only if the corresponding boolean flag is true
                bool applyTechBuff = false;
                if (i == 0 && a1_tech) applyTechBuff = true;
                if (i == 1 && a2_tech) applyTechBuff = true;
                if (i == 2 && a3_tech) applyTechBuff = true;
                if (i == 3 && a4_tech) applyTechBuff = true;

                // note: techniques alone won't give toughness dmg, will need smth like EnterBattle buffs
                if (applyTechBuff)
                {
                    var techniqueId = (uint)((avatarId * 100) + 1);
                    battleInfo.Gaekhpnnppoes.Add(new Flmdpdcelio
                    {
                        Pfikmpgfecj = techniqueId, // obvious
                        Fopfhgjhebm = 1,  // tech id lvl
                        Ehljdlekgjp = (uint)i, // Owner index, from 0 to 3 cause avatar slot
                        Ljpcidgmdlc = 4294967295, // Wave flag
                        Ckbldngkkncs = new uint[] {/*0, 1, 2, 3*/}, // Target index, was told its the same as owner index
                    });
                    // Dynamic values
                    battleInfo.Gaekhpnnppoes[0].Pomhfojgchns["SkillIndex"] = 0.0f;
                }
            }

            // Monster setup
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

        private static uint[] GetTeamMembers()
        {
            var teamMembers = new uint[]
            {
                LineupReqGroup.Avatar1,
                LineupReqGroup.Avatar2,
                LineupReqGroup.Avatar3,
                LineupReqGroup.Avatar4,
            };

            teamMembers = teamMembers.Where(avatarId => avatarId != 0).ToArray();
            return teamMembers;
        }
    }
}
