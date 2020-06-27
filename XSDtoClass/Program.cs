using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XSDtoClass
{
    class Program
    {
        static void Main(string[] args)
        {
            InvoiceType invoiceType = new InvoiceType();

            UBLVersionIDType uBLVersionIDType = new UBLVersionIDType();
            uBLVersionIDType.Value = "2.1";
            invoiceType.UBLVersionID = uBLVersionIDType;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(InvoiceType));
            var oStringWriter = new StringWriter();
            xmlSerializer.Serialize(XmlWriter.Create(oStringWriter), invoiceType);
            string stringXML = oStringWriter.ToString();
            System.IO.File.WriteAllText("XML_Sunat.xml",stringXML);

        }
    }
}
