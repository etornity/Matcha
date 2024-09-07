namespace Matcha.Dispatch.Handlers
{
    using Ceen;
    using Matcha.Dispatch.Util;
    using Matcha.Proto;
    using Newtonsoft.Json.Linq;
    using System.Threading.Tasks;

    internal class RiskyApiCheckHandler : IHttpModule
    {
        public async Task<bool> HandleAsync(IHttpContext context)
        {
            context.Response.StatusCode = HttpStatusCode.OK;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAllJsonAsync(DispatchResponseBuilder.Create()
                                                     .Retcode(0)
                                                     .Message("OK")
                                                     .Object("data", CaptchaData)
                                                     .Build());

            return true;
        }

        private static JObject CaptchaData
        {
            get
            {
                return new JObject
                {
                    {"id", ""},
                    {"action", "ACTION_NONE"},
                    {"geetest", null}
                };
            }
        }
    }
}
