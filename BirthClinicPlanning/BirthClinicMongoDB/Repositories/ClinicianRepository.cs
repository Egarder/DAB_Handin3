using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using System.Linq;
using BirthClinicMongoDB.Domainmodels;
using BirthClinicMongoDB.Repositories.Interfaces;

namespace BirthClinicMongoDB.Repositories
{
    public class ClinicianRepository : BaseRepository<Clinician>, IClinicianRepository
    {
        public ClinicianRepository(IMongoDbContext context) : base(context)
        {
        }

        public void AddClinician(Clinician clinician)
        {
            _dbCollection.InsertOne(clinician);
        }

        public bool CliniciansExist()
        {
            var test =_dbCollection.Find(FilterDefinition<Clinician>.Empty).Any();
            return test;
        }

        public ObservableCollection<Clinician> GetAllClinicians()
        {
            return new ObservableCollection<Clinician>(_dbCollection.Find(new BsonDocument()).ToList());
        }

        public Clinician GetSingleClinician(string id)
        {
            return _dbCollection.Find(c => c.ClinicianID == id).SingleOrDefault();
        }
    }
}
