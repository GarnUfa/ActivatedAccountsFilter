using System;
using System.IO;
using System.Windows;
using OfficeOpenXml;
using System.Collections.Generic;
using ActivatedAccountsFilter.ViewModel;

namespace ActivatedAccountsFilter.Model
{
    class DataTable
    {
        private IDialogService dialog;
        private string login;
        private string header;
        private List<Account> AccountList = new List<Account>();
        
        public DataTable(IDialogService dialog)
        {
            this.dialog = dialog;
        }

        public List<Account> ReturnAccountList()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //Исключение если выбрана не выбрана папка
            using (ExcelPackage pakageAccInfo = new ExcelPackage(new FileInfo(dialog.FilePathAllAccInfo)))
            {
                //Исключение если выбран не тот файл
                // blocc acc проверку перенести в if
                // в for добавить проверку sheet.Cells[i, 1].Value == null
                ExcelWorksheet sheetAccInfo = pakageAccInfo.Workbook.Worksheets[0];
                for (int i = 2; !(string.IsNullOrEmpty(sheetAccInfo.Cells[i, 1].Value.ToString())) && !(sheetAccInfo.Cells[i, 3].Value.ToString().Trim() == "block acc"); i++)
                {
                    if (sheetAccInfo.Cells[i, 5].Value == null || string.IsNullOrEmpty(sheetAccInfo.Cells[i, 5].Value.ToString()))
                    {
                        login = (sheetAccInfo.Cells[i, 1].Value.ToString());
                        //MessageBox.Show(sheet.Cells[i, 1].Value.ToString());
                        using (ExcelPackage pakageSecAccInfo = new ExcelPackage(new FileInfo(dialog.FilePathSecondAccInfo)))
                        {
                            ExcelWorksheet sheetSecAccInfo = pakageSecAccInfo.Workbook.Worksheets[0];
                            for (int j = 2; sheetSecAccInfo.Cells[j,4].Value!=null && !(string.IsNullOrEmpty(sheetSecAccInfo.Cells[j, 4].Value.ToString())); j++)
                            {
                                if (sheetSecAccInfo.Cells[j, 2].Value.ToString() == login && sheetSecAccInfo.Cells[j, 2].Value != null)
                                {
                                    header = sheetSecAccInfo.Cells[j, 4].Value.ToString();
                                    AccountList.Add(new Account (login, header));
                                    //MessageBox.Show(login + " " + header);

                                }
                            }

                        }
                    }
                }
            }
            return AccountList;
        }

    }
}
