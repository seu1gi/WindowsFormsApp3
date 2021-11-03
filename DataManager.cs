using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace WindowsFormsApp3
{
    class DataManager
    {
        public static List<Income> Incomes = new List<Income>();
        public static List<Expenditure> Expenditures = new List<Expenditure>();

        static DataManager()
        {
            Load();
        }
        public static void Load()
        {
            try
            {
                string incomesOutput = File.ReadAllText(@"./Incomes.xml");
                XElement incomesXElement = XElement.Parse(incomesOutput);

                Incomes = (from item in incomesXElement.Descendants("income")
                         select new Income()
                         {
                             Num = int.Parse(item.Element("num").Value),
                             Contents = item.Element("contents").Value,
                             Money = int.Parse(item.Element("money").Value),
                             Date = DateTime.Parse(item.Element("date").Value)
                         }).ToList<Income>();

                string expendituresOutput = File.ReadAllText(@"./Expenditures.xml");
                XElement expendituresXElement = XElement.Parse(expendituresOutput);
                Expenditures = (from item in expendituresXElement.Descendants("expenditure")
                                select new Expenditure()
                                {
                                    Num = int.Parse(item.Element("num").Value),
                                    Contents = item.Element("contents").Value,
                                    Money = int.Parse(item.Element("money").Value),
                                    Date = DateTime.Parse(item.Element("date").Value)
                                }
                         ).ToList<Expenditure>();
            }
            catch (FileNotFoundException ex)
            {
                Save();
            }
        }

        public static void Save()
        {
            string incomesOutput = "";
            incomesOutput += "<incomes>\n";
            foreach (var item in Incomes)
            {
                incomesOutput += "<income>\n";
                incomesOutput += "<num>" + item.Num + "</num>\n";
                incomesOutput += "<contents>" + item.Contents + "</contents>\n";
                incomesOutput += "<money>" + item.Money + "</money>\n";
                incomesOutput += "<date>" + item.Date.ToLongDateString() + "</date>\n";
                incomesOutput += "</income>\n";
            }

            incomesOutput += "</incomes>";
            string expendituresOutput = "";
            expendituresOutput += "<expenditures>\n";
            foreach (var item in Expenditures)
            {
                expendituresOutput += "<expenditure>\n";
                expendituresOutput += "<num>" + item.Num + "</num>\n";
                expendituresOutput += "<contents>" + item.Contents + "</contents>\n";
                expendituresOutput += "<money>" + item.Money + "</money>\n";
                expendituresOutput += "<date>" + item.Date.ToLongDateString() + "</date>\n";
                expendituresOutput += "</expenditure>\n";
            }
            expendituresOutput += "</expenditures>";

            File.WriteAllText(@"./Incomes.xml", incomesOutput);
            File.WriteAllText(@"./Expenditures.xml", expendituresOutput);
        }
    }
}
