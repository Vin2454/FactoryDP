using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class FactoryMethod
    {
        static void Main(string[] args)
        {
            // Simple factory pattern
            while (true)
            {
                Console.WriteLine("Enter annual income...");
                string annualIncomeString = Console.ReadLine();
                Decimal annualIncome = Convert.ToDecimal(annualIncomeString);
                FactoryWithFactoryMethod factoryWithFactoryMethod = new CardFactory();
                string cardType = "credit";
                if (cardType.ToLower() == "credit")
                {
                    PostPaidCard postPaidCard = factoryWithFactoryMethod.GetPostPaidCard(annualIncome);
                    Console.WriteLine($"{typeof(PostPaidCard)} {postPaidCard.Name} : {annualIncome}");
                }
                else
                {
                    Console.WriteLine("No card");
                }
            }
        }
    }
    abstract class FactoryWithFactoryMethod
    {
        internal abstract PostPaidCard GetPostPaidCard(decimal amount);
    }
    class CardFactory : FactoryWithFactoryMethod
    {
        internal override PostPaidCard GetPostPaidCard(decimal amount)
        {
            PostPaidCard postPaidCard = new PostPaidCard();
            if (amount > 50000)
            {
                postPaidCard = new Smart();
                postPaidCard.Name = "Smart";
            }
            else if (amount > 20000)
            {
                postPaidCard = new MRCC();
                postPaidCard.Name = "MRCC";
            }
            else
            {
                postPaidCard = new Everyday();
                postPaidCard.Name = "Everyday";
            }
            return postPaidCard;
        }
    }
    class Card
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
    class PostPaidCard : Card
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
