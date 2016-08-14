using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Register;
using Register.Wpf;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Configuration;
using System.Data.SqlClient;
//using Microsoft.SqlServer.Management.Smo;
//using Microsoft.SqlServer.Management.Common;

namespace Register.ViewModels
{
    class PersonDisplayModel : INotifyPropertyChanged
    {
        public PersonDisplayModel() 
        {
            Messenger messenger = App.Messenger;
            messenger.Register("PersonSelectionChanged", (Action<kms>)(param => ProcessPerson(param)));
            messenger.Register("SetStatus", (Action<String>)(param => stat.Status = param));
            cmbStatusItems = status.StatusList(App.conString);
            cmbCodFioItems = codfio.CodFioList(App.conString);
        } //ctor

        private bool isSelected = false;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private IList<status> _cmbStatusItems;
        public IList<status> cmbStatusItems
        {
            get { return _cmbStatusItems; }
            set { _cmbStatusItems = value; }
        }

        private IList<codfio> _cmbCodFioItems; 
        public IList<codfio> cmbCodFioItems 
        {
            get { return _cmbCodFioItems; }
            set { _cmbCodFioItems = value; }
        }

        private kms displayedPerson = new kms();
        public kms DisplayedPerson 
        {
            get { return displayedPerson; }
            set { displayedPerson = value; OnPropertyChanged(new PropertyChangedEventArgs("DisplayedPerson")); }
        }

        //data checks and status indicators done in another class
        private readonly PersonDisplayModelStatus stat = new PersonDisplayModelStatus();
        public PersonDisplayModelStatus Stat { get { return stat; } }

        private RelayCommand createNSI;
        public ICommand CreateNSI 
        {
            get { return createNSI ?? (createNSI = new RelayCommand(() => crNSI(), () => isSelected)); }
        }
        private void crNSI()
        {
        }

        private RelayCommand savePerson; 
        public ICommand SavePerson 
        {
            get { return savePerson ?? (savePerson = new RelayCommand(() => SaveKMS())); }
        }
        private void SaveKMS() 
        {
            MessageBox.Show("Save!");
        }

        private RelayCommand getPersonsCommand;  
        public ICommand GetPersonsCommand  
        {
            get { return getPersonsCommand ?? (getPersonsCommand = new RelayCommand(() => GetPersons())); }
        }

        private void GetPersons() 
        {
            isSelected = false;
            stat.NoError();
            DisplayedPerson = new kms();
            App.Messenger.NotifyColleagues("GetPersons");
        }

        private RelayCommand clearCommand;
        public ICommand ClearCommand
        {
            get { return clearCommand ?? (clearCommand = new RelayCommand(() => ClearPersonDisplay()/*, ()=>isSelected*/)); }
        }

        private void ClearPersonDisplay() 
        {
            isSelected = false;
            stat.NoError();
            DisplayedPerson = new kms();
            App.Messenger.NotifyColleagues("PersonCleared");
        } //ClearPersonDisplay()

        public void ProcessPerson(kms p)
        {
            if (p == null) { /*DisplayedPerson = null;*/  isSelected = false; return; }
            kms temp = new kms();
            temp.CopyPerson(p);
            DisplayedPerson = temp;
            isSelected = true;
            stat.NoError();
        } // ProcessProduct()
    }
}
