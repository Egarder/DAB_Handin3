using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BirthClinicGUI.ViewModels;
using BirthClinicGUI.Views;
using EmilMongoRepoTestudvikling.Domainmodels;
using Prism.Ioc;
using Prism.Unity;

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
