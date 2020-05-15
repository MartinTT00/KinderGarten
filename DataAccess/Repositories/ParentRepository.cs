using DataStructure;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace DataAccess.Repositories
{
    public class ParentRepository
    {
        private readonly KinderGartenDBContext kinderGartenDBContext = new KinderGartenDBContext();

            public ParentRepository(KinderGartenDBContext kinderGartenDBContext)
            {
                this.kinderGartenDBContext = kinderGartenDBContext;
            }
            public void Create()
            {

            }

            public void Create(Parent parent)
            {
                kinderGartenDBContext.Parents.Add(parent);
            }

            public List<Parent> Read()
            {
                List<Parent> allParents = kinderGartenDBContext.Parents.ToList();
                return allParents;
            }

            public Parent Update(int id)
            {
                Parent parent = new Parent();
                parent = GetByID(id);
                return parent;
            }

            public void Update(Parent parent)
            {
                kinderGartenDBContext.Entry(parent).State = EntityState.Modified;
            }
            public Parent Delete(int? id)
            {
                Parent parent = new Parent();
                parent = GetByID(id);
                return parent;
            }
            public Parent Delete(int id)
            {
                Parent parent = new Parent();
                parent = GetByID(id);
                kinderGartenDBContext.Parents.Remove(parent);
                return parent;
        }

            public List<Parent> GetAll()
            {
                List<Parent> allParents = kinderGartenDBContext.Parents.ToList();
                return allParents;
            }
            public Parent GetByID(int id)
            {
            Parent parent = new Parent();
                parent = kinderGartenDBContext.Parents.Find(id);
                return parent;
            }
            public Parent GetByID(int? id)
            {
                Parent parent = new Parent();
                parent = kinderGartenDBContext.Parents.Find(id);
                return parent;
            }

        }
    }
