using BirthClinicMongoDB;
using Itenso.TimePeriod;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;
using BirthClinicMongoDB.Domainmodels;

namespace BirthClinicGUI.ViewModels
{
    class MaternityRoomViewModel : BindableBase, IDialogAware
    {
        private IDataAccessActions access;
        private IDialogService _dialog;

        private Room _currentMaternityRoom;
        public Room CurrentMaternityRoom
        {
            get => _currentMaternityRoom;
            set => SetProperty(ref _currentMaternityRoom, value);
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

        private Child _child;

        public Child Child
        {
            get => _child;
            set => SetProperty(ref _child, value);
        }
        private ObservableCollection<Clinician> _clinicians = new ();

        public ObservableCollection<Clinician> Clinicians
        {
            get => _clinicians;
            set => SetProperty(ref _clinicians, value);
        }

        public MaternityRoomViewModel(IDialogService dialog)
        {
            var context = new MongoDbContext(MongoDbSettings.ConnectionString, MongoDbSettings.DatabaseName);

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

            CurrentMaternityRoom = access.Rooms.GetMaternityRoomWithSpecificNumber(roomid);

            
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
