using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
  public interface ITAUserPermissionRepo
    {
        string GetTAUserPermission(string username);
    }
}
