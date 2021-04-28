using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthClinicPlanningMongoDb
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
