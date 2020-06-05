using SUBD.Interface;
using SUBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SUBD.Service
{
    public class ClientLogic : ILogic<Client>
    {
        private static AutoServiceDataBase db = Program.db;
        public void Create(Client model)
        {
            var news = db.Clients.FirstOrDefault(c => c.Name == model.Name);
            if (news != null)
            {
                throw new Exception("Такое событие уже есть");
            }
            db.Clients.Add(model);
            db.SaveChanges();
        }
        public void Update(Client model)
        {
            var news = db.Clients.FirstOrDefault(c => c.Id == model.Id);
            if (news == null)
            {
                throw new Exception("Такго события  нет");
            }
            news.InformationId = model.InformationId;
            news.Name = model.Name;
            db.SaveChanges();
        }
        public void Delete(Client model)
        {
            var news = db.Clients.FirstOrDefault(c => c.Id == model.Id);
            if (news == null)
            {
                throw new Exception("Такого события нет");
            }
            db.Clients.Remove(news);
            db.SaveChanges();
        }
        public List<Client> Read()
        {
            return db.Clients.ToList();
        }
        public Client Get(int Id)
        {
            return db.Clients.FirstOrDefault(c => c.Id == Id);
        }
    }
}
