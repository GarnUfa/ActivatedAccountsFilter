namespace ActivatedAccountsFilter.ViewModel
{
    interface IDialogService
    {
        bool OpenFileDialog();
        string FilePathAllAccInfo { get; set; }
        string FilePathSecondAccInfo { get; set; }
    }
}
