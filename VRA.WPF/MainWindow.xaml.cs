using CheckManager;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using VRA.BusinessLayer;
using VRA.Dto;

namespace VRA.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string currentTable = string.Empty;
        VRA.DataAccess.WorkerDao workerDao = new DataAccess.WorkerDao();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            dgMain.ItemsSource = ProcessFactory.GetWorkerProcess().GetList();
            currentTable = "Worker";
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            dgMain.ItemsSource = ProcessFactory.GetDivisionProcess().GetList();
            currentTable = "Division";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            dgMain.ItemsSource = ProcessFactory.GetExpenseByWorkerProcess().GetList();
            currentTable = "ExpenseByWorker";
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            dgMain.ItemsSource = ProcessFactory.GetTypeExpenseProcess().GetList();
            currentTable = "TypeExpense";
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            switch (currentTable)
            {
                case "Worker":
                    WorkerDto workerDto = (WorkerDto)dgMain.SelectedItem;
                    if (workerDto != null)
                    {
                        WorkerWindow workerWindow = new WorkerWindow();
                        workerWindow.Load(workerDto);
                        workerWindow.ShowDialog();
                        MenuItem_Click(sender, e);//update table
                    }
                    break;
                case "Division":
                    DivisionDto divisionDto = (DivisionDto)dgMain.SelectedItem;
                    if (divisionDto != null)
                    {
                        DivisionWindow divisionWindow = new DivisionWindow();
                        divisionWindow.Load(divisionDto);
                        divisionWindow.ShowDialog();
                        MenuItem_Click_1(sender, e);
                    }
                    break;
                case "ExpenseByWorker":
                    ExpenseDto expenseDto = (ExpenseDto)dgMain.SelectedItem;
                    if (expenseDto != null)
                    {
                        ExpenseWindow expenseWindow = new ExpenseWindow();
                        expenseWindow.Load(expenseDto);
                        expenseWindow.ShowDialog();
                        MenuItem_Click_3(sender, e);
                    }
                    break;
                case "TypeExpense":
                    TypeExpenseDto typeExpenseDto = (TypeExpenseDto)dgMain.SelectedItem;
                    if (typeExpenseDto != null)
                    {
                        TypeExpenseWindow typeExpenseWindow = new TypeExpenseWindow();
                        typeExpenseWindow.Load(typeExpenseDto);
                        typeExpenseWindow.ShowDialog();
                        MenuItem_Click_4(sender, e);
                    }
                    break;


            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            switch (currentTable)
            {
                case "Worker":
                    WorkerWindow workerWindow = new WorkerWindow();
                    workerWindow.ShowDialog();
                    MenuItem_Click(sender, e);//update table
                    break;
                case "Division":
                    DivisionWindow divisionWindow = new DivisionWindow();
                    divisionWindow.ShowDialog();
                    MenuItem_Click_1(sender, e);
                    break;
                case "ExpenseByWorker":
                    ExpenseWindow expenseWindow = new ExpenseWindow();
                    expenseWindow.ShowDialog();
                    MenuItem_Click_3(sender, e);
                    break;
                case "TypeExpense":
                    TypeExpenseWindow typeExpenseWindow = new TypeExpenseWindow();
                    typeExpenseWindow.ShowDialog();
                    MenuItem_Click_4(sender, e);
                    break;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            switch (currentTable)
            {
                case "Worker":
                    WorkerDto item = (WorkerDto)dgMain.SelectedItem;

                    if (item == null)
                    {
                        MessageBox.Show("Choose item from delete", "Worker delete");
                        return;
                    }

                    MessageBoxResult result = MessageBox.Show("Delete " + item.Name + "?", "Worker delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result != MessageBoxResult.Yes)
                        return;

                    ProcessFactory.GetWorkerProcess().Delete(item.idWorker);
                    MenuItem_Click(sender, e);//update table
                    break;
                case "Division":
                    DivisionDto itemDivision = (DivisionDto)dgMain.SelectedItem;

                    if (itemDivision == null)
                    {
                        MessageBox.Show("Choose item from delete", "Division delete");
                        return;
                    }

                    MessageBoxResult resultDivision = MessageBox.Show("Delete " + itemDivision.Title + "?", "Division delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (resultDivision != MessageBoxResult.Yes)
                        return;

                    ProcessFactory.GetDivisionProcess().Delete(itemDivision.idDivision);
                    MenuItem_Click_1(sender, e);
                    break;
                case "ExpenseByWorker":
                    ExpenseDto itemExpenseDto = (ExpenseDto)dgMain.SelectedItem;

                    if (itemExpenseDto == null)
                    {
                        MessageBox.Show("Choose item from delete", "Expense delete");
                        return;
                    }

                    MessageBoxResult resultExpense = MessageBox.Show("Delete " + itemExpenseDto.Description + "?", "Expense delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (resultExpense != MessageBoxResult.Yes)
                        return;

                    ProcessFactory.GetExpenseByWorkerProcess().Delete(itemExpenseDto.idConsumption);
                    MenuItem_Click_3(sender, e);
                    break;
                case "TypeExpense":
                    TypeExpenseDto itemTypeExpenseDto = (TypeExpenseDto)dgMain.SelectedItem;

                    if (itemTypeExpenseDto == null)
                    {
                        MessageBox.Show("Choose item from delete", "Type expense delete");
                        return;
                    }

                    MessageBoxResult resultTypeExpense = MessageBox.Show("Delete " + itemTypeExpenseDto.Title + "?", "Type expense delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (resultTypeExpense != MessageBoxResult.Yes)
                        return;

                    ProcessFactory.GetExpenseByWorkerProcess().Delete(itemTypeExpenseDto.idType);
                    MenuItem_Click_4(sender, e);
                    break;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            switch (currentTable)
            {
                case "Worker":
                    MenuItem_Click(sender, e);//update table
                    break;
                case "Division":
                    MenuItem_Click_1(sender, e);
                    break;
                case "ExpenseByWorker":
                    MenuItem_Click_3(sender, e);
                    break;
                case "TypeExpense":
                    MenuItem_Click_4(sender, e);
                    break;
            }
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            List<object> grid = dgMain.ItemsSource.Cast<object>().ToList();

            SaveFileDialog saveXlsxDialog = new SaveFileDialog
            {
                DefaultExt = ".xlsx",
                Filter = "Excel Files(.xlsx) | *.xlsx",
                AddExtension = true,
                FileName = currentTable
            };

            bool? result = Convert.ToBoolean(saveXlsxDialog.ShowDialog());

            if (result == true)
            {
                FileInfo xlsxFile = new FileInfo(saveXlsxDialog.FileName);
                ProcessFactory.GetReport().fillExcelTableByType(grid, currentTable, xlsxFile);
                MessageBox.Show("Отчет успешно создан!", "Результат");
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow(currentTable);
            searchWindow.ShowDialog();
            if (searchWindow.exec)
            {
                switch (currentTable)
                {
                    case "Worker":
                        dgMain.ItemsSource = searchWindow.findedWorker;
                        break;
                    case "Division":
                        dgMain.ItemsSource = searchWindow.findedDivision;
                        break;
                    case "ExpenseByWorker":
                        dgMain.ItemsSource = searchWindow.findedExpense;
                        break;
                    case "TypeExpense":
                        dgMain.ItemsSource = searchWindow.findedTypeExpense;
                        break;
                }
            }
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            AboutBox1 box = new AboutBox1();
            box.ShowDialog();
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {

        }
    }
}
