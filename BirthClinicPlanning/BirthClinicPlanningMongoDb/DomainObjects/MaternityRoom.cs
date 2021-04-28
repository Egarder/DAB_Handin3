using BirthClinicPlanningDB.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanningDB.DomainObjects
{
    [BsonCollection("MaternityRoom")]
    public class MaternityRoom : Room
    {
        public MaternityRoom() : base()
        {
            base.RoomType = "Maternity Room";
        }
    }
}
