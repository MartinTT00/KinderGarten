using DataStructure;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
//using System;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Mvc;

namespace DataAccess.Repositories
{
    public class KidRepository
    {
        private readonly KinderGartenDBContext kinderGartenDBContext = new KinderGartenDBContext();

        public KidRepository(KinderGartenDBContext kinderGartenDBContext)
        {
            this.kinderGartenDBContext = kinderGartenDBContext;
        }
        public void Create(DataStructure.ViewModels.KidViewModel kidViewModel)
        {
           
        }

        public void Create(Kid kid)
        {
            kinderGartenDBContext.Kids.Add(kid);
        }

        public List<Kid> Index()
        {
            List<Kid> allKids = kinderGartenDBContext.Kids.ToList();
            return allKids;
        }

        public void Update(Kid kid)
        {
            kinderGartenDBContext.Kids.AddOrUpdate(kid);
        }

        public Kid Delete(int id)
        {
            Kid kid = new Kid();
            kid = GetByID(id); 
            kinderGartenDBContext.Kids.Remove(kid);
            return kid;
        }

        public List<Kid> GetAll()
        {
            List<Kid> allKids = kinderGartenDBContext.Kids.ToList();
            return allKids;
        }
        public Kid GetByID(int id)
        {
            Kid kid = new Kid();
            kid = kinderGartenDBContext.Kids.Find(id);
            return kid;
        }

    }
}
