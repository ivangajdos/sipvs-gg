using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml;
using System.Xml.Schema;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Xsl;
using System.Net.Mail;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace app.Pages;

public class IndexModel : PageModel
{
    public string XMLfilePath = "C:\\Users\\Ivo\\Desktop\\SIPVS\\Project\\SIPVS2023-main\\app\\MyNewFile.xml";
    public string XSDfilePath = "C:\\Users\\Ivo\\Desktop\\SIPVS\\Project\\SIPVS2023-main\\app\\PrihlasenieSchema.xsd";
    public string XSLfilePath = "C:\\Users\\Ivo\\Desktop\\SIPVS\\Project\\SIPVS2023-main\\app\\PrihlasenieStranka.xsl";
    public DateTime CurrentDate { get; set; }
    //clovek
    public string meno = "";
    public string adresa = "";
    public string rodne_cislo = "";
    public string kontakt = "";


    public string meno0 = "";
    public string adresa0 = "";
    public string rodne_cislo0 = "";
    public string kontakt0 = "";






    public string meno1 = "";
    public string adresa1 = "";
    public string rodne_cislo1 = "";
    public string kontakt1 = "";

    // Pes
    public string zariadenie = "";
    public string narodenie_psa = "";
    public string drzba_psa = "";
    public string meno_psa = "";
    public string plemeno = "";
    public string pohlavie = "";
    public string farba = "";
    public string znamka = "";
    public string c_cipu = "";
    public string pocet_psov = "";
    public string pohryznutie = "";
    public string button = "";
    public string datum = "";
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult OnGetXmlData()
    {
        try
        {
            XDocument xmlDoc = XDocument.Load("MyNewFile.xml");

            return Content(xmlDoc.ToString(), "text/xml");
        }
        catch (Exception ex)
        {
            return BadRequest("Error loading XML: " + ex.Message);
        }
    }

    [HttpGet]
    public IActionResult OnGetXsdData()
    {
        try
        {
            XDocument xmlDoc = XDocument.Load("PrihlasenieSchema.xsd");

            return Content(xmlDoc.ToString(), "text/xml");
        }
        catch (Exception ex)
        {
            return BadRequest("Error loading XML: " + ex.Message);
        }
    }

    [HttpGet]
    public IActionResult OnGetXslData()
    {
        try
        {
            XDocument xmlDoc = XDocument.Load("PrihlasenieStranka.xsl");

            return Content(xmlDoc.ToString(), "text/xml");
        }
        catch (Exception ex)
        {
            return BadRequest("Error loading XML: " + ex.Message);
        }
    }

    public void OnGet()
    {
        CurrentDate = DateTime.Today;
    }

    public void OnPost()
    {
        button = Request.Form["in"].ToString() ?? " ";
        meno = Request.Form["meno"].ToString() ?? " ";
        adresa = Request.Form["adresa"].ToString() ?? " ";
        rodne_cislo = Request.Form["rodne_cislo"].ToString() ?? " ";
        kontakt = Request.Form["kontakt"].ToString() ?? " ";

        meno0 = Request.Form["meno0"].ToString() ?? " ";
        adresa0 = Request.Form["adresa0"].ToString() ?? " ";
        rodne_cislo0 = Request.Form["rodne_cislo0"].ToString() ?? " ";
        kontakt0 = Request.Form["kontakt0"].ToString() ?? " ";

        meno1 = Request.Form["meno1"].ToString() ?? " ";
        adresa1 = Request.Form["adresa1"].ToString() ?? " ";
        rodne_cislo1 = Request.Form["rodne_cislo1"].ToString() ?? " ";
        kontakt1 = Request.Form["kontakt1"].ToString() ?? " ";

        zariadenie = Request.Form["zariadenie"].ToString() ?? " ";
        meno_psa = Request.Form["meno_psa"].ToString() ?? " ";
        narodenie_psa = Request.Form["narodenie_psa"].ToString() ?? " ";
        c_cipu = Request.Form["c_cipu"].ToString() ?? " ";
        pohryznutie = Request.Form["pohryznutie"].ToString() ?? " ";
        button = Request.Form["in"].ToString() ?? " ";
        pocet_psov = Request.Form["pocet_psov"].ToString() ?? " ";
        znamka = Request.Form["znamka"].ToString() ?? " ";
        datum = Request.Form["datum"].ToString() ?? " ";
        pohlavie = Request.Form["pohlavie"].ToString() ?? " ";
        farba = Request.Form["farba"].ToString() ?? " ";
        drzba_psa = Request.Form["drzba_psa"].ToString() ?? " ";
        plemeno = Request.Form["plemeno"].ToString() ?? " ";

        if (pohryznutie == "false")
        {
            pohryznutie = "false";
        }
        else
        {
            pohryznutie = "true";
        }
        if (button == "Over")
        {
            ValidateXmlWithXsd();
        }
        else if (button == "Podpíš")
        {

        }
        else if (button == "Ulož")
        {
            GenerateXML();
        }

        else
        {
            transformXML();
        }


        Page();




    }

    public IActionResult OnPostMyButtonClick()
    {
        ValidateXmlWithXsd();
        return RedirectToPage("index");
    }

