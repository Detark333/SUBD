using SUBD.Model;
using SUBD.Service;
using System;
using System.Diagnostics;
using System.Linq;

namespace SUBD
{
    class Program
    {
        
        public static readonly AutoServiceDataBase db = new AutoServiceDataBase();
        private static readonly AutoLogic autoLogic;
        private static readonly ClientLogic clientLogic;
        private static readonly ContractLogic contractLogic;
        private static readonly InformationLogic informationLogic;
        private static readonly SalePeopleLogic salePeopleLogic;
        static void Main(string[] args)
        {
            using (var context = new AutoServiceDataBase())
            {
                ReadAuto();
                ReadSalePeople();
                ReadClient();
                ReadContract();
                ReadInformation();
                GetPages(context);
                zapros2(1000, context);
                zapros3(3000, context);
                zapros4(50, context);
            }


            Stopwatch clock = new Stopwatch();
            clock.Start();
            CreateAuto(2, "Mark2tourerv", "Toyota", "1jz-gte-500HP", 0);
            UpdateAuto(2, "Mark2tourerv", "Toyota", "1jz-gte-500HP", 0);
            DeleteAuto(2, "Mark2tourerv", "Toyota", "1jz-gte-500HP", 0);
            
            clock.Stop();
            Console.WriteLine(clock.ElapsedMilliseconds);
            
            Console.ReadKey();
        }
        public static void ReadAuto()
        {
            foreach (var p in autoLogic.Read())
            {
                Console.WriteLine(p.Id + " " + p.ModelName + " " + p.BrandName + " " + p.TypeMotor + " " + p.CountAirbags);
            }
        }
        public static void ReadSalePeople()
        {
            var list = salePeopleLogic.Read();
            foreach (var p in list)
            {
                Console.WriteLine(p.Id + " " + p.Name + " " + p.InformationId + " " + p.WageDollars);
            }
        }
        public static void ReadClient()
        {
            foreach (var p in clientLogic.Read())
            {
                Console.WriteLine(p.Id + " " + p.Name + " " + p.InformationId);
            }
        }
        public static void ReadContract()
        {
            foreach (var p in contractLogic.Read())
            {
                Console.WriteLine(p.Id + " " + p.Curency + " " + p.Amount + " " + p.ClientId + " " + p.SalePeopleId + " " + p.AutoId);
            }
        }
        public static  void ReadInformation()
        {
            foreach (var p in informationLogic.Read())
            {
                Console.WriteLine(p.Id + " " + p.Adress + " " + p.PhoneNumber + " " + p.Passport);
            }
        }
        public static void Insert()
        {
            
            CreateInformation(0, "Ulaynovsk", "888888", "7310252522");
            CreateInformation(1, "MSK", "878888", "731522");
            CreateInformation(2, "KZN", "878788", "725222");
            CreateInformation(3, "ULSTU", "202020", "789632");
            CreateAuto(0, "Camary", "Toyota", "1jz-gte-500HP", 0);
            CreateAuto(1, "Chaiser", "Toyota", "1jz-gte-500HP", 0);
            CreateClient(0, "Winston", 1);
            CreateClient(1, "Rex", 0);
            CreateSalePeople(0, "Alexey", 1000, 2);
            CreateSalePeople(1, "Andrey", 50, 3);
            CreateContract(0, "Rubles", 500, 1, 1, 0);
            CreateContract(1, "Dollars", 10000, 0, 0, 1);
        }
        public static void GetPages(AutoServiceDataBase context)
        {
            AutoLogic orderLogic = new AutoLogic(context);
            var autos = orderLogic.ReadPage(0, 4);
            foreach (var order in autos)
            {
                Console.WriteLine(order.ModelName + " "
                    + order.BrandName + " " + order.TypeMotor + " " + order.CountAirbags);
            }
            Console.WriteLine();
            ClientLogic authorLogic = new ClientLogic(context);
            var clients = authorLogic.ReadPage(0, 4);
            foreach (var author in clients)
            {
                Console.WriteLine(author.Name + " " + author.InformationId);
            }
            Console.WriteLine();
    }
        public static void zapros2(int x, AutoServiceDataBase context)
        {
            var peoples = context.SalePeoples
        .Where(p => p.WageDollars == x);
            foreach (var people in peoples)
            {
                Console.WriteLine("Name is:" + people.Name + " he earns " + x + "money");
            }
        }
        public static void zapros3(int x, AutoServiceDataBase context)
        {
            var contracts = context.Contracts(p => p.Amount > x).OrderBy(p => p.Amount);
            foreach (var contract in contracts)
            {
                Console.WriteLine("Id контракта: " + contract.Id + " Оплата: " + contract.Amount);
            }
        }
        public static void zapros4(int x, AutoServiceDataBase context)
        {
            var contractPeople = context.Contracts.Join(context.SalePeoples,
                c => c.SalePeopleID,
                s => s.SalePeopleID,
                (c, s) => new
                {
                    ContrID = c.ContractID,
                    PersonName = s.Name,
                    Wage = s.WageDollars
                }).Where(rec => rec.Wage == x);
            foreach (var cp in contractPeople)
            {
                Console.WriteLine("Id контракта: " + cp.ContrID + " Продавец: " + cp.PersonName);
            }
        }
        public static void CreateAuto(int id, string ModelName, string BrandName, string TypeMotor, int CountAirbags)
        {
            Auto user = new Auto()
            {
                Id = id,
                ModelName = ModelName,
                BrandName = BrandName,
                TypeMotor = TypeMotor,
                CountAirbags = CountAirbags
            };
            autoLogic.Create(user);
        }
        public static void CreateClient(int id, string Name, int InformationId)
        {
            Client user = new Client()
            {
                Id = id,
                Name = Name,
                InformationId = InformationId
            };
            clientLogic.Create(user);
        }
        public static void CreateContract(int id, string Curency, int Amount, int ClientId, int SalePeopleId, int AutoId)
        {
            Contract user = new Contract()
            {
                Id = id,
                Curency = Curency,
                Amount = Amount,
                ClientId = ClientId,
                SalePeopleId = SalePeopleId,
                AutoId = AutoId
            };
            contractLogic.Create(user);
        }
        public static void CreateInformation(int id, string Adress, string PhoneNumber, string Passport)
        {
            Information user = new Information()
            {
                Id = id,
                Adress = Adress,
                PhoneNumber = PhoneNumber,
                Passport = Passport
            };
            informationLogic.Create(user);
        }
        public static void CreateSalePeople(int id, string Name, int WageDollars, int InformationId)
        {
            SalePeople user = new SalePeople()
            {
                Id = id,
                Name = Name,
                InformationId = InformationId,
                WageDollars = WageDollars
            };
            salePeopleLogic.Create(user);
        }
        public static void DeleteSalePeople(int id, string Name, int WageDollars, int InformationId)
        {
            SalePeople user = new SalePeople()
            {
                Id = id,
                Name = Name,
                InformationId = InformationId,
                WageDollars = WageDollars
            };
            salePeopleLogic.Delete(user);
        }
        public static void UpdateSalePeople(int id, string Name, int WageDollars, int InformationId)
        {
            var list = salePeopleLogic.Get(id);
            SalePeople user = new SalePeople()
            {
                Id = list.Id,
                Name = Name,
                InformationId = InformationId,
                WageDollars = WageDollars
            };
            salePeopleLogic.Delete(user);
        }

