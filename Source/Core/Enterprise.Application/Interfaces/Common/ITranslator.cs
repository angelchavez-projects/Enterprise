namespace Enterprise.Application.Interfaces.Common
{
    public interface ITranslator
    {
        string this[string name] { get; }

        string GetString(string name);
        string GetString();
    }
}
