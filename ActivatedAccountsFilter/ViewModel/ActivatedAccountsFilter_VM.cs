using ActivatedAccountsFilter.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Documents;

namespace ActivatedAccountsFilter.ViewModel
{
    class ActivatedAccountsFilter_VM : INotifyPropertyChanged
    {
        private RelayCommand openFileCommand;
        private IDialogService dialogService;
        private DataTable tableData;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<ActivatedAccountsFilter_VM> AccountList { get; set; } = new ObservableCollection<ActivatedAccountsFilter_VM>();
        public string login { get; set; }
        public string header { get; set; }
        public ActivatedAccountsFilter_VM(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            //ActivatedAccountsFilter.Model.FilterModel toModel = new ActivatedAccountsFilter.Model.FilterModel();
        }
        public ActivatedAccountsFilter_VM(string login, string header)
        {
            this.login = login;
            this.header = header;
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
            List<Account> acc = tableData.ReturnAccountList();
            foreach (Account account in acc)
            {
                login = account.login;
                header = account.header;
                AccountList.Add(new ActivatedAccountsFilter_VM(login, header));
            }

            //vm.login = tableData.ID2; как разберусь - убрать
            
            //MessageBox.Show(vm.login);

        }
        public RelayCommand openCommand => openFileCommand ?? (openFileCommand = new RelayCommand(OpenFile));

    }
}
