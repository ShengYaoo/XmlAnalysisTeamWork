using XMLanalysis.OpenData;
using System.Linq;

namespace XMLanalysis.Database
{
    public class mDbContext:System.Data.Entity.DbContext
    {
        static mDbContext() {
            //DbInit dbinit = new DbInit();
            //System.Data.Entity.Database.SetInitializer(dbinit);
        }
        public mDbContext():base("FarmTran")
        {

        }
        public System.Data.Entity.IDbSet<FarmTran> FarmTrans { get; set; }

    }

    public class DbInit : System.Data.Entity.CreateDatabaseIfNotExists <mDbContext>
    {



        public override void InitializeDatabase(mDbContext context)
        {

            base.InitializeDatabase(context);
            MGenericsDB<FarmTran> _rep = new FarmTranTable();
 
            
            _rep.Xml_Load().OfType<FarmTran>().ToList().ForEach(item =>
            {
                context.FarmTrans.Add(item);
            });
            
            context.SaveChanges();

        }
    }
}
