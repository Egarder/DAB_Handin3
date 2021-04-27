using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BirthClinicPlanningDB.DomainObjects;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace BirthClinicGUI.ViewModels
{
    class BabyInformationViewModel : BindableBase, IDialogAware
    {
        public Child Child { get; set; }
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            ((App) Application.Current).Child = Child;
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Child = new Child();
        }

        public string Title { get; }
        public event Action<IDialogResult> RequestClose;

        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        protected virtual void CloseDialog(string parameter)
        {
            if (parameter == "true")
            {
                ButtonResult result = ButtonResult.OK;

                if (Child.FirstName == "" || Child.LastName == "" || Child.Weight == 0 || Child.Length == 0)
                    MessageBox.Show("Please fill out all fields", "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                else
                    RequestClose(new DialogResult(result));
            }
        }
    }
}
