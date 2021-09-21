using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public class Adatbázis
    {
        SqlConnection conn;

        public Adatbázis()
        {
            conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; Initial Catalog = labdarugas; Integrated Security = True");
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<Bajnokság> BajnokságLista
        {
            get
            {
                List<Bajnokság> d = new List<Bajnokság>();
                SqlCommand cmd = new SqlCommand("SELECT * FROM bajnoksag", conn);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    d.Add(
                        new Bajnokság
                        {
                            Baj_id = (int)r["baj_id"],
                            Név = (string)r["nev"],
                            Ország = (string)r["orszag"]
                        }
                        );
                }

                r.Close();
                return d;
            }
        }

        public List<Csapat> CsapatLista
        {
            get
            {
                List<Csapat> d = new List<Csapat>();
                SqlCommand cmd = new SqlCommand("SELECT * FROM csapat", conn);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    d.Add(
                        new Csapat
                        {
                            Csapat_id = (int)r["csapat_id"],
                            Név = (string)r["nev"],
                            Baj_id = (int)r["baj_id"],
                            Edző_név = (string)r["edzo"],
                            Edző_nemzet = (string)r["edzo_nemzet"],
                            Stadion = (string)r["stadion"]
                        }
                        );
                }

                r.Close();
                return d;
            }
        }

        public List<Csapat> Csapatok(int baj_id)
        {
            List<Csapat> d = new List<Csapat>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM csapat WHERE baj_id = @baj_id", conn);
            cmd.Parameters.Add(new SqlParameter("@baj_id", baj_id));
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                d.Add(
                    new Csapat
                    {
                        Csapat_id = (int)r["csapat_id"],
                        Név = (string)r["nev"],
                        Baj_id = (int)r["baj_id"],
                        Edző_név = (string)r["edzo"],
                        Edző_nemzet = (string)r["edzo_nemzet"],
                        Stadion = (string)r["stadion"]
                    }
                    );
            }
            r.Close();
            return d;
        }

        public List<Játékos> Játékosok(int cs_id)
        {
            List<Játékos> d = new List<Játékos>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM jatekos WHERE cs_id = @cs_id", conn);
            cmd.Parameters.Add(new SqlParameter("@cs_id", cs_id));
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                d.Add(
                    new Játékos
                    {
                        Játékos_id = (int)r["jatekos_id"],
                        Csapat_id = (int)r["cs_id"],
                        Poszt_id = (int)r["poszt_id"],
                        Név = (string)r["nev"],
                        Mez = (int)r["mezszam"],
                        Kor = (int)r["kor"],
                        Nemzet = (string)r["nemzet"]
                    }
                    );
            }
            r.Close();
            return d;
        }

        public List<Poszt> PosztLista
        {
            get
            {
                List<Poszt> d = new List<Poszt>();
                SqlCommand cmd = new SqlCommand("SELECT * FROM poszt", conn);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    d.Add(
                        new Poszt
                        {
                            Poszt_id = (int)r["poszt_id"],
                            Név = (string)r["nev"]
                        }
                        );
                }

                r.Close();
                return d;
            }
        }

        public List<Meccs> MeccsLista
        {
            get
            {
                List<Meccs> d = new List<Meccs>();
                SqlCommand cmd = new SqlCommand("SELECT * FROM meccs", conn);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    d.Add(
                        new Meccs
                        {
                            Meccs_id = (int)r["meccs_id"],
                            H_csid = (int)r["h_csid"],
                            V_csid = (int)r["v_csid"],
                            H_csgol = (int)r["h_csgol"],
                            V_csgol = (int)r["v_csgol"],
                            Típus_id = (int)r["tipus_id"],
                            Dátum = (DateTime)r["datum"]
                        }
                        );
                }
                r.Close();
                return d;
            }
        }

        public List<Meccstipus> MeccsTipusLista
        {
            get
            {
                List<Meccstipus> d = new List<Meccstipus>();
                SqlCommand cmd = new SqlCommand("SELECT * FROM meccs_tipus", conn);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    d.Add(
                        new Meccstipus
                        {
                            Tipus_id = (int)r["id"],
                            Név = (string)r["nev"]
                        }
                        );
                }
                r.Close();
                return d;
            }
        }

        public List<Játékos> JátékosLista
        {
            get
            {
                List<Játékos> d = new List<Játékos>();
                SqlCommand cmd = new SqlCommand("SELECT * FROM jatekos", conn);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    d.Add(
                        new Játékos
                        {
                            Játékos_id = (int)r["jatekos_id"],
                            Csapat_id = (int)r["cs_id"],
                            Poszt_id = (int)r["poszt_id"],
                            Név = (string)r["nev"],
                            Mez = (int)r["mezszam"],
                            Kor = (int)r["kor"],
                            Nemzet = (string)r["nemzet"]
                        }
                        );
                }
                r.Close();
                return d;
            }
        }


        public int BajnokságID(string név)
        {
            int Baj_id = -1;
            SqlCommand cmd = new SqlCommand("SELECT baj_id FROM bajnoksag WHERE nev = @név", conn);
            cmd.Parameters.Add(new SqlParameter("@név", név));
            Baj_id = int.Parse(cmd.ExecuteScalar().ToString());
            return Baj_id;
        }

        public int CsapatID(string név)
        {
            int cs_id = -1;
            SqlCommand cmd = new SqlCommand("SELECT csapat_id FROM csapat WHERE nev = @név", conn);
            cmd.Parameters.Add(new SqlParameter("@név", név));
            cs_id = int.Parse(cmd.ExecuteScalar().ToString());
            return cs_id;
        }

        public string CsapatNév(int cs_id)
        {
            string cs = "";
            SqlCommand cmd = new SqlCommand("SELECT nev FROM csapat WHERE csapat_id = @cs_id", conn);
            cmd.Parameters.Add(new SqlParameter("@cs_id", cs_id));
            cs = cmd.ExecuteScalar().ToString();
            return cs;
        }

        public string PosztÁtÍr(int poszt_id, List<Poszt> poszt)
        {
            string posztnév = "";
            for (int i = 0; i < poszt.Count && posztnév == ""; ++i)
            {
                if (poszt[i].Poszt_id == poszt_id)
                    posztnév = poszt[i].Név;
            }

            return posztnév;
        }

        public int PosztVisszaÍr(string posztnév, List<Poszt> poszt)
        {
            int poszt_id = 0;
            for (int i = 0; i < poszt.Count && poszt_id == 0; ++i)
            {
                if (poszt[i].Név == posztnév)
                    poszt_id = poszt[i].Poszt_id;
            }

            return poszt_id;
        }

        public void InsertJátékos(int játékos_id, int cs_id, int poszt_id, string név, int mezszam, int kor, string nemzet)
        {
            SqlCommand cmd = new SqlCommand("insert into jatekos (jatekos_id,cs_id,poszt_id,nev,mezszam,kor,nemzet) values (@jatekos_id, @cs_id, @poszt_id, @nev, @mezszam, @kor, @nemzet)", conn);
            cmd.Parameters.Add(new SqlParameter("@jatekos_id", játékos_id));
            cmd.Parameters.Add(new SqlParameter("@cs_id", cs_id));
            cmd.Parameters.Add(new SqlParameter("@poszt_id", poszt_id));
            cmd.Parameters.Add(new SqlParameter("@nev", név));
            cmd.Parameters.Add(new SqlParameter("@mezszam", mezszam));
            cmd.Parameters.Add(new SqlParameter("@kor", kor));
            cmd.Parameters.Add(new SqlParameter("@nemzet", nemzet));
            int r = cmd.ExecuteNonQuery();
        }

        public void DeleteJátékos(int játékos_id, int cs_id, int poszt_id, string név, int mezszam, int kor, string nemzet)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM jatekos WHERE jatekos_id = @jatekos_id and cs_id = @cs_id and poszt_id = @poszt_id and nev = @nev and mezszam = @mezszam and kor = @kor and nemzet = @nemzet", conn);
            cmd.Parameters.Add(new SqlParameter("@jatekos_id", játékos_id));
            cmd.Parameters.Add(new SqlParameter("@cs_id", cs_id));
            cmd.Parameters.Add(new SqlParameter("@poszt_id", poszt_id));
            cmd.Parameters.Add(new SqlParameter("@nev", név));
            cmd.Parameters.Add(new SqlParameter("@mezszam", mezszam));
            cmd.Parameters.Add(new SqlParameter("@kor", kor));
            cmd.Parameters.Add(new SqlParameter("@nemzet", nemzet));
            int r = cmd.ExecuteNonQuery();
        }

        public int NextJátékosID()
        {
            int jatekos_id = -1;
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 jatekos_id FROM jatekos ORDER BY jatekos_id desc", conn);
            jatekos_id = int.Parse(cmd.ExecuteScalar().ToString()) + 1;
            return jatekos_id;
        }

        public int MezAdás(int csapat_id)
        {
            int mez = -1;
            SqlCommand cmd = new SqlCommand("SELECT mezszam FROM jatekos j WHERE j.cs_id = @cs_id ORDER BY mezszam", conn);
            cmd.Parameters.Add(new SqlParameter("@cs_id", csapat_id));
            SqlDataReader r = cmd.ExecuteReader();

            List<int> mezek = new List<int>();

            while (r.Read())
            {
                mezek.Add(int.Parse(r.GetValue(0).ToString()));
            }
            r.Close();

            int előző = mezek[0];

            for (int i = 1; i < mezek.Count && mez == -1; i++)
            {
                if (mezek[i] - előző > 1)
                    mez = mezek[i] - 1;
                else
                    előző = mezek[i];
            }

            return mez;
        }

        public void InsertMeccs(int meccs_id, int h_csid, int v_csid, int h_csgol, int v_csgol, int tipus_id, DateTime dátum)
        {
            SqlCommand cmd = new SqlCommand("insert into meccs (meccs_id,h_csid,v_csid,h_csgol,v_csgol,tipus_id,datum) values (@meccs_id,@h_csid,@v_csid,@h_csgol,@v_csgol,@tipus_id,@datum)", conn);
            cmd.Parameters.Add(new SqlParameter("@meccs_id", meccs_id));
            cmd.Parameters.Add(new SqlParameter("@h_csid", h_csid));
            cmd.Parameters.Add(new SqlParameter("@v_csid", v_csid));
            cmd.Parameters.Add(new SqlParameter("@h_csgol", h_csgol));
            cmd.Parameters.Add(new SqlParameter("@v_csgol", v_csgol));
            cmd.Parameters.Add(new SqlParameter("@tipus_id", tipus_id));
            cmd.Parameters.Add(new SqlParameter("@datum", dátum));
            int r = cmd.ExecuteNonQuery();
        }

        public void DeleteMeccs(int meccs_id, int h_csid, int v_csid, int h_csgol, int v_csgol, int tipus_id, DateTime dátum)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM meccs WHERE meccs_id = @meccs_id and h_csid = @h_csid and v_csid = @v_csid and h_csgol = @h_csgol and v_csgol = @v_csgol and tipus_id = @tipus_id and datum = @datum", conn);
            cmd.Parameters.Add(new SqlParameter("@meccs_id", meccs_id));
            cmd.Parameters.Add(new SqlParameter("@h_csid", h_csid));
            cmd.Parameters.Add(new SqlParameter("@v_csid", v_csid));
            cmd.Parameters.Add(new SqlParameter("@h_csgol", h_csgol));
            cmd.Parameters.Add(new SqlParameter("@v_csgol", v_csgol));
            cmd.Parameters.Add(new SqlParameter("@tipus_id", tipus_id));
            cmd.Parameters.Add(new SqlParameter("@datum", dátum));
            int r = cmd.ExecuteNonQuery();
        }

        public int NextMeccsID()
        {
            int meccs_id = -1;
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 meccs_id FROM meccs ORDER BY meccs_id desc", conn);
            meccs_id = int.Parse(cmd.ExecuteScalar().ToString()) + 1;
            return meccs_id;
        }

        public int MeccsTipusIDre(string meccs_tipus, List<Meccstipus> meccstipus)
        {
            int meccst = -1;
            for (int i = 0; i < meccstipus.Count && meccst == -1; i++)
            {
                if (meccstipus[i].Név == meccs_tipus)
                    meccst = meccstipus[i].Tipus_id;
            }
            return meccst;
        }

        public Tabella TabellaFeltölt(int cs_id)
        {
            Tabella o = new Tabella();
            SqlCommand cmd = new SqlCommand("SELECT @cs_id, HAZAIM.LG + VENDÉGM.LG as LG, HAZAIM.KG + VENDÉGM.KG as KG FROM (SELECT SUM(h_csgol) as LG, SUM(v_csgol) as KG FROM  meccs m INNER JOIN meccs_tipus mt on m.tipus_id =mt.id WHERE m.h_csid = @cs_id and mt.nev = 'bajnoki') as HAZAIM , (SELECT SUM(v_csgol) as LG, SUM(h_csgol) as KG FROM  meccs m INNER JOIN meccs_tipus mt on m.tipus_id =mt.id WHERE m.v_csid = @cs_id and mt.nev = 'bajnoki') as VENDÉGM", conn);
            cmd.Parameters.Add(new SqlParameter("@cs_id", cs_id));
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                o.Lőttgól = (int)r.GetValue(1);
                o.Kapottgól = (int)r.GetValue(2);
            }
            r.Close();

            cmd = new SqlCommand("SELECT HAZAIM.db+VENDÉGM.db FROM (SELECT Count(*) as db FROM meccs m INNER JOIN meccs_tipus mt on m.tipus_id = mt.id WHERE m.h_csid = @cs_id and mt.nev = 'bajnoki') as HAZAIM, (SELECT Count(*) as db FROM meccs m INNER JOIN meccs_tipus mt on m.tipus_id = mt.id WHERE m.v_csid = @cs_id and mt.nev = 'bajnoki') as VENDÉGM", conn);
            cmd.Parameters.Add(new SqlParameter("@cs_id", cs_id));
            o.Lejátszott = int.Parse(cmd.ExecuteScalar().ToString());
            cmd = new SqlCommand("SELECT HAZAIM.db+VENDÉGM.db FROM (SELECT Count(*) as db FROM meccs m INNER JOIN meccs_tipus mt on m.tipus_id = mt.id WHERE m.h_csid = @cs_id and mt.nev = 'bajnoki' and m.h_csgol > m.v_csgol) as HAZAIM, (SELECT Count(*) as db FROM meccs m INNER JOIN meccs_tipus mt on m.tipus_id = mt.id WHERE m.v_csid = @cs_id and mt.nev = 'bajnoki' and m.h_csgol < m.v_csgol) as VENDÉGM", conn);
            cmd.Parameters.Add(new SqlParameter("@cs_id", cs_id));
            o.Győzelem = int.Parse(cmd.ExecuteScalar().ToString());
            cmd = new SqlCommand("SELECT HAZAIM.db+VENDÉGM.db FROM (SELECT Count(*) as db FROM meccs m INNER JOIN meccs_tipus mt on m.tipus_id = mt.id WHERE m.h_csid = @cs_id and mt.nev = 'bajnoki' and m.h_csgol = m.v_csgol) as HAZAIM, (SELECT Count(*) as db FROM meccs m INNER JOIN meccs_tipus mt on m.tipus_id = mt.id WHERE m.v_csid = @cs_id and mt.nev = 'bajnoki' and m.h_csgol = m.v_csgol) as VENDÉGM", conn);
            cmd.Parameters.Add(new SqlParameter("@cs_id", cs_id));
            o.Döntetlen = int.Parse(cmd.ExecuteScalar().ToString());
            cmd = new SqlCommand("SELECT HAZAIM.db+VENDÉGM.db FROM (SELECT Count(*) as db FROM meccs m INNER JOIN meccs_tipus mt on m.tipus_id = mt.id WHERE m.h_csid = @cs_id and mt.nev = 'bajnoki' and m.h_csgol < m.v_csgol) as HAZAIM, (SELECT Count(*) as db FROM meccs m INNER JOIN meccs_tipus mt on m.tipus_id = mt.id WHERE m.v_csid = @cs_id and mt.nev = 'bajnoki' and m.h_csgol > m.v_csgol) as VENDÉGM", conn);
            cmd.Parameters.Add(new SqlParameter("@cs_id", cs_id));
            o.Vereség = int.Parse(cmd.ExecuteScalar().ToString());
            o.Pont = o.Győzelem * 3 + o.Döntetlen;
            o.Név = CsapatNév(cs_id);
            return o;
        }

        public List<Meccs> MeccsListaCsapat(int csapat_id)
        {
            List<Meccs> d = new List<Meccs>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM meccs m INNER JOIN meccs_tipus mt on m.tipus_id = mt.id WHERE mt.nev = 'bajnoki' and m.h_csid = @cs_id", conn);
            cmd.Parameters.Add(new SqlParameter("@cs_id", csapat_id));
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                d.Add(
                     new Meccs
                     {
                         Meccs_id = (int)r["meccs_id"],
                         H_csid = (int)r["h_csid"],
                         V_csid = (int)r["v_csid"],
                         H_csgol = (int)r["h_csgol"],
                         V_csgol = (int)r["v_csgol"],
                         Típus_id = (int)r["tipus_id"],
                         Dátum = (DateTime)r["datum"]
                     }
                     );
            }
            r.Close();
            cmd = new SqlCommand("SELECT * FROM meccs m INNER JOIN meccs_tipus mt on m.tipus_id = mt.id WHERE mt.nev = 'bajnoki' and m.v_csid = @cs_id", conn);
            cmd.Parameters.Add(new SqlParameter("@cs_id", csapat_id));
            r = cmd.ExecuteReader();
            while (r.Read())
            {
                d.Add(
                     new Meccs
                     {
                         Meccs_id = (int)r["meccs_id"],
                         H_csid = (int)r["h_csid"],
                         V_csid = (int)r["v_csid"],
                         H_csgol = (int)r["h_csgol"],
                         V_csgol = (int)r["v_csgol"],
                         Típus_id = (int)r["tipus_id"],
                         Dátum = (DateTime)r["datum"]
                     }
                     );
            }
            r.Close();
            return d;
        }
    }
}

