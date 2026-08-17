using CisCore.Models;

namespace CisCore.Helper
{
    public interface IMailService
    {
        Task SendEmailAsync(Mail model);
    }
}
