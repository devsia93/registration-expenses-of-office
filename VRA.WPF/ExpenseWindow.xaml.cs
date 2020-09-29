using CheckManager;
using System;
using System.Collections;
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
using VRA.DataAccess;

namespace VRA.WPF
{
    /// <summary>
    /// Логика взаимодействия для ExpenseWindow.xaml
    /// </summary>
    public partial class ExpenseWindow : Window
    {
        private int _id;
        public ExpenseWindow()
        {
            InitializeComponent();

            cb_typeID.ItemsSource = ProcessFactory.GetTypeExpenseProcess().GetTypeID();
        }

        public void Load(ExpenseDto expenseDto)
        {
            if (expenseDto == null)
            {
                return;
            }

            _id = expenseDto.idConsumption;
            //this.tbDivisionID.Text = divisionDto.idDivision.ToString();
            dpDate.SelectedDate = expenseDto.Date;
            this.tbDescription.Text = expenseDto.Description.ToString();
            this.cb_typeID.SelectedItem = expenseDto.idType.ToString();
            this.tbIdWorker.Text = expenseDto.idWorker.ToString();
            this.tbSum.Text = expenseDto.Sum.ToString();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExpenseDto expenseDto = new ExpenseDto();
                //divisionDto.idDivision = int.Parse(tbDivisionID.Text);
                expenseDto.Date = dpDate.SelectedDate.Value;
                expenseDto.Description = tbDescription.Text;
                expenseDto.idType = int.Parse(cb_typeID.SelectedItem.ToString());
                expenseDto.idWorker = int.Parse(tbIdWorker.Text);
                expenseDto.Sum = double.Parse(tbSum.Text);
                IExpenseByWorkerProcess expenseProcess = ProcessFactory.GetExpenseByWorkerProcess();

                if (_id == 0)
                {
                    expenseProcess.Add(expenseDto);
                }
                else
                {
                    expenseDto.idConsumption = _id;
                    expenseProcess.Update(expenseDto);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSearchWorker_Click(object sender, RoutedEventArgs e)
        {
            SearchWorker searchWorker = new SearchWorker();
            searchWorker.ShowDialog();
            if (SearchWorker.findedWorker.Count != 0)
            {
                tbIdWorker.Text = SearchWorker.findedWorker[0].idWorker.ToString();
            }
            else tbIdWorker.Text = string.Empty;
        }
    }
}
