using Microsoft.Win32;
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
	public partial class frmBrowsers : Form
	{
		public frmBrowsers()
		{
			InitializeComponent();
		}

		public Browser[] GetBrowsers()
		{
			List<Browser> result = new List<Browser>();

			RegistryKey browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Clients\StartMenuInternet");
			if(browserKeys == null)
				browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");

			string[] browserNames = browserKeys.GetSubKeyNames();
			for(int i = 0; i < browserNames.Length; i++)
			{
				try
				{
					Browser browser = new Browser();

					//Hoofdkey van de browser ophalen -> Default-waarde uitlezen
					RegistryKey browserKey = browserKeys.OpenSubKey(browserNames[i]);
					browser.Name = (string)browserKey.GetValue(null);

					//Executable Path uitlezen
					RegistryKey browserKeyPath = browserKey.OpenSubKey(@"shell\open\command");
					browser.Path = (string)browserKeyPath.GetValue(null);

					//Icoon pad uitlezen
					RegistryKey browserIconPath = browserKey.OpenSubKey(@"DefaultIcon");
					browser.IconPath = (string)browserIconPath.GetValue(null);

					//Nieuw "Browser"-object toevoegen aan lijst
					result.Add(browser);
				}
				catch(Exception)
				{ }
			}
			return result.ToArray();
		}

		private void frmBrowsers_Load(object sender, EventArgs e)
		{
			listView1.Items.Clear();
			ImageList lijst = new ImageList() { ImageSize = new Size(60, 60), ColorDepth = ColorDepth.Depth32Bit };
			Browser[] browsers = GetBrowsers();
			int i = 0;
			foreach(Browser b in browsers)
			{
				ListViewItem lvi = new ListViewItem();
				lvi.Text = b.Name;
				lvi.Tag = b.Path.Trim('\"');
				string[] parts = b.IconPath.Split(',');
				Icon ic = GetIconFromFile(parts[0], 0);
				lijst.Images.Add(ic);
				lvi.ImageIndex = i++;
				listView1.Items.Add(lvi);
			}
			listView1.LargeImageList = lijst;
		}

		public Icon GetIconFromFile(string file, int index)
		{
			IconExtractor extr = new IconExtractor(file);
			Icon icon = extr.GetIcon(index);
			Icon[] splitIcons = IconUtil.Split(icon);
			Icon biggest = splitIcons.Where(T => T.Width == splitIcons.Max(U => U.Width)).First();
			return biggest;
		}

		public string GetSelectedBrowserExecutablePath()
		{
			return listView1.SelectedItems[0].Tag.ToString();
		}
		public string GetSelectedBrowserName()
		{
			return listView1.SelectedItems[0].Text;
		}
	}
}
