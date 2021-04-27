using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthClinicPlanningDB.DomainObjects
{
    public class BirthRoom : Room
    {
        public BirthRoom() : base()
        {
            base.RoomType = "Birth Room";
        }
    }
}