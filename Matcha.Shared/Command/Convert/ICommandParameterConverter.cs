﻿namespace Matcha.Shared.Command.Convert
{
    public interface ICommandParameterConverter
    {
        bool TryConvert(string parameter, out object result);
    }
}
