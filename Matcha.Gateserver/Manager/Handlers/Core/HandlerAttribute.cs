namespace Matcha.Gateserver.Manager.Handlers.Core
{
    using Matcha.Gateserver.Network;
    using Matcha.Proto;

    [AttributeUsage(AttributeTargets.Method)]
    internal class HandlerAttribute : Attribute
    {
        public int CmdID { get; }

        public HandlerAttribute(CmdType cmdID)
        {
            this.CmdID = (int)cmdID;
        }

        public delegate void HandlerDelegate(NetSession session, int cmdId, object data);
    }
}
