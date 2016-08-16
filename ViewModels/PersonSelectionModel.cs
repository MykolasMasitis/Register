using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Register;
using Register.Views;
using Register.Wpf;
using Register.Model;

namespace Register.ViewModels
{
    public class PersonSelectionModel : INotifyPropertyChanged
    {
        public PersonSelectionModel()
        {
            dataItems = new MyObservableCollection<kms>();
            DataItems = App.StoreDB.GetPersons();
            listBoxCommand = new RelayCommand(() => SelectionHasChanged());
            App.Messenger.Register("PersonCleared", (Action)(() => SelectedPerson = null));
            App.Messenger.Register("GetPersons", (Action)(() => GetPersons()));
            App.Messenger.Register("UpdatePerson", (Action<kms>)(param => UpdatePerson(param)));
            App.Messenger.Register("DeletePerson", (Action)(() => DeletePerson()));
            App.Messenger.Register("AddPerson", (Action<kms>)(param => AddPerson(param)));
        }

        private void AddPerson(kms p)
        {
            dataItems.Add(p);
        }

        private void UpdatePerson(kms p)
        {
            int index = dataItems.IndexOf(selectedPerson);
            dataItems.ReplaceItem(index, p);
            SelectedPerson = p;
        }

        private void DeletePerson()  
        {
            dataItems.Remove(selectedPerson);
        }

        private void GetPersons() 
        {
            DataItems = App.StoreDB.GetPersons();
            if (App.StoreDB.hasError)
                App.Messenger.NotifyColleagues("SetStatus", App.StoreDB.errorMessage);
        }

        private MyObservableCollection<kms> dataItems;
        public MyObservableCollection<kms> DataItems
        {
            get { return dataItems; }
            set { dataItems = value; OnPropertyChanged(new PropertyChangedEventArgs("DataItems")); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private kms selectedPerson;
        public kms SelectedPerson
        {
            get { return selectedPerson; }
            set { selectedPerson = value; OnPropertyChanged(new PropertyChangedEventArgs("SelectedPerson")); }
        }

        private RelayCommand listBoxCommand;
        public ICommand ListBoxCommand
        {
            get { return listBoxCommand; }
        }

        private void SelectionHasChanged()
        {
            Messenger messenger = App.Messenger;
            messenger.NotifyColleagues("PersonSelectionChanged", selectedPerson);
        }
    }

    public class MyObservableCollection<kms> : ObservableCollection<kms>
    {
        public void UpdateCollection()
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                                NotifyCollectionChangedAction.Reset));
        }


        public void ReplaceItem(int index, kms item)
        {
            base.SetItem(index, item);
        }

    } // class MyObservableCollection

}
