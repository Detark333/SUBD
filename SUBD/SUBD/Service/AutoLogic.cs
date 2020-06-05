using SUBD.Interface;
using SUBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SUBD.Service
{
    public class AutoLogic : ILogic<Auto>
    {
        private static AutoServiceDataBase db = Program.db;
        public void Create(Auto model)
        {
            var news = db.Autos.FirstOrDefault(c => c.Id == model.Id);
            if (news != null)
            {
                throw new Exception("Такое событие уже есть");
            }
            db.Autos.Add(model);
            db.SaveChanges();
        }
        public void Update(Auto model)
        {
            var news = db.Autos.FirstOrDefault(c => c.Id == model.Id);
            if (news == null)
            {
                throw new Exception("Такго события  нет");
            }
            news.ModelName = model.ModelName;
            news.BrandName = model.BrandName;
            news.TypeMotor = model.TypeMotor;
            news.CountAirbags = model.CountAirbags;
            db.SaveChanges();
        }
        public void Delete(Auto model)
        {
            var news = db.Autos.FirstOrDefault(c => c.Id == model.Id);
            if (news == null)
            {
                throw new Exception("Такого события нет");
            }
            db.Autos.Remove(news);
            db.SaveChanges();
        }
        public List<Auto> Read()
        {
            return db.Autos.ToList();
        }
        public Auto Get(int Id)
        {
            return db.Autos.FirstOrDefault(c => c.Id == Id);
        }
    }
}
