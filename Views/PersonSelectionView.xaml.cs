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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Register.ViewModels;

namespace Register.Views
{
    /// <summary>
    /// Логика взаимодействия для PersonSelectionView.xaml
    /// </summary>
    public partial class PersonSelectionView : UserControl
    {
        //PersonSelectionModel persModel = new PersonSelectionModel();
        public PersonSelectionView() 
        {

            InitializeComponent();
            //this.DataContext = persModel;
        }
    }
}
