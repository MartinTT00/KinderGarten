using DataStructure;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace DataAccess.Repositories
{
    public class GroupRepository
    {
        private readonly KinderGartenDBContext kinderGartenDBContext = new KinderGartenDBContext();

        public GroupRepository(KinderGartenDBContext kinderGartenDBContext)
        {
            this.kinderGartenDBContext = kinderGartenDBContext;
        }
        public void Create()
        {

        }

        public void Create(Group group)
        {
            kinderGartenDBContext.Groups.Add(group);
        }

        public List<Group> Read()
        {
            List<Group> allGroups = kinderGartenDBContext.Groups.ToList();
            return allGroups;
        }

        public Group Update(int id)
        {
            Group group = new Group();
            group = GetByID(id);
            return group;
        }

        public void Update(Group group)
        {
            kinderGartenDBContext.Entry(group).State = EntityState.Modified;
        }
        public Group Delete(int? id)
        {
            Group group = new Group();
            group = GetByID(id);
            return group;
        }
        public Group Delete(int id)
        {
            Group group = new Group();
            group = GetByID(id); 
            kinderGartenDBContext.Groups.Remove(group);
            return group;
        }

        public List<Group> GetAll()
        {
            List<Group> allGroups = kinderGartenDBContext.Groups.ToList();
            return allGroups;
        }
        public Group GetByID(int id)
        {
            Group group = new Group();
            group = kinderGartenDBContext.Groups.Find(id);
            return group;
        }
        public Group GetByID(int? id)
        {
            Group group = new Group();
            group = kinderGartenDBContext.Groups.Find(id);
            return group;
        }

    }
}
