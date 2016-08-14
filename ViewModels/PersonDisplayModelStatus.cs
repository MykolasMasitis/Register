using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Media;

namespace Register.ViewModels
{
    class PersonDisplayModelStatus : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        //Error status msg and field Brushes to indicate product field errors
        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged(new PropertyChangedEventArgs("Status")); }
        }

        private static SolidColorBrush errorBrush = new SolidColorBrush(Colors.Red);
        private static SolidColorBrush okBrush = new SolidColorBrush(Colors.Black);

        private SolidColorBrush dpBrush = okBrush;
        public SolidColorBrush DpBrush
        {
            get { return dpBrush; }
            set { dpBrush = value; OnPropertyChanged(new PropertyChangedEventArgs("DpBrush")); }
        }

        private SolidColorBrush famBrush = okBrush;
        public SolidColorBrush FamBrush 
        {
            get { return famBrush; }
            set { famBrush = value; OnPropertyChanged(new PropertyChangedEventArgs("FamBrush")); }
        }

        private SolidColorBrush imBrush = okBrush;
        public SolidColorBrush ImBrush  
        {
            get { return imBrush; }
            set { imBrush = value; OnPropertyChanged(new PropertyChangedEventArgs("ImBrush")); }
        }

        private SolidColorBrush otBrush = okBrush;
        public SolidColorBrush OtBrush
        {
            get { return otBrush; }
            set { otBrush = value; OnPropertyChanged(new PropertyChangedEventArgs("OtBrush")); }
        }

        private SolidColorBrush statusBrush = okBrush;
        public SolidColorBrush StatusBrush 
        {
            get { return statusBrush; }
            set { statusBrush = value; OnPropertyChanged(new PropertyChangedEventArgs("StatusBrush")); }
        }

        //set error field brushes to OKBrush and status msg to OK
        public void NoError()
        {
            FamBrush = ImBrush = OtBrush = okBrush;
            Status = "OK";
        } //NoError()

        public PersonDisplayModelStatus() 
        {
            NoError();
        } //ctor

    }
}
