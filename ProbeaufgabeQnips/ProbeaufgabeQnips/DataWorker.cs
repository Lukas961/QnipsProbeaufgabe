using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static ProbeaufgabeQnips.JsonModel;

namespace ProbeaufgabeQnips
{
    internal class DataWorker
    {
        string url = @"https://my.qnips.io/dbapi/ha";

        HttpClient client = new HttpClient();
        private List<ProductDetails> ProductDetails = new List<ProductDetails>();
        private List<Allergen> Allergens= new List<Allergen>();


        public async Task GetData()
        {
            await GetItems();

        }

        //Get the JSON and deserialize it before building the dataset
        private async Task GetItems()
        {
            string response = await client.GetStringAsync(url);

            Rootobject rootobject = JsonConvert.DeserializeObject<Rootobject>(response);

            ProductDetails = GetProducts(rootobject);
            Allergens = GetAllergens(rootobject);
            DisplayData(ProductDetails, Allergens, rootobject);

        }

        //Build a table and display all needed infortmation from the JSON
        private void DisplayData(List<ProductDetails> details, List<Allergen> allergens, Rootobject rootobject)
        {
            string nameAktion1 = "";
            string allergeneAktion1 = "";
            string priceAktion1 = "";
            string nameAktion2 = "";
            string allergeneAktion2 = "";
            string priceAktion2 = "";
            string nameSalatbar = "";
            string allergeneSalatbar = "";
            string priceSalatbar = "";
            int counter1 = 0;
            int counter2 = 0;
            int counterSalatbar = 0;

            DataTable table = new DataTable();
            DataRow rowNames1 = table.NewRow();
            DataRow rowAllergens1 = table.NewRow();
            DataRow rowPrices1 = table.NewRow();
            DataRow rowNames2 = table.NewRow();
            DataRow rowAllergens2 = table.NewRow();
            DataRow rowPrices2 = table.NewRow();
            DataRow rowSalatbarName = table.NewRow();
            DataRow rowSalatbarAllergens = table.NewRow();
            DataRow rowSalatbarPrice = table.NewRow();
            table.Columns.Add("Tage");
            table.Columns.Add("Montag");
            table.Columns.Add("Dienstag");
            table.Columns.Add("Mittwoch");
            table.Columns.Add("Donnerstag");
            table.Columns.Add("Freitag");
            int counter = 0;

            for (int i = 0; i < 4; i++)
            {
                if(counter <3)
                {
                    foreach (var item in rootobject.Rows.Select(x => x.Days))
                    {

                        foreach (var test in item.Select(y => y.ProductIds))
                        {
                            foreach (var id in test.Select(z => z.ProductId))
                            {
                                if (counter == 0)
                                {
                                        
                                    var resp = details.Find(r => r.ProductId == id);

                                    for (int a = 0; a < resp.AllergenIds.Count; a++)
                                    {
                                        if (a == 0)
                                            allergeneAktion1 = "";
                                        var respAl = allergens.Find(al => al.Id == resp.AllergenIds[a]);
                                        allergeneAktion1 += respAl.Label + ",";
                                    }
                                       
                                    priceAktion1 = Math.Round(resp.ProductPrice,2).ToString() + "€";
                                    nameAktion1 = resp.ProductName;
                                    switch (counter1)
                                    {
                                        case 0:
                                            rowNames1["Montag"] = nameAktion1;
                                            rowAllergens1["Montag"] = allergeneAktion1;
                                            rowPrices1["Montag"] = priceAktion1;
                                            break;
                                        case 1:
                                            rowNames1["Dienstag"] = nameAktion1;
                                            rowAllergens1["Dienstag"] = allergeneAktion1;
                                            rowPrices1["Dienstag"] = priceAktion1;
                                            break;
                                        case 2:
                                            rowNames1["Mittwoch"] = nameAktion1;
                                            rowAllergens1["Mittwoch"] = allergeneAktion1;
                                            rowPrices1["Mittwoch"] = priceAktion1;
                                            break;
                                        case 3:
                                            rowNames1["Donnerstag"] = nameAktion1;
                                            rowAllergens1["Donnerstag"] = allergeneAktion1;
                                            rowPrices1["Donnerstag"] = priceAktion1;
                                            break;
                                        case 4:
                                            rowNames1["Freitag"] = nameAktion1;
                                            rowAllergens1["Freitag"] = allergeneAktion1;
                                            rowPrices1["Freitag"] = priceAktion1;
                                            table.Rows.Add(rowNames1);
                                            table.Rows.Add(rowAllergens1);
                                            table.Rows.Add(rowPrices1);
                                            break;
                                    }
                                        
                                    if (counter1 == 4)
                                    {
                                        Console.WriteLine("{0}| {1, 10}| {2, 25}| {3, 25}| {4, 50}| {5, 35}\n", table.Columns[0], table.Columns[1], table.Columns[2], table.Columns[3], table.Columns[4], table.Columns[5]);
                                        Console.WriteLine("{0}| {1, 17}| {2, 17}| {3, 40}| {4, 35}| {5,35}\n", "Aktion1", rowNames1["Montag"], rowNames1["Dienstag"], rowNames1["Mittwoch"], rowNames1["Donnerstag"], rowNames1["Freitag"]);
                                        Console.WriteLine("{0, 15}| {1, 22}| {2, 25}| {3, 45}| {4, 45}\n", rowAllergens1["Montag"], rowAllergens1["Dienstag"], rowAllergens1["Mittwoch"], rowAllergens1["Donnerstag"], rowAllergens1["Freitag"]);
                                        Console.WriteLine("{0, 15}| {1, 22}| {2, 25}| {3, 45}| {4, 45}\n\n", rowPrices1["Montag"], rowPrices1["Dienstag"], rowPrices1["Mittwoch"], rowPrices1["Donnerstag"], rowPrices1["Freitag"]);
                                    }
                                            
                                    counter1++;
                                }
                                else if (counter == 1)
                                {
                                    var resp = details.Find(r => r.ProductId == id);

                                    for (int a = 0; a < resp.AllergenIds.Count; a++)
                                    {
                                        if (a == 0)
                                            allergeneAktion2 = "";
                                        var respAl = allergens.Find(al => al.Id == resp.AllergenIds[a]);
                                        allergeneAktion2 += respAl.Label + ",";
                                    }

                                    priceAktion2 = Math.Round(resp.ProductPrice, 2).ToString() + "€";
                                    nameAktion2 = resp.ProductName;

                                    switch (counter2)
                                    {
                                        case 0:
                                            rowNames2["Montag"] = nameAktion2;
                                            rowAllergens2["Montag"] = allergeneAktion2;
                                            rowPrices2["Montag"] = priceAktion2;
                                            break;
                                        case 1:
                                            rowNames2["Dienstag"] = nameAktion2;
                                            rowAllergens2["Dienstag"] = allergeneAktion2;
                                            rowPrices2["Dienstag"] = priceAktion2;
                                            break;
                                        case 2:
                                            rowNames2["Mittwoch"] = nameAktion2;
                                            rowAllergens2["Mittwoch"] = allergeneAktion2;
                                            rowPrices2["Mittwoch"] = priceAktion2;
                                            break;
                                        case 3:
                                            rowNames2["Donnerstag"] = nameAktion2;
                                            rowAllergens2["Donnerstag"] = allergeneAktion2;
                                            rowPrices2["Donnerstag"] = priceAktion2;
                                            break;
                                        case 4:
                                            rowNames2["Freitag"] = nameAktion2;
                                            rowAllergens2["Freitag"] = allergeneAktion2;
                                            rowPrices2["Freitag"] = priceAktion2;
                                            table.Rows.Add(rowNames2);
                                            table.Rows.Add(rowAllergens2);
                                            table.Rows.Add(rowPrices2);
                                            break;
                                    }

                                    //counter = 5;
                                    if (counter2 == 4)
                                    {
                                        Console.WriteLine("{0}| {1, 17}| {2, 17}| {3, 30}| {4, 40}| {5,35}\n", "Aktion2", rowNames2["Montag"], rowNames2["Dienstag"], rowNames2["Mittwoch"], rowNames2["Donnerstag"], rowNames2["Freitag"]);
                                        Console.WriteLine("{0, 15}| {1, 25}| {2, 25}| {3, 45}| {4, 45}\n", rowAllergens2["Montag"], rowAllergens2["Dienstag"], rowAllergens2["Mittwoch"], rowAllergens2["Donnerstag"], rowAllergens2["Freitag"]);
                                        Console.WriteLine("{0, 15}| {1, 25}| {2, 25}| {3, 45}| {4, 45}\n\n", rowPrices2["Montag"], rowPrices2["Dienstag"], rowPrices2["Mittwoch"], rowPrices2["Donnerstag"], rowPrices2["Freitag"]);
                                    }

                                    counter2++;
                                }
                                else
                                {
                                    var resp = details.Find(r => r.ProductId == id);

                                    for (int a = 0; a < resp.AllergenIds.Count; a++)
                                    {
                                        if (a == 0)
                                            allergeneSalatbar = "";
                                        var respAl = allergens.Find(al => al.Id == resp.AllergenIds[a]);
                                        allergeneSalatbar += respAl.Label + ",";
                                    }

                                    priceSalatbar = Math.Round(resp.ProductPrice,2).ToString() + "€";
                                    nameSalatbar = resp.ProductName;
                                    switch (counterSalatbar)
                                    {
                                        case 0:
                                            rowSalatbarName["Montag"] = nameSalatbar;
                                            rowSalatbarAllergens["Montag"] = allergeneSalatbar;
                                            rowSalatbarPrice["Montag"] = priceSalatbar;
                                            break;
                                        case 1:
                                            rowSalatbarName["Dienstag"] = nameSalatbar;
                                            rowSalatbarAllergens["Dienstag"] = allergeneSalatbar;
                                            rowSalatbarPrice["Dienstag"] = priceSalatbar;
                                            break;
                                        case 2:
                                            rowSalatbarName["Mittwoch"] = nameSalatbar;
                                            rowSalatbarAllergens["Mittwoch"] = allergeneSalatbar;
                                            rowSalatbarPrice["Mittwoch"] = priceSalatbar;
                                            break;
                                        case 3:
                                            rowSalatbarName["Donnerstag"] = nameSalatbar;
                                            rowSalatbarAllergens["Donnerstag"] = allergeneSalatbar;
                                            rowSalatbarPrice["Donnerstag"] = priceSalatbar;
                                            break;
                                        case 4:
                                            rowSalatbarName["Freitag"] = nameSalatbar;
                                            rowSalatbarAllergens["Freitag"] = allergeneSalatbar;
                                            rowSalatbarPrice["Freitag"] = priceSalatbar;
                                            table.Rows.Add(rowSalatbarName);
                                            table.Rows.Add(rowSalatbarAllergens);
                                            table.Rows.Add(rowSalatbarPrice);
                                            break;
                                    }
                                    if (counterSalatbar == 4)
                                    {

                                        Console.WriteLine("{0}| {1, 17}| {2, 17}| {3, 40}| {4, 35}| {5,30}\n", "Salatbar", rowSalatbarName["Montag"], rowSalatbarName["Dienstag"], rowSalatbarName["Mittwoch"], rowSalatbarName["Donnerstag"], rowSalatbarName["Freitag"]);
                                        Console.WriteLine("{0, 15}| {1, 22}| {2, 25}| {3, 45}| {4, 45}\n", rowSalatbarAllergens["Montag"], rowSalatbarAllergens["Dienstag"], rowSalatbarAllergens["Mittwoch"], rowSalatbarAllergens["Donnerstag"], rowSalatbarAllergens["Freitag"]);
                                        Console.WriteLine("{0, 15}| {1, 22}| {2, 25}| {3, 45}| {4, 45}", rowSalatbarPrice["Montag"], rowSalatbarPrice["Dienstag"], rowSalatbarPrice["Mittwoch"], rowSalatbarPrice["Donnerstag"], rowSalatbarPrice["Freitag"]);
                                    }

                                    counterSalatbar++;
                                }

                            }

                        }
                        counter++;
                    }
                    
                }
            }

        }
      
