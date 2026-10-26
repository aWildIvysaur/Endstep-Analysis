using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Endstep_Analysis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// The open file button is clicked     
        /// </summary>
        private void fileButton_Click(object sender, EventArgs e)
        {
            // Open a file dialog to select a JSON file
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "JSON |*.json| All |*.*";
            fileDialog.ShowDialog();

            // read the JSON file and deserialize it into a dynamic object
            dynamic items;
            using (StreamReader r = new StreamReader(fileDialog.FileName))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject(json);
            }

            List<Match> matches = new List<Match>();
            foreach (dynamic m in items.matches)
            {
                matches.Add(new Match(m));
            }
            Console.WriteLine("done");
            foreach (dynamic m in matches)
            {
                Console.WriteLine(m.MyDeckName + " - " + Deck.decks[m.MyDeckName].DeckAvailable);
            }
        }
    }
}
