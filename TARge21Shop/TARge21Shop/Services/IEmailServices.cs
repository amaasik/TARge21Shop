using TARge21Shop.Models;

namespace TARge21Shop.Services
{
    public interface IEmailServices
    {
        void SendEmail(EmailDto request);
    }
}
