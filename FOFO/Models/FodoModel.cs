using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOFO.Models
{
    public class FodoModel
    {
       // public string BusinessDate { get; set; }
         public string Token { get; set; }
    }

    public class Token
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        

    }

 
    public class TokenData
    {
        public string accessToken { get; set; }
        public int userId { get; set; }
    }

    public class Root_Token
    {
        public int status { get; set; }
        public TokenData data { get; set; }
        public string message { get; set; }
    }




    public class Meal
    {

        public string TOKEN { get; set; }


        public string SAPCODE { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string Price { get; set; }
        public string Cost { get; set; }
        public string Notes { get; set; }

    }


    public class CostDailyReceived
    {
        public string SAPNO { get; set; }
        public string businessDate { get; set; }
     

    }

    public class Root_CostDailyReceived
    {
        public List<CostDailyReceived> CostDailyReceived { get; set; }
        public string TOKEN { get; set; }
    }



    
    public class CostMonthlyReceived
    {
        public string SAPNO { get; set; }
        public string ZMONTH { get; set; }
        public string ZYEAR { get; set; }
        public string LOCATIONID { get; set; }
        public string COST { get; set; }
     

    }
     
    public class Root_MealCostMonthlyReceived
    {
        public List<CostMonthlyReceived> ZFODO_COST { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
    }




    public class MealPlan
    {
        //public string SAPCODEMeal { get; set; }
        //public string BusinessDate { get; set; }
        //public string SAPCODELocation { get; set; }
        //public string IsDefault { get; set; }

        public string sapLocationCode { get; set; }
        public string sapMealCode { get; set; }
        public DateTime businessDate { get; set; }
        public bool isDefault { get; set; }
    }

    public class Root_MealPlan
    {
        public List<MealPlan> MealPlans { get; set; }
         public string TOKEN { get; set; }
    }




    public class Employees
    {
        public string SAPNo { get; set; }
        public string CardNo { get; set; }
        public string Name { get; set; }
        public Boolean IsActive { get; set; }
        public string LocationId { get; set; }
        public string EmployeeTypeId { get; set; }
         
    }


    //public class Document
    //{
    //   // public string TOKEN { get; set; }

    //    public List<Employees> Employees { get; set; }
      
    //}
    public class Root
    {
        public string TOKEN { get; set; }
        public List<Employees> Employees { get; set; }
    }

}