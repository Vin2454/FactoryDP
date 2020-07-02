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
                Console.WriteLine("Enter card type...");
                string cardType = Console.ReadLine();
                FactoryWithFactoryMethod factoryWithFactoryMethod = new CardFactory();
                if (cardType.ToLower() == "credit")
                {
                    PostPaidCard postPaidCard = factoryWithFactoryMethod.GetPostPaidCard(annualIncome);
                    Console.WriteLine($"{typeof(PostPaidCard)} {postPaidCard.Name} : {annualIncome}");
                }
                else if (cardType.ToLower() == "debit")
                {
                    PrepaidCard prePaidCard = factoryWithFactoryMethod.GetPrePaidCard(annualIncome);
                    Console.WriteLine($"{typeof(PrepaidCard)} {prePaidCard.Name} : {annualIncome}");
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
        internal abstract PrepaidCard GetPrePaidCard(decimal amount);
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

        internal override PrepaidCard GetPrePaidCard(decimal amount)
        {
            PrepaidCard prePaidCard = new PrepaidCard();
            if (amount > 5000)
            {
                prePaidCard = new Hdfc();
                prePaidCard.Name = "Hdfc";
            }
            else
            {
                prePaidCard = new Icici();
                prePaidCard.Name = "Icici";
            }
            return prePaidCard;
        }
    }
    class PostPaidCard
    {
        public string Name { get; set; }
        public decimal AnnualFee { get; set; }
        public string Type { get; set; }
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

    //debit cards(prepaid)
    class PrepaidCard
    {
        public string Name { get; set; }
        public decimal AnnualFee { get; set; }
        public string Type { get; set; }
        public string Balance { get; set; }
    }
    class Icici : PrepaidCard
    {

    }
    class Hdfc : PrepaidCard
    {
        public string Feedback { get; set; }
    }
}
