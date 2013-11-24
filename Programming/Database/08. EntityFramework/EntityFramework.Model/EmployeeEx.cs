using System;
using System.Data.Linq;
using System.Linq;

namespace EntityFramework.Model
{
    public partial class Employee
    {
        public EntitySet<Territory> TerritoriesSet
        {
            get
            {
                var territoriesSet = new EntitySet<Territory>();
                territoriesSet.AddRange(this.Territories);
                return territoriesSet;
            }
        }
    }
}
