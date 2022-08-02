using System;
using System.Collections.Generic;
using System.Text;

namespace FG.Authentication.Interface
{
    public interface IJTAuth
    {
        string Authentication(string username, string password);
    }
}
