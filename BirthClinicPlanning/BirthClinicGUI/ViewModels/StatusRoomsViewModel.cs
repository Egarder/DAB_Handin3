using BirthClinicMongoDB;
using BirthClinicMongoDB.Domainmodels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;

namespace BirthClinicGUI.ViewModels
{
    public class StatusRoomsViewModel : BindableBase, IDialogAware
    {
        private IDataAccessActions access;
        private IDialogService _dialog;

        public StatusRoomsViewModel(IDialogService dialog)
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

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Rooms = new ObservableCollection<Room>();
            Rooms = access.Rooms.GetAllRoom();

            BirthRooms = new ObservableCollection<Room>();
            BirthRooms = access.BirthRooms.GetAllBirthsRooms();

            Rooms = new ObservableCollection<Room>();
            Rooms = access.Rooms.GetAllRooms();
        }

        private string title = "StatusRoomsViewModel";

        public string Title
        {
            get=>title;
            set => SetProperty(ref title, value);
        }
        public event Action<IDialogResult> RequestClose;

        #region Rooms collections + CurrentRoom properties

        private Room _currentRoom;

        public Room CurrentRoom
        {
            get=>_currentRoom; 
            set=>SetProperty(ref _currentRoom, value);
        }

        public string CurrentRoomId
        {
            get => CurrentRoom.RoomNumber.ToString();
        }


        private ObservableCollection<Room> _rooms; //Room

        public ObservableCollection<Room> Rooms
        {
            get => _rooms;
            set => SetProperty(ref _rooms, value);
        }

        private Room _currentRoom;

        public Room CurrentRoom
        {
            get => _currentRoom;
            set => SetProperty(ref _currentRoom, value);
        }

        public string CurrentRoomId
        {
            get => CurrentRoom.RoomNumber.ToString();
        }
        #endregion

        #region Select Room Command
        private DelegateCommand<string> _selectRoomCommand;

        public DelegateCommand<string> SelectRoomCommand
        {
            get
            {
                return _selectRoomCommand ?? (_selectRoomCommand = new DelegateCommand<string>(SelectRoomCommandExecute));
            }
        }

        private void SelectRoomCommandExecute(string roomType)
        {
            if (roomType == "Rooms")
            {
                if (RoomIndex < 5)
                {
                    CurrentRoom = Rooms[RoomIndex];
                    _dialog.ShowDialog("RoomView", new DialogParameters($"Message={CurrentRoom.RoomNumber}"), r => { });
                }

                else
                    return;
            }

            else if (roomType == "BirthRooms")
            {
                if (BirthRoomIndex < 15)
                {
                    CurrentBirthRoom = BirthRooms[BirthRoomIndex];
                    _dialog.ShowDialog("BirthRoomView", new DialogParameters($"Message={CurrentBirthRoom.RoomNumber}"), r => { });
                }
                else
                    return;
            }

            else if (roomType == "Rooms")
            {
                if (MaternityIndex < 22)
                {
                    CurrentRoom = Rooms[MaternityIndex];
                    _dialog.ShowDialog("RoomView", new DialogParameters($"Message={CurrentRoom.RoomNumber}"), r => { });
                }

                else
                    return;
            }
        }
        #endregion

        #region Room indexes
        private int _RoomIndex;
        public int RoomIndex
        {
            get => _RoomIndex;
            set => _RoomIndex = value;
        }


        private int _birthRoomIndex;
        public int BirthRoomIndex
        {
            get => _birthRoomIndex;
            set => _birthRoomIndex = value;
        }

        private int _RoomIndex;
        public int MaternityIndex
        {
            get => _RoomIndex;
            set => _RoomIndex = value;
        }


        #endregion

    }
}
