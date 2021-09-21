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
	public partial class Form3 : Form
	{
		Adatbázis DB;
		List<Csapat> Csapatok;
		List<Meccstipus> Tipusok;

		public Form3()
		{		
			InitializeComponent();
			DB = new Adatbázis();
			CsapatCBsLoad();
			TipusCBLoad();
		}

		void CsapatCBsLoad()
		{
			HazaiCSCB.Items.Clear();
			VendégCSCB.Items.Clear();
			Csapatok = DB.CsapatLista;
			foreach (var item in Csapatok)
			{
				HazaiCSCB.Items.Add(item.Név);
				VendégCSCB.Items.Add(item.Név);
			}
		}

		void TipusCBLoad()
		{
			TipusCB.Items.Clear();
			Tipusok = DB.MeccsTipusLista;
			foreach (var item in Tipusok)
			{
				TipusCB.Items.Add(item.Név);
			}
		}

		private void MeccsAddB_Click(object sender, EventArgs e)
		{
			if (HazaiCSCB.SelectedIndex != -1 && VendégCSCB.SelectedIndex != -1 && TipusCB.SelectedIndex != -1)
			{
				int h_csid = -1;
				int v_csid = -1;
				for (int i = 0; i < Csapatok.Count && h_csid == -1; i++)
				{
					if (HazaiCSCB.SelectedItem.ToString() == Csapatok[i].Név)
						h_csid = Csapatok[i].Csapat_id;
				}

				for (int i = 0; i < Csapatok.Count && v_csid == -1; i++)
				{
					if (VendégCSCB.SelectedItem.ToString() == Csapatok[i].Név)
						v_csid = Csapatok[i].Csapat_id;
				}

				DB.InsertMeccs(DB.NextMeccsID(), h_csid, v_csid, int.Parse(HazaiG.Value.ToString()), int.Parse(VendégG.Value.ToString()), DB.MeccsTipusIDre(TipusCB.SelectedItem.ToString(), Tipusok), dateTimePicker1.Value.Date);
				this.Close();
			}
			else
				MessageBox.Show("Valami nem jó!");
		}
	}
}
