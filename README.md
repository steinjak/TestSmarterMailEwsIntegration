Reproduction of problems with SmarterMail EWS integration
========
This is a minimal program to reproduce the problems we're facing when trying to integrate with
SmarterMail 10 through EWS, created to make it easier on the engineers following up our
support request.

See FiddlerTrace.txt for a full trace of this transaction towards SmarterMail. Change urls/usernames/etc
for debugging; commented-out versions are the ones needed to connect to the Exchange Server 2010 VHD
published by Microsoft.

This program runs without error when run against MS Exchange 2010 SP1 with Update Rollup 4 installed.

Output:
```


Executing GetUserAvailability (FreeBusy only)
  -> GetUserAvailability (FreeBusy only) succeeded


Executing GetUserAvailability (FreeBusyAndSuggestions)
Error when executing GetUserAvailability (FreeBusyAndSuggestions), ServiceReques
tException: The request failed. The remote server returned an error: (504) Gatew
ay Timeout.
   at Microsoft.Exchange.WebServices.Data.ServiceRequestBase.GetEwsHttpWebRespon
se(HttpWebRequest request)
   at Microsoft.Exchange.WebServices.Data.ServiceRequestBase.ValidateAndEmitRequ
est(HttpWebRequest& request)
   at Microsoft.Exchange.WebServices.Data.ExchangeService.GetUserAvailability(IE
numerable`1 attendees, TimeWindow timeWindow, AvailabilityData requestedData, Av
ailabilityOptions options)
   at Microsoft.Exchange.WebServices.Data.ExchangeService.GetUserAvailability(IE
numerable`1 attendees, TimeWindow timeWindow, AvailabilityData requestedData)
   at TestSmarterMailEwsIntegration.Program.<>c__DisplayClass8.<Main>b__5() in C
:\Development\vs\TestSmarterMailEwsIntegration\TestSmarterMailEwsIntegration\Pro
gram.cs:line 28
   at TestSmarterMailEwsIntegration.Program.Test(String name, Action executeActi
on) in C:\Development\vs\TestSmarterMailEwsIntegration\TestSmarterMailEwsIntegra
tion\Program.cs:line 46


Executing CreateItem
Error when executing CreateItem, ServiceXmlDeserializationException: The expecte
d XML node type was Element, but the actual type is EndElement.
   at Microsoft.Exchange.WebServices.Data.EwsXmlReader.Read(XmlNodeType nodeType
)
   at Microsoft.Exchange.WebServices.Data.EwsXmlReader.InternalReadElement(XmlNa
mespace xmlNamespace, String localName, XmlNodeType nodeType)
   at Microsoft.Exchange.WebServices.Data.ServiceResponse.LoadFromXml(EwsService
XmlReader reader, String xmlElementName)
   at Microsoft.Exchange.WebServices.Data.MultiResponseServiceRequest`1.ParseRes
ponse(EwsServiceXmlReader reader)
   at Microsoft.Exchange.WebServices.Data.ServiceRequestBase.ReadResponse(EwsSer
viceXmlReader ewsXmlReader)
   at Microsoft.Exchange.WebServices.Data.SimpleServiceRequestBase.ReadResponse(
HttpWebResponse response)
   at Microsoft.Exchange.WebServices.Data.MultiResponseServiceRequest`1.Execute(
)
   at Microsoft.Exchange.WebServices.Data.ExchangeService.InternalCreateItems(IE
numerable`1 items, FolderId parentFolderId, Nullable`1 messageDisposition, Nulla
ble`1 sendInvitationsMode, ServiceErrorHandling errorHandling)
   at Microsoft.Exchange.WebServices.Data.Item.InternalCreate(FolderId parentFol
derId, Nullable`1 messageDisposition, Nullable`1 sendInvitationsMode)
   at Microsoft.Exchange.WebServices.Data.Item.Save()
   at TestSmarterMailEwsIntegration.Program.<>c__DisplayClass8.<Main>b__6() in C
:\Development\vs\TestSmarterMailEwsIntegration\TestSmarterMailEwsIntegration\Pro
gram.cs:line 37
   at TestSmarterMailEwsIntegration.Program.Test(String name, Action executeActi
on) in C:\Development\vs\TestSmarterMailEwsIntegration\TestSmarterMailEwsIntegra
tion\Program.cs:line 46
Press any key to continue . . .
```