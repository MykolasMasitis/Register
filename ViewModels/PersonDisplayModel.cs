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
            StatusItems = status.StatusList(App.conString);
            CodFioItems = codfio.CodFioList(App.conString);
            WItems = w.WList();
            PredstItems = predst.PredstList(App.conString);
        } //ctor

        private bool isSelected = false;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private IList<status> _StatusItems;
        public IList<status> StatusItems
        {
            get { return _StatusItems; }
            set { _StatusItems = value; }
        }

        private IList<codfio> _CodFioItems; 
        public IList<codfio> CodFioItems 
        {
            get { return _CodFioItems; }
            set { _CodFioItems = value; }
        }

        private IList<w> _WItems;
        public IList<w> WItems
        {
            get { return _WItems; }
            set { _WItems = value; }
        }

        private IList<predst> _PredstItems;
        public IList<predst> PredstItems
        {
            get { return _PredstItems; }
            set { _PredstItems = value; }
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
            get { return createNSI ?? (createNSI = new RelayCommand(() => crNSI())); }
        }
        private void crNSI()
        {
        }

        private RelayCommand addCommand; 
        public ICommand AddCommand  
        {
            get { return addCommand ?? (addCommand = new RelayCommand(() => AddKMS())); }
        }
        private void AddKMS() 
        {
            //if (!stat.ChkProductForAdd(DisplayedProduct)) return;
            if (!App.StoreDB.AddPerson(DisplayedPerson))
            {
                MessageBox.Show(App.StoreDB.errorMessage);
                stat.Status = App.StoreDB.errorMessage;
                return;
            }
            App.Messenger.NotifyColleagues("AddPerson", DisplayedPerson);
        }

        private RelayCommand deleteCommand;  
        public ICommand DeleteCommand  
        {
            get { return deleteCommand ?? (deleteCommand = new RelayCommand(() => DeleteKMS(), () => isSelected)); }
        }
        private void DeleteKMS() 
        {
            if (!App.StoreDB.DeletePerson(DisplayedPerson.recid))
            {
                MessageBox.Show(App.StoreDB.errorMessage);
                stat.Status = App.StoreDB.errorMessage;
                return;
            }
            isSelected = false;
            App.Messenger.NotifyColleagues("DeletePerson");
        } //DeleteProduct

        private RelayCommand updateCommand;   
        public ICommand UpdateCommand  
        {
            get { return updateCommand ?? (updateCommand = new RelayCommand(() => UpdatePerson(), () => isSelected)); }
        }
        private void UpdatePerson()  
        {
            //if (!stat.ChkProductForUpdate(DisplayedPerson)) return;
            if (!App.StoreDB.UpdatePerson(DisplayedPerson))
            {
                MessageBox.Show(App.StoreDB.errorMessage);
                stat.Status = App.StoreDB.errorMessage;
                return;
            }
            App.Messenger.NotifyColleagues("UpdatePerson", DisplayedPerson);
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
