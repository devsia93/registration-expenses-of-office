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
    /// Логика взаимодействия для SearchWorker.xaml
    /// </summary>
    public partial class SearchWorker : Window
    {
        public static IList<WorkerDto> findedWorker;
        public SearchWorker()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            findedWorker = ProcessFactory.GetWorkerProcess().SearchWorker(tbNameWorker.Text);

            if (findedWorker.Count == 0)
            {
                if (MessageBox.Show("Not found. Repeat?", "Error search", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    this.Close();
                    SearchWorker searchWorker = new SearchWorker();
                    searchWorker.ShowDialog();
                }
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
