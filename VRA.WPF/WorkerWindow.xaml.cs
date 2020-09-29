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
    /// Логика взаимодействия для WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        private int _id;
        public WorkerWindow()
        {
            InitializeComponent();
        }

        public void Load(WorkerDto workerDto)
        {
            _id = workerDto.idDivision;
            this.tbDivisionID.Text = workerDto.idDivision.ToString();
            this.tbName.Text = workerDto.Name;
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WorkerDto workerDto = new WorkerDto();
                workerDto.idDivision = int.Parse(tbDivisionID.Text);
                //workerDto.idWorker = int.Parse(tbID.Text);
                workerDto.Name = tbName.Text;
                IWorkerProcess workerProcess = ProcessFactory.GetWorkerProcess();

                if (_id == 0)
                    workerProcess.Add(workerDto);
                else
                {
                    workerDto.idDivision = _id;
                    workerProcess.Update(workerDto);
                }
                this.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
