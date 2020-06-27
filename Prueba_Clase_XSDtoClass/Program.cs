using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Prueba_Clase_XSDtoClass
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nuevo Documento
            InvoiceType oInvoiceType = new InvoiceType();
            UBLVersionIDType oUBLVersionIDType = new UBLVersionIDType();
            oUBLVersionIDType.Value = "2.1";

            oInvoiceType.UBLVersionID = oUBLVersionIDType;

            
            //Arreglo TaxAmountype
            TaxAmountType taxAmountType = new TaxAmountType();
            taxAmountType.Value = 10;
            taxAmountType.currencyCodeListVersionID = "100"; //Atributos

            //Arreglo de taxSubTotalType
            TaxSubtotalType taxSubtotalType_igv = new TaxSubtotalType();
            taxSubtotalType_igv.TaxAmount = taxAmountType;
            TaxSubtotalType[] taxSubtotalType = { taxSubtotalType_igv };

            //Arreglo TaxTotalType
            TaxTotalType TaxTotalType_1 = new TaxTotalType();
            TaxTotalType_1.TaxSubtotal = taxSubtotalType;
            TaxTotalType[] taxTotalType = { TaxTotalType_1 };
 
            oInvoiceType.TaxTotal = taxTotalType;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(InvoiceType));
            var swf = new StringWriter();
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add("cbc","urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            xmlSerializer.Serialize(XmlWriter.Create(swf),oInvoiceType, xmlSerializerNamespaces);
            string sXML = swf.ToString();
            System.IO.File.WriteAllText("prueba.xml", sXML);
            
        }
    }
}
