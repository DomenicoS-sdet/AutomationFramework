using System;
using System.Collections.Generic;
using System.Text;
using PageObjects.Common;
using Coypu;
using Utility.HelperObjects;

namespace PageObjects.Pages
{
    public class HomePage : Page
    {

        public HomePage(BrowserSession browserSession) : base(browserSession)
        {
            _browserSession = browserSession;
        }

        private ElementScope SearchBtn => _browserSession.FindXPath("//button[text() = ' Search']");
        private ElementScope CitySearch => _browserSession.FindXPath("//span[text()='Search by Hotel or City Name']/parent::a/parent::div//input");
        private ElementScope CheckIn => _browserSession.FindXPath("//input[@placeholder=\"Check in\" and @name='checkin']");
        private ElementScope CheckOut => _browserSession.FindXPath("//input[@placeholder=\"Check out\" and @name='checkout']");
        private ElementScope TravellersInput => _browserSession.FindId("htravellersInput");
        private ElementScope AdultInput => _browserSession.FindId("hadultInput");
        private ElementScope ChildInput => _browserSession.FindId("hchildInput");

        public bool IsHomePageReady()
        {
            return SearchBtn.Exists();
        }

        public void StartSearch() => SearchBtn.Click();

        public void FillHotelSearchFields(HotelSearch hotelSearch)
        {
            CitySearch.SendKeys(hotelSearch.City);
            _browserSession.FindXPath($"//*[text()='Locations']/following-sibling::ul/li//span[text()='{hotelSearch.City}']").Click();

            CheckIn.FillInWith(hotelSearch.CheckIn);
            CheckOut.FillInWith(hotelSearch.CheckOut);

            TravellersInput.Click();

            //fill the adult and child fields by pressing the + or - button
            while(!AdultInput.GetAttribute("value").Equals(hotelSearch.Adults))
            {
                if(int.Parse(AdultInput.GetAttribute("value")) < int.Parse(hotelSearch.Adults))
                {
                    _browserSession.FindId("hadultPlusBtn").Click();
                }
                else
                {
                    _browserSession.FindId("hadultMinusBtn").Click();
                }
            }
            while (!ChildInput.GetAttribute("value").Equals(hotelSearch.Childs))
            {
                if (int.Parse(ChildInput.GetAttribute("value")) < int.Parse(hotelSearch.Childs))
                {
                    _browserSession.FindId("hchildPlusBtn").Click();
                }
                else
                {
                    _browserSession.FindId("hchildMinusBtn").Click();
                }
            }

            TravellersInput.Click(); //to save the changes to the adult and child fields
        }
    }
}
