using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ActivatedAccountsFilter.ViewModel
{
    class ActivatedAccountsFilter_VM : INotifyPropertyChanged
    {
        private RelayCommand openFileCommand;
        private IDialogService dialogService;
        private DataTable tableData;
        public event PropertyChangedEventHandler PropertyChanged;
        private string _login;
        public ObservableCollection<ActivatedAccountsFilter_VM> huilo { get; set; } = new ObservableCollection<ActivatedAccountsFilter_VM>();
        public string login {get => _login; set {_login = value; OnPropertyChanged(); } }
        public ActivatedAccountsFilter_VM(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            //ActivatedAccountsFilter.Model.FilterModel toModel = new ActivatedAccountsFilter.Model.FilterModel();
        }

        public ActivatedAccountsFilter_VM()
        {
        }
        public void OnPropertyChanged ([CallerMemberName]string prp = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prp));
        }
        public void OpenFile(object value = null)
        {
            ActivatedAccountsFilter_VM vm = new ActivatedAccountsFilter_VM(dialogService = new DialogService());
            dialogService.OpenFileDialog();
            tableData = new DataTable(dialogService);
            tableData.ReturnID();
            vm.login = tableData.ID2;
            huilo.Add(vm); 
            //MessageBox.Show(vm.login);

        }
        public RelayCommand openCommand => openFileCommand ?? (openFileCommand = new RelayCommand(OpenFile));

    }
}