        //Fill a list with all product details
        private List<ProductDetails> GetProducts(Rootobject rootobject)
        {
            List<ProductDetails> details = new List<ProductDetails>();
            int loop = 0;
            bool end = false;
            while (!end)
            {
                switch (loop)
                {
                    case 0:
                        ProductDetails productDetails = new ProductDetails();
                        productDetails.AllergenIds = new List<string>();
                        productDetails.ProductPrice = rootobject.Products._4293205.Price.Betrag;
                        productDetails.ProductName = rootobject.Products._4293205.Name;
                        foreach (var item in rootobject.Products._4293205.AllergenIds)
                        {

                            productDetails.AllergenIds.Add(item);
                        }
                        productDetails.ProductId = rootobject.Products._4293205.ProductId;

                        details.Add(productDetails);
                        loop++;
                        break;
                    case 1:
                        productDetails = new ProductDetails();
                        productDetails.AllergenIds = new List<string>();
                        productDetails.ProductPrice = rootobject.Products._4293206.Price.Betrag;
                        productDetails.ProductName = rootobject.Products._4293206.Name;
                        foreach (var item in rootobject.Products._4293206.AllergenIds)
                        {

                            productDetails.AllergenIds.Add(item);
                        }
                        productDetails.ProductId = rootobject.Products._4293206.ProductId;

                        details.Add(productDetails);
                        loop++;
                        break;
                    case 2:
                        productDetails = new ProductDetails();
                        productDetails.AllergenIds = new List<string>();
                        productDetails.ProductPrice = rootobject.Products._4299359.Price.Betrag;
                        productDetails.ProductName = rootobject.Products._4299359.Name;
                        foreach (var item in rootobject.Products._4299359.AllergenIds)
                        {

                            productDetails.AllergenIds.Add(item);
                        }
                        productDetails.ProductId = rootobject.Products._4299359.ProductId;

                        details.Add(productDetails);
                        loop++;
                        break;
                    case 3:
                        productDetails = new ProductDetails();
                        productDetails.AllergenIds = new List<string>();
                        productDetails.ProductPrice = rootobject.Products._4299392.Price.Betrag;
                        productDetails.ProductName = rootobject.Products._4299392.Name;
                        foreach (var item in rootobject.Products._4299392.AllergenIds)
                        {

                            productDetails.AllergenIds.Add(item);
                        }
                        productDetails.ProductId = rootobject.Products._4299392.ProductId;

                        details.Add(productDetails);
                        loop++;
                        break;
                    case 4:
                        productDetails = new ProductDetails();
                        productDetails.AllergenIds = new List<string>();
                        productDetails.ProductPrice = rootobject.Products._4299401.Price.Betrag;
                        productDetails.ProductName = rootobject.Products._4299401.Name;
                        foreach (var item in rootobject.Products._4299401.AllergenIds)
                        {

                            productDetails.AllergenIds.Add(item);
                        }
                        productDetails.ProductId = rootobject.Products._4299401.ProductId;

                        details.Add(productDetails);
                        loop++;
                        break;
                    case 5:
                        productDetails = new ProductDetails();
                        productDetails.AllergenIds = new List<string>();
                        productDetails.ProductPrice = rootobject.Products._4299402.Price.Betrag;
                        productDetails.ProductName = rootobject.Products._4299402.Name;
                        foreach (var item in rootobject.Products._4299402.AllergenIds)
                        {

                            productDetails.AllergenIds.Add(item);
                        }
                        productDetails.ProductId = rootobject.Products._4299402.ProductId;

                        details.Add(productDetails);
                        loop++;
                        break;
                    case 6:
                        productDetails = new ProductDetails();
                        productDetails.AllergenIds = new List<string>();
                        productDetails.ProductPrice = rootobject.Products._4299404.Price.Betrag;
                        productDetails.ProductName = rootobject.Products._4299404.Name;
                        foreach (var item in rootobject.Products._4299404.AllergenIds)
                        {

                            productDetails.AllergenIds.Add(item);
                        }
                        productDetails.ProductId = rootobject.Products._4299404.ProductId;

                        details.Add(productDetails);
                        loop++;
                        break;
                    case 7:
                        productDetails = new ProductDetails();
                        productDetails.AllergenIds = new List<string>();
                        productDetails.ProductPrice = rootobject.Products._4299405.Price.Betrag;
                        productDetails.ProductName = rootobject.Products._4299405.Name;
                        foreach (var item in rootobject.Products._4299405.AllergenIds)
                        {

                            productDetails.AllergenIds.Add(item);
                        }
                        productDetails.ProductId = rootobject.Products._4299405.ProductId;

                        details.Add(productDetails);
                        loop++;
                        break;
                    case 8:
                        productDetails = new ProductDetails();
                        productDetails.AllergenIds = new List<string>();
                        productDetails.ProductPrice = rootobject.Products._4299407.Price.Betrag;
                        productDetails.ProductName = rootobject.Products._4299407.Name;
                        foreach (var item in rootobject.Products._4299407.AllergenIds)
                        {

                            productDetails.AllergenIds.Add(item);
                        }
                        productDetails.ProductId = rootobject.Products._4299407.ProductId;

                        details.Add(productDetails);
                        loop++;
                        break;
                    case 9:
                        productDetails = new ProductDetails();
                        productDetails.AllergenIds = new List<string>();
                        productDetails.ProductPrice = rootobject.Products._4299411.Price.Betrag;
                        productDetails.ProductName = rootobject.Products._4299411.Name;
                        foreach (var item in rootobject.Products._4299411.AllergenIds)
                        {

                            productDetails.AllergenIds.Add(item);
                        }
                        productDetails.ProductId = rootobject.Products._4299411.ProductId;

                        details.Add(productDetails);
                        loop++;
                        break;
                    case 10:
                        productDetails = new ProductDetails();
                        productDetails.AllergenIds = new List<string>();
                        productDetails.ProductPrice = rootobject.Products._4299413.Price.Betrag;
                        productDetails.ProductName = rootobject.Products._4299413.Name;
                        foreach (var item in rootobject.Products._4299413.AllergenIds)
                        {

                            productDetails.AllergenIds.Add(item);
                        }
                        productDetails.ProductId = rootobject.Products._4299413.ProductId;

                        details.Add(productDetails);
                        loop++;
                        end = true;
                        break;
                }
            }

            return details;
        }

