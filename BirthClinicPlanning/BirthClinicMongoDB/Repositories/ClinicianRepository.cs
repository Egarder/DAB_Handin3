using EmilMongoRepoTestudvikling.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using EmilMongoRepoTestudvikling.Domainmodels;

namespace EmilMongoRepoTestudvikling.Repositories
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
