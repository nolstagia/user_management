using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_API.Contract.Requests
{
    public class PermissionRequest
    {
        public string Screen { set; get; }
        public string Name { set; get; }
    }
}