    public void GenerateXML()
    {
        string kontaktTyp = "telefon";
        if (validMail(kontakt))
        {
            kontaktTyp = "email";
        }


        XNamespace xmlns = "http://example.com/PrihlasenieSchema.xsd";
        XDocument xmlDocument = new XDocument(
           new XDeclaration("1.0", "utf-8", "yes"),
           new XElement(xmlns + "reg_formular",
               new XElement(xmlns + "pes",
                   new XElement(xmlns + "osoba",
                       new XElement(xmlns + "meno", meno),
                       new XElement(xmlns + "adresa", adresa),
                       new XElement(xmlns + "rodne_cislo", rodne_cislo),
                       new XElement(xmlns + "kontakt", new XAttribute("typ", kontaktTyp), kontakt)),
                   new XElement(xmlns + "zariadenie", zariadenie),
                   new XElement(xmlns + "narodenie_psa", narodenie_psa),
                   new XElement(xmlns + "drzba_psa", drzba_psa),
                   new XElement(xmlns + "meno_psa", meno_psa),
                   new XElement(xmlns + "plemeno", plemeno),
                   new XElement(xmlns + "pohlavie", pohlavie),
                   new XElement(xmlns + "farba", farba),
                   new XElement(xmlns + "znamka", znamka),
                   new XElement(xmlns + "c_cipu", c_cipu),
                   new XElement(xmlns + "pocet_psov", pocet_psov),
                   new XElement(xmlns + "pohryznutie", pohryznutie),
                   new XElement(xmlns + "datum", datum)
               )
           )
       );
        XElement osobaElement = xmlDocument.Descendants().Where(e => e.Name.LocalName == "osoba").FirstOrDefault();
        if (meno1 != "")
        {
            osobaElement.AddAfterSelf(new XElement(xmlns + "osoba",
                     new XElement(xmlns + "meno", meno1),
                     new XElement(xmlns + "adresa", adresa1),
                     new XElement(xmlns + "rodne_cislo", rodne_cislo1),
                     new XElement(xmlns + "kontakt", new XAttribute("typ", kontaktTyp), kontakt1)));
        }
        if (meno0 != "")
        {
            osobaElement.AddAfterSelf(new XElement(xmlns + "osoba",
                     new XElement(xmlns + "meno", meno0),
                     new XElement(xmlns + "adresa", adresa0),
                     new XElement(xmlns + "rodne_cislo", rodne_cislo0),
                     new XElement(xmlns + "kontakt", new XAttribute("typ", kontaktTyp), kontakt0)));
        }


        xmlDocument.Save(XMLfilePath);
        ViewData["result"] = "XML Vytvorený";
    }

    public void ValidateXmlWithXsd()
    {
        XmlReaderSettings xmlSettings = new XmlReaderSettings();
        xmlSettings.Schemas.Add("http://example.com/PrihlasenieSchema.xsd", "C:\\Users\\Ivo\\Desktop\\SIPVS\\Project\\SIPVS2023-main\\app\\PrihlasenieSchema.xsd");
        xmlSettings.ValidationType = ValidationType.Schema;

        xmlSettings.ValidationFlags |= System.Xml.Schema.XmlSchemaValidationFlags.ProcessSchemaLocation;
        xmlSettings.ValidationFlags |= System.Xml.Schema.XmlSchemaValidationFlags.ReportValidationWarnings;
        xmlSettings.ValidationEventHandler += ValidationEventHandler;
        XmlReader verificator = XmlReader.Create(XMLfilePath, xmlSettings);

        try
        {

            while (verificator.Read()) { }
            verificator.Close();
            ViewData["result"] = "Validation Passed";
        }
        catch (Exception e)
        {
            verificator.Close();
            ViewData["result"] = e.Message;
        }



    }

    static void ValidationEventHandler(object sender, ValidationEventArgs e)
    {
        if (e.Severity == XmlSeverityType.Warning)
        {
            Console.Write("WARNING: ");
            Console.WriteLine(e.Message);
            throw new Exception("Validation failed.  Message: " + e.Message);
        }
        else if (e.Severity == XmlSeverityType.Error)
        {
            Console.Write("ERROR: ");
            Console.WriteLine(e.Message);
            throw new Exception("Validation failed.  Message: " + e.Message);
        }
    }

    public void transformXML()
    {
        string xmlString = System.IO.File.ReadAllText(XMLfilePath);
        string xsltString = System.IO.File.ReadAllText(XSLfilePath);
        XslCompiledTransform transform = new XslCompiledTransform();
        using (XmlReader reader = XmlReader.Create(new StringReader(xsltString)))
        {
            transform.Load(reader);
        }
        StringWriter results = new StringWriter();
        using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
        {
            transform.Transform(reader, null, results);

        }
        StreamWriter sw1 = new StreamWriter("../TestDocs.html");
        sw1.Write(results);
        ViewData["result"] = "HTML úspešne vytvorené";
        sw1.Flush();
        sw1.Close();
        sw1.Dispose();

    }

    public bool validMail(string emailaddress)
    {
        try
        {
            MailAddress m = new MailAddress(emailaddress);

            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }



}
