using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class NoFactoryPattern
    {
        static void Main(string[] args)
        {
            // Without any factory
            while (true)
            {
                Console.WriteLine("Enter annual income...");
                string annualIncome = Console.ReadLine();
                if (Convert.ToDecimal(annualIncome) > 50000)
                {
                    Smart smartCard = new Smart();
                    Console.WriteLine($"{typeof(Smart)} credit smart card: {annualIncome}");
                }
                else if (Convert.ToDecimal(annualIncome) > 20000)
                {
                    Everyday everydayCard = new Everyday();
                    Console.WriteLine($"{typeof(Everyday)} credit everyday card: {annualIncome}");
                }
                else
                {
                    Console.WriteLine("No card");
                }
            }
        }
    }
    class Card
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
    class PostPaidCard: Card
    {
        public decimal AnnualFee { get; set; }
        public string Balance { get; set; }
        public decimal Charge { get; set; }
    }
    //credit cards(postpaid)
    class Everyday : PostPaidCard
    {

    }
    class MRCC : PostPaidCard
    {
        public string Rewards { get; set; }
    }
    class Smart : PostPaidCard
    {

    }
}
