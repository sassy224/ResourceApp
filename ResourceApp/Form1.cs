using ResourceApp.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceApp
{
    public partial class Form1 : Form
    {
        private CultureInfo cIFrCA = null;
        private CultureInfo cIFrFr = null;
        private CultureInfo cIDefault = null;

        public Form1()
        {
            InitializeComponent();

            cIFrCA = new CultureInfo("fr-CA");
            cIFrFr = new CultureInfo("fr-FR");
            cIDefault = new CultureInfo("en-US");

            BindResources();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (Thread.CurrentThread.CurrentUICulture == cIFrCA)
            {
                Thread.CurrentThread.CurrentUICulture = cIFrFr;
                Thread.CurrentThread.CurrentCulture = cIFrFr;
            }
            else if (Thread.CurrentThread.CurrentUICulture == cIFrFr)
            {
                Thread.CurrentThread.CurrentUICulture = cIDefault;
                Thread.CurrentThread.CurrentCulture = cIDefault;
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = cIFrCA;
                Thread.CurrentThread.CurrentCulture = cIFrCA;
            }

            //this.Controls.Clear();
            //this.InitializeComponent();
            BindResources();
        }

        private void BindResources()
        {
            lstResources.Items.Clear();
            //ResourceManager rm = new ResourceManager("Resources", Assembly.GetExecutingAssembly());
            ResourceSet resourceSet = Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                string resourceKey = (string)entry.Key;
                //object resource = entry.Value;
                lstResources.Items.Add(new ListViewItem(new string[] { resourceKey, entry.Value.ToString() }));
            }

            //resourceSet.GetString("String1");
            txtString.Text = Resources.ResourceManager.GetString("String1");
            txtIcon.Text = Resources.Icon1.ToString();
            txtAudio.Text = Resources.Audio1.ToString();
            txtFile.Text = Resources.File1.ToString();
            picBox.Image = Resources.Image1;

            this.Icon = Resources.Icon1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindResources();
        }
    }
}