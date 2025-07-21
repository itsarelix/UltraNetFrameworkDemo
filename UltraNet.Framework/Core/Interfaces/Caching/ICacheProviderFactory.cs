namespace UltraNet.Framework.Core.Interfaces.Caching
{
    public interface ICacheProviderFactory
    {
        ICacheProvider GetProvider(string name);
    }
}
