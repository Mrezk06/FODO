using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOFO.Models
{
    public class HostModel
    {

        //DEV FODO
        //public static string HostName_FODO = "https://testsapapi.fodoapps.net/Sapapi/";
        //public static string Client = "?SAP-CLIENT=110";



        //  FODO PRD
        public static string HostName_FODO = "http://10.9.2.200:8844/Sapapi/";
        //public static string Client = "?SAP-CLIENT=110";



        //SAP DEV
        //public static string HostName = "http://10.10.3.11:8000/SAP/fmcall/";
        //public static string Client = "?SAP-CLIENT=100";


         


        // SAP PRODUCTION
//public static string HostName_SAP = "http://10.10.3.11:8000/SAP/fmcall/";
        public static string HostName_SAP = "http://prodci2.elarabygroup.com:8001/SAP/TRDINV/";
        public static string Client = "?SAP-CLIENT=100";


    }
}