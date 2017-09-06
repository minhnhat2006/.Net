using System.Collections.Generic;

namespace QLMamNon.Service.SMS
{
    public interface ISMS
    {
        void SendSMS(List<string> phoneNumbers, string content);
    }
}
