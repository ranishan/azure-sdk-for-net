namespace Azure.Data.AppConfiguration
{
    public partial class ConfigurationClient
    {
        protected ConfigurationClient() { }
        public ConfigurationClient(string connectionString) { }
        public ConfigurationClient(string connectionString, Azure.Data.AppConfiguration.ConfigurationClientOptions options) { }
        public ConfigurationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ConfigurationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Data.AppConfiguration.ConfigurationClientOptions options) { }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> AddConfigurationSetting(Azure.Data.AppConfiguration.ConfigurationSetting setting, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> AddConfigurationSetting(string key, string value, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> AddConfigurationSettingAsync(Azure.Data.AppConfiguration.ConfigurationSetting setting, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> AddConfigurationSettingAsync(string key, string value, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteConfigurationSetting(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteConfigurationSetting(string key, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteConfigurationSettingAsync(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteConfigurationSettingAsync(string key, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> GetConfigurationSetting(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool onlyIfChanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> GetConfigurationSetting(Azure.Data.AppConfiguration.ConfigurationSetting setting, System.DateTimeOffset acceptDateTime, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> GetConfigurationSetting(string key, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> GetConfigurationSettingAsync(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool onlyIfChanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> GetConfigurationSettingAsync(Azure.Data.AppConfiguration.ConfigurationSetting setting, System.DateTimeOffset acceptDateTime, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> GetConfigurationSettingAsync(string key, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetConfigurationSettings(Azure.Data.AppConfiguration.SettingSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetConfigurationSettingsAsync(Azure.Data.AppConfiguration.SettingSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetRevisions(Azure.Data.AppConfiguration.SettingSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetRevisions(string key, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetRevisionsAsync(Azure.Data.AppConfiguration.SettingSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetRevisionsAsync(string key, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> SetConfigurationSetting(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> SetConfigurationSetting(string key, string value, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> SetConfigurationSettingAsync(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> SetConfigurationSettingAsync(string key, string value, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> SetReadOnly(string key, bool isReadOnly, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> SetReadOnly(string key, string label, bool isReadOnly, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> SetReadOnlyAsync(string key, bool isReadOnly, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> SetReadOnlyAsync(string key, string label, bool isReadOnly, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class ConfigurationClientOptions : Azure.Core.ClientOptions
    {
        public ConfigurationClientOptions(Azure.Data.AppConfiguration.ConfigurationClientOptions.ServiceVersion version = Azure.Data.AppConfiguration.ConfigurationClientOptions.ServiceVersion.V1_0) { }
        public enum ServiceVersion
        {
            V1_0 = 0,
        }
    }
    public static partial class ConfigurationModelFactory
    {
        public static Azure.Data.AppConfiguration.ConfigurationSetting ConfigurationSetting(string key, string value, string label = null, string contentType = null, Azure.ETag eTag = default(Azure.ETag), System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), bool? isReadOnly = default(bool?)) { throw null; }
    }
    public sealed partial class ConfigurationSetting
    {
        public ConfigurationSetting(string key, string value, string label = null) { }
        public string ContentType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.ETag ETag { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool? IsReadOnly { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Key { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Label { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.DateTimeOffset? LastModified { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Value { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    [System.FlagsAttribute]
    public enum SettingFields : uint
    {
        Key = (uint)1,
        Label = (uint)2,
        Value = (uint)4,
        ContentType = (uint)8,
        ETag = (uint)16,
        LastModified = (uint)32,
        IsReadOnly = (uint)64,
        Tags = (uint)128,
        All = (uint)4294967295,
    }
    public partial class SettingSelector
    {
        public static readonly string Any;
        public SettingSelector() { }
        public SettingSelector(string key, string label = null) { }
        public System.DateTimeOffset? AcceptDateTime { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Data.AppConfiguration.SettingFields Fields { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.Collections.Generic.IList<string> Keys { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IList<string> Labels { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class ConfigurationClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Data.AppConfiguration.ConfigurationClient, Azure.Data.AppConfiguration.ConfigurationClientOptions> AddConfigurationClient<TBuilder>(this TBuilder builder, string connectionString) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Data.AppConfiguration.ConfigurationClient, Azure.Data.AppConfiguration.ConfigurationClientOptions> AddConfigurationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
