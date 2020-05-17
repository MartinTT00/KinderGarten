using DataStructure;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;


namespace DataAccess.Repositories
{
    public class LocationRepository
    {
        private readonly KinderGartenDBContext kinderGartenDBContext = new KinderGartenDBContext();

        public LocationRepository(KinderGartenDBContext kinderGartenDBContext)
        {
            this.kinderGartenDBContext = kinderGartenDBContext;
        }


        public void Create()
        {

        }

        public void Create(Location location)
        {
            kinderGartenDBContext.Locations.Add(location);
        }

        public List<Location> Read()
        {
            List<Location> allLocations = kinderGartenDBContext.Locations.ToList();
            return allLocations;
        }

        public Location Update(int id)
        {
            Location location = new Location();
            location = GetByID(id);
            return location;
        }

        public void Update(Location location)
        {
            kinderGartenDBContext.Locations.AddOrUpdate(location);
        }
        public Location Delete(int? id)
        {
            Location location = new Location();
            location = GetByID(id);
            return location;
        }
        public Location Delete(int id)
        {
            Location location = new Location();
            location = GetByID(id); 
            kinderGartenDBContext.Locations.Remove(location);
            return location;
        }

        public List<Location> GetAll()
        {
            List<Location> allLocations = kinderGartenDBContext.Locations.ToList();
            return allLocations;
        }
        public Location GetByID(int id)
        {
            Location location = new Location();
            location = kinderGartenDBContext.Locations.Find(id);
            return location;
        }
        public Location GetByID(int? id)
        {
            Location location = new Location();
            location = kinderGartenDBContext.Locations.Find(id);
            return location;
        }

    }
}
