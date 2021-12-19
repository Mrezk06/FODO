using FOFO.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FOFO.Controllers
{
    public class FODOController : ApiController
    {

       // public static string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6ImFkbWluIiwiZXhwIjoxNjMyODM3MTkyLCJpc3MiOiJGb2RvIEVtcGxveWVlIENhdGVyaW5nIEFQSS5jby51ayIsImF1ZCI6IkZvZG9FbXBsb3llZUNhdGVyaW5nQVBJQXVkaWVuY2UifQ.zzriGpM0bQrMO2wNPVq49RY72HkijmNgPFT6WARhYZA";
        //
        // GET: /FODO/




        [System.Web.Http.HttpPost]
        public HttpResponseMessage Token([FromBody]  Token BodyRequest)
        {


            string raw_API = JsonConvert.SerializeObject(BodyRequest, Formatting.Indented);

            Write_Log_ToFile(raw_API);

            var data = new StringContent(raw_API, Encoding.UTF8, "application/json");

            var url = HostModel.HostName_FODO + "Token/"; ;
                       
            var clientx = new HttpClient();
                     

            var post_request = clientx.PostAsync(url, data).Result;

            var response = post_request.Content.ReadAsStringAsync();

            var Output_response = Request.CreateResponse(HttpStatusCode.OK);

            Output_response.Content = new StringContent(response.Result, System.Text.Encoding.UTF8, "application/json");

            return Output_response;

        }





        [System.Web.Http.HttpPost]
        public string  GetToken([FromBody]  Token BodyRequest)
        {
            /*
            Website: FodoMW.elarabygroup.com
WebSite IP: 10.100.6.10:8077

            {
    "UserName": "admin",
    "Password": "0000"
}
            */

            string raw_API = JsonConvert.SerializeObject(BodyRequest, Formatting.Indented);

            Write_Log_ToFile(raw_API);

            var data = new StringContent(raw_API, Encoding.UTF8, "application/json");

            var url = HostModel.HostName_FODO + "Token/"; ;

            var clientx = new HttpClient();


            var post_request = clientx.PostAsync(url, data).Result;

            var response = post_request.Content.ReadAsStringAsync();

            var rootObject = JsonConvert.DeserializeObject<Root_Token>(response.Result);
            return rootObject.data.accessToken;

        }



//        [System.Web.Http.HttpPost]
//        public string AddNewListEmployee([FromBody]  Root BodyRequest)
//        {



//            var client = new RestClient("https://testsapapi.fodoapps.net/Sapapi/AddNewListEmployee");
//            client.Timeout = -1;
//            var request = new RestRequest(Method.POST);
//            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6ImFkbWluIiwiZXhwIjoxNjMyMjMwMDIzLCJpc3MiOiJGb2RvIEVtcGxveWVlIENhdGVyaW5nIEFQSS5jby51ayIsImF1ZCI6IkZvZG9FbXBsb3llZUNhdGVyaW5nQVBJQXVkaWVuY2UifQ.JxKpAhkWr_Wt43RwEXLizwhVmX1aKUH5OP3UqzX-12U");
//            request.AddHeader("Content-Type", "application/json");
//            var body = @"{
//" + "\n" +
//            @"    ""Employees"": [
//" + "\n" +
//            @"        {
//" + "\n" +
//            @"            ""SAPNo"": ""50006127"",
//" + "\n" +
//            @"            ""CardNo"": ""201514"",
//" + "\n" +
//            @"            ""Name"": ""هادي عبدالخالق "",
//" + "\n" +
//            @"            ""IsActive"": ""1"",
//" + "\n" +
//            @"            ""LocationId"": ""1"",
//" + "\n" +
//            @"            ""EmployeeTypeId"": ""1""
//" + "\n" +
//            @"        }
//" + "\n" +
//            @"    ]
//" + "\n" +
//            @"}";
//            request.AddParameter("application/json", body, ParameterType.RequestBody);
//            IRestResponse response = client.Execute(request);
//            Console.WriteLine(response.Content);



//            string raw_API = JsonConvert.SerializeObject(BodyRequest, Formatting.Indented);
//            var data = new StringContent(raw_API, Encoding.UTF8, "application/json");

//            var url = HostModel.HostName + "AddNewListEmployee";
//            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6ImFkbWluIiwiZXhwIjoxNjMyMjI5Njg2LCJpc3MiOiJGb2RvIEVtcGxveWVlIENhdGVyaW5nIEFQSS5jby51ayIsImF1ZCI6IkZvZG9FbXBsb3llZUNhdGVyaW5nQVBJQXVkaWVuY2UifQ.Gr2qkz7GHV_m-Zfe6eEU72c447HMMTsWkih8w3dC17E";


//            //var client = new RestSharp.RestClient(url);
//            //var request = new RestSharp.RestRequest(RestSharp.Method.POST);
//            //request.RequestFormat = RestSharp.DataFormat.Json;
//            //request.AddHeader("Content-Type", "application/json");
//            //request.AddHeader("Authorization", "Bearer " + token);
//            //request.AddJsonBody(raw_API);
//            //var response = client.Execute(request);

//            var ccc = response.StatusCode;


//            var sss = response.Content;

//            //add GetToken() API method parameters


//            var url = HostModel.HostName + "AddNewListEmployee";

//            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6ImFkbWluIiwiZXhwIjoxNjMyMjMwMDIzLCJpc3MiOiJGb2RvIEVtcGxveWVlIENhdGVyaW5nIEFQSS5jby51ayIsImF1ZCI6IkZvZG9FbXBsb3llZUNhdGVyaW5nQVBJQXVkaWVuY2UifQ.JxKpAhkWr_Wt43RwEXLizwhVmX1aKUH5OP3UqzX-12U";
//            using (var client = new HttpClient())
//            {

//                client.BaseAddress = new Uri(url);
//                client.DefaultRequestHeaders.Accept.Clear();
//                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//                client.DefaultRequestHeaders.Add("apikey", apikey);
//                client.DefaultRequestHeaders.Add("Authorization", token);


//                client.DefaultRequestHeaders.Authorization =
//                  new AuthenticationHeaderValue("Bearer", token);
//                var response = client.PostAsync(url, data).Result;


//                var ccc = response.Content.ReadAsStringAsync();

//            }






//            var post_request = clientx.PostAsync(url, data).Result;

//            var response = post_request.Content.ReadAsStringAsync();

//            var Output_response = Request.CreateResponse(HttpStatusCode.OK);

//            Output_response.Content = new StringContent(response.Result, System.Text.Encoding.UTF8, "application/json");

//            return "";

//        }


         [System.Web.Http.HttpPost]
         public HttpResponseMessage AddNewListEmployee([FromBody]  Root BodyRequest)
         {


             string raw_API = JsonConvert.SerializeObject(BodyRequest, Formatting.Indented);

             Write_Log_ToFile(raw_API);

             var data = new StringContent(raw_API, Encoding.UTF8, "application/json");

             var url = HostModel.HostName_FODO + "AddNewListEmployee";




             var clientx = new HttpClient();


             clientx.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BodyRequest.TOKEN);
             //clientx.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


             //var response_status = clientx.PostAsync(url, data).Result;
             //var ccc_status = response_status.Content.ReadAsStringAsync();




             var post_request = clientx.PostAsync(url, data).Result;

             var response = post_request.Content.ReadAsStringAsync();

             var Output_response = Request.CreateResponse(HttpStatusCode.OK);

             Output_response.Content = new StringContent(response.Result, System.Text.Encoding.UTF8, "application/json");

             return Output_response;

         }






         [System.Web.Http.HttpPost]
         public HttpResponseMessage UpdateListEmployee([FromBody]  Root BodyRequest)
         {


             string raw_API = JsonConvert.SerializeObject(BodyRequest, Formatting.Indented);

             Write_Log_ToFile(raw_API);

             var data = new StringContent(raw_API, Encoding.UTF8, "application/json");

             var url = HostModel.HostName_FODO + "UpdateListEmployee";




             var clientx = new HttpClient();

             

             clientx.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BodyRequest.TOKEN);


             //var response_status = clientx.PostAsync(url, data).Result;
             //var ccc_status = response_status.Content.ReadAsStringAsync();




             var post_request = clientx.PostAsync(url, data).Result;

             var response = post_request.Content.ReadAsStringAsync();

             var Output_response = Request.CreateResponse(HttpStatusCode.OK);

             Output_response.Content = new StringContent(response.Result, System.Text.Encoding.UTF8, "application/json");

             return Output_response;

         }





         [System.Web.Http.HttpPost]
         public HttpResponseMessage CreateNewMeal([FromBody]  Meal BodyRequest)
         {


             string raw_API = JsonConvert.SerializeObject(BodyRequest, Formatting.Indented);

             Write_Log_ToFile(raw_API);

             var data = new StringContent(raw_API, Encoding.UTF8, "application/json");

             var url = HostModel.HostName_FODO + "CreateNewMeal";




             var clientx = new HttpClient();



             clientx.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BodyRequest.TOKEN);


            

             var post_request = clientx.PostAsync(url, data).Result;

             var response = post_request.Content.ReadAsStringAsync();

             var Output_response = Request.CreateResponse(HttpStatusCode.OK);

             Output_response.Content = new StringContent(response.Result, System.Text.Encoding.UTF8, "application/json");

             return Output_response;

         }





         [System.Web.Http.HttpPost]
         public HttpResponseMessage UpdateMeal([FromBody]  Meal BodyRequest)
         {


             string raw_API = JsonConvert.SerializeObject(BodyRequest, Formatting.Indented);

            Write_Log_ToFile(raw_API);

             var data = new StringContent(raw_API, Encoding.UTF8, "application/json");

             var url = HostModel.HostName_FODO + "UpdateMeal";
             
             var clientx = new HttpClient();

            
             clientx.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BodyRequest.TOKEN);



             var post_request = clientx.PostAsync(url, data).Result;

             var response = post_request.Content.ReadAsStringAsync();

             var Output_response = Request.CreateResponse(HttpStatusCode.OK);

             Output_response.Content = new StringContent(response.Result, System.Text.Encoding.UTF8, "application/json");

             return Output_response;

         }



         [System.Web.Http.HttpPost]
        //// public HttpResponseMessage SendMealPlan([FromBody]  MealPlan BodyRequest)
        public string SendMealPlan([FromBody]  Root_MealPlan BodyRequest)
         {

           string raw_API = JsonConvert.SerializeObject(BodyRequest, Formatting.Indented);
           

           

             var url = HostModel.HostName_FODO + "SendMealPlan";
             
             
             var clientx = new HttpClient();


             clientx.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BodyRequest.TOKEN);

             raw_API = raw_API.Substring(17);//Remove : MealPlans
         

             int indexOfSteam = raw_API.IndexOf("TOKEN");
             if (indexOfSteam >= 0)
             {
                 raw_API = raw_API.Remove(indexOfSteam);

             }


             string resultxx = raw_API.Remove(raw_API.Length - 2);

              resultxx = raw_API.Remove(raw_API.Length - 1).Trim();
              raw_API = resultxx.Remove(resultxx.Length - 1);
             
              Write_Log_ToFile(raw_API);


              var data = new StringContent(raw_API, Encoding.UTF8, "application/json");
             var post_request = clientx.PostAsync(url, data).Result;

             var response = post_request.Content.ReadAsStringAsync();

             var Output_response = Request.CreateResponse(HttpStatusCode.OK);

             Output_response.Content = new StringContent(response.Result, System.Text.Encoding.UTF8, "application/json");

             //return Output_response;

             return response.Result;

         }





         [System.Web.Http.HttpPost]
         public string UpdateMealPlan([FromBody]  Root_MealPlan BodyRequest)
         {

             string raw_API = JsonConvert.SerializeObject(BodyRequest, Formatting.Indented);




             var url = HostModel.HostName_FODO + "UpdateMealPlan";


             var clientx = new HttpClient();


             clientx.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BodyRequest.TOKEN);

             raw_API = raw_API.Substring(17);//Remove : MealPlans


             int indexOfSteam = raw_API.IndexOf("TOKEN");
             if (indexOfSteam >= 0)
             {
                 raw_API = raw_API.Remove(indexOfSteam);

             }


             string resultxx = raw_API.Remove(raw_API.Length - 2);

             resultxx = raw_API.Remove(raw_API.Length - 1).Trim();
             raw_API = resultxx.Remove(resultxx.Length - 1);
             /// raw_API = raw_API.Remove(raw_API.Length - 1);
             //raw_API = raw_API.Remove(raw_API.Length - 1);
             Write_Log_ToFile(raw_API);


             var data = new StringContent(raw_API, Encoding.UTF8, "application/json");
             var post_request = clientx.PostAsync(url, data).Result;

             var response = post_request.Content.ReadAsStringAsync();

             var Output_response = Request.CreateResponse(HttpStatusCode.OK);

             Output_response.Content = new StringContent(response.Result, System.Text.Encoding.UTF8, "application/json");

             //return Output_response;

             return response.Result;

         }

         





         [System.Web.Http.HttpPost]
         public HttpResponseMessage GetEmployeeMealCostDaily([FromBody] FodoModel BodyRequest, string BusinessDate)
         {
             //FodoModel F = new FodoModel();
             //F.BusinessDate = BusinessDate;

             string raw_API = JsonConvert.SerializeObject(BusinessDate, Formatting.Indented);

             Write_Log_ToFile(raw_API);

             ///var data = new StringContent(raw_API, Encoding.UTF8, "application/json");

             var url = HostModel.HostName_FODO + "GetEmployeeMealCostDaily?BusinessDate=" + BusinessDate;




             var clientx = new HttpClient();



             clientx.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BodyRequest.Token);




             var post_request = clientx.GetAsync(url).Result;

             
             var response = post_request.Content.ReadAsStringAsync();

             var Output_response = Request.CreateResponse(HttpStatusCode.OK);

             Output_response.Content = new StringContent(response.Result, System.Text.Encoding.UTF8, "application/json");

             return Output_response;

         }






     
         [System.Web.Http.HttpPost]
         public HttpResponseMessage SendEmployeeMealCostDailyReceived([FromBody]  Root_CostDailyReceived BodyRequest)
         {


             string raw_API = JsonConvert.SerializeObject(BodyRequest, Formatting.Indented);
             raw_API = raw_API.Substring(25);
             raw_API = raw_API.Remove(raw_API.Length - 1);
             Write_Log_ToFile(raw_API);


             int indexOfSteam = raw_API.IndexOf("TOKEN");
             if (indexOfSteam >= 0)
             {
                 raw_API = raw_API.Remove(indexOfSteam);

             }


             string resultxx = raw_API.Remove(raw_API.Length - 2);

             resultxx = raw_API.Remove(raw_API.Length - 1).Trim();
             raw_API = resultxx.Remove(resultxx.Length - 1);


             var data = new StringContent(raw_API, Encoding.UTF8, "application/json");

             var url = HostModel.HostName_FODO + "SendEmployeeMealCostDailyReceived";




             var clientx = new HttpClient();



             clientx.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BodyRequest.TOKEN);




             var post_request = clientx.PostAsync(url, data).Result;

             var response = post_request.Content.ReadAsStringAsync();

             var Output_response = Request.CreateResponse(HttpStatusCode.OK);

             Output_response.Content = new StringContent(response.Result, System.Text.Encoding.UTF8, "application/json");

             return Output_response;

         }






        /// <summary>
        /// FODO WILL SEBD THIS REQUETS TO SAP
        /// </summary>
        /// <param name="json"></param>

         [System.Web.Http.HttpPost]
       ///  public HttpResponseMessage SendEmployeeMealCostMonthlyReceived([FromBody]  Root_MealCostMonthlyReceived BodyRequest)

         public HttpResponseMessage ZBAPI_FODO_COST_RECEIVED([FromBody]  Root_MealCostMonthlyReceived BodyRequest)
         {


             string raw_API = JsonConvert.SerializeObject(BodyRequest, Formatting.Indented);
             //raw_API = raw_API.Substring(25);
             //raw_API = raw_API.Remove(raw_API.Length - 1);
             Write_Log_ToFile(raw_API);


             //int indexOfSteam = raw_API.IndexOf("TOKEN");
             //if (indexOfSteam >= 0)
             //{
             //    raw_API = raw_API.Remove(indexOfSteam);

             //}


             //string resultxx = raw_API.Remove(raw_API.Length - 2);

             //resultxx = raw_API.Remove(raw_API.Length - 1).Trim();
             //raw_API = resultxx.Remove(resultxx.Length - 1);


             var data = new StringContent(raw_API, Encoding.UTF8, "application/json");

             var url = HostModel.HostName_SAP + "ZBAPI_FODO_COST_RECEIVED" + HostModel.Client; ;




             var clientx = new HttpClient();



            /// clientx.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BodyRequest.TOKEN);




             var post_request = clientx.PostAsync(url, data).Result;

             var response = post_request.Content.ReadAsStringAsync();

             var Output_response = Request.CreateResponse(HttpStatusCode.OK);

             Output_response.Content = new StringContent(response.Result, System.Text.Encoding.UTF8, "application/json");

             return Output_response;

         }


        private void Write_Log_ToFile(string json)
        {

            string filename = String.Format("{0}", DateTime.Now.ToString("ddMMyyyy_HHmmss")) + ".txt"; ;
            string path = Path.Combine(@"C:\TradersInventory_LOG", filename);
            System.IO.File.WriteAllText(path, json);



        }


	}
}