        //Fill a list with all allergen Ids and Labels
        private List<Allergen> GetAllergens(Rootobject rootobject)
        {
            List<Allergen> allergens = new List<Allergen>();
            int loop = 0;
            bool end = false;

            while (!end)
            {
                switch (loop)
                {
                    case 0:
                        Allergen allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._0_.Id;
                        allergen.Label = rootobject.Allergens._0_.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 1:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._0_0.Id;
                        allergen.Label = rootobject.Allergens._0_0.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 2:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._0_2.Id;
                        allergen.Label = rootobject.Allergens._0_2.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 3:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._0_3.Id;
                        allergen.Label = rootobject.Allergens._0_3.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 4:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._0_1.Id;
                        allergen.Label = rootobject.Allergens._0_1.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 5:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._1_.Id;
                        allergen.Label = rootobject.Allergens._1_.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 6:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._2_.Id;
                        allergen.Label = rootobject.Allergens._2_.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 7:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._3_.Id;
                        allergen.Label = rootobject.Allergens._3_.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 8:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._4_.Id;
                        allergen.Label = rootobject.Allergens._4_.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 9:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._5_.Id;
                        allergen.Label = rootobject.Allergens._5_.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 10:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._6_.Id;
                        allergen.Label = rootobject.Allergens._6_.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 11:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._7_.Id;
                        allergen.Label = rootobject.Allergens._7_.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 12:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._7_0.Id;
                        allergen.Label = rootobject.Allergens._7_0.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 13:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._7_1.Id;
                        allergen.Label = rootobject.Allergens._7_1.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 14:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._7_2.Id;
                        allergen.Label = rootobject.Allergens._7_2.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 15:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._7_3.Id;
                        allergen.Label = rootobject.Allergens._7_3.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 16:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._7_4.Id;
                        allergen.Label = rootobject.Allergens._7_4.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 17:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._7_5.Id;
                        allergen.Label = rootobject.Allergens._7_5.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 18:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._7_6.Id;
                        allergen.Label = rootobject.Allergens._7_6.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 19:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._7_7.Id;
                        allergen.Label = rootobject.Allergens._7_7.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 20:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._8_.Id;
                        allergen.Label = rootobject.Allergens._8_.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 21:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._9_.Id;
                        allergen.Label = rootobject.Allergens._9_.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 22:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._10_.Id;
                        allergen.Label = rootobject.Allergens._10_.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 23:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._11_.Id;
                        allergen.Label = rootobject.Allergens._11_.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 24:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._12_.Id;
                        allergen.Label = rootobject.Allergens._12_.Label;
                        allergens.Add(allergen);
                        loop++;
                        break;
                    case 25:
                        allergen = new Allergen();
                        allergen.Id = rootobject.Allergens._13_.Id;
                        allergen.Label = rootobject.Allergens._13_.Label;
                        allergens.Add(allergen);
                        loop++;
                        end = true;
                        break;
                }
            }
            

            return allergens;
        }

    }
}
