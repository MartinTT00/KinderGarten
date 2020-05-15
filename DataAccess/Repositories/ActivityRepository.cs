using DataStructure;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace DataAccess.Repositories
{
    public class ActivityRepository
    {
        private readonly KinderGartenDBContext kinderGartenDBContext = new KinderGartenDBContext();

        public ActivityRepository(KinderGartenDBContext kinderGartenDBContext)
        {
            this.kinderGartenDBContext = kinderGartenDBContext;
        }
        public void Create()
        {

        }


        public void Create(Activity activity)
        {
            kinderGartenDBContext.Activities.Add(activity);
        }

        public List<Activity> Read()
        {
            List<Activity> allActivities = kinderGartenDBContext.Activities.ToList();
            return allActivities;
        }

        public Activity Update(int id)
        {
            Activity activity = new Activity();
            activity = GetByID(id);
            return activity;
        }

        public void Update(Activity activity)
        {
            kinderGartenDBContext.Entry(activity).State = EntityState.Modified;
        }
        public Activity Delete(int? id)
        {
            Activity activity = new Activity();
            activity = GetByID(id);
            return activity;
        }
        public Activity Delete(int id)
        {
            Activity activity = new Activity();
            activity = GetByID(id);
            activity = kinderGartenDBContext.Activities.Remove(activity);
            return activity;
        }

        public List<Activity> GetAll()
        {
            List<Activity> allActivities = kinderGartenDBContext.Activities.ToList();
            return allActivities;
        }
        public Activity GetByID(int id)
        {
            Activity activity = new Activity();
            activity = kinderGartenDBContext.Activities.Find(id);
            return activity;
        }
        public Activity GetByID(int? id)
        {
            Activity activity = new Activity();
            activity = kinderGartenDBContext.Activities.Find(id);
            return activity;
        }

    }
}
