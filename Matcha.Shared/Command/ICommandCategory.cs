namespace Matcha.Shared.Command
{
    using Matcha.Shared.Command.Context;

    public interface ICommandCategory
    {
        CommandResult Invoke(ICommandContext context, string[] parameters, uint depth);
    }
}
