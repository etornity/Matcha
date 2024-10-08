﻿namespace Matcha.Gateserver.Network
{
    using DotNetty.Buffers;
    using DotNetty.Transport.Channels;
    using Matcha.Gateserver.Network.Packet;
    using Matcha.Proto;

    internal class NetSession
    {
        private IChannel _channel;

        public NetSession(IChannel channel)
        {
            _channel = channel;
        }

        public async void Send<T>(CmdType cmdId, T data) where T : class
        {
            var packet = new NetPacket()
            {
                CmdId = (int)cmdId,
                Data = data
            };

            var buffer = Unpooled.Buffer();
            packet.Serialize<T>(buffer);
            packet.Buf = buffer;

            await _channel.WriteAndFlushAsync(packet);
        }
    }
}
