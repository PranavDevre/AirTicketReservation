using System;

namespace AIR_RESERVATION_SYSTEM_API.Exception
{
    public class AdminCredentialInvalidExceptions : ApplicationException
    {
        public AdminCredentialInvalidExceptions()
        {

        }

        public AdminCredentialInvalidExceptions(string msg) : base(msg)
        {

        }
    }
}
