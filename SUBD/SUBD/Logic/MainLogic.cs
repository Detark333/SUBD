using SUBD.Model;
using SUBD.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace SUBD.Logic
{
    public class MainLogic
    {
        private readonly AutoLogic autoLogic;
        private readonly ClientLogic clientLogic;
        private readonly ContractLogic contractLogic;
        private readonly InformationLogic informationLogic;
        private readonly SalePeopleLogic salePeopleLogic;
        public MainLogic(AutoLogic autoLogic, ClientLogic clientLogic, ContractLogic contractLogic, InformationLogic informationLogic, SalePeopleLogic salePeopleLogic)
        {
            this.autoLogic = autoLogic;
            this.clientLogic = clientLogic;
            this.contractLogic = contractLogic;
            this.informationLogic = informationLogic;
            this.salePeopleLogic = salePeopleLogic;
        }
        public void CreateAuto(int id, string ModelName, string BrandName, string TypeMotor, int CountAirbags)
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
        public void CreateClient(int id, string Name, int InformationId)
        {
            Client user = new Client()
            {
                Id = id,
                Name = Name,
                InformationId = InformationId
            };
            clientLogic.Create(user);
        }
        public void CreateContract(int id, string Curency, int Amount, int ClientId, int SalePeopleId, int AutoId)
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
        public void CreateInformation(int id, string Adress, string PhoneNumber, string Passport)
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
        public void CreateSalePeople(int id, string Name, int WageDollars, int InformationId)
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
        public void DeleteSalePeople(int id, string Name, int WageDollars, int InformationId)
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
        public void UpdateSalePeople(int id, string Name, int WageDollars, int InformationId)
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
        public void ReadSalePeople()
        {
            var list = salePeopleLogic.Read();
            foreach (var p in list)
            {
                Console.WriteLine(p.Id + " " + p.Name + " " + p.InformationId + " " + p.WageDollars);
            }
        }
        public void DeleteInformation(int id, string Adress, string PhoneNumber, string Passport)
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
        public void UpdateInformation(int id, string Adress, string PhoneNumber, string Passport)
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
        public void ReadInformation()
        {
            foreach (var p in informationLogic.Read())
            {
                Console.WriteLine(p.Id + " " + p.Adress + " " + p.PhoneNumber + " " + p.Passport);
            }
        }
        public void DeleteContract(int id, string Curency, int Amount, int ClientId, int SalePeopleId, int AutoId)
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
        public void UpdateContract(int id, string Curency, int Amount, int ClientId, int SalePeopleId, int AutoId)
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
        public void ReadContract()
        {
            foreach (var p in contractLogic.Read())
            {
                Console.WriteLine(p.Id + " " + p.Curency + " " + p.Amount + " " + p.ClientId + " " + p.SalePeopleId + " " + p.AutoId);
            }
        }
        public void DeleteClient(int id, string Name, int InformationId)
        {
            Client user = new Client()
            {
                Id = id,
                Name = Name,
                InformationId = InformationId
            };
            clientLogic.Delete(user);
        }
        public void UpdateClient(int id, string Name, int InformationId)
        {
            Client user = new Client()
            {
                Id = id,
                Name = Name,
                InformationId = InformationId
            };
            clientLogic.Update(user);
        }
        public void ReadClient()
        {
            foreach (var p in clientLogic.Read())
            {
                Console.WriteLine(p.Id + " " + p.Name + " " + p.InformationId);
            }
        }
        public void DeleteAuto(int id, string ModelName, string BrandName, string TypeMotor, int CountAirbags)
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
        public void UpdateAuto(int id, string ModelName, string BrandName, string TypeMotor, int CountAirbags)
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
        public void ReadAuto()
        {
            foreach (var p in autoLogic.Read())
            {
                Console.WriteLine(p.Id + " " + p.ModelName + " " + p.BrandName + " " + p.TypeMotor + " " + p.CountAirbags);
            }
        }
    }
}
