using ABMWebService.Classes;
using ABMWebService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace ABMWebService
{
    /// <summary>
    /// Summary description for DocumentValidationWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DocumentValidationWebService : System.Web.Services.WebService, IDocumentValidation
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public DeclarationDocument ValidateDocument(string doc)
        {
            const string nodePattern = "InputDocument/DeclarationList/Declaration";
            DeclarationDocument declarationDocument = new DeclarationDocument();
            XmlDocument xmlDocument = new XmlDocument();

            try
            {
                xmlDocument.LoadXml(doc);

                foreach (XmlNode item in xmlDocument.SelectNodes(nodePattern))
                {
                    string commandAttribute = item.Attributes["Command"].Value;

                    if (commandAttribute == "DEFAULT")
                    {
                        declarationDocument.DeclarationCommand = ValidationStatus.InvalidDeclarationCommand.ToString("D");
                    }
                }

                foreach (XmlNode t in xmlDocument.GetElementsByTagName("SiteID"))
                {
                    string siteId = t.FirstChild.InnerText;

                    if (siteId == "DUB")
                    {
                        declarationDocument.SiteId = ValidationStatus.InvalidSiteId.ToString("D");
                    }
                }

                declarationDocument.DocumentStructure = ValidationStatus.ValidStructure.ToString("D");

                return declarationDocument;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                declarationDocument.DocumentStructure = "";
                declarationDocument.DeclarationCommand = "";
                declarationDocument.SiteId = "";
                return declarationDocument;
            }

        }
    }
}
