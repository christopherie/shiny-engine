using ABMWebService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABMWebService.Classes
{
    public class DeclarationDocument
    {
        public string DocumentStructure { get; set; }
        public string DeclarationCommand { get; set; }
        public string SiteId { get; set; }
    }
}