        public static void DeleteInformation(int id, string Adress, string PhoneNumber, string Passport)
        {
            Information user = new Information()
            {
                Id = id,
                Adress = Adress,
                PhoneNumber = PhoneNumber,
                Passport = Passport
            };
            informationLogic.Delete(user);
        }
        public static void UpdateInformation(int id, string Adress, string PhoneNumber, string Passport)
        {
            Information user = new Information()
            {
                Id = id,
                Adress = Adress,
                PhoneNumber = PhoneNumber,
                Passport = Passport
            };
            informationLogic.Update(user);
        }

        public static void DeleteContract(int id, string Curency, int Amount, int ClientId, int SalePeopleId, int AutoId)
        {
            Contract user = new Contract()
            {
                Id = id,
                Curency = Curency,
                Amount = Amount,
                ClientId = ClientId,
                SalePeopleId = SalePeopleId,
                AutoId = AutoId
            };
            contractLogic.Delete(user);
        }
        public static void UpdateContract(int id, string Curency, int Amount, int ClientId, int SalePeopleId, int AutoId)
        {
            Contract user = new Contract()
            {
                Id = id,
                Curency = Curency,
                Amount = Amount,
                ClientId = ClientId,
                SalePeopleId = SalePeopleId,
                AutoId = AutoId
            };
            contractLogic.Update(user);
        }

        public static void DeleteClient(int id, string Name, int InformationId)
        {
            Client user = new Client()
            {
                Id = id,
                Name = Name,
                InformationId = InformationId
            };
            clientLogic.Delete(user);
        }
        public static void UpdateClient(int id, string Name, int InformationId)
        {
            Client user = new Client()
            {
                Id = id,
                Name = Name,
                InformationId = InformationId
            };
            clientLogic.Update(user);
        }

        public static void DeleteAuto(int id, string ModelName, string BrandName, string TypeMotor, int CountAirbags)
        {
            Auto user = new Auto()
            {
                Id = id,
                ModelName = ModelName,
                BrandName = BrandName,
                TypeMotor = TypeMotor,
                CountAirbags = CountAirbags
            };
            autoLogic.Delete(user);
        }
        public static void UpdateAuto(int id, string ModelName, string BrandName, string TypeMotor, int CountAirbags)
        {
            Auto user = new Auto()
            {
                Id = id,
                ModelName = ModelName,
                BrandName = BrandName,
                TypeMotor = TypeMotor,
                CountAirbags = CountAirbags
            };
            autoLogic.Update(user);
        }
    }
}
