namespace Matcha.Gateserver.Network.Handlers.Manager
{
    using DotNetty.Transport.Channels;
    using Matcha.Gateserver.Manager;
    using Matcha.Gateserver.Network.Packet;
    using Matcha.Proto;
    using NLog;
    using ProtoBuf;

    internal class PacketHandler : ChannelHandlerAdapter
    {
        private static readonly Logger s_log = LogManager.GetCurrentClassLogger();
        private readonly NetSession _session;

        public PacketHandler(NetSession session)
        {
            _session = session;
        }

        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            NetPacket packet = message as NetPacket;
            if (packet.Data == null)
            {
                if (!SendDummyResponse(packet.CmdId))
                    s_log.Warn($"CmdType {packet.CmdId} is undefined.");

                return;
            }

            s_log.Info($"Received packet {packet.CmdId}!");
            NotifyManager.Notify(_session, packet.CmdId, packet.Data);
        }

        private bool SendDummyResponse(int id)
        {
            if (s_dummyTable.TryGetValue((CmdType)id, out CmdType rspId))
            {
                _session.Send(rspId, new DummyPacket());
                return true;
            }

            return false;
        }

        private static Dictionary<CmdType, CmdType> s_dummyTable = new Dictionary<CmdType, CmdType>
        {
            {CmdType.CmdGetLevelRewardTakenListCsReq, CmdType.CmdGetLevelRewardTakenListScRsp},
            {CmdType.CmdGetRogueScoreRewardInfoCsReq, CmdType.CmdGetRogueScoreRewardInfoScRsp},
            {CmdType.CmdGetGachaInfoCsReq, CmdType.CmdGetGachaInfoScRsp},
            {CmdType.CmdQueryProductInfoCsReq, CmdType.CmdQueryProductInfoScRsp},
            {CmdType.CmdGetQuestDataCsReq, CmdType.CmdGetQuestDataScRsp},
            {CmdType.CmdGetQuestRecordCsReq, CmdType.CmdGetQuestRecordScRsp},
            {CmdType.CmdGetFriendListInfoCsReq, CmdType.CmdGetFriendListInfoScRsp},
            {CmdType.CmdGetFriendApplyListInfoCsReq, CmdType.CmdGetFriendApplyListInfoScRsp},
            {CmdType.CmdGetCurAssistCsReq, CmdType.CmdGetCurAssistScRsp},
            {CmdType.CmdGetRogueHandbookDataCsReq, CmdType.CmdGetRogueHandbookDataScRsp},
            {CmdType.CmdGetDailyActiveInfoCsReq, CmdType.CmdGetDailyActiveInfoScRsp},
            {CmdType.CmdGetFightActivityDataCsReq, CmdType.CmdGetFightActivityDataScRsp},
            {CmdType.CmdGetMultipleDropInfoCsReq, CmdType.CmdGetMultipleDropInfoScRsp},
            {CmdType.CmdGetPlayerReturnMultiDropInfoCsReq, CmdType.CmdGetPlayerReturnMultiDropInfoScRsp},
            {CmdType.CmdGetShareDataCsReq, CmdType.CmdGetShareDataScRsp},
            {CmdType.CmdGetTreasureDungeonActivityDataCsReq, CmdType.CmdGetTreasureDungeonActivityDataScRsp},
            {CmdType.CmdPlayerReturnInfoQueryCsReq, CmdType.CmdPlayerReturnInfoQueryScRsp},
            {CmdType.CmdGetBasicInfoCsReq, CmdType.CmdGetBasicInfoScRsp},
            {CmdType.CmdGetMultiPathAvatarInfoCsReq, CmdType.CmdGetMultiPathAvatarInfoScRsp},
            {CmdType.CmdGetBagCsReq, CmdType.CmdGetBagScRsp},
            {CmdType.CmdGetPlayerBoardDataCsReq, CmdType.CmdGetPlayerBoardDataScRsp},
            {CmdType.CmdGetAvatarDataCsReq, CmdType.CmdGetAvatarDataScRsp},
            {CmdType.CmdGetAllLineupDataCsReq, CmdType.CmdGetAllLineupDataScRsp},
            {CmdType.CmdGetActivityScheduleConfigCsReq, CmdType.CmdGetActivityScheduleConfigScRsp},
            {CmdType.CmdGetMissionDataCsReq, CmdType.CmdGetMissionDataScRsp},
            {CmdType.CmdGetMissionEventDataCsReq, CmdType.CmdGetMissionEventDataScRsp},
            {CmdType.CmdGetChallengeCsReq, CmdType.CmdGetChallengeScRsp},
            {CmdType.CmdGetCurChallengeCsReq, CmdType.CmdGetCurChallengeScRsp},
            {CmdType.CmdGetRogueInfoCsReq, CmdType.CmdGetRogueInfoScRsp},
            {CmdType.CmdGetExpeditionDataCsReq, CmdType.CmdGetExpeditionDataScRsp},
            {CmdType.CmdGetJukeboxDataCsReq, CmdType.CmdGetJukeboxDataScRsp},
            {CmdType.CmdSyncClientResVersionCsReq, CmdType.CmdSyncClientResVersionScRsp},
            {CmdType.CmdDailyFirstMeetPamCsReq, CmdType.CmdDailyFirstMeetPamScRsp},
            {CmdType.CmdGetMuseumInfoCsReq, CmdType.CmdGetMuseumInfoScRsp},
            {CmdType.CmdGetLoginActivityCsReq, CmdType.CmdGetLoginActivityScRsp},
            {CmdType.CmdGetRaidInfoCsReq, CmdType.CmdGetRaidInfoScRsp},
            {CmdType.CmdGetTrialActivityDataCsReq, CmdType.CmdGetTrialActivityDataScRsp},
            {CmdType.CmdGetBoxingClubInfoCsReq, CmdType.CmdGetBoxingClubInfoScRsp},
            {CmdType.CmdGetNpcStatusCsReq, CmdType.CmdGetNpcStatusScRsp},
            {CmdType.CmdTextJoinQueryCsReq, CmdType.CmdTextJoinQueryScRsp},
            {CmdType.CmdGetSpringRecoverDataCsReq, CmdType.CmdGetSpringRecoverDataScRsp},
            {CmdType.CmdGetChatFriendHistoryCsReq, CmdType.CmdGetChatFriendHistoryScRsp},
            {CmdType.CmdGetSecretKeyInfoCsReq, CmdType.CmdGetSecretKeyInfoScRsp},
            {CmdType.CmdGetVideoVersionKeyCsReq, CmdType.CmdGetVideoVersionKeyScRsp},
            {CmdType.CmdGetCurLineupDataCsReq, CmdType.CmdGetCurLineupDataScRsp},
            {CmdType.CmdGetCurBattleInfoCsReq, CmdType.CmdGetCurBattleInfoScRsp},
            {CmdType.CmdGetCurSceneInfoCsReq, CmdType.CmdGetCurSceneInfoScRsp},
            {CmdType.CmdGetPhoneDataCsReq, CmdType.CmdGetPhoneDataScRsp},
            {CmdType.CmdPlayerLoginFinishCsReq, CmdType.CmdPlayerLoginFinishScRsp},
            {CmdType.CmdGetMarkItemListCsReq, CmdType.CmdGetMarkItemListScRsp},
            {CmdType.CmdGetAllServerPrefsDataCsReq, CmdType.CmdGetAllServerPrefsDataScRsp},
            {CmdType.CmdGetRogueCommonDialogueDataCsReq, CmdType.CmdGetRogueCommonDialogueDataScRsp},
            {CmdType.CmdGetRogueEndlessActivityDataCsReq, CmdType.CmdGetRogueEndlessActivityDataScRsp},
            {CmdType.CmdGetMonsterResearchActivityDataCsReq, CmdType.CmdGetMonsterResearchActivityDataScRsp},
            {CmdType.CmdGetMainMissionCustomValueCsReq, CmdType.CmdGetMainMissionCustomValueScRsp},
            {CmdType.CmdGetAssistHistoryCsReq, CmdType.CmdGetAssistHistoryScRsp},
            {CmdType.CmdRogueTournQueryCsReq, CmdType.CmdRogueTournQueryScRsp},
            {CmdType.CmdGetBattleCollegeDataCsReq, CmdType.CmdGetBattleCollegeDataScRsp},
            {CmdType.CmdGetHeartDialInfoCsReq, CmdType.CmdGetHeartDialInfoScRsp},
            {CmdType.CmdHeliobusActivityDataCsReq, CmdType.CmdHeliobusActivityDataScRsp},
            {CmdType.CmdGetEnteredSceneCsReq, CmdType.CmdGetEnteredSceneScRsp},
            {CmdType.CmdGetAetherDivideInfoCsReq, CmdType.CmdGetAetherDivideInfoScRsp},
            {CmdType.CmdGetMapRotationDataCsReq, CmdType.CmdGetMapRotationDataScRsp},
            {CmdType.CmdGetRogueCollectionCsReq, CmdType.CmdGetRogueCollectionScRsp},
            {CmdType.CmdGetRogueExhibitionCsReq, CmdType.CmdGetRogueExhibitionScRsp},
            {CmdType.CmdGetNpcMessageGroupCsReq, CmdType.CmdGetNpcMessageGroupScRsp},
            {CmdType.CmdGetFriendLoginInfoCsReq, CmdType.CmdGetFriendLoginInfoScRsp},
            {CmdType.CmdGetChessRogueNousStoryInfoCsReq, CmdType.CmdGetChessRogueNousStoryInfoScRsp},
            {CmdType.CmdCommonRogueQueryCsReq, CmdType.CmdCommonRogueQueryScRsp},
            {CmdType.CmdGetStarFightDataCsReq, CmdType.CmdGetStarFightDataScRsp},
            {CmdType.CmdEvolveBuildQueryInfoCsReq, CmdType.CmdEvolveBuildQueryInfoScRsp},
            {CmdType.CmdGetAlleyInfoCsReq, CmdType.CmdGetAlleyInfoScRsp},
            {CmdType.CmdGetAetherDivideChallengeInfoCsReq, CmdType.CmdGetAetherDivideChallengeInfoScRsp},
            {CmdType.CmdGetStrongChallengeActivityDataCsReq, CmdType.CmdGetStrongChallengeActivityDataScRsp},
            {CmdType.CmdGetOfferingInfoCsReq, CmdType.CmdGetOfferingInfoScRsp},
            {CmdType.CmdClockParkGetInfoCsReq, CmdType.CmdClockParkGetInfoScRsp},
            {CmdType.CmdGetGunPlayDataCsReq, CmdType.CmdGetGunPlayDataScRsp},
            {CmdType.CmdSpaceZooDataCsReq, CmdType.CmdSpaceZooDataScRsp},
            {CmdType.CmdGetUnlockTeleportCsReq, CmdType.CmdGetUnlockTeleportScRsp},
            {CmdType.CmdTravelBrochureGetDataCsReq, CmdType.CmdTravelBrochureGetDataScRsp},
            {CmdType.CmdRaidCollectionDataCsReq, CmdType.CmdRaidCollectionDataScRsp},
            {CmdType.CmdGetChatEmojiListCsReq, CmdType.CmdGetChatEmojiListScRsp},
            {CmdType.CmdGetTelevisionActivityDataCsReq, CmdType.CmdGetTelevisionActivityDataScRsp},
            {CmdType.CmdGetTrainVisitorRegisterCsReq, CmdType.CmdGetTrainVisitorRegisterScRsp},
            {CmdType.CmdGetLoginChatInfoCsReq, CmdType.CmdGetLoginChatInfoScRsp},
            {CmdType.CmdGetFeverTimeActivityDataCsReq, CmdType.CmdGetFeverTimeActivityDataScRsp},
            {CmdType.CmdGetAllSaveRaidCsReq, CmdType.CmdGetAllSaveRaidScRsp},
            {CmdType.CmdGetPlayerDetailInfoCsReq, CmdType.CmdGetPlayerDetailInfoScRsp},
            {CmdType.CmdGetFriendBattleRecordDetailCsReq, CmdType.CmdGetFriendBattleRecordDetailScRsp},
            {CmdType.CmdGetFriendDevelopmentInfoCsReq, CmdType.CmdGetFriendDevelopmentInfoScRsp},
            {CmdType.CmdFinishTalkMissionCsReq, CmdType.CmdFinishTalkMissionScRsp},
            {CmdType.CmdRogueTournGetPermanentTalentInfoCsReq, CmdType.CmdRogueTournGetPermanentTalentInfoScRsp},
            {CmdType.CmdChessRogueQueryCsReq, CmdType.CmdChessRogueQueryScRsp},
            {CmdType.CmdGetTrackPhotoActivityDataCsReq, CmdType.CmdGetTrackPhotoActivityDataScRsp},
            {CmdType.CmdGetSwordTrainingDataCsReq, CmdType.CmdGetSwordTrainingDataScRsp},
            {CmdType.CmdGetSummonActivityDataCsReq, CmdType.CmdGetSummonActivityDataScRsp},
            {CmdType.CmdMatchThreeGetDataCsReq, CmdType.CmdMatchThreeGetDataScRsp},
            {CmdType.CmdGetDrinkMakerDataCsReq, CmdType.CmdGetDrinkMakerDataScRsp},
            {CmdType.CmdUpdateServerPrefsDataCsReq, CmdType.CmdUpdateServerPrefsDataScRsp},
            {CmdType.CmdGetShopListCsReq, CmdType.CmdGetShopListScRsp},
            {CmdType.CmdUpdateTrackMainMissionIdCsReq, CmdType.CmdUpdateTrackMainMissionIdScRsp},
            {CmdType.CmdRelicRecommendCsReq, CmdType.CmdRelicRecommendScRsp},
            {CmdType.CmdEnterSectionCsReq, CmdType.CmdEnterSectionScRsp},
            {CmdType.CmdRogueArcadeGetInfoCsReq, CmdType.CmdRogueArcadeGetInfoScRsp},
            {CmdType.CmdGetPetDataCsReq, CmdType.CmdGetPetDataScRsp},
            {CmdType.CmdGetFightFestDataCsReq, CmdType.CmdGetFightFestDataScRsp},
            {CmdType.CmdDifficultyAdjustmentGetDataCsReq, CmdType.CmdDifficultyAdjustmentGetDataScRsp},
            {CmdType.CmdGetMailCsReq, CmdType.CmdGetMailScRsp},
        };

        [ProtoContract]
        private class DummyPacket { }
    }
}
