using System;
using System.Windows.Input;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Register.ViewModels
{
    public class answer 
    {
        #region Fields
        private int _recid;
        public int recid
        {
            get { return _recid; }
            set { _recid = value; NotifyPropertyChanged("recid"); }
        }

        private int _kmsid;
        public int kmsid
        {
            get { return _kmsid; }
            set { _kmsid = value; NotifyPropertyChanged("kmsid"); }
        }

        private DateTime? _data;
        public DateTime? data
        {
            get { return _data; }
            set { _data = value; NotifyPropertyChanged("data"); }
        }

        private string _tiperz;
        public string tiperz
        {
            get { return _tiperz; }
            set { _tiperz = value; NotifyPropertyChanged("tiperz"); }
        }

        private string _sn_pol;
        public string sn_pol
        {
            get { return _sn_pol; }
            set { _sn_pol = value; NotifyPropertyChanged("sn_pol"); }
        }

        private string _enp;
        public string enp
        {
            get { return _enp; }
            set { _enp = value; NotifyPropertyChanged("enp"); }
        }

        private string _s_card;
        public string s_card
        {
            get { return _s_card; }
            set { _s_card = value; NotifyPropertyChanged("s_card"); }
        }

        private string _n_card;
        public string n_card
        {
            get { return _n_card; }
            set { _n_card = value; NotifyPropertyChanged("n_card"); }
        }

        private DateTime? _date_b;
        public DateTime? date_b 
        {
            get { return _date_b; }
            set { _date_b = value; NotifyPropertyChanged("date_b"); }
        }

        private DateTime? _date_e;
        public DateTime? date_e
        {
            get { return _date_e; }
            set { _date_e = value; NotifyPropertyChanged("date_e"); }
        }

        private string _q;
        public string q
        {
            get { return _q; }
            set { _q = value; NotifyPropertyChanged("q"); }
        }

        private string _q_ogrn;
        public string q_ogrn
        {
            get { return _q_ogrn; }
            set { _q_ogrn = value; NotifyPropertyChanged("q_ogrn"); }
        }

        private string _fam;
        public string fam
        {
            get { return _fam; }
            set { _fam = value; NotifyPropertyChanged("fam"); }
        }

        private string _im;
        public string im
        {
            get { return _im; }
            set { _im = value; NotifyPropertyChanged("im"); }
        }

        private string _ot;
        public string ot
        {
            get { return _ot; }
            set { _ot = value; NotifyPropertyChanged("ot"); }
        }

        private byte _w;
        public byte w
        {
            get { return _w; }
            set { _w = value; NotifyPropertyChanged("w"); }
        }

        private string _dr;
        public string dr
        {
            get { return _dr; }
            set { _dr = value; NotifyPropertyChanged("dr"); }
        }

        private string _ans_r;
        public string ans_r
        {
            get { return _ans_r; }
            set { _ans_r = value; NotifyPropertyChanged("ans_r"); }
        }

        private string _snils;
        public string snils
        {
            get { return _snils; }
            set { _snils = value; NotifyPropertyChanged("snils"); }
        }

        private byte _c_doc;
        public byte c_doc
        {
            get { return _c_doc; }
            set { _c_doc = value; NotifyPropertyChanged("c_doc"); }
        }

        private string _s_doc;
        public string s_doc
        {
            get { return _s_doc; }
            set { _s_doc = value; NotifyPropertyChanged("s_doc"); }
        }

        private string _n_doc;
        public string n_doc
        {
            get { return _n_doc; }
            set { _n_doc = value; NotifyPropertyChanged("n_doc"); }
        }

        private DateTime? _d_doc;
        public DateTime? d_doc
        {
            get { return _d_doc; }
            set { _d_doc = value; NotifyPropertyChanged("d_doc"); }
        }

        private string _gr;
        public string gr
        {
            get { return _gr; }
            set { _gr = value; NotifyPropertyChanged("gr"); }
        }

        private string _erz;
        public string erz
        {
            get { return _erz; }
            set { _erz = value; NotifyPropertyChanged("erz"); }
        }

        private string _tip_d;
        public string tip_d
        {
            get { return _tip_d; }
            set { _tip_d = value; NotifyPropertyChanged("tip_d"); }
        }

        private string _okato;
        public string okato
        {
            get { return _okato; }
            set { _okato = value; NotifyPropertyChanged("okato"); }
        }

        private byte _npp;
        public byte npp
        {
            get { return _npp; }
            set { _npp = value; NotifyPropertyChanged("npp"); }
        }

        private string _err;
        public string err
        {
            get { return _err; }
            set { _err = value; NotifyPropertyChanged("err"); }
        }

        private DateTime _created;
        public DateTime created
        {
            get { return _created; }
            set { _created = value; NotifyPropertyChanged("created"); }
        }
        #endregion #Fields

        public void CopyAnswer(answer p)
        {
            this.recid = p.recid;
            this.kmsid = p.kmsid;
            this.data = p.data;
            this.tiperz = p.tiperz;
            this.sn_pol = p.sn_pol;
            this.enp = p.enp;
            this.s_card = p.s_card;
            this.n_card = p.n_card;
            this.date_b = p.date_b;
            this.date_e = p.date_e;
            this.q = p.q;
            this.q_ogrn = p.q_ogrn;
            this.fam = p.fam;
            this.im = p.im;
            this.ot = p.ot;
            this.dr = p.dr;
            this.w = p.w;
            this.ans_r = p.ans_r;
            this.snils = p.snils;
            this.c_doc = p.c_doc;
            this.s_doc = p.s_doc;
            this.n_doc = p.n_doc;
            this.d_doc = p.d_doc;
            this.gr = p.gr;
            this.erz = p.erz;
            this.tip_d = p.tip_d;
            this.okato = p.okato;
            this.npp = p.npp;
            this.err = p.err;
            this.created = p.created;
        }

        #region Constructors
        public answer() { }

        public answer(int _recid, int _kmsid, DateTime? _data, string _tiperz, string _sn_pol, string _enp, 
            string _s_card, string _n_card, DateTime? _date_b, DateTime? _date_e, string _q, string _q_ogrn,
            string _fam, string _im, string _ot, string _dr, byte _w, string _ans_r, string _snils,
            byte _c_doc, string _s_doc, string _n_doc, DateTime? _d_doc, string _gr, string _erz, string _tip_d,
            string _okato, byte _npp, string _err, DateTime _created)
        {
            recid = _recid; kmsid = _kmsid; data = _data; tiperz = _tiperz; sn_pol = _sn_pol; enp = _enp;
            s_card = _s_card; n_card = _n_card; date_b = _date_b; date_e = _date_e; q = _q; q_ogrn = _q_ogrn;
            fam = _fam; im = _im; ot = _ot; dr = _dr; w = _w; ans_r = _ans_r; snils = _snils; c_doc = _c_doc;
            s_doc = _s_doc; n_doc = _n_doc; d_doc = _d_doc; gr = _gr; erz = _erz; tip_d = _tip_d; okato = _okato;
            npp = _npp; err = _err; created = _created;
        }
        #endregion Constructors

        #region Implemented Interface
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
        #endregion Implemented Interface
    } //class
} //namespace
