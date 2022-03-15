using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using PurrplingCore.Framework.Serialization.Converters;
using StardewModdingAPI;
using StardewModdingAPI.Toolkit.Serialization;
using System;
using System.Collections.Generic;

namespace PurrplingCore.Framework.Serialization
{
    class DataHelper : IDataHelper
    {
        public DataHelper(IDataHelper innerHelper, TypeBinder _typeBinder, IMonitor monitor)
        {
            var jsonSettings = new JsonHelper().JsonSettings;
            var converters = new List<JsonConverter>()
            {
                new ColorConverter(),
                new PointConverter(),
                new Vector2Converter(),
                new RectangleConverter(),
                new NetFieldConverter(),
                new NetStringDictionaryConverter(),
            };

            jsonSettings.ContractResolver = new SContractResolver();
            jsonSettings.SerializationBinder = _typeBinder;
            jsonSettings.TypeNameHandling = TypeNameHandling.Auto;
            jsonSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jsonSettings.Error = this.OnError;
            converters.ForEach(c => jsonSettings.Converters.Add(c));
            
            this.Serializer = JsonSerializer.CreateDefault(jsonSettings);
            this.InnerHelper = innerHelper;
            this.monitor = monitor;
        }

        private void OnError(object sender, ErrorEventArgs e)
        {
            if (e.ErrorContext.Error is JsonSerializationException ex && ex.Path.Contains("$type"))
            {
                e.ErrorContext.Handled = true;
                this.monitor.Log($"Ommited inconsistent data for path `{e.ErrorContext.Path}`", LogLevel.Warn);  
            }
        }

        private JsonSerializer Serializer { get; }
        private IDataHelper InnerHelper { get; }

        private IMonitor monitor;

        public TModel ReadGlobalData<TModel>(string key) where TModel : class
        {
            return this.FromJToken<TModel>(this.InnerHelper.ReadGlobalData<JToken>(key));
        }

        public TModel ReadJsonFile<TModel>(string path) where TModel : class
        {
            return this.FromJToken<TModel>(this.InnerHelper.ReadJsonFile<JToken>(path));
        }

        public TModel ReadSaveData<TModel>(string key) where TModel : class
        {
            return this.FromJToken<TModel>(this.InnerHelper.ReadSaveData<JToken>(key));
        }

        public void WriteGlobalData<TModel>(string key, TModel data) where TModel : class
        {
            this.InnerHelper.WriteGlobalData(key, this.ToJToken(data));
        }

        public void WriteJsonFile<TModel>(string path, TModel data) where TModel : class
        {
            this.InnerHelper.WriteJsonFile(path, this.ToJToken(data));
        }

        public void WriteSaveData<TModel>(string key, TModel data) where TModel : class
        {
            this.InnerHelper.WriteSaveData(key, this.ToJToken(data));
        }

        public JToken ToJToken<TModel>(TModel data) where TModel : class
        {
            return JToken.FromObject(data, this.Serializer);
        }

        public TModel FromJToken<TModel>(JToken jToken) where TModel : class
        {
            return jToken?.ToObject<TModel>(this.Serializer);
        }
    }
}
