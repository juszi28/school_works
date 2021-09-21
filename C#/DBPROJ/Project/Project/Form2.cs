using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form2 : Form
    {
        Adatbázis DB;
        List<Poszt> Posztok;
        int cs_id;

        public Form2(int csapat_id)
        {
            InitializeComponent();
            DB = new Adatbázis();
            Poszt_CBLoad();
            cs_id = csapat_id;
        }

        void Poszt_CBLoad()
        {
            Posztok = DB.PosztLista;
            Poszt_CB.Items.AddRange(Posztok.ToArray());
        }

        private void Add_B_Click(object sender, EventArgs e)
        {
            if (NévTB.TextLength > 0 && Poszt_CB.SelectedIndex != -1 && Kor_TB.TextLength == 2 && Nemzet_TB.TextLength > 0)
            {
                DB.InsertJátékos(DB.NextJátékosID(), cs_id, DB.PosztVisszaÍr(Poszt_CB.SelectedItem.ToString(), Posztok), NévTB.Text, DB.MezAdás(cs_id), int.Parse(Kor_TB.Text), Nemzet_TB.Text);
                this.Close();
            }
            else
                MessageBox.Show("Valami nem jó");
        }
    }
}
