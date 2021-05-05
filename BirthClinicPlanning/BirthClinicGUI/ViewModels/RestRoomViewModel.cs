﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilMongoRepoTestudvikling;
using EmilMongoRepoTestudvikling.Domainmodels;
using Itenso.TimePeriod;
using Polly;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace BirthClinicGUI.ViewModels
{
    class RestRoomViewModel : BindableBase, IDialogAware
    {
        private IDataAccessActions access;
        private IDialogService _dialog;

        private RestRoom _currentRestRoom;
        public RestRoom CurrentRestRoom { 
            get=> _currentRestRoom; 
            set=>SetProperty(ref _currentRestRoom,value); }

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

        private ObservableCollection<Clinician> _clinicians = new ObservableCollection<Clinician>();

        public ObservableCollection<Clinician> Clinicians
        {
            get => _clinicians;
            set => SetProperty(ref _clinicians, value);
        }
        public RestRoomViewModel(IDialogService dialog)
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
            int roomNumber = int.Parse(parameters.GetValue<string>("Message"));

            CurrentRestRoom = access.RestRooms.GetRestRoomWithSpecificNumber(roomNumber);

            AppointmentsForRoom = CurrentRestRoom.Appointments;

            foreach (var appointment in AppointmentsForRoom)
            {
                DateTime currentTime = DateTime.Now;
                TimeRange nowrange = new TimeRange(currentTime, currentTime);
                TimeRange appointmentrange = new TimeRange(appointment.StartTime, appointment.EndTime);

                if (appointmentrange.IntersectsWith(nowrange) || appointmentrange.OverlapsWith(nowrange))
                {
                    CurrentRestRoom.Occupied = true;
                    Occupied = true;
                    Parents = appointment.Parents;
                    Clinicians = appointment.Clinicians;
                }
                else
                {
                    CurrentRestRoom.Occupied = false;
                    Occupied = false;
                }
            }

            access.Complete();
        }

        public string Title { get; }
        public event Action<IDialogResult> RequestClose;
    }
}
