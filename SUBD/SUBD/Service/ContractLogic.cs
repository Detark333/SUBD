using SUBD.Interface;
using SUBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SUBD.Service
{
    public class ContractLogic : ILogic<Contract>
    {
        private static AutoServiceDataBase db = Program.db;
        private readonly AutoServiceDataBase context;
        public ContractLogic(AutoServiceDataBase context)
        {
            this.context = context;
        }
        public void Create(Contract model)
        {
            var news = db.Contracts.FirstOrDefault(c => c.Id == model.Id);
            if (news != null)
            {
                throw new Exception("Такое событие уже есть");
            }
            db.Contracts.Add(model);
            db.SaveChanges();
        }
        public void Update(Contract model)
        {
            var news = db.Contracts.FirstOrDefault(c => c.Id == model.Id);
            if (news == null)
            {
                throw new Exception("Такго события  нет");
            }
            news.Curency = model.Curency;
            news.Amount = model.Amount;
            news.ClientId = model.ClientId;
            news.SalePeopleId = model.SalePeopleId;
            news.AutoId = model.AutoId;
            db.SaveChanges();
        }
        public void Delete(Contract model)
        {
            var news = db.Contracts.FirstOrDefault(c => c.Id == model.Id);
            if (news == null)
            {
                throw new Exception("Такого события нет");
            }
            db.Contracts.Remove(news);
            db.SaveChanges();
        }
        public List<Contract> Read()
        {
            return db.Contracts.ToList();
        }
        public Contract Get(int Id)
        {
            return db.Contracts.FirstOrDefault(c => c.Id == Id);
        }
        public List<Contract> ReadPage(int skip, int take)
        {
            return context.Contracts
            .Skip(skip).Take(take).Select(rec =>
            new Contract
            {
                Id = rec.Id,
                Curency = rec.Curency,
                ClientId = rec.ClientId,
                SalePeopleId = rec.SalePeopleId,
                AutoId = rec.AutoId
            })
            .ToList();
        }
    }
}
