using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore2.WebUI.Infrastructure.Abstract
{
    public interface IAuthor
    {
        bool Authenticate(string p_UserName, string p_Password);
    }
}
