namespace Matcha.Gateserver.Manager.Handlers
{
    using Matcha.Gateserver.Manager.Handlers.Core;
    using Matcha.Gateserver.Network;
    using Matcha.Proto;
    using System.Numerics;


    internal static class SceneReqGroup
    {
        [Handler(CmdType.CmdGetCurSceneInfoCsReq)]
        public static void OnGetCurSceneInfoCsReq(NetSession session, int cmdId, object data)
        {
            Fnpmbfbajoo scene = new Fnpmbfbajoo
            {
                Jncgaingmmm = 1,
                Kihpigcjcgi = 1,
                Mkijjannfck = 2010101,
                Gmimohebhdd = 20101,
                Hidjhpobjnj = 20101001,

            };

            scene.Pjhnkkdcjbps.Add(new Lploiglegif
            {
                Nbblpieddgf = 1, // state
                Lgibpajamgfs = {
                    new SceneEntityInfo()
                    {
                        Actor = new Afdgciijbop()
                        {
                            Ffadhpadgdc = 1222,
                            Dilejkdjnfg = Chegccaonce.AvatarFormalType,
                            Mgmaepjlghb = 1337,
                            Pmmfnkeaplg = 2,
                        },
                        Motion = new Ohmhbkookfc()
                        {
                            Edicgaolije = new Oceoogombch()
                            {
                                Onpiinjgbfg = -570,
                                Jjgfomehcfg = 19364,
                                Aohmpoildbd = 4480,
                            },
                            Anmgefmiofn = new Oceoogombch()
                            {
                                Onpiinjgbfg = 0,
                                Jjgfomehcfg = 0,
                                Aohmpoildbd = 0,
                            }
                        }
                    }
                }
            });

            scene.Pjhnkkdcjbps.Add(new Lploiglegif
            {
                Nbblpieddgf = 1, // state
                Iaaodipnfnj = 19, // group id
                Lgibpajamgfs = { 
                    new SceneEntityInfo() 
                    {
                        GroupId = 19,
                        InstId = 300001,
                        EntityId = 1337,
                        Prop = new Iomneabpnin()
                        {
                            Eibbgniflem = 808,
                            Fehgnikklmd = 1,
                        },
                        Motion = new Ohmhbkookfc()
                        {
                            Edicgaolije = new Oceoogombch()
                            {
                                Onpiinjgbfg = -570,
                                Jjgfomehcfg = 19364,
                                Aohmpoildbd = 4480,
                            },
                            Anmgefmiofn = new Oceoogombch()
                            {
                                Onpiinjgbfg = 0,
                                Jjgfomehcfg = 0,
                                Aohmpoildbd = 0,
                            }
                        }
                    } 
                }
            });


            /*scene.Pjhnkkdcjbps.Add(new Lploiglegif
            {
                EntityId = 0,
                GroupId = 0,
                InstId = 0,
                Motion = new MotionInfo()
                {
                    Pos = new Vector(),
                    Rot = new Vector()
                }
            });*/

            session.Send(CmdType.CmdGetCurSceneInfoScRsp, new Eejmenojoje
            {
                Aikeafjhkia = scene,
                Nfhbjlibabk = 0,
            });
        }
    }
}
