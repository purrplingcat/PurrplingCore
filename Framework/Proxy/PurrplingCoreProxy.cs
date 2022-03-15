using PurrplingCore.Framework.Serialization;
using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurrplingCore.Framework.Proxy
{
    internal class PurrplingCoreProxy : IPurrplingCoreProxy
    {
        private PurrplingCoreMod purrplingCoreMod;
        private Mod forMod;
        private readonly TypeBinder _typeBinder;
        private readonly DataHelper _dataHelper;

        public PurrplingCoreProxy(PurrplingCoreMod purrplingCoreMod, Mod forMod)
        {
            this.purrplingCoreMod = purrplingCoreMod;
            this.forMod = forMod;
            this._typeBinder = new TypeBinder(forMod.ModManifest, forMod.Monitor);
            this._dataHelper = new DataHelper(forMod.Helper.Data, this._typeBinder, forMod.Monitor);

            this.Data = this._dataHelper;
        }

        public IDataHelper Data { get; }

        public void RegisterDataType<TModel>()
        {
            Type type = typeof(TModel);

            this._typeBinder.RegisterType(type, type.Name);
        }

        public void RegisterDataType<TModel>(string name)
        {
            Type type = typeof(TModel);

            this._typeBinder.RegisterType(type, name);
        }

        public void RegisterDataType(Type type, string name)
        {
            this._typeBinder.RegisterType(type, name);
        }
    }
}
