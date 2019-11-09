using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABMWebService.Classes
{
    public enum ValidationStatus
    {
        ValidStructure = 0,
        InvalidDeclarationCommand = -1,
        InvalidSiteId = -2
    }
}