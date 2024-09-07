namespace Matcha.Dispatch.Handlers
{
    using Ceen;
    using Matcha.Dispatch.Util;
    using Matcha.Proto;

    internal class GetExperimentListHandler : IHttpModule
    {
        public async Task<bool> HandleAsync(IHttpContext context)
        {
            context.Response.StatusCode = HttpStatusCode.OK;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAllJsonAsync(DispatchResponseBuilder.Create()
                                                     .Retcode(0)
                                                     .Boolean("success", true)
                                                     .String("message", "")
                                                     .Build());

            return true;
        }
    }
}
