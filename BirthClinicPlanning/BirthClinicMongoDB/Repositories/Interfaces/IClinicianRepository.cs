using System.Collections.ObjectModel;
using BirthClinicMongoDB.Domainmodels;

namespace BirthClinicMongoDB.Repositories.Interfaces
{
    public interface IClinicianRepository: IBaseRepository<Clinician>
    {
        public ObservableCollection<Clinician> GetAllClinicians();

        public Clinician GetSingleClinician(string id);

        public void AddClinician(Clinician clinician);
    }
}
