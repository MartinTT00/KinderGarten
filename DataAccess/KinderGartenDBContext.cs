namespace DataAccess
{
    using DataStructure;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class KinderGartenDBContext : DbContext
    {
        public KinderGartenDBContext()
            : base("name=KinderGartenDBContext")
        {
        }

        public System.Data.Entity.DbSet<DataStructure.Kid> Kids { get; set; }

        public System.Data.Entity.DbSet<DataStructure.Group> Groups { get; set; }

        public System.Data.Entity.DbSet<DataStructure.Parent> Parents { get; set; }

        public System.Data.Entity.DbSet<DataStructure.Location> Locations { get; set; }

        public System.Data.Entity.DbSet<DataStructure.Activity> Activities { get; set; }

    }
}