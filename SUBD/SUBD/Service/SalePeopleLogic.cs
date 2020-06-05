using SUBD.Interface;
using SUBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SUBD.Service
{
    public class SalePeopleLogic : ILogic<SalePeople>
    {
        private static AutoServiceDataBase db = Program.db;
        private readonly AutoServiceDataBase context;
        public SalePeopleLogic(AutoServiceDataBase context)
        {
            this.context = context;
        }
        public void Create(SalePeople model)
        {
            var news = db.SalePeoples.FirstOrDefault(c => c.Id == model.Id);
            if (news != null)
            {
                throw new Exception("Такое событие уже есть");
            }
            db.SalePeoples.Add(model);
            db.SaveChanges();
        }
        public void Update(SalePeople model)
        {
            var news = db.SalePeoples.FirstOrDefault(c => c.Id == model.Id);
            if (news == null)
            {
                throw new Exception("Такго события  нет");
            }
            news.InformationId = model.InformationId;
            news.Name = model.Name;
            news.WageDollars = model.WageDollars;
            db.SaveChanges(); 
        }
        public void Delete(SalePeople model)
        {
            var news = db.SalePeoples.FirstOrDefault(c => c.Id == model.Id);
            if (news == null)
            {
                throw new Exception("Такого события нет");
            }
            db.SalePeoples.Remove(news);
            db.SaveChanges();
        }
        public List<SalePeople> Read()
        {
            return db.SalePeoples.ToList();
        }
        public SalePeople Get(int Id)
        {
            return db.SalePeoples.FirstOrDefault(c => c.Id == Id);
        }
        public List<SalePeople> ReadPage(int skip, int take)
        {
            return context.SalePeoples
            .Skip(skip).Take(take).Select(rec =>
            new SalePeople
            {
                Id = rec.Id,
                Name = rec.Name,
                WageDollars = rec.WageDollars,
                InformationId = rec.InformationId,
            })
            .ToList();
        }
    }
}
