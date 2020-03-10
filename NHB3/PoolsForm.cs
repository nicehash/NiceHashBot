using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace NHB3
{
    public partial class PoolsForm : Form
    {
        ApiConnect ac;
        JArray pools;

        public PoolsForm(ApiConnect ac)
        {
            InitializeComponent();
            this.Show();
            this.ac = ac;

            loadPools(true);
        }

        private void loadPools(bool force) {
            if (ac.connected) {
                pools = ac.getPools(force);
                dataGridView1.DataSource = pools;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dataGridView1.AllowUserToOrderColumns = true;
                dataGridView1.AllowUserToResizeColumns = true;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            PoolForm pf = new PoolForm(ac, 1, null);
            pf.FormBorderStyle = FormBorderStyle.FixedSingle;
            pf.FormClosed += new FormClosedEventHandler(f_FormClosed);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected) == 1) {
                PoolForm pf = new PoolForm(ac, 2, pools[dataGridView1.SelectedRows[0].Index]);
                pf.FormBorderStyle = FormBorderStyle.FixedSingle;
                pf.FormClosed += new FormClosedEventHandler(f_FormClosed);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected) == 1) {
                PoolForm pf = new PoolForm(ac, 3, pools[dataGridView1.SelectedRows[0].Index]);
                pf.FormBorderStyle = FormBorderStyle.FixedSingle;
                pf.FormClosed += new FormClosedEventHandler(f_FormClosed);
            }
        }

        private void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadPools(true); //refresh
        }
    }
}
