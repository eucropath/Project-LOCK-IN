using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT13VotingAppFinal
{
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
        }
        private void LoadResults()
        {
            var dt = DataAccess.ExecuteProcedureToDataTable("sp_GetResults");
            dgvResults.DataSource = dt;
        }
        private void ResultsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
