using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Input;
using EmilMongoRepoTestudvikling;
using EmilMongoRepoTestudvikling.Domainmodels;
using ImTools;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace BirthClinicGUI.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        private IDialogService _dialog;
        private ObservableCollection<Appointment> _appointments;
        private string _clinicianFirstName;
        private string _clinicianLastName;
        private IDataAccessActions access;

        public string ClinicianFirstName 
        { 
            get => _clinicianFirstName;
            set => SetProperty(ref _clinicianFirstName, value);
        }
        public string ClinicianLastName 
        { 
            get => _clinicianLastName;
            set => SetProperty(ref _clinicianLastName, value); 
        }

        private int _appointmentIndex;
        public int AppointmentIndex
        {
            get => _appointmentIndex;
            set => SetProperty(ref _appointmentIndex, value);
        }

        public ObservableCollection<Appointment> Appointments
        {
            get => _appointments;
            set => SetProperty(ref _appointments, value);
        }

        public MainWindowViewModel(IDialogService dialog)
        {
            _dialog = dialog;

            SetUpRoomsAppointmentsListInDb(); //Setting up relation between seeded rooms and appointments

            IMongoDbSettings settings = new MongoDbSettings();
            settings.ConnectionString = "mongodb://localhost:27017";
            settings.DatabaseName = "BirthClinicPlanning";
            var context = new MongoDbContext(settings.ConnectionString, settings.DatabaseName);

            access = new DataAccessActions(context);

            Appointments = access.Appointments.GetAllAppointments();
            
            AppointmentIndex = 0;

        }

        internal void SetUpRoomsAppointmentsListInDb() 
        {
            var room1 = access.RestRooms.GetSingleRestRoom(""); // skal have et andet id

            var appoint1 = access.Appointments.GetSingleAppointment(room1.RoomID);

            var temp = room1.Appointments.FindFirst(a => a.AppointmentID == appoint1.AppointmentID);

            if (temp == null)
                room1.Appointments.Add(appoint1);

            var room2 = access.RestRooms.GetSingleRestRoom(""); // skal have et andet id

            var appoint2 = access.Appointments.GetSingleAppointment(room2.RoomID);

            var temp2 = room2.Appointments.FindFirst(b => b.AppointmentID == appoint2.AppointmentID);

            if (temp2 == null)
                room2.Appointments.Add(appoint2);
        }

        private ICommand _addAppointmentCommand;

        public ICommand AddAppointmentCommand
        {
            get
            {
                return _addAppointmentCommand ??
                       (_addAppointmentCommand = new DelegateCommand(AddAppointmentCommandExecute));
            }
        }

        private void AddAppointmentCommandExecute()
        {
            _dialog.ShowDialog("AddAppointmentView", r =>
            {
                Appointments = access.Appointments.GetAllAppointments();
            });
        }

        private ICommand _delAppointmentCommand;

        public ICommand DelAppointmentCommand
        {
            get
            {
                return _delAppointmentCommand ??
                       (_delAppointmentCommand = new DelegateCommand(DelAppointmentCommandExecute));
            }
        }

        private void DelAppointmentCommandExecute()
        {
            var temp = access.Appointments.GetSingleAppointment(Appointments[AppointmentIndex].AppointmentID);
            
            access.Appointments.DelAppointment(temp);

            Appointments = access.Appointments.GetAllAppointments();
        }


        private ICommand _selectAppointmentCommand;

        public ICommand SelectAppointmentCommand
        {
            get
            {
                return _selectAppointmentCommand ??
                       (_selectAppointmentCommand = new DelegateCommand(SelectAppointmentCommandExecute));
            }

        }

        private void SelectAppointmentCommandExecute()
        {
            if (AppointmentIndex >= Appointments.Count)
            {
                MessageBox.Show("The chosen field has no value", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                string id = Appointments[AppointmentIndex].AppointmentID.ToString();
                _dialog.ShowDialog("SpecificAppointmentView", new DialogParameters($"Message={id}"), r =>
                {
                });
                Appointments = access.Appointments.GetAllAppointments();
            }
        }

        private ICommand _statusRoomsCommand;

        public ICommand StatusRoomsCommand
        {
            get
            {
                return _statusRoomsCommand ?? (_statusRoomsCommand = new DelegateCommand(StatusRoomsCommandExecute));
            }

        }

        private void StatusRoomsCommandExecute()
        {
            _dialog.ShowDialog("StatusRoomsView", r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    if (r.Result == ButtonResult.OK)
                    {
                        Appointments = access.Appointments.GetAllAppointments();
                    }
                }
            });
        }

        private ICommand _addClinician;


        public ICommand AddClinician
        {
            get
            {
                return _addClinician ?? (_addClinician = new DelegateCommand(AddClinicianCanExcecute));
            }
        }

        private void AddClinicianCanExcecute()
        {
            if ((ClinicianFirstName == "" || ClinicianLastName == ""))
                MessageBox.Show("Please fill out all required fields", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);

            else
            {
                Clinician newClinician = new Clinician() { FirstName = ClinicianFirstName, LastName = ClinicianLastName };
                access.Clinicians.AddClinician(newClinician);

                MessageBox.Show("Clinician " + ClinicianFirstName + " " + ClinicianLastName + " added", "Clinician added", MessageBoxButton.OK);

                ClinicianFirstName = "";
                ClinicianLastName = "";
            }
        }
    }
}
