using BirthClinicPlanningDB.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthClinicPlanningDB.DomainObjects
{
    [BsonCollection("BirthRoom")]
    public class BirthRoom : Room
    {
        public BirthRoom() : base()
        {
            base.RoomType = "Birth Room";
        }
    }
}