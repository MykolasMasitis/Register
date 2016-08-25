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
    class AnswersViewModel : INotifyPropertyChanged
    {
        public AnswersViewModel()
        {
            Messenger messenger = App.Messenger;
            messenger.Register("PersonSelectionChanged", (Action<kms>)(param => ProcessAnswers(param)));
            dataItems = new AnswerObservableCollection<move>();
        } //ctor

        private AnswerObservableCollection<move> dataItems;
        public AnswerObservableCollection<move> DataItems
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
            DataItems = App.Answers.GeGetMoves(p.recid);
        } // ProcessProduct()
    }
    public class AnswerObservableCollection<move> : ObservableCollection<move>
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

    } // class AnswerObservableCollection

}
