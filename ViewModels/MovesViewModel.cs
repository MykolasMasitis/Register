using System;
using System.Collections.Generic;
using Register.Wpf;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Register.ViewModels
{
    class MovesViewModel : INotifyPropertyChanged
    {
        public MovesViewModel() 
        {
            Messenger messenger = App.Messenger;
            messenger.Register("PersonSelectionChanged", (Action<kms>)(param => ProcessMoves(param)));
            dataItems = new MoveObservableCollection<move>();
        } //ctor

        private MoveObservableCollection<move> dataItems;
        public MoveObservableCollection<move> DataItems
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

        public void ProcessMoves(kms p)
        {
            if (p == null) { return; }
            DataItems = App.Moves.GetMoves(p.recid);
        } // ProcessProduct()
    }
    public class MoveObservableCollection<move> : ObservableCollection<move>
    {
        public void UpdateCollection()
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                                NotifyCollectionChangedAction.Reset));
        }


        public void ReplaceItem(int index, move item)
        {
            base.SetItem(index, item);
        }

    } // class MoveObservableCollection

}
