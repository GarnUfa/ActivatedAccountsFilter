namespace ActivatedAccountsFilter.ViewModel
{
    interface IDialogService
    {
        bool OpenFileDialog();
        string FilePath { get; set; }
    }
}
