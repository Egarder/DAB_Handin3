using BirthClinicMongoDB;
using Itenso.TimePeriod;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;
using BirthClinicMongoDB.Domainmodels;

namespace BirthClinicGUI.ViewModels
{
    class BirthRoomViewModel : BindableBase, IDialogAware
    {
        private IDataAccessActions access;
        private IDialogService _dialog;

        private Room _currentBirthRoom;
        public Room CurrentBirthRoom
        {
            get => _currentBirthRoom;
            set => SetProperty(ref _currentBirthRoom, value);
        }

        private ObservableCollection<Appointment> _appointmentsForRoom = new ();

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

        private ObservableCollection<Clinician> _clinicians = new ();

        public ObservableCollection<Clinician> Clinicians
        {
            get => _clinicians;
            set => SetProperty(ref _clinicians, value);
        }
        public BirthRoomViewModel(IDialogService dialog)
        {
            _dialog = dialog;

            var context = new MongoDbContext(MongoDbSettings.ConnectionString, MongoDbSettings.DatabaseName);

            access = new DataAccessActions(context);
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

            CurrentBirthRoom = access.Rooms.GetBirthRoomWithSpecificNumber(roomid);

            AppointmentsForRoom = CurrentBirthRoom.Appointments;

            foreach (var appointment in AppointmentsForRoom)
            {
                DateTime currentTime = DateTime.Now;
                TimeRange appointmentrange = new TimeRange(appointment.StartTime, appointment.EndTime);
                TimeRange nowrange = new TimeRange(currentTime, currentTime);

                if (appointmentrange.IntersectsWith(nowrange) || appointmentrange.OverlapsWith(nowrange))
                {
                    CurrentBirthRoom.Occupied = true;
                    Occupied = true;
                    Parents = appointment.Parents;
                    Clinicians = appointment.Clinicians;
                }
                else
                {
                    CurrentBirthRoom.Occupied = false;
                    Occupied = false;
                }
            }
        }

        public string Title { get; }
        public event Action<IDialogResult> RequestClose;
    }
}
