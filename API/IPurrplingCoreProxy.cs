using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurrplingCore
{
    public interface IPurrplingCoreProxy
    {
        IDataHelper Data { get; }
        void RegisterDataType<TModel>();
        void RegisterDataType<TModel>(string name);
        void RegisterDataType(Type type, string name);
    }
}
