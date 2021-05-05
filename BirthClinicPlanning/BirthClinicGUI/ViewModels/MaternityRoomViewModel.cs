using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilMongoRepoTestudvikling;
using EmilMongoRepoTestudvikling.Domainmodels;
using Itenso.TimePeriod;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace BirthClinicGUI.ViewModels
{
    class MaternityRoomViewModel : BindableBase, IDialogAware
    {
        private IDataAccessActions access;
        private IDialogService _dialog;

        private MaternityRoom _currentMaternityRoom;
        public MaternityRoom CurrentMaternityRoom
        {
            get => _currentMaternityRoom;
            set => SetProperty(ref _currentMaternityRoom, value);
        }

        private ObservableCollection<Appointment> _appointmentsForRoom = new ObservableCollection<Appointment>();

        public ObservableCollection<Appointment> AppointmentsForRoom
        {
            get => _appointmentsForRoom;
            set => SetProperty(ref _appointmentsForRoom, value);
        }

        private Parents _parents;

        public Parents Parents
        {
            get => _parents;
            set => SetProperty(ref _parents, value);
        }

        private Child _child;

        public Child Child
        {
            get => _child;
            set => SetProperty(ref _child, value);
        }
        private ObservableCollection<Clinician> _clinicians = new ObservableCollection<Clinician>();

        public ObservableCollection<Clinician> Clinicians
        {
            get => _clinicians;
            set => SetProperty(ref _clinicians, value);
        }

        public MaternityRoomViewModel(IDialogService dialog)
        {
            IMongoDbSettings settings = new MongoDbSettings();
            settings.ConnectionString = "mongodb://localhost:27017";
            settings.DatabaseName = "BirthClinicPlanning";
            var context = new MongoDbContext(settings.ConnectionString, settings.DatabaseName);

            access = new DataAccessActions(context);

            _dialog = dialog;
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public bool Occupied { get; set; }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            int roomid = int.Parse(parameters.GetValue<string>("Message"));

            CurrentMaternityRoom = access.MaternityRooms.GetMaternityRoomWithSpecificNumber(roomid);

            
                AppointmentsForRoom = CurrentMaternityRoom.Appointments;

                foreach (var appointment in AppointmentsForRoom)
                {
                    DateTime currentTime = DateTime.Now;
                    TimeRange appointmentrange = new TimeRange(appointment.StartTime, appointment.EndTime);
                    TimeRange nowrange = new TimeRange(currentTime, currentTime);

                    if (appointmentrange.IntersectsWith(nowrange) || appointmentrange.OverlapsWith(nowrange))
                    {
                        CurrentMaternityRoom.Occupied = true;
                        Occupied = true;
                        Parents = appointment.Parents;
                        Clinicians = appointment.Clinicians;
                        Child = appointment.Child;
                    }
                    else
                    {
                        CurrentMaternityRoom.Occupied = false;
                        Occupied = false;
                    }
                }
        }

        public string Title { get; }
        public event Action<IDialogResult> RequestClose;
    }
}
