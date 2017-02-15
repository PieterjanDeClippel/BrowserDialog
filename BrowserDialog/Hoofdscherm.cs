using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowserDialog
{
	public partial class Hoofdscherm : Form
	{
		public Hoofdscherm()
		{
			InitializeComponent();
		}

private void btnKiesBrowser_Click(object sender, EventArgs e)
{
	frmBrowsers dialoog = new frmBrowsers();
	if(dialoog.ShowDialog() == DialogResult.OK)
	{
		MessageBox.Show(string.Format("U koos voor {0}.\r\nDe executable path is {1}.", dialoog.GetSelectedBrowserName(), dialoog.GetSelectedBrowserExecutablePath()));
	}
}
	}
}
