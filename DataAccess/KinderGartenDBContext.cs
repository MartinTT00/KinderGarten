namespace DataAccess
{
    using DataStructure;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class KinderGartenDBContext : DbContext
    {
        // Your context has been configured to use a 'KinderGartenDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DataAccess.KinderGartenDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'KinderGartenDBContext' 
        // connection string in the application configuration file.
        public KinderGartenDBContext()
            : base("name=KinderGartenDBContext")
        {
        }

        //internal void Add(Kid kid)
        //{
        //    throw new NotImplementedException();
        //}

        //private DbSet<Kid> kids;

        //private DbSet<Kid> GetKids()
        //{
        //    return kids;
        //}

        //private void SetKids(DbSet<Kid> value)
        //{
        //    kids = value;
        //}


        //DbSet<Kid> Kids { get; set; }
        //DbSet<Activity> Activities { get; set; }
        //DbSet<Parent> Parents { get; set; }
        //DbSet<Location> Locations { get; set; }
        //DbSet<Group> Groups { get; set; }

        internal object GetAll()
        {
            throw new NotImplementedException();
        }

        public System.Data.Entity.DbSet<DataStructure.Kid> Kids { get; set; }

        public System.Data.Entity.DbSet<DataStructure.Group> Groups { get; set; }

        public System.Data.Entity.DbSet<DataStructure.Parent> Parents { get; set; }

        public System.Data.Entity.DbSet<DataStructure.Location> Locations { get; set; }

        public System.Data.Entity.DbSet<DataStructure.Activity> Activities { get; set; }

        public object GetKids()
        {
            throw new NotImplementedException();
        }




        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}