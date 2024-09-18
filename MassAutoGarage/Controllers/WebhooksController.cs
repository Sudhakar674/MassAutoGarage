using MassAutoGarage.Models.Facebook;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MassAutoGarage.Controllers
{
    public class WebhooksController : ApiController
    {

        //public async Task<HttpResponseMessage> Post([FromBody] JsonDataModel data)
        //{
        //    try
        //    {
        //        var entry = data.Entry.FirstOrDefault();
        //        var change = entry?.Changes.FirstOrDefault();
        //        if (change == null) return new HttpResponseMessage(HttpStatusCode.BadRequest);

        //        //Generate user access token here https://developers.facebook.com/tools/accesstoken/
        //        const string token = "abcxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";

        //        var leadUrl = $"https://graph.facebook.com/v14.0/{change.Value.LeadGenId}?access_token={token}";
        //        var formUrl = $"https://graph.facebook.com/v14.0/{change.Value.FormId}?access_token={token}";

        //        using (var httpClientLead = new HttpClient())
        //        {
        //            var response = await httpClientLead.GetStringAsync(formUrl);
        //            if (!string.IsNullOrEmpty(response))
        //            {
        //                var jsonobjLead = JsonConvert.DeserializeObject<LeadFormData>(response);
        //                using (var httpClientFields = new HttpClient())
        //                {
        //                    var responseFields = await httpClientFields.GetStringAsync(leadUrl);
        //                    if (!string.IsNullOrEmpty(responseFields))
        //                    {
        //                        var jsonObjFields = JsonConvert.DeserializeObject<LeadData>(responseFields);
        //                        Lead obj = new Lead();

        //                        foreach (var t in jsonObjFields.FieldData)
        //                        {
        //                            if (t.Name == "full_name")
        //                            {
        //                                //leadnovo.name = t.Values.FirstOrDefault();
        //                            }
        //                            if (t.Name == "first_name")
        //                            {
        //                                obj.first_name = t.Values.FirstOrDefault();
        //                            }
        //                            if (t.Name == "last_name")
        //                            {
        //                                obj.last_name = t.Values.FirstOrDefault();
        //                            }
        //                            else if (t.Name == "email")
        //                            {
        //                                obj.email = t.Values.FirstOrDefault();
        //                            }
        //                            else if (t.Name == "phone_number")
        //                            {
        //                                obj.phon_number = t.Values.FirstOrDefault();
        //                            }
        //                            else if (t.Name == "work_phone_number")
        //                            {
        //                                obj.work_phone_number = t.Values.FirstOrDefault();
        //                            }
        //                            else if (t.Name == "campaign_name")
        //                            {
        //                                obj.campaign_name = t.Values.FirstOrDefault();
        //                            }
        //                            else if (t.Name == "platform")
        //                            {
        //                                obj.platform = t.Values.FirstOrDefault();
        //                            }
        //                            else
        //                            {

        //                            }
        //                        }

        //                        obj.LeadID = jsonobjLead.Id;
        //                        obj.campaign_name = jsonobjLead.Name;
        //                        obj.CreatedOn = DateTime.Now;

        //                        // db.Leads.add(obj);
        //                        // db.SaveChange();


        //                    }
        //                }
        //            }
        //        }
        //        return new HttpResponseMessage(HttpStatusCode.OK);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}

    }
}
