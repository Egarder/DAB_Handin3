using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BirthClinicPlanningDB;
using BirthClinicPlanningDB.DomainObjects;
using Itenso.TimePeriod;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace BirthClinicGUI.ViewModels
{
    class SpecificAppointmentViewModel : BindableBase, IDialogAware
    {
        private IDataAccessActions access = new DataAccessActions(new Context());
        private Appointment _appointment;
        public Appointment Appointment { get => _appointment; set => SetProperty(ref _appointment, value); }
        private IDialogService _dialog;
        public ObservableCollection<string> RoomType { get; set; }
        public int RoomTypeIndex { get; set; }

        public SpecificAppointmentViewModel(IDialogService dialog)
        {
            _dialog = dialog;
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            int id = int.Parse(parameters.GetValue<string>("Message"));
            Appointment = access.Appointments.getSingleAppointment(id);
            
            RoomType = new ObservableCollection<string>() { "Birth Room", "Maternity Room", "Rest Room" };
        }

        public string Title { get; }
        public event Action<IDialogResult> RequestClose;

        private ICommand _checkout;

        public ICommand Checkout
        {
            get
            {
                return _checkout ?? (_checkout = new DelegateCommand(CheckoutExecute));
            }
        }

        private void CheckoutExecute()
        {
            switch (Appointment.Room.RoomType)
            {
                case "Rest Room":
                    ChangeToBirthRoom();
                    break;

                case "Birth Room":
                    ChangeToMaternityRoom();
                    break;

                case "Maternity Room":
                    access.Appointments.DelAppointment(Appointment);
                    access.Complete();
                    break;
            }
        }


        public bool ValidateDate(Appointment existingAppointment)
        {
            TimeRange AppointmentToCompare = new TimeRange(DateTime.Now.Date.Add(existingAppointment.StartTime.TimeOfDay), DateTime.Now.Date.Add(existingAppointment.EndTime.TimeOfDay));
            TimeRange AppointmentToInsert = new TimeRange(DateTime.Now.Date.Add(Appointment.StartTime.TimeOfDay), DateTime.Now.Date.Add(Appointment.EndTime.TimeOfDay));

            if (AppointmentToCompare.OverlapsWith(AppointmentToInsert))
            {
                MessageBox.Show("TimeRange overlaps another Timerange");
                return AppointmentToCompare.OverlapsWith(AppointmentToInsert);
            }

            if (AppointmentToCompare.IntersectsWith(AppointmentToInsert))
            {
                MessageBox.Show("Timerange intersects with another Timerange");
                return AppointmentToCompare.IntersectsWith(AppointmentToInsert);
            }

            return false;
        }

        private void ChangeToBirthRoom()
        {
            ObservableCollection<BirthRoom> birthRooms = access.BirthRooms.GetAllBirthsRooms();

            foreach (var room in birthRooms)
            {
                if (room.Appointments.Count == 0)
                {
                    room.Appointments.Add(Appointment);
                    access.Complete();

                    Appointment.Room.Appointments.Remove(Appointment);
                    access.Complete();

                    return;
                }

                else
                {
                    foreach (var appointment in room.Appointments)
                    {
                        if (!ValidateDate(appointment))
                        {
                            room.Appointments.Add(Appointment);
                            Appointment.Room.Appointments.Remove(Appointment);
                            access.Complete();

                            return;
                        }
                    }
                }
            }

            MessageBox.Show("No Birth rooms available");
        }

        private void ChangeToMaternityRoom()
        {
            ObservableCollection<MaternityRoom> maternityRooms = access.MaternityRooms.GetAllMaternityRooms();

            foreach (var room in maternityRooms)
            {
                foreach (var appointment in room.Appointments)
                {
                    if (!ValidateDate(appointment))
                    {
                        room.Appointments.Add(Appointment);
                        access.Complete();
                    }
                }
            }
        }
    }
}
