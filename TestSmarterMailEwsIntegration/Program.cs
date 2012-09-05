using System;
using System.Net;
using Microsoft.Exchange.WebServices.Data;

namespace TestSmarterMailEwsIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://spsdevserver:9998/EWS/Exchange.asmx"; // "https://192.168.150.1/EWS/Exchange.asmx";
            var username = "steinjak@sps.connectdemo"; //"MaryN";
            var password = "password1"; //"pass@word1";
            var domain = (string)null; //"CONTOSO";

            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true; // ignore certificate errors for HTTPS
            var exchange = new ExchangeService(ExchangeVersion.Exchange2007_SP1)
            {
                Url = new Uri(url),
                Credentials = new WebCredentials(username, password, domain),
            };

            // req#1: this succeeds
            Test("GetUserAvailability (FreeBusy only)",
                () => exchange.GetUserAvailability(new[]{new AttendeeInfo{SmtpAddress = username}}, new TimeWindow(DateTime.Today, DateTime.Today.AddDays(1)), AvailabilityData.FreeBusy));
            // req#2: this fails with an empty response
            Test("GetUserAvailability (FreeBusyAndSuggestions)",
                () => exchange.GetUserAvailability(new[]{new AttendeeInfo{SmtpAddress = username}}, new TimeWindow(DateTime.Today, DateTime.Today.AddDays(1)), AvailabilityData.FreeBusyAndSuggestions));
            // req#3: this fails because the ResponseMessages xml element is empty
            Test("CreateItem",
                () =>
                    {
                        var appointment = new Appointment(exchange);
                        appointment.Start = DateTime.Today.AddHours(10);
                        appointment.End = DateTime.Today.AddHours(12);
                        appointment.Subject = "Test appointment";
                        appointment.Save();
                    });
        }

        private static void Test(string name, Action executeAction)
        {
            Console.WriteLine("\n\nExecuting {0}", name);
            try
            {
                executeAction();
                Console.WriteLine("  -> {0} succeeded", name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when executing {0}, {1}: {2}", name, e.GetType().Name, e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
