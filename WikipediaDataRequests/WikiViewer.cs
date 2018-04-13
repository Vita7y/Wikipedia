using System;
using System.Windows.Forms;
using WikipediaDataRequests.Core.Wiki;

namespace WikipediaDataRequests
{
    public partial class WikiViewer : Form
    {
        private readonly WikiSearchController _wikiSearchController;

        public delegate void UpdateGrid();

        public WikiViewer()
        {
            InitializeComponent();
            _wikiSearchController = new WikiSearchController(new Wikipedia());
            _wikiSearchController.NeedToUpdate += _wikiSearchController_NeedToUpdate;
            dataGridView.DataSource = _wikiSearchController.CompareInfo;
        }

        private void Updater()
        {
            button1.Enabled = true;
            dataGridView.DataSource = null;
            dataGridView.DataSource = _wikiSearchController.CompareInfo;
        }

        private void _wikiSearchController_NeedToUpdate(object sender, EventArgs e)
        {
            Invoke(new UpdateGrid(Updater));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            _wikiSearchController.GetAllImagesNamesOnPointAsync(xPos.Value, yPos.Value, (int)limit.Value);
        }
    }
}
