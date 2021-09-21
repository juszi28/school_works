using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using ExtensionMethods;

namespace Project
{
    public partial class FutballAdatbázis : Form
    {
        #region változók
        int aktBajnokság = -1;
        int aktCsapat = -1;
        int aktJátékos = -1;
        ListViewItem aktMeccs;
        Adatbázis DB;
        List<Bajnokság> Bajnokságok;
        List<Csapat> AktCsapatok;
        List<Játékos> AktJátékosok;
        List<Poszt> Posztok;
        List<Meccs> Meccsek;
        List<Meccstipus> MeccsTipusok;
        List<Játékos> ÖsszesJátékos;
        List<MeccsSzerkesztett> MeccsKeres = new List<MeccsSzerkesztett>();
        DataTable DT;
        #endregion

        public FutballAdatbázis()
        {
            InitializeComponent();
            DB = new Adatbázis();
            BajnokságCBLoad(BajnokságCB);

            BajnokságCsapatokLB.Visible = false;
            CsapatJátékosokDGV.Visible = false;

            Posztok = DB.PosztLista;

            ÚjJátékosB.Visible = false;
            JátékosDelB.Visible = false;
            JátékosDelB.Enabled = false;

            TabC.SelectTab(0);
            TabC.TabPages["TP2"].Elrejt();
            TabC.TabPages["TP3"].Elrejt();
            TabC.TabPages["TP4"].Elrejt();
            TabC.TabPages["TP5"].Elrejt();
        }

        void BajnokságCBLoad(ComboBox a)
        {
            Bajnokságok = DB.BajnokságLista;
            a.Items.Clear();
            a.Items.AddRange(Bajnokságok.ToArray());
        }

        private void BajnokságCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BajnokságCB.SelectedIndex != -1)
            {
                aktBajnokság = DB.BajnokságID(BajnokságCB.SelectedItem.ToString());
                BajnokságCsapatokLB.Visible = true;
                CsapatJátékosokDGV.Rows.Clear();
            }
            else
            {
                aktBajnokság = -1;
                BajnokságCsapatokLB.Visible = false;
            }

