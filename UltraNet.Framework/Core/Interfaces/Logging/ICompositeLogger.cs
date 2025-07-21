namespace UltraNet.Framework.Core.Interfaces.Logging
{
    public interface ICompositeLogger
    {
        void Info(string message);
        void Warning(string message);
        void Error(string message, Exception? ex = null);
    }
}
