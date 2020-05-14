using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UnitOfWork
    {
        private GroupRepository groupRepository;
        public GroupRepository GroupR
        {
            get
            {
                if (groupRepository == null)
                {
                    groupRepository = new GroupRepository(kinderGartenDBContext);
                }
                return groupRepository;
            }
        }


        private KidRepository kidRepository;
        public KidRepository KidR
        {
            get
            {
                if (kidRepository == null)
                {
                    kidRepository = new KidRepository(kinderGartenDBContext);
                }
                return kidRepository;
            }
        }


        private ActivityRepository activityRepository;
        public ActivityRepository ActivityR
        {
            get
            {
                if (activityRepository == null)
                {
                    activityRepository = new ActivityRepository(kinderGartenDBContext);
                }
                return activityRepository;
            }
        }


        private ParentRepository parentRepository;
        public ParentRepository ParentR
        {
            get
            {
                if(parentRepository == null)
                {
                    parentRepository = new ParentRepository(kinderGartenDBContext);
                }
                return parentRepository;
            }
        }



        private LocationRepository locationRepository;
        public LocationRepository LocationR
        {
            get
            {
                if (locationRepository == null)
                {
                    locationRepository = new LocationRepository(kinderGartenDBContext);
                }
                return locationRepository;
            }
        }


        private UnitOfWork()
        {
            this.kinderGartenDBContext = new KinderGartenDBContext();
        }

        public void Save()
        {
            kinderGartenDBContext.SaveChanges();
        }




        private KinderGartenDBContext kinderGartenDBContext;

        public KinderGartenDBContext KGdbContex
        {
            get
            {
                if(kinderGartenDBContext == null)
                {
                    kinderGartenDBContext = new KinderGartenDBContext();
                }
                return kinderGartenDBContext;
            }
        }
        private static UnitOfWork uow; 
        public UnitOfWork UOW
        {
            get
            {
                if (uow == null)
                {
                    uow = new UnitOfWork();
                }
                return uow;
            }
        }
    }
}