            BajnokságCsapatLBLoad();

        }

        void BajnokságCsapatLBLoad()
        {
            AktCsapatok = DB.Csapatok(aktBajnokság);
            BajnokságCsapatokLB.Items.Clear();
            foreach (var item in AktCsapatok)
            {
                BajnokságCsapatokLB.Items.Add(item);
            }
        }

        private void BajnokságCsapatokLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BajnokságCsapatokLB.SelectedIndex != -1)
            {
                aktCsapat = DB.CsapatID(BajnokságCsapatokLB.SelectedItem.ToString().Split('\t')[0]);
                CsapatJátékosokDGV.Visible = true;
                ÚjJátékosB.Visible = true;
                JátékosDelB.Visible = true;
            }
            else
            {
                aktCsapat = -1;
                CsapatJátékosokDGV.Visible = false;
            }
            CsapatJátékosokDGVLoad();
        }

        void CsapatJátékosokDGVLoad()
        {
            CsapatJátékosokDGV.Rows.Clear();
            if (aktCsapat != -1)
            {
                AktJátékosok = DB.Játékosok(aktCsapat);
                foreach (var item in AktJátékosok)
                {
                    object[] o = new object[5];
                    o[0] = item.Mez;
                    o[1] = item.Név;
                    o[2] = DB.PosztÁtÍr(item.Poszt_id, Posztok);
                    o[3] = item.Kor;
                    o[4] = item.Nemzet;
                    CsapatJátékosokDGV.Rows.Add(o);
                }
            }
            CsapatJátékosokDGV.ClearSelection();
        }

        private void ÚjJátékosB_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(aktCsapat);
            f2.ShowDialog();
            CsapatJátékosokDGVLoad();
        }

        private void CsapatJátékosokDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            JátékosDelB.Enabled = true;
            aktJátékos = e.RowIndex;
        }

        private void JátékosDelB_Click(object sender, EventArgs e)
        {
            if (aktJátékos != -1)
            {
                if (MessageBox.Show("Biztos törölni kívánja a kijelölt játékost?", "Törlés", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int játékos_id = AktJátékosok[aktJátékos].Játékos_id;
                    int cs_id = aktCsapat;
                    int poszt_id = DB.PosztVisszaÍr(CsapatJátékosokDGV.Rows[aktJátékos].Cells[2].Value.ToString(), Posztok);
                    string név = CsapatJátékosokDGV.Rows[aktJátékos].Cells[1].Value.ToString();
                    int mezszam = int.Parse(CsapatJátékosokDGV.Rows[aktJátékos].Cells[0].Value.ToString());
                    int kor = int.Parse(CsapatJátékosokDGV.Rows[aktJátékos].Cells[3].Value.ToString());
                    string nemzet = CsapatJátékosokDGV.Rows[aktJátékos].Cells[4].Value.ToString();

                    DB.DeleteJátékos(játékos_id, cs_id, poszt_id, név, mezszam, kor, nemzet);
                    CsapatJátékosokDGVLoad();
                }
            }
        }

        void MeccsekLVLoad()
        {
            Meccsek = DB.MeccsLista;
            MeccsTipusok = DB.MeccsTipusLista;
            MeccsLV.Items.Clear();
            foreach (var item in Meccsek)
            {
                object[] o = new object[7];
                o[0] = DB.CsapatNév(item.H_csid);
                o[1] = item.H_csgol;
                o[2] = item.V_csgol;
                o[3] = DB.CsapatNév(item.V_csid);
                o[4] = item.Dátum.ToShortDateString();
                o[5] = MeccsTipusok[item.Típus_id - 1].Név;
                o[6] = item.Meccs_id;

                string[] s = { o[0].ToString(), o[1].ToString(), o[2].ToString(), o[3].ToString(), o[4].ToString(), o[5].ToString(), o[6].ToString() };
                var LVsor = new ListViewItem(s);
                MeccsLV.Items.Add(LVsor);
                MeccsSzerkesztett msz = new MeccsSzerkesztett();
                msz.Hazai = o[0].ToString(); msz.Hazaig = int.Parse(o[1].ToString()); msz.Vendégg = int.Parse(o[2].ToString()); msz.Vendég = o[3].ToString();  msz.Dátum = Convert.ToDateTime(o[4].ToString()); msz.Típus = o[5].ToString(); msz.Meccs_id = int.Parse(o[6].ToString());
                MeccsKeres.Add(msz);
            }
            MeccsLV.Columns[6].Width = 0;
        }

        void MeccsKeresés(string keresés)
        {
            MeccsLV.Items.Clear();
            foreach (MeccsSzerkesztett s in MeccsKeres)
            {
                if (s.Hazai.ToLower().Contains(keresés.ToLower()) || s.Vendég.ToLower().Contains(keresés.ToLower()))
                {
                    string[] sor = { s.Hazai, s.Hazaig.ToString(), s.Vendégg.ToString(), s.Vendég, s.Dátum.ToShortDateString(), s.Típus, s.Meccs_id.ToString() };
                    var LVsor = new ListViewItem(sor);
                    MeccsLV.Items.Add(LVsor);
                }
            }
        }

        private void MeccsAddB_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
            MeccsekLVLoad();
        }

        private void MeccsDelB_Click(object sender, EventArgs e)
        {
            if (aktMeccs.SubItems.Count != 0)
            {
                if (MessageBox.Show("Biztos törölni akarja?", "Törlés", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int meccs_id = int.Parse(aktMeccs.SubItems[6].Text);
                    int h_csid = DB.CsapatID(aktMeccs.SubItems[0].Text);
                    int v_csid = DB.CsapatID(aktMeccs.SubItems[3].Text);
                    int h_csgol = int.Parse(aktMeccs.SubItems[1].Text);
                    int v_csgol = int.Parse(aktMeccs.SubItems[2].Text);
                    DateTime dátum = Convert.ToDateTime(aktMeccs.SubItems[4].Text);
                    int tipus = DB.MeccsTipusIDre(aktMeccs.SubItems[5].Text, MeccsTipusok);

                    DB.DeleteMeccs(meccs_id, h_csid, v_csid, h_csgol, v_csgol, tipus, dátum);
                    MeccsekLVLoad();
                }
            }
        }

        private void MeccsLV_Click(object sender, EventArgs e)
        {
            aktMeccs = MeccsLV.SelectedItems[0];
            MeccsDelB.Enabled = true;
        }

        void TabellaLoad(int aktbajnokság)
        {
            List<Tabella> Tabella = new List<Tabella>();
            List<Csapat> aktcsapatok = DB.Csapatok(aktbajnokság);
            for (int i = 0; i < aktcsapatok.Count; i++)
            {
                Tabella.Add(DB.TabellaFeltölt(aktcsapatok[i].Csapat_id));
            }

            for (int i = Tabella.Count - 1; i > 0; i--)
            {
                for (int k = 0; k < i; k++)
                {
                    if (Tabella[k].Pont < Tabella[k + 1].Pont)
                    {
                        Tabella segéd = Tabella[k];
                        Tabella[k] = Tabella[k + 1];
                        Tabella[k + 1] = segéd;
                    }
                    if (Tabella[k].Pont == Tabella[k + 1].Pont)
                    {
                        if ((Tabella[k].Lőttgól - Tabella[k].Kapottgól) < (Tabella[k + 1].Lőttgól - Tabella[k + 1].Kapottgól))
                        {
                            Tabella segéd = Tabella[k];
                            Tabella[k] = Tabella[k + 1];
                            Tabella[k + 1] = segéd;
                        }
                    }
                }
            }

            for (int i = 0; i < Tabella.Count; i++)
            {
                object[] o = new object[9];
                o[0] = i + 1;
                o[1] = Tabella[i].Név;
                o[2] = Tabella[i].Lejátszott;
                o[3] = Tabella[i].Győzelem;
                o[4] = Tabella[i].Döntetlen;
                o[5] = Tabella[i].Vereség;
                o[6] = Tabella[i].Lőttgól;
                o[7] = Tabella[i].Kapottgól;
                o[8] = Tabella[i].Pont;

                TabellaDGV.Rows.Add(o);
            }
            TabellaDGV.ClearSelection();
        }

        private void BajnokságCB2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BajnokságCB2.SelectedIndex != -1)
            {
                aktBajnokság = DB.BajnokságID(BajnokságCB2.SelectedItem.ToString());
                TabellaDGV.Rows.Clear();
                TabellaCsapatLV.Items.Clear();
            }
            else
                aktBajnokság = -1;

            TabellaLoad(aktBajnokság);
        }

        void TabellaCSLVLoad(int cs_id)
        {
            Meccsek = DB.MeccsListaCsapat(cs_id);
            MeccsTipusok = DB.MeccsTipusLista;
            TabellaCsapatLV.Items.Clear();
            foreach (var item in Meccsek)
            {
                object[] o = new object[7];
                o[0] = DB.CsapatNév(item.H_csid);
                o[1] = item.H_csgol;
                o[2] = item.V_csgol;
                o[3] = DB.CsapatNév(item.V_csid);
                o[4] = item.Dátum.ToShortDateString();
                o[5] = MeccsTipusok[item.Típus_id - 1].Név;
                o[6] = item.Meccs_id;

                string[] s = { o[0].ToString(), o[1].ToString(), o[2].ToString(), o[3].ToString(), o[4].ToString(), o[5].ToString(), o[6].ToString() };
                var LVsor = new ListViewItem(s);
                TabellaCsapatLV.Items.Add(LVsor);
            }
            MeccsLV.Columns[6].Width = 0;
        }

        private void TabellaDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string csapatnév = TabellaDGV[1, e.RowIndex].Value.ToString();
            int cs_id = DB.CsapatID(csapatnév);
            TabellaCSLVLoad(cs_id);
        }

        private void TabellaShowB_Click(object sender, EventArgs e)
        {
            if (BajnokságCB.SelectedIndex != -1)
            {
                TP4.Megjelenít(TabC);
                TabC.SelectTab("TP4");
                TabellaLoad(aktBajnokság);
                BajnokságCB2.Text = BajnokságCB.Text;
            }
            else
                MessageBox.Show("Jelöljön ki egy bajnokságot!");
        }

        void JátékosKDGVLoad()
        {
            JátékosKDGV.Rows.Clear();
            ÖsszesJátékos = DB.JátékosLista;
            List<Játékos> Rendezett = ÖsszesJátékos.OrderBy(q => q.Név).ToList();
            DT = new DataTable();
            DT.Columns.Add("Név", typeof(string));
            DT.Columns.Add("Csapat", typeof(string));
            DT.Columns.Add("Poszt", typeof(string));
            DT.Columns.Add("Mezszám", typeof(int));
            DT.Columns.Add("Kor", typeof(int));
            DT.Columns.Add("Nemzet", typeof(string));

            foreach (var item in Rendezett)
            {
                object[] o = new object[6];
                o[0] = item.Név;
                o[1] = DB.CsapatNév(item.Csapat_id);
                o[2] = DB.PosztÁtÍr(item.Poszt_id, Posztok);
                o[3] = item.Mez;
                o[4] = item.Kor;
                o[5] = item.Nemzet;
                DT.Rows.Add(o[0], o[1], o[2], o[3], o[4], o[5]);
            }
            JátékosKDGV.DataSource = DT;
            JátékosKDGV.Columns[0].Width = 200;
            JátékosKDGV.Columns[1].Width = 200;
            JátékosKDGV.Columns[2].Width = 100;
            JátékosKDGV.Columns[3].Width = 75;
            JátékosKDGV.Columns[4].Width = 50;
            JátékosKDGV.Columns[5].Width = 150;
        }

        #region keresések
        private void JátékosSearchTB_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(DT);
            DV.RowFilter = string.Format("Név Like '%{0}%'", JátékosSearchTB.Text);
            JátékosKDGV.DataSource = DV;
        }

        private void CsapatSearchTB_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(DT);
            DV.RowFilter = string.Format("Csapat Like '%{0}%'", CsapatSearchTB.Text);
            JátékosKDGV.DataSource = DV;
        }

        private void PosztSearchTB_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(DT);
            DV.RowFilter = string.Format("Poszt Like '%{0}%'", PosztSearchTB.Text);
            JátékosKDGV.DataSource = DV;
        }

        private void NemzetSearchTB_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(DT);
            DV.RowFilter = string.Format("Nemzet Like '%{0}%'", NemzetSearchTB.Text);
            JátékosKDGV.DataSource = DV;
        }

        private void KorSearchTB_TextChanged(object sender, EventArgs e)
        {
            if (KorSearchTB.Text.Length == 2)
            {
                DataView DV = new DataView(DT);
                DV.RowFilter = string.Format("Kor = '{0}'", KorSearchTB.Text.ToString());
                JátékosKDGV.DataSource = DV;
            }
            else if (KorSearchTB.Text.Length == 0)
            {
                DataView DV = new DataView(DT);
                JátékosKDGV.DataSource = DV;
            }
        }

        private void MezszámSearchTB_TextChanged(object sender, EventArgs e)
        {
            if (MezszámSearchTB.Text.Length == 2 || MezszámSearchTB.Text.Length == 1)
            {
                DataView DV = new DataView(DT);
                DV.RowFilter = string.Format("Mezszám = '{0}'", MezszámSearchTB.Text.ToString());
                JátékosKDGV.DataSource = DV;
            }
            else if (MezszámSearchTB.Text.Length == 0)
            {
                DataView DV = new DataView(DT);
                JátékosKDGV.DataSource = DV;
            }
        }

        private void CsapatKeresTB_TextChanged(object sender, EventArgs e)
        {
            MeccsKeresés(CsapatKeresTB.Text);
        }
        #endregion

        private void CsapatokPB_DoubleClick(object sender, EventArgs e)
        {
            if (TP2.Látható() == false)
            {
                TP2.Megjelenít(TabC);
                TabC.SelectTab("TP2");
                BajnokságCBLoad(BajnokságCB);
            }
            else
                MessageBox.Show("Már meg van nyitva!");
        }

        private void TabellaPB_DoubleClick(object sender, EventArgs e)
        {
            if(TP4.Látható() == false)
            {
                TP4.Megjelenít(TabC);
                TabC.SelectTab("TP4");
                BajnokságCBLoad(BajnokságCB2);
            }
            else
                MessageBox.Show("Már meg van nyitva!");
        }

        private void MeccsekPB_DoubleClick(object sender, EventArgs e)
        {
            if (TP3.Látható() == false)
            {
                TP3.Megjelenít(TabC);
                TabC.SelectTab("TP3");
                MeccsekLVLoad();
            }
            else
                MessageBox.Show("Már meg van nyitva!");
        }

        private void KeresőPB_DoubleClick(object sender, EventArgs e)
        {
            if (TP5.Látható() == false)
            {
                TP5.Megjelenít(TabC);
                TabC.SelectTab("TP5");
                JátékosKDGVLoad();
            }
            else
                MessageBox.Show("Már meg van nyitva!");
        }

        private void CsapatokTabClose_Click(object sender, EventArgs e)
        {
            TP2.Elrejt();
            TabC.SelectTab("TP1");
        }

        private void MeccsekTabJump_Click(object sender, EventArgs e)
        {
            if (TP3.Látható() == false)
            {
                TP3.Megjelenít(TabC);
                TabC.SelectTab("TP3");
                MeccsekLVLoad();
            }
            else
                TabC.SelectTab("TP3");
        }

        private void JátékosKTabJump_Click(object sender, EventArgs e)
        {
            if (TP5.Látható() == false)
            {
                TP5.Megjelenít(TabC);
                TabC.SelectTab("TP5");
                JátékosKDGVLoad();
            }
            else
                TabC.SelectTab("TP5");
        }

        private void MeccsekClose_Click(object sender, EventArgs e)
        {
            TP3.Elrejt();
            TabC.SelectTab("TP1");
        }

        private void TabellaJump_Click(object sender, EventArgs e)
        {
            if (TP4.Látható() == false)
            {
                TP4.Megjelenít(TabC);
                TabC.SelectTab("TP4");
                BajnokságCBLoad(BajnokságCB2);
            }
            else
                TabC.SelectTab("TP4");
        }

        private void JátékosKeresőJump_Click(object sender, EventArgs e)
        {
            if (TP5.Látható() == false)
            {
                TP5.Megjelenít(TabC);
                TabC.SelectTab("TP5");
                JátékosKDGVLoad();
            }
            else
                TabC.SelectTab("TP5");
        }

        private void CsapatJump_Click(object sender, EventArgs e)
        {
            if (TP2.Látható() == false)
            {
                TP2.Megjelenít(TabC);
                TabC.SelectTab("TP2");
                BajnokságCBLoad(BajnokságCB);
            }
            else
                TabC.SelectTab("TP2");
        }

        private void TabellaClose_Click(object sender, EventArgs e)
        {
            TP4.Elrejt();
            TabC.SelectTab("TP1");
        }

        private void CsapatJump2_Click(object sender, EventArgs e)
        {
            if (TP2.Látható() == false)
            {
                TP2.Megjelenít(TabC);
                TabC.SelectTab("TP2");
                BajnokságCBLoad(BajnokságCB);
            }
            else
                TabC.SelectTab("TP2");
        }

        private void JátékoskeresőJump2_Click(object sender, EventArgs e)
        {
            if (TP5.Látható() == false)
            {
                TP5.Megjelenít(TabC);
                TabC.SelectTab("TP5");
                JátékosKDGVLoad();
            }
            else
                TabC.SelectTab("TP5");
        }

        private void MeccsekJump2_Click(object sender, EventArgs e)
        {
            if (TP3.Látható() == false)
            {
                TP3.Megjelenít(TabC);
                TabC.SelectTab("TP3");
                MeccsekLVLoad();
            }
            else
                TabC.SelectTab("TP3");
        }

        private void JátékoskeresőClose_Click(object sender, EventArgs e)
        {
            TP5.Elrejt();
            TabC.SelectTab("TP1");
        }

        private void CsapatJump3_Click(object sender, EventArgs e)
        {
            if (TP2.Látható() == false)
            {
                TP2.Megjelenít(TabC);
                TabC.SelectTab("TP2");
                BajnokságCBLoad(BajnokságCB);
            }
            else
                TabC.SelectTab("TP2");
        }

        private void MeccsekJump3_Click(object sender, EventArgs e)
        {
            if (TP3.Látható() == false)
            {
                TP3.Megjelenít(TabC);
                TabC.SelectTab("TP3");
                MeccsekLVLoad();
            }
            else
                TabC.SelectTab("TP3");
        }

        private void TabellaJump3_Click(object sender, EventArgs e)
        {
            if (TP4.Látható() == false)
            {
                TP4.Megjelenít(TabC);
                TabC.SelectTab("TP4");
                BajnokságCBLoad(BajnokságCB2);
            }
            else
                TabC.SelectTab("TP4");
        }
    }

}

