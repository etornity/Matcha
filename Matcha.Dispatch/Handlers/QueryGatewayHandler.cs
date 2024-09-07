namespace Matcha.Dispatch.Handlers
{
    using Ceen;
    using Matcha.Dispatch.Util;
    using Matcha.Proto;
    using System.Threading.Tasks;

    internal class QueryGatewayHandler : IHttpModule
    {
        public async Task<bool> HandleAsync(IHttpContext context)
        {
            context.Response.StatusCode = HttpStatusCode.OK;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAllAsync(Convert.ToBase64String(ProtobufUtil.Serialize(new Cokohpcdnfo
            {
                Nfhbjlibabk = 0,
                Jdmpkhbijmn = "127.0.0.1",
                Cfanklgaeoi = 23301,
                // Didfenikjdg = "https://autopatchcn-ipv6.bhsr.com/asb/BetaLive/output_7663997_cd086af3f307",
                // Kejpmagdbai = "https://autopatchcn-ipv6.bhsr.com/design_data/BetaLive/output_7680597_a60760caba0f",
                // Ificjdejjdn = "https://autopatchcn-ipv6.bhsr.com/lua/BetaLive/output_7668875_0231727458ad",
                // Jmaggbeaiib = "7668875",
                Fkenkkhlhhd = true,
                Opgmnlinakc = true,
                Mbdacjejamf = true,
                Bgpcckkddmb = true,
                Moikmlhoiap = true,
                Kjadmknddjl = true,
                Gjaeghbeaio = true,
                Lamjdogmfam = true,
                Hafcipegpin = true,
            })));

            return true;
        }
    }
}
