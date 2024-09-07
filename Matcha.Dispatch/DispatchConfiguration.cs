namespace Matcha.Dispatch
{
    using Matcha.Dispatch.Configuration;
    using Matcha.Shared.Configuration;

    internal class DispatchConfiguration
    {
        public NetworkConfiguration Network { get; set; }
        public RegionConfiguration Region { get; set; }
    }
}
