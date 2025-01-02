using NunitCompetition.Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NunitCompetition.Utilities
{
    public class InputAddCertificate

    {





        public static void InputCertificate(string cert,string from,string year)
        {


           
            CertificatePage.Certificate(cert);
            CertificatePage.From(from);
            CertificatePage.Year(year);
            CertificatePage.ClickAddButton();  //Locate Add button and click

        }
    }
}
