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
    public class InputAddEducation

    {
        
        public static void InputEducation(string university, string degree, string country, string title, string year)
        {


            EducationPage.LocateEnterUniversityTextbox(university);
            EducationPage.Country(country);
            EducationPage.Title(title);
            EducationPage.LocateEnterDegreeTextbox(degree);
            EducationPage.YearOption(year);
            EducationPage.ClickAddButton();  //Locate Add button and click

        }
    }
}
