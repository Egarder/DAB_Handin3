using BirthClinicPlanningMongoDbWebAPI.DomainObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace EmilMongoRepoTestudvikling.Repositories.Interfaces
{
    public interface IClinicianRepository: IBaseRepository<Clinician>
    {
        public ObservableCollection<Clinician> GetAllClinicians();

        public Clinician GetSingleClinician(string id);

        public void AddClinician(Clinician clinician);
    }
}
