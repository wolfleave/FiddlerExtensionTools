using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;
using EventReportTest;
using Fiddler;
using Newtonsoft.Json;

[assembly: RequiredVersion("2.1.8.1")]
namespace EventReportTool
{
    public class EventReportExtension : IFiddlerExtension
    {
        public void OnLoad()
        {
            //throw new NotImplementedException();
        }

        public void OnBeforeUnload()
        {
            //throw new NotImplementedException();
        }
    }

    public class EventReportAutoTamper:IAutoTamper
    {
        private const string MyouHost = "myou.cvte.com";
        private const string Url = "myou.cvte.com/friday/agent/api/app/v2/report";
        private EventReportControl eventReportControl;

        public void OnLoad()
        {
            var eventReportPage = new TabPage("EventReport");
            eventReportPage.ImageIndex = (int) SessionIcons.Silverlight;
            eventReportControl = new EventReportControl();
            eventReportPage.Controls.Add(eventReportControl);
            FiddlerApplication.UI.tabsViews.TabPages.Add(eventReportPage);
        }

        public void OnBeforeUnload()
        {
            //throw new NotImplementedException();
        }

        public IList<string> EventList=new List<string>(); 

        public void AutoTamperRequestBefore(Session oSession)
        {
            //throw new NotImplementedException();
            //if (oSession.host == MyouHost &&
            //    oSession.url.Contains("http://myou.cvte.com/friday/agent/api/app/v2/report"))
            if (oSession.host == MyouHost && oSession.url== Url)
            {
                var requestBody = oSession.RequestBody;
                var stream=new MemoryStream(requestBody);
                var reader=new StreamReader(stream);
                var text = reader.ReadToEnd();

                var model = JsonConvert.DeserializeObject<EventModel>(text);
                if (model != null)
                {
                    FiddlerApplication.Log.LogString(oSession.url);
                    foreach (var dict in model.SP)
                    {
                        string eventItem = String.Empty;
                        foreach (var keyValuePair in dict)
                        {
                            if (keyValuePair.Key == "$code")
                            {
                                eventItem = keyValuePair.Value.ToString();
                                continue;
                            }
                            if (keyValuePair.Key == "value")
                            {
                                eventItem = eventItem + ":" + keyValuePair.Value;
                            }

                            if (keyValuePair.Key == "$ts")
                            {
                                continue;
                            }
                            eventItem = eventItem + "[" + keyValuePair.Key + ":" + keyValuePair.Value + "]";
                        }
                        EventList.Add(eventItem);
                    }
                }

                text= EventList.Aggregate(String.Empty, (current, item) => current + (item + Environment.NewLine));
                FiddlerApplication.Log.LogString(text);
                eventReportControl.UpdateEvent(EventList);
            }
        }

        [DataContract]
        private class EventModel
        {
            [DataMember(Name = "$sp")]
            public IList<IDictionary<string, object>> SP { get; set; }
        }

        public void AutoTamperRequestAfter(Session oSession)
        {
            //throw new NotImplementedException();
        }

        public void AutoTamperResponseBefore(Session oSession)
        {
            //throw new NotImplementedException();
        }

        public void AutoTamperResponseAfter(Session oSession)
        {
            //throw new NotImplementedException();
        }

        public void OnBeforeReturningError(Session oSession)
        {
            //throw new NotImplementedException();
        }
    }
}
