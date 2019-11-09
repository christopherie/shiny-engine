using ABMWebService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMWebService.Interfaces
{
    public interface IDocumentValidation
    {
        DeclarationDocument ValidateDocument(string doc);
    }
}
