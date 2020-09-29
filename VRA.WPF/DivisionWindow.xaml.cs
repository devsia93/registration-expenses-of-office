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

namespace VRA.WPF
{
    /// <summary>
    /// Логика взаимодействия для DivisionWindow.xaml
    /// </summary>
    public partial class DivisionWindow : Window
    {
        private int _id;
        public DivisionWindow()
        {
            InitializeComponent();
        }

        public void Load(DivisionDto divisionDto)
        {
            if (divisionDto == null)
                return;
            _id = divisionDto.idDivision;
            //this.tbDivisionID.Text = divisionDto.idDivision.ToString();
            this.tbBudget.Text = divisionDto.Budget.ToString();
            this.tbCountWorker.Text = divisionDto.CountWorkers.ToString();
            this.tbTitle.Text = divisionDto.Title.ToString();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                DivisionDto divisionDto = new DivisionDto();
                //divisionDto.idDivision = int.Parse(tbDivisionID.Text);
                divisionDto.Budget = double.Parse(tbBudget.Text);
                divisionDto.CountWorkers = int.Parse(tbCountWorker.Text);
                divisionDto.Title = tbTitle.Text;
                IDivisionProcess divisionProcess= ProcessFactory.GetDivisionProcess();

                if (_id == 0)
                    divisionProcess.Add(divisionDto);
                else
                {
                    divisionDto.idDivision = _id;
                    divisionProcess.Update(divisionDto);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
