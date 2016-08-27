using System;
using System.Windows.Input;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Register.ViewModels
{
    public class move 
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

        private string _frecid;
        public string frecid
        {
            get { return _frecid; }
            set { _frecid = value; NotifyPropertyChanged("frecid"); }
        }

        private string _et;
        public string et
        {
            get { return _et; }
            set { _et = value; NotifyPropertyChanged("et"); }
        }

        private string _fname;
        public string fname
        {
            get { return _fname; }
            set { _fname = value; NotifyPropertyChanged("fname"); }
        }

        private DateTime? _mkdate;
        public DateTime? mkdate
        {
            get { return _mkdate; }
            set { _mkdate = value; NotifyPropertyChanged("mkdate"); }
        }

        private string _vs;
        public string vs
        {
            get { return _vs; }
            set { _vs = value; NotifyPropertyChanged("vs"); }
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

        private string _c_okato;
        public string c_okato
        {
            get { return _c_okato; }
            set { _c_okato = value; NotifyPropertyChanged("c_okato"); }
        }

        private string _enp;
        public string enp
        {
            get { return _enp; }
            set { _enp = value; NotifyPropertyChanged("enp"); }
        }

        private DateTime? _dp; 
        public DateTime? dp
        {
            get { return _dp; }
            set { _dp = value; NotifyPropertyChanged("dp"); }
        }

        private string _jt;
        public string jt
        {
            get { return _jt; }
            set { _jt = value; NotifyPropertyChanged("jt"); }
        }

        private string _scn;
        public string scn
        {
            get { return _scn; }
            set { _scn = value; NotifyPropertyChanged("scn"); }
        }

        private string _pricin;
        public string pricin
        {
            get { return _pricin; }
            set { _pricin = value; NotifyPropertyChanged("pricin"); }
        }

        private string _tranz;
        public string tranz
        {
            get { return _tranz; }
            set { _tranz = value; NotifyPropertyChanged("tranz"); }
        }

        private string _q;
        public string q
        {
            get { return _q; }
            set { _q = value; NotifyPropertyChanged("q"); }
        }

        private string _err;
        public string err
        {
            get { return _err; }
            set { _err = value; NotifyPropertyChanged("err"); }
        }

        private string _err_text;
        public string err_text
        {
            get { return _err_text; }
            set { _err_text = value; NotifyPropertyChanged("err_text"); }
        }

        private string _ans_fl;
        public string ans_fl
        {
            get { return _ans_fl; }
            set { _ans_fl = value; NotifyPropertyChanged("ans_fl"); }
        }

        private int _nz;
        public int nz
        {
            get { return _nz; }
            set { _nz = value; NotifyPropertyChanged("nz"); }
        }

        private int _n_kor;
        public int n_kor
        {
            get { return _n_kor; }
            set { _n_kor = value; NotifyPropertyChanged("n_kor"); }
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

        private DateTime? _dr;
        public DateTime? dr
        {
            get { return _dr; }
            set { _dr = value; NotifyPropertyChanged("dr"); }
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

        private DateTime? _e_doc;
        public DateTime? e_doc
        {
            get { return _e_doc; }
            set { _e_doc = value; NotifyPropertyChanged("e_doc"); }
        }

        private DateTime _created;
        public DateTime created
        {
            get { return _created; }
            set { _created = value; NotifyPropertyChanged("created"); }
        }
        #endregion #Fields

        public void CopyMove(move p) 
        {
            this.recid = p.recid;
            this.kmsid = p.kmsid;
            this.frecid = p.frecid;
            this.et = p.et;
            this.fname = p.fname;
            this.mkdate = p.mkdate;
            this.vs = p.vs;
            this.s_card = p.s_card;
            this.n_card = p.n_card;
            this.c_okato = p.c_okato;
            this.enp = p.enp;
            this.dp = p.dp;
            this.jt = p.jt;
            this.scn = p.scn;
            this.pricin = p.pricin;
            this.tranz = p.tranz;
            this.q = p.q;
            this.err = p.err;
            this.err_text = p.err_text;
            this.ans_fl = p.ans_fl;
            this.nz = p.nz;
            this.n_kor = p.n_kor;
            this.fam = p.fam;
            this.im = p.im;
            this.ot = p.ot;
            this.w = p.w;
            this.dr = p.dr;
            this.c_doc = p.c_doc;
            this.s_doc = p.s_doc;
            this.n_doc = p.n_doc;
            this.d_doc = p.d_doc;
            this.e_doc = p.e_doc;
            this.created = p.created;
        }

        #region Constructors
        public move() { }

        public move(int _recid, string _et, string _fname, DateTime? _mkdate, int _kmsid, string _frecid, string _vs,
            string _s_card, string _n_card, string _c_okato, string _enp, DateTime? _dp, string _jt, string _scn,
            string _pricin, string _tranz, string _q, string _err, string _err_text, string _ans_fl, int _nz,
            int _n_kor, string _fam, string _im, string _ot, byte _w, DateTime? _dr, byte _c_doc, string _s_doc,
            string _n_doc, DateTime? _d_doc, DateTime? _e_doc, DateTime _created)
        {
            recid = _recid; et = _et; fname = _fname; mkdate = _mkdate; kmsid = _kmsid; frecid = _frecid;  vs = _vs;
            s_card = _s_card; n_card = _n_card; c_okato = _c_okato; enp = _enp; dp = _dp; jt = _jt; scn = _scn;
            pricin = _pricin; tranz = _tranz; q = _q; err = _err; err_text = _err_text; ans_fl = _ans_fl; nz = _nz;
            n_kor = _n_kor; fam = _fam; im = _im; ot = _ot; w = _w; dr = _dr; c_doc = _c_doc; s_doc = _s_doc;
            n_doc = _n_doc; d_doc = _d_doc; e_doc = _e_doc; created = _created;
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
