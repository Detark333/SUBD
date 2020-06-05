using SUBD.Interface;
using SUBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SUBD.Service
{
    public class InformationLogic : ILogic<Information>
    {
        private static AutoServiceDataBase db = Program.db;
        private readonly AutoServiceDataBase context;
        public InformationLogic(AutoServiceDataBase context)
        {
            this.context = context;
        }
        public void Create(Information model)
        {
            var news = db.Informations.FirstOrDefault(c => c.Id == model.Id);
            if (news != null)
            {
                throw new Exception("Такое событие уже есть");
            }
            db.Informations.Add(model);
            db.SaveChanges();
        }
        public void Update(Information model)
        {
            var news = db.Informations.FirstOrDefault(c => c.Id == model.Id);
            if (news == null)
            {
                throw new Exception("Такго события  нет");
            }
            news.Adress = model.Adress;
            news.PhoneNumber = model.PhoneNumber;
            news.Adress = model.Adress;
            news.Passport = model.Passport;
            db.SaveChanges();
        }
        public void Delete(Information model)
        {
            var news = db.Informations.FirstOrDefault(c => c.Id == model.Id);
            if (news == null)
            {
                throw new Exception("Такого события нет");
            }
            db.Informations.Remove(news);
            db.SaveChanges();
        }
        public List<Information> Read()
        {
            return db.Informations.ToList();
        }
        public Information Get(int Id)
        {
            return db.Informations.FirstOrDefault(c => c.Id == Id);
        }
        public List<Information> ReadPage(int skip, int take)
        {
            return context.Informations
            .Skip(skip).Take(take).Select(rec =>
            new Information
            {
                Id = rec.Id,
                Adress = rec.Adress,
                PhoneNumber = rec.PhoneNumber,
                Passport = rec.Passport,
            })
            .ToList();
        }
    }
}
