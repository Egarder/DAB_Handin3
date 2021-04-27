using BirthClinicPlanningDB.DomainObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanningDB.Repositories.RepositoryInterfaces
{
    public interface IClinicianRepository : IRepository<Clinician>
    {
        public ObservableCollection<Clinician> GetAllClinicians();

        public Clinician GetSingleClinician(int id);

        public void AddClinician(Clinician clinician);
    }
}
