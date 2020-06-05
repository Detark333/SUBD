using SUBD.Logic;
using SUBD.Service;
using System;
using System.Diagnostics;

namespace SUBD
{
    class Program
    {
        public static readonly AutoServiceDataBase db = new AutoServiceDataBase();
        static void Main(string[] args)
        {
            //MainLogic logic = new MainLogic(new AutoLogic(), new ClientLogic(), new ContractLogic(), new InformationLogic(), new SalePeopleLogic());
            //Insert(logic);
            //Stopwatch clock = new Stopwatch();
            /*clock.Start();
            logic.CreateAuto(2, "Mark2tourerv", "Toyota", "1jz-gte-500HP", 0);
            logic.ReadAuto();
            logic.UpdateAuto(2, "Mark2tourerv", "Toyota", "1jz-gte-500HP", 0);
            logic.DeleteAuto(2, "Mark2tourerv", "Toyota", "1jz-gte-500HP", 0);
            */
            //clock.Stop();
            //Console.WriteLine(clock.ElapsedMilliseconds);
            //zapros2(1000);
            //zapros3(3000);
            //zapros4(50);
            Console.ReadKey();
        }
        public static void Insert(MainLogic logic)
        {
            logic.CreateInformation(0, "Ulaynovsk", "888888", "7310252522");
            logic.CreateInformation(1, "MSK", "878888", "731522");
            logic.CreateInformation(2, "KZN", "878788", "725222");
            logic.CreateInformation(3, "ULSTU", "202020", "789632");
            logic.CreateAuto(0, "Camary", "Toyota", "1jz-gte-500HP", 0);
            logic.CreateAuto(1, "Chaiser", "Toyota", "1jz-gte-500HP", 0);
            logic.CreateClient(0, "Winston", 1);
            logic.CreateClient(1, "Rex", 0);
            logic.CreateSalePeople(0, "Alexey", 1000, 2);
            logic.CreateSalePeople(1, "Andrey", 50, 3);
            logic.CreateContract(0, "Rubles", 500, 1, 1, 0);
            logic.CreateContract(1, "Dollars", 10000, 0, 0, 1);
        }
        //public void zapros2(int x)
        //{
        //    var peoples = context.SalePeople
        //.Where(p => p.WageDollars == x);
        //    foreach (var people in peoples)
        //    {
        //        Console.WriteLine("Name is:" + people.Name + " he earns " + x + "money");
        //    }
        //}
        //public void zapros3(int x)
        //{
        //    var contracts = context.Contract(p => p.Amount > x).OrderBy(p => p.Amount);
        //    foreach (var contract in contracts)
        //    {
        //        Console.WriteLine("Id контракта: " + contract.Id + " Оплата: " + contract.Amount);
        //    }
        //}
        //public void zapros4(int x)
        //{
        //    var contractPeople = context.Contracts.Join(context.SalePeople,
        //        c => c.SalePeopleID,
        //        s => s.SalePeopleID,
        //        (c, s) => new
        //        {
        //            ContrID = c.ContractID,
        //            PersonName = s.Name,
        //            Wage = s.WageDollars
        //        }).Where(rec => rec.Wage == x);
        //    foreach (var cp in contractPeople)
        //    {
        //        Console.WriteLine("Id контракта: " + cp.ContrID + " Продавец: " + cp.PersonName);
        //    }
        //}
    }
}
