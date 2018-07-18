using SportsStore2.WebUI.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SportsStore2.WebUI.Infrastructure.Concrete
{
    public class FormAuthenticate : IAuthor
    {
        public bool Authenticate(string p_UserName, string p_Password)
        {
            bool result = false;

            result = FormsAuthentication.Authenticate(p_UserName, p_Password);

            if (result)
            {
                FormsAuthentication.SetAuthCookie(p_UserName, false);
            }

            return result;
        }
    }
}