using System;
using System.Runtime.CompilerServices;

namespace SpaceTransport.Scripts.Interfaces
{
    public interface IRequireViewIdentification
    {
        Guid ViewGuid { get; }
    }
}