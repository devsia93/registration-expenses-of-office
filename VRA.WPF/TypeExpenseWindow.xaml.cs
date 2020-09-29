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
    /// Логика взаимодействия для TypeExpenseWindow.xaml
    /// </summary>
    public partial class TypeExpenseWindow : Window
    {
        private int _id;
        public TypeExpenseWindow()
        {
            InitializeComponent();
        }
        public void Load(TypeExpenseDto typeExpenseDto)
        {
            if (typeExpenseDto == null)
                return;
            _id = typeExpenseDto.idType;
            //this.tbDivisionID.Text = divisionDto.idDivision.ToString();
            this.tbDescription.Text = typeExpenseDto.Description.ToString();
            this.tbLimited.Text = typeExpenseDto.Limited.ToString();
            this.tbTitle.Text = typeExpenseDto.Title.ToString();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TypeExpenseDto typeExpenseDto = new TypeExpenseDto();
                typeExpenseDto.Description = tbDescription.Text;
                typeExpenseDto.Limited = double.Parse(tbLimited.Text);
                typeExpenseDto.Title = tbTitle.Text;

                ITypeExpenseProcess typeExpenseProcess = ProcessFactory.GetTypeExpenseProcess();

                if (_id == 0)
                    typeExpenseProcess.Add(typeExpenseDto);
                else
                {
                    typeExpenseDto.idType = _id;
                    typeExpenseProcess.Update(typeExpenseDto);
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
    }
}
