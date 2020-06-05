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
    }
}
