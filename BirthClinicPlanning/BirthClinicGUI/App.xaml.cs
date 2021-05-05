using BirthClinicGUI.ViewModels;
using BirthClinicGUI.Views;
using Prism.Ioc;
using Prism.Unity;
using System.Windows;
using BirthClinicMongoDB.Domainmodels;

namespace BirthClinicGUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>();
            containerRegistry.RegisterDialog<AddAppointmentView, AddAppointmentViewModel>();
            containerRegistry.RegisterDialog<SpecificAppointmentView, SpecificAppointmentViewModel>();
            containerRegistry.RegisterDialog<StatusRoomsView, StatusRoomsViewModel>();
            containerRegistry.RegisterDialog<RestRoomView, RestRoomViewModel>();
            containerRegistry.RegisterDialog<MaternityRoomView, MaternityRoomViewModel>();
            containerRegistry.RegisterDialog<BirthRoomView, BirthRoomViewModel>();
            containerRegistry.RegisterDialog<BabyInformationView, BabyInformationViewModel>();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        public Child Child { get; set; }
    }
}
