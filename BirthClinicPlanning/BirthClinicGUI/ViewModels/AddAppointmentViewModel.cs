using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Itenso.TimePeriod;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using EmilMongoRepoTestudvikling;
using EmilMongoRepoTestudvikling.Domainmodels;
using EmilMongoRepoTestudvikling.Repositories;
using EmilMongoRepoTestudvikling.Repositories.Interfaces;

namespace BirthClinicGUI.ViewModels
{
    class AddAppointmentViewModel : BindableBase, IDialogAware
    {
        #region Properties

        public Appointment Appointment { get; set; }
        public int ClinicianIndex { get; set; }
        public ObservableCollection<Clinician> AllClinicians { get; set; }

        public ObservableCollection<string> RoomType { get; set; }
        public int RoomTypeIndex { get; set; }
        public bool CanClose { get; set; }

        #endregion
        private IMongoDbSettings settings = new MongoDbSettings();
        
        private IDataAccessActions access;
        private bool _okButtonPressed;
        private IDialogService _dialog;

        public AddAppointmentViewModel(IDialogService dialog)
        {
            _dialog = dialog;

            settings.ConnectionString = "mongodb://localhost:27017";
            settings.DatabaseName = "BirthClinicPlanning";
            var context = new MongoDbContext(settings.ConnectionString, settings.DatabaseName);

            access = new DataAccessActions(context);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public bool ValidateDate(Appointment existingAppointment)
        {
            TimeRange AppointmentToInsert = new TimeRange(DateTime.Now.Date.Add(Appointment.StartTime.TimeOfDay), DateTime.Now.Date.Add(Appointment.EndTime.TimeOfDay));
            TimeRange AppointmentToCompare = new TimeRange(DateTime.Now.Date.Add(existingAppointment.StartTime.TimeOfDay), DateTime.Now.Date.Add(existingAppointment.EndTime.TimeOfDay));

            if (AppointmentToCompare.IsSamePeriod(AppointmentToInsert))
            {
                MessageBox.Show("TimeRange is occupied");
                return AppointmentToCompare.IsSamePeriod(AppointmentToInsert);
            }
            else if (AppointmentToCompare.HasInside(AppointmentToInsert))
            {
                MessageBox.Show("TimeRange overlaps another Timerange");
                return AppointmentToCompare.HasInside(AppointmentToInsert);
            }
            else if (AppointmentToCompare.OverlapsWith(AppointmentToInsert))
            {
                MessageBox.Show("TimeRange overlaps another Timerange");
                return AppointmentToCompare.OverlapsWith(AppointmentToInsert);
            }
            else if (AppointmentToCompare.IntersectsWith(AppointmentToInsert))
            {
                MessageBox.Show("Timerange intersects with another Timerange");
                return AppointmentToCompare.IntersectsWith(AppointmentToInsert);
            }

            else
                return false;
        }

        public void OnDialogClosed()
        { }

        #region Helper methods
        public void AddAppointmentToRestRoom()
        {
            if (Appointment.Room.RoomNumber > 5)
            {
                MessageBox.Show("Cannot create appointment for restroom with a room number above 5 \nOnly 5 restrooms exist.", "Invalid room number");
                CanClose = false;
                return;
            }

            RestRoom roomToInsert = access.RestRooms.GetRestRoomWithSpecificNumber(Appointment.Room.RoomNumber);

            foreach (var appointment in roomToInsert.Appointments)
            {
                if (appointment != null && appointment.StartTime.Date == Appointment.StartTime.Date)
                {
                    if (ValidateDate(appointment))
                    {
                        CanClose = false;
                        return;
                    } } }

            roomToInsert.Appointments.Add(Appointment);
            access.Complete();
        }
        public void AddAppointmentToBirthRoom()
        {
            BirthRoom roomToInsert = access.BirthRooms.GetBirthRoomWithSpecificNumber(Appointment.Room.RoomNumber);

            foreach (var appointment in roomToInsert.Appointments)
            {
                if (appointment != null && appointment.StartTime.Date == Appointment.StartTime.Date)
                {
                    if (ValidateDate(appointment))
                    {
                        CanClose = false;
                        return;
                    } } }

            roomToInsert.Appointments.Add(Appointment);
            access.Complete();
        }

        public void AddAppointmentToMaternityRoom()
        {
            MaternityRoom roomToInsert = access.MaternityRooms.GetMaternityRoomWithSpecificNumber(Appointment.Room.RoomNumber);

            foreach (var appointment in roomToInsert.Appointments)
            {
                if (appointment != null && appointment.StartTime.Date == Appointment.StartTime.Date)
                {
                    if (ValidateDate(appointment))
                    {
                        CanClose = false;
                        return;
                    } } }

            _dialog.ShowDialog("BabyInformationView");
            Appointment.Child = ((App)Application.Current).Child;

            roomToInsert.Appointments.Add(Appointment);
            access.Complete();
        }
        #endregion

        public void OnDialogOpened(IDialogParameters parameters)
        {
            CanClose = true;

            AllClinicians = access.Clinicians.GetAllClinicians();

            RoomType = new ObservableCollection<string>() {"Birth Room", "Maternity Room", "Rest Room"};

            Appointment = new Appointment()
                {Room = new Room(), Child = new Child(), Parents = new Parents() {MomCPR = "", DadCPR = ""}, Clinicians = new ObservableCollection<Clinician>()};

            Appointment.StartTime = DateTime.Now.AddHours(1);
            Appointment.EndTime = DateTime.Now.AddHours(5);

        }

        public string Title => "Add Appointment";
        public event Action<IDialogResult> RequestClose;

        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        protected virtual void CloseDialog(string parameter)
        {
            CanClose = true;
            ButtonResult result = ButtonResult.None;

            if (parameter?.ToLower() == "true")
            {
                if (DateTime.Compare(Appointment.StartTime, DateTime.Now) < 0)
                {
                    CanClose = false;
                    MessageBox.Show("Appointment start cannot be earlier than present date/time");
                    return;
                }

                if (Appointment.StartTime > Appointment.EndTime)
                {
                    CanClose = false;
                    MessageBox.Show("Appointment start cannot be later than end date/time");
                }

                if (Appointment.Parents.MomCPR == "" || Appointment.Room.RoomNumber == 0)
                {
                    MessageBox.Show("Please fill out all required fields", "Error");
                    CanClose = false;
                }

                else
                {
                    Cpr = Appointment.Parents.MomCPR;
                    CheckCPR("mother");

                    if (Appointment.Parents.DadCPR != "")
                    {
                        Cpr = Appointment.Parents.DadCPR;
                        CheckCPR("father");
                    }
                }

                if (CanClose)
                {
                    switch (RoomType[RoomTypeIndex])
                    {
                        case "Rest Room":
                            AddAppointmentToRestRoom();
                            break;

                        case "Birth Room":
                            AddAppointmentToBirthRoom();
                            break;

                        case "Maternity Room":
                            AddAppointmentToMaternityRoom();
                            break;
                    }
                }

                if (CanClose)
                {
                    result = ButtonResult.OK;
                    _okButtonPressed = true;
                }
            }
            else if (parameter?.ToLower() == "false")
                result = ButtonResult.Cancel;

            

            if (CanClose)
                RequestClose(new DialogResult(result));
        }


        private ICommand _addClinicianFromList;

        public ICommand AddClinicianFromList
        {
            get
            {
                return _addClinicianFromList ?? (_addClinicianFromList = new DelegateCommand(AddClinicianFromListExcecute));
            }
        }

        private void AddClinicianFromListExcecute()
        {
            Clinician clinician = AllClinicians[ClinicianIndex];
            Appointment.Clinicians.Add(clinician);

            string message = "";

            foreach (var staff in Appointment.Clinicians)
            {
                message += string.Join(", ", $"\n{staff.Type} {staff.FirstName} {staff.LastName}");
            }

            MessageBox.Show($"Currently added Clinicians:\n {message}", "Clinician added to appointment", MessageBoxButton.OK);
        }

        #region CPR-validation

        private void CheckCPR(string parent)
        {
            if (!CheckFormat())
            {
                MessageBox.Show($"Please input a CPR with 10 digits ({parent})", "CPR digits error");
                CanClose = false;
                return;
            }

            if (!CheckDate())
            {
                MessageBox.Show($"Please input a CPR with a valid date ({parent})", "CPR date error");
                CanClose = false;
                return;
            }

            if (!Check11Test())
            {
                MessageBox.Show($"Please input a valid CPR ({parent})", "CPR-invalid error");
                CanClose = false;
                return;
            }
        }

        private bool CheckFormat()
        {
            if (cpr.Length == 10)
                return true;

            return false;
        }

        private bool CheckDate()
        {
            string daystring = cpr.Substring(0, 2);
            string monthstring = cpr.Substring(2, 2);
            string yearstring = cpr.Substring(4, 2);

            int day = int.Parse(daystring);
            int month = int.Parse(monthstring);
            int tempyear = int.Parse(yearstring);
            int year = (tempyear >= 0 && tempyear <= 20 ? 2000 + tempyear : 1900 + tempyear);

            try
            {
                DateTime date = new DateTime(year, month, day);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        private bool Check11Test()
        {
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += int.Parse(cpr.Substring(i, 1)) * (4 - i);
            }

            for (int i = 3; i < 10; i++)
            {
                sum += int.Parse(cpr.Substring(i, 1)) * (10 - i);
            }

            if (sum % 11 != 0)
                return false;

            return true;
        }


        private string cpr;

        private string Cpr
        {
            get => (cpr.Substring(0, 6) + "-" + cpr.Substring(7, 4));
            set
            {
                if (cpr == value.Replace("-", string.Empty))
                    return;

                cpr = value.Replace("-", string.Empty).Replace("/", string.Empty).Replace(" ", string.Empty);
            }
        }

        #endregion
    }
}
