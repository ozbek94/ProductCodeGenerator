namespace ProductCodeGenarator.Domain.Services.Code
{
    public interface ICodeService
    {
        Task<List<string>> GenerateCodes(int Count);
        Task<bool> CheckCode(string Code);
    }
}
