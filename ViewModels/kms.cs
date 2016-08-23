using System;
using System.Windows.Documents;
using System.Windows.Input;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Register.ViewModels
{
    // Class for the GUI to display and modify persons.
    //[Table("kms"), NotMapped]
    public class kms
    {
        #region Fields
        [Key]
        private int _recid;
        public int recid
        {
            get { return _recid; }
            set { _recid = value; NotifyPropertyChanged("recid"); }
        }
        private bool _act;
        public bool act
        {
            get { return _act; }
            set { _act = value; NotifyPropertyChanged("act"); }
        }

        [Column(TypeName = "varchar"), MaxLength(3)]
        private string _pv;
        public string pv
        {
            get { return _pv; }
            set { _pv = value; NotifyPropertyChanged("pv"); }
        }

        [Column(TypeName = "varchar"), MaxLength(5)]
        private string _nz;
        public string nz
        {
            get { return _nz; }
            set { _nz = value; NotifyPropertyChanged("nz"); }
        }

        private byte _status;
        public byte status
        {
            get { return _status; }
            set { _status = value; NotifyPropertyChanged("status"); }
        }

        private byte _p_doc;
        public byte p_doc
        {
            get { return _p_doc; }
            set { _p_doc = value; NotifyPropertyChanged("p_doc"); }
        }

        private byte _p_doc2; 
        public byte p_doc2
        {
            get { return _p_doc2; }
            set { _p_doc2 = value; NotifyPropertyChanged("p_doc2"); }
        }

        [Column(TypeName = "varchar"), MaxLength(9)]
        private string _vs;
        public string vs
        {
            get { return _vs; }
            set { _vs = value; NotifyPropertyChanged("vs"); }
        }

        private DateTime? _vs_data;
        public DateTime? vs_data
        {
            get { return _vs_data; }
            set { _vs_data = value; NotifyPropertyChanged("vs_data"); }
        }

        [Column(TypeName = "varchar"), MaxLength(17)]
        private string _sn_card;
        public string sn_card
        {
            get { return _sn_card; }
            set { _sn_card = value; NotifyPropertyChanged("sn_card"); }
        }

        [Column(TypeName = "varchar"), MaxLength(16)]
        private string _enp;
        public string enp
        {
            get { return _enp; }
            set { _enp = value; NotifyPropertyChanged("enp"); }
        }

        private DateTime? _gz_data; 
        public DateTime? gz_data
        {
            get { return _gz_data; }
            set { _gz_data = value; NotifyPropertyChanged("gz_data"); }
        }

        [Column(TypeName = "varchar"), MaxLength(2)]
        private string _q;
        public string q
        {
            get { return _q; }
            set { _q = value; NotifyPropertyChanged("q"); }
        }

        private DateTime? _dp;
        public DateTime? dp
        {
            get { return _dp; }
            set { _dp = value; NotifyPropertyChanged("dp"); }
        }

        [Column(TypeName = "date")]
        private DateTime? _dt;
        public DateTime? dt
        {
            get { return _dt; }
            set { _dt = value; NotifyPropertyChanged("dt"); }
        }
        [Column(TypeName = "varchar"), MaxLength(40)]
        private string _fam;
        public string fam
        {
            get { return _fam; }
            set { _fam = value; NotifyPropertyChanged("fam"); }
        }
        [Column(TypeName = "varchar"), MaxLength(1)]
        private string _d_type1;
        public string d_type1
        {
            get { return _d_type1; }
            set { _d_type1 = value; NotifyPropertyChanged("d_type1"); }
        }

        [Column(TypeName = "varchar"), MaxLength(40)]
        private string _im;
        public string im
        {
            get { return _im; }
            set { _im = value; NotifyPropertyChanged("im"); }
        }

        [Column(TypeName = "varchar"), MaxLength(1)]
        private string _d_type2;
        public string d_type2
        {
            get { return _d_type2; }
            set { _d_type2 = value; NotifyPropertyChanged("d_type2"); }
        }

        [Column(TypeName = "varchar"), MaxLength(40)]
        private string _ot;
        public string ot
        {
            get { return _ot; }
            set { _ot = value; NotifyPropertyChanged("ot"); }
        }

        [Column(TypeName = "varchar"), MaxLength(1)]
        private string _d_type3;
        public string d_type3
        {
            get { return _d_type3; }
            set { _d_type3 = value; NotifyPropertyChanged("d_type3"); }
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

        private byte _true_dr;
        public byte true_dr
        {
            get { return _true_dr; }
            set { _true_dr = value; NotifyPropertyChanged("true_dr"); }
        }

        [ForeignKey("adr77")]
        public int? adr_id { get; set; }

        public int? adr50_id { get; set; }

        [Column(TypeName = "varchar"), MaxLength(1)]
        private string _jt;
        public string jt
        {
            get { return _jt; }
            set { _jt = value; NotifyPropertyChanged("jt"); }
        }

        [Column(TypeName = "varchar"), MaxLength(3)]
        private string _scn;
        public string scn
        {
            get { return _scn; }
            set { _scn = value; NotifyPropertyChanged("scn"); }
        }

        private byte _kl;
        public byte kl
        {
            get { return _kl; }
            set { _kl = value; NotifyPropertyChanged("kl"); }
        }

        [Column(TypeName = "varchar"), MaxLength(40)]
        private string _cont;
        public string cont
        {
            get { return _cont; }
            set { _cont = value; NotifyPropertyChanged("cont"); }
        }

        private byte _c_doc;
        public byte c_doc
        {
            get { return _c_doc; }
            set { _c_doc = value; NotifyPropertyChanged("c_doc"); }
        }

        [Column(TypeName = "varchar"), MaxLength(9)]
        private string _s_doc;
        public string s_doc
        {
            get { return _s_doc; }
            set { _s_doc = value; NotifyPropertyChanged("s_doc"); }
        }

        [Column(TypeName = "varchar"), MaxLength(8)]
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

        private byte _x_doc;
        public byte x_doc
        {
            get { return _x_doc; }
            set { _x_doc = value; NotifyPropertyChanged("x_doc"); }
        }

        [Column(TypeName = "varchar"), MaxLength(250)]
        private string _u_doc;
        public string u_doc
        {
            get { return _u_doc; }
            set { _u_doc = value; NotifyPropertyChanged("u_doc"); }
        }

        [Column(TypeName = "varchar"), MaxLength(14)]
        private string _snils;
        public string snils
        {
            get { return _snils; }
            set { _snils = value; NotifyPropertyChanged("snils"); }
        }

        [Column(TypeName = "varchar"), MaxLength(3)]
        private string _gr;
        public string gr
        {
            get { return _gr; }
            set { _gr = value; NotifyPropertyChanged("gr"); }
        }

        [Column(TypeName = "varchar"), MaxLength(250)]
        private string _mr;
        public string mr
        {
            get { return _mr; }
            set { _mr = value; NotifyPropertyChanged("mr"); }
        }

        private DateTime? _d_reg;
        public DateTime? d_reg
        {
            get { return _d_reg; }
            set { _d_reg = value; NotifyPropertyChanged("d_reg"); }
        }

        private byte _form;
        public byte form
        {
            get { return _form; }
            set { _form = value; NotifyPropertyChanged("form"); }
        }

        [Column(TypeName = "varchar"), MaxLength(1)]
        private string _predst;
        public string predst
        {
            get { return _predst; }
            set { _predst = value; NotifyPropertyChanged("predst"); }
        }

        private byte _spos;
        public byte spos
        {
            get { return _spos; }
            set { _spos = value; NotifyPropertyChanged("spos"); }
        }

        private byte _d_type4;
        public byte d_type4
        {
            get { return _d_type4; }
            set { _d_type4 = value; NotifyPropertyChanged("d_type4"); }
        }

        [Column(TypeName = "varchar"), MaxLength(250)]
        private string _coment;
        public string coment
        {
            get { return _coment; }
            set { _coment = value; NotifyPropertyChanged("coment"); }
        }

        [Column(TypeName = "varchar"), MaxLength(1)]
        private string _ktg;
        public string ktg
        {
            get { return _ktg; }
            set { _ktg = value; NotifyPropertyChanged("ktg"); }
        }

        private byte _gzk_flag;
        public byte gzk_flag
        {
            get { return _gzk_flag; }
            set { _gzk_flag = value; NotifyPropertyChanged("gzk_flag"); }
        }

        private byte _doc_flag;
        public byte doc_flag
        {
            get { return _doc_flag; }
            set { _doc_flag = value; NotifyPropertyChanged("doc_flag"); }
        }

        [Column(TypeName = "varchar"), MaxLength(1)]
        private string _uec_flag;
        public string uec_flag
        {
            get { return _uec_flag; }
            set { _uec_flag = value; NotifyPropertyChanged("uec_flag"); }
        }

        [Column(TypeName = "varchar"), MaxLength(12)]
        private string _s_card2;
        public string s_card2
        {
            get { return _s_card2; }
            set { _s_card2 = value; NotifyPropertyChanged("s_card2"); }
        }

        [Column(TypeName = "varchar"), MaxLength(32)]
        private string _n_card2;
        public string n_card2
        {
            get { return _n_card2; }
            set { _n_card2 = value; NotifyPropertyChanged("n_card2"); }
        }

        [Column(TypeName = "varchar"), MaxLength(1)]
        private string _is2fio;
        public string is2fio
        {
            get { return _is2fio; }
            set { _is2fio = value; NotifyPropertyChanged("is2fio"); }
        }

        public int? ofioid { get; set; }

        [Column(TypeName = "varchar"), MaxLength(1)]
        private string _is2doc;
        public string is2doc
        {
            get { return _is2doc; }
            set { _is2doc = value; NotifyPropertyChanged("is2doc"); }
        }

        public int? odocid { get; set; }

        [Column(TypeName = "varchar"), MaxLength(7)]
        private string _mcod;
        public string mcod
        {
            get { return _mcod; }
            set { _mcod = value; NotifyPropertyChanged("mcod"); }
        }

        private byte? _oper;
        public byte? oper
        {
            get { return _oper; }
            set { _oper = value; NotifyPropertyChanged("oper"); }
        }

        private byte? _operpv;
        public byte? operpv
        {
            get { return _operpv; }
            set { _operpv = value; NotifyPropertyChanged("operpv"); }
        }

        private byte? _isrereg;
        public byte? isrereg
        {
            get { return _isrereg; }
            set { _isrereg = value; NotifyPropertyChanged("isrereg"); }
        }

        public int? osmoid { get; set; }
        public int? permid { get; set; }
        public int? perm2id { get; set; }
        public int? enp2id { get; set; }
        public int? predstid { get; set; }
        public int? wrkid { get; set; }

        [Column(TypeName = "varchar"), MaxLength(5)]
        private string _plant;
        public string plant
        {
            get { return _plant; }
            set { _plant = value; NotifyPropertyChanged("plant"); }
        }

        private DateTime? _dpok;
        public DateTime? dpok
        {
            get { return _dpok; }
            set { _dpok = value; NotifyPropertyChanged("dpok"); }
        }

        [Column(TypeName = "varchar"), MaxLength(11)]
        private string _blanc;
        public string blanc
        {
            get { return _blanc; }
            set { _blanc = value; NotifyPropertyChanged("blanc"); }
        }

        private byte[] _photo;
        public byte[] photo
        {
            get { return _photo; }
            set { _photo = value; NotifyPropertyChanged("photo"); }
        }

        private byte[] _sign;
        public byte[] sign
        {
            get { return _sign; }
            set { _sign = value; NotifyPropertyChanged("sign"); }
        }

        public DateTime created { get; set; }

        private int? _ul;
        public int? ul 
        {
            get { return _ul; }
            set { _ul = value; NotifyPropertyChanged("ul"); }
        }

        private string _dom;
        public string dom
        {
            get { return _dom; }
            set { _dom = value; NotifyPropertyChanged("dom"); }
        }

        private string _kor;
        public string kor
        {
            get { return _kor; }
            set { _kor = value; NotifyPropertyChanged("kor"); }
        }

        private string _str;
        public string str
        {
            get { return _str; }
            set { _str = value; NotifyPropertyChanged("str"); }
        }

        private string _kv;
        public string kv
        {
            get { return _kv; }
            set { _kv = value; NotifyPropertyChanged("kv"); }
        }

        private byte _c_perm;
        public byte c_perm
        {
            get { return _c_perm; }
            set { _c_perm = value; NotifyPropertyChanged("c_perm"); }
        }

        private string _s_perm;
        public string s_perm
        {
            get { return _s_perm; }
            set { _s_perm = value; NotifyPropertyChanged("s_perm"); }
        }

        private string _n_perm;
        public string n_perm
        {
            get { return _n_perm; }
            set { _n_perm = value; NotifyPropertyChanged("n_perm"); }
        }

        private DateTime? _d_perm;
        public DateTime? d_perm
        {
            get { return _d_perm; }
            set { _d_perm = value; NotifyPropertyChanged("d_perm"); }
        }

        private DateTime? _e_perm;
        public DateTime? e_perm
        {
            get { return _e_perm; }
            set { _e_perm = value; NotifyPropertyChanged("e_perm"); }
        }

        private byte _c_perm2;
        public byte c_perm2
        {
            get { return _c_perm2; }
            set { _c_perm2 = value; NotifyPropertyChanged("c_perm2"); }
        }

        private string _s_perm2;
        public string s_perm2
        {
            get { return _s_perm2; }
            set { _s_perm2 = value; NotifyPropertyChanged("s_perm2"); }
        }

        private string _n_perm2;
        public string n_perm2
        {
            get { return _n_perm2; }
            set { _n_perm2 = value; NotifyPropertyChanged("n_perm2"); }
        }

        private DateTime? _d_perm2;
        public DateTime? d_perm2
        {
            get { return _d_perm2; }
            set { _d_perm2 = value; NotifyPropertyChanged("d_perm2"); }
        }

        private DateTime? _e_perm2;
        public DateTime? e_perm2
        {
            get { return _e_perm2; }
            set { _e_perm2 = value; NotifyPropertyChanged("e_perm2"); }
        }

        #endregion #Fields

        public void CopyPerson(kms p)
        {
            this.recid = p.recid;
            this.act = p.act;
            this.pv = p.pv;
            this.nz = p.nz;
            this.status = p.status;
            this.p_doc = p.p_doc;
            this.p_doc2 = p.p_doc2;
            this.vs = p.vs;
            this.vs_data = p.vs_data;
            this.sn_card = p.sn_card;
            this.enp = p.enp;
            this.gz_data = p.gz_data;
            this.q = p.q;
            this.dp = p.dp;
            this.dt = p.dt;
            this.fam = p.fam;
            this.d_type1 = p.d_type1;
            this.im = p.im;
            this.d_type2 = p.d_type2;
            this.ot = p.ot;
            this.d_type3 = p.d_type3;
            this.w = p.w;
            this.dr = p.dr;
            this.true_dr = p.true_dr;
            this.adr_id = p.adr_id;
            this.adr50_id = p.adr50_id;
            this.jt = p.jt;
            this.scn = p.scn;
            this.kl = p.kl;
            this.cont = p.cont;
            this.c_doc = p.c_doc;
            this.s_doc = p.s_doc;
            this.n_doc = p.n_doc;
            this.d_doc = p.d_doc;
            this.e_doc = p.e_doc;
            this.x_doc = p.x_doc;
            this.u_doc = p.u_doc;
            this.snils = p.snils;
            this.gr = p.gr;
            this.mr = p.mr;
            this.d_reg = p.d_reg;
            this.form = p.form;
            this.predst = p.predst;
            this.spos = p.spos;
            this.d_type4 = p.d_type4;
            this.coment = p.coment;
            this.ktg = p.ktg;
            this.gzk_flag = p.gzk_flag;
            this.doc_flag = p.doc_flag;
            this.uec_flag = p.uec_flag;
            this.s_card2 = p.s_card2;
            this.n_card2 = p.n_card2;
            this.is2fio = p.is2fio;
            this.ofioid = p.ofioid;
            this.is2doc = p.is2doc;
            this.odocid = p.odocid;
            this.mcod = p.mcod;
            this.oper = p.oper;
            this.operpv = p.operpv;
            this.isrereg = p.isrereg;
            this.osmoid = p.osmoid;
            this.permid = p.permid;
            this.perm2id = p.perm2id;
            this.enp2id = p.enp2id;
            this.predstid = p.predstid;
            this.wrkid = p.wrkid;
            this.plant = p.plant;
            this.dpok = p.dpok;
            this.blanc = p.blanc;
            this.photo = p.photo;
            this.sign = p.sign;
            this.created = p.created;
            this.ul = p.ul;
            this.dom = p.dom;
            this.kor = p.kor;
            this.str = p.str;
            this.kv = p.kv;
            this.c_perm = p.c_perm;
            this.s_perm = p.s_perm;
            this.n_perm = p.n_perm;
            this.d_perm = p.d_perm;
            this.e_perm = p.e_perm;
        }

        #region Constructors
        public kms() { }
        
        public kms(int _recid, bool _act, string _pv, string _nz, byte _status, byte _p_doc, byte _p_doc2,
            string _vs, DateTime? _vs_data, string _sn_card, string _enp, DateTime? _gz_data, string _q, 
            DateTime? _dp, DateTime? _dt, string _fam, string _d_type1, string _im, string _d_type2, 
            string _ot, string _d_type3, byte _w, DateTime? _dr, byte _true_dr, int? _adr_id, int? _adr50_id,
            string _jt, string _scn, byte _kl, string _cont, byte _c_doc, string _s_doc, string _n_doc,
            DateTime? _d_doc, DateTime? _e_doc, byte _x_doc, string _u_doc, string _snils, string _gr,
            string _mr, DateTime? _d_reg, byte _form, string _predst, byte _spos, byte _d_type4,
            string _coment, string _ktg, byte _gzk_flag, byte _doc_flag, string _uec_flag, string _s_card2,
            string _n_card2, string _is2fio, int? _ofioid, string _is2doc, int? _odocid, string _mcod, byte? _oper,
            byte? _operpv, byte? _isrereg, int? _osmoid, int? _permid, int? _perm2id, int? _enp2id, int? _predstid,
            int? _wrkid, string _plant, DateTime? _dpok, string _blanc, byte[] _photo, byte[] _sign, DateTime _created, int? _ul, string _dom,
            string _kor, string _str, string _kv, byte _c_perm, string _s_perm, string _n_perm, DateTime? _d_perm,
            DateTime? _e_perm, byte _c_perm2, string _s_perm2, string _n_perm2, DateTime? _d_perm2,
            DateTime? _e_perm2)
        {   recid = _recid; act = _act; pv = _pv; nz = _nz; status = _status; p_doc = _p_doc; p_doc2 = _p_doc2;
            vs = _vs; vs_data = _vs_data; sn_card = _sn_card; enp = _enp; gz_data = _gz_data; q = _q; dp = _dp;
            dt = _dt; fam = _fam; d_type1 = _d_type1; im = _im; d_type2 = _d_type2; ot = _ot; d_type3 = _d_type3;
            w = _w; dr = _dr; true_dr = _true_dr; adr_id = _adr_id; adr50_id = _adr50_id; jt = _jt; scn = _scn;
            kl = _kl; cont = _cont; c_doc = _c_doc; s_doc = _s_doc; n_doc = _n_doc; d_doc = _d_doc;
            e_doc = _e_doc; x_doc = _x_doc; u_doc = _u_doc; snils = _snils; gr = _gr; mr = _mr; d_reg = _d_reg; form = _form;
            predst = _predst; spos = _spos; d_type4 = _d_type4; coment = _coment; ktg = _ktg; gzk_flag = _gzk_flag;
            doc_flag = _doc_flag; uec_flag = _uec_flag; s_card2 = _s_card2; n_card2 = _n_card2; is2fio = _is2fio;
            ofioid = _ofioid; is2doc = _is2doc; odocid = _odocid; mcod = _mcod; oper = _oper; operpv = _operpv;
            isrereg = _isrereg; osmoid = _osmoid; permid = _permid; perm2id = _perm2id; enp2id = _enp2id;
            predstid = _predstid; wrkid = _wrkid; plant = _plant; dpok = _dpok; blanc = _blanc; photo = _photo;
            sign = _sign; created =_created; ul = _ul; dom = _dom; kor = _kor; str = _str; kv = _kv; c_perm = _c_perm;
            s_perm = _s_perm ; n_perm = _n_perm; d_perm = _d_perm; e_perm = _e_perm; c_perm2 = _c_perm2;
            s_perm2 = _s_perm2; n_perm2 = _n_perm2; d_perm2 = _d_perm2; e_perm2 = _e_perm2;
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
