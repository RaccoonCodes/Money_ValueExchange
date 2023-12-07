using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Money_ValueExchange.Website
{
    public partial class Main_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                CombineDropList(CurrencyID);
                CombineDropList(Currency2ID);
            }
        }
        private void CombineDropList(DropDownList addlist)
        {
            addlist.Items.Add(new ListItem("USD", "Dollar(s)"));
            addlist.Items.Add(new ListItem("MXN", "Peso(s)"));
            addlist.Items.Add(new ListItem("JPY", "Yen"));
            addlist.Items.Add(new ListItem("AUD", "Australian Dollar(s)"));
        }

        protected void BtnEnterID_Click(object sender, EventArgs e)
        {
            string currency1 = CurrencyID.SelectedValue;
            string currency2 = Currency2ID.SelectedValue;
            string inputValue = InputCashID.Text;
            string printresult = " ";
            string formatedTotal = "";
            string workShown = "";
            
           decimal total = 0;
        
            if(currency1 == currency2)
            {
                printresult = "Two currencies are the same, please select different currencies";
                MathWork.Text = workShown;
            }
            else
            {
                total = Exchange(currency1, currency2,ref workShown);
                formatedTotal = total.ToString("0.00");
                printresult = $"Exchanging {inputValue} {currency1} to {currency2}";
                MathWork.Text = $"{workShown} {formatedTotal} {currency2}";
            }
            
            ResultsID.Text = printresult;
        }

        private decimal Exchange(string currencyText,string currencyText2, ref string mathWork)
        {
            decimal result = 0;
            decimal currencyVal = decimal.Parse(InputCashID.Text); ;
            decimal currencyVal2 = 0;

            if((currencyText == "Dollar(s)" && currencyText2 == "Peso(s)") || (currencyText == "Peso(s)" && currencyText2 == "Dollar(s)"))
            {
                currencyVal2 = 17.30m; //1 USD = 17.30

                if (currencyText == "Dollar(s)" && currencyText2 == "Peso(s)")
                    result = formula(currencyVal, currencyVal2, true, ref mathWork);
                else
                    result = formula(currencyVal, currencyVal2, false, ref mathWork);
            }
            else if ((currencyText == "Dollar(s)" && currencyText2 == "Yen") || (currencyText == "Yen" && currencyText2 == "Dollar(s)"))
            {
                currencyVal2 = 147.26m; //1 USD = 147.26

                if(currencyText == "Dollar(s)" && currencyText2 == "Yen")
                    result = formula(currencyVal, currencyVal2, true, ref mathWork);
                else
                    result = formula(currencyVal, currencyVal2, false, ref mathWork);
            }
            else if((currencyText == "Dollar(s)" && currencyText2 == "Australian Dollar(s)")|| (currencyText == "Australian Dollar(s)" && currencyText2 == "Dollar(s)"))
            {
                currencyVal2 = 1.51m;//1USD = 1.51

                if (currencyText == "Dollar(s)" && currencyText2 == "Australian Dollar(s)")
                    result = formula(currencyVal, currencyVal2, true, ref mathWork);
                else
                    result = formula(currencyVal, currencyVal2,false, ref mathWork);

            }

            else if ((currencyText == "Peso(s)" && currencyText2 =="Yen")|| (currencyText =="Yen" && currencyText2 == "Peso(s)"))
            {
                currencyVal2 = 8.20m; //1 Peso = 8.20 Yen

                if (currencyText == "Peso(s)" && currencyText2 == "Yen")
                    result = formula(currencyVal, currencyVal2, true, ref mathWork);
                else
                    result = formula(currencyVal, currencyVal2, false, ref mathWork);

            }

            else if ((currencyText == "Australian Dollar(s)" && currencyText2 == "Yen") || (currencyText == "Yen" && currencyText2 == "Australian Dollar(s)"))
            {
                currencyVal2 = 95.17m; //1 AUD = 95.17
                                       
                if(currencyText == "Australian Dollar(s)" && currencyText2 == "Yen")
                    result = formula(currencyVal, currencyVal2, true, ref mathWork);
                else 
                    result = formula(currencyVal, currencyVal2,false,ref mathWork);
                

            }
            else if ((currencyText == "Australian Dollar(s)" && currencyText2 == "Peso(s)") || (currencyText == "Peso(s)" && currencyText2 == "Australian Dollar(s)"))
            {
                currencyVal2 = 11.53m; //1 AUD = 11.53 Pesos

                if (currencyText == "Australian Dollar(s)" && currencyText2 == "Peso(s)")
                    result = formula(currencyVal, currencyVal2, true, ref mathWork);
                else
                    result = formula(currencyVal, currencyVal2, false, ref mathWork);
            }

                return result;
        }
        private decimal formula(decimal val1,decimal val2, bool flag, ref string mathout)
        {

            if (flag){
                mathout = $"{val1} * {val2} = ";
                return val1 * val2;
            }
            else {
                mathout = $"{val1} / {val2} = ";
                return val1 / val2; 
            }
            
        }
    }
}