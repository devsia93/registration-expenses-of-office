using CheckManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VRA.BusinessLayer;
using VRA.Dto;

namespace VRA.WPF
{
    /// <summary>
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        private readonly IList<WorkerDto> workerDtos = ProcessFactory.GetWorkerProcess().GetList();
        private readonly IList<DivisionDto> divisionDtos = ProcessFactory.GetDivisionProcess().GetList();
        private readonly IList<ExpenseDto> expenseDtos = ProcessFactory.GetExpenseByWorkerProcess().GetList();
        private readonly IList<TypeExpenseDto> typeExpenseDtos = ProcessFactory.GetTypeExpenseProcess().GetList();

        public IList<WorkerDto> findedWorker;
        public IList<DivisionDto> findedDivision;
        public IList<ExpenseDto> findedExpense;
        public IList<TypeExpenseDto> findedTypeExpense;

        public bool exec;

        public SearchWindow(string currentTable)
        {
            InitializeComponent();

            switch (currentTable)
            {
                case "Worker":
                    tabControlSearch.SelectedItem = ti_searchWorker;
                    ti_searchDivision.Visibility = Visibility.Collapsed;
                    ti_searchExpense.Visibility = Visibility.Collapsed;
                    ti_searchTypeExpense.Visibility = Visibility.Collapsed;
                    ti_searchWorker.Visibility = Visibility.Visible;
                    break;
                case "Division":
                    tabControlSearch.SelectedItem = ti_searchDivision;
                    ti_searchDivision.Visibility = Visibility.Visible;
                    ti_searchExpense.Visibility = Visibility.Collapsed;
                    ti_searchTypeExpense.Visibility = Visibility.Collapsed;
                    ti_searchWorker.Visibility = Visibility.Collapsed;
                    break;
                case "ExpenseByWorker":
                    tabControlSearch.SelectedItem = ti_searchExpense;
                    ti_searchDivision.Visibility = Visibility.Collapsed;
                    ti_searchExpense.Visibility = Visibility.Visible;
                    ti_searchTypeExpense.Visibility = Visibility.Collapsed;
                    ti_searchWorker.Visibility = Visibility.Collapsed;
                    break;
                case "TypeExpense":
                    tabControlSearch.SelectedItem = ti_searchTypeExpense;
                    ti_searchDivision.Visibility = Visibility.Collapsed;
                    ti_searchExpense.Visibility = Visibility.Collapsed;
                    ti_searchTypeExpense.Visibility = Visibility.Visible;
                    ti_searchWorker.Visibility = Visibility.Collapsed;
                    break;
                default:
                    MessageBox.Show("Choose table for searching", "Incorrect", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    break;
            }
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            switch (tabControlSearch.SelectedIndex)
            {
                case 0:
                    findedWorker = ProcessFactory.GetWorkerProcess().SearchWorker(tb_nameWorker.Text);
                    exec = true;
                    Close();
                    break;
                case 1:
                    findedDivision = ProcessFactory.GetDivisionProcess().SearchDivision(tb_titleDivision.Text);
                    exec = true;
                    Close();
                    break;
                case 2:
                    findedExpense = ProcessFactory.GetExpenseByWorkerProcess().SearchExpenseByWorker(int.Parse(tb_IDConsumptionExpense.Text), int.Parse(tb_IDWorkerExpense.Text), int.Parse(tb_IDTypeExpense.Text), dpDateExpense.SelectedDate.Value);
                    exec = true;
                    Close();
                    break;
                case 3:
                    findedTypeExpense = ProcessFactory.GetTypeExpenseProcess().SearchTypeExpense(int.Parse(tbIDTypetExpense.Text), tbTitleTypeExpense.Text);
                    exec = true;
                    Close();
                    break;
            }
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
