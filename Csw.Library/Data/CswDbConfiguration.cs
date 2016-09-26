using System.Data.Entity;

namespace Csw.Library.Data
{
    public class CswDbConfiguration : DbConfiguration
    {
        public CswDbConfiguration()
        {
            this.SetDatabaseInitializer( new CswDbInitializer() );
        }
    }
}