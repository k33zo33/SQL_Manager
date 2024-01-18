using SQLManager.Dal;
using SQLManager.Models;
using System.Data;

namespace SQLManager.View
{
    public partial class MainForm : Form
    {
        private List<Database>? databases;
        private enum TagType
        {
            Databases, Tables, Views, Procedures
        }
        public MainForm()
        {
            InitializeComponent();
            LoadDatabases();
            InitTree();
            ClearForm();
        }

        private void LoadDatabases()
        {
            databases = new List<Database>(RepositoryFactory.Repository.GetDatabases());
        }

        private void InitTree()
        {
            var dbNode = new TreeNode(
                TagType.Databases.ToString(),
                new[] { new TreeNode() }
                )
            { Tag = TagType.Databases };
            tvServer.Nodes.Add(dbNode);
        }

        private void ClearForm()
        {
            tbContent.Text = string.Empty;
            tsbSave.Enabled = false;
            tsbSelect.Enabled = false;
            dBEntity = null;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
            => Application.Exit();

        private void TsbSelect_Click(object sender, EventArgs e)
        {
            if (dBEntity == null)
            {
                return;
            }
            DataSet ds = RepositoryFactory.Repository.CreateDataset(dBEntity);
            new SearchResultsForm(ds.Tables[0]).ShowDialog();
        }
        private const string FileFilter = "XML files(*.xml)|*.xml|All files(*.*)|*.*";
        private const string FileName = "{0}.xml";

        private void TsbSave_Click(object sender, EventArgs e)
        {
            if (dBEntity == null)
            {
                return;
            }
            var dialog = new SaveFileDialog
            {
                FileName = string.Format(FileName, dBEntity.Name),
                Filter = FileFilter
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DataSet ds = RepositoryFactory.Repository.CreateDataset(dBEntity);
                ds.WriteXml(dialog.FileName, XmlWriteMode.WriteSchema);
            }

        }
        private Database? database;
        private void TvServer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e is null || databases == null)
            {
                return;
            }
            ClearForm();
            tvServer.BeginUpdate();
            switch (e.Node)
            {
                case { Tag: TagType.Databases }:
                    e.Node.Nodes.Clear();
                    databases
                        .ForEach(db => e.Node.Nodes.Add(
                             new TreeNode(
                                  db.ToString(),
                                  new[] { new TreeNode() }
                                  )
                             { Tag = db }
                             ));

                    break;
                case { Tag: TagType.Tables }:
                    e.Node.Nodes.Clear();
                    database = e.Node.Parent.Tag as Database;
                    database?
                        .Tables
                        .ToList()
                        .ForEach(t => e.Node.Nodes.Add(
                             new TreeNode(
                                  t.ToString(),
                                  new[] { new TreeNode() }
                                  )
                             { Tag = t }
                             ));

                    break;
                case { Tag: TagType.Views }:
                    e.Node.Nodes.Clear();
                    database = e.Node.Parent.Tag as Database;
                    database?
                        .Views
                        .ToList()
                        .ForEach(t => e.Node.Nodes.Add(
                             new TreeNode(
                                  t.ToString(),
                                  new[] { new TreeNode() }
                                  )
                             { Tag = t }
                             ));

                    break;
                case { Tag: TagType.Procedures }:
                    e.Node.Nodes.Clear();
                    database = e.Node.Parent.Tag as Database;
                    database?
                        .Procedures
                        .ToList()
                        .ForEach(t => e.Node.Nodes.Add(
                             new TreeNode(
                                  t.ToString(),
                                  new[] { new TreeNode() }
                                  )
                             { Tag = t }
                             ));
                    break;
                case { Tag: Database db }:
                    e.Node.Nodes.Clear();
                    database = db;
                    e.Node.Nodes.Add(new TreeNode(
                        TagType.Tables.ToString(),
                        new[] { new TreeNode() }
                        )
                    { Tag = TagType.Tables });
                    e.Node.Nodes.Add(new TreeNode(
                        TagType.Views.ToString(),
                        new[] { new TreeNode() }
                        )
                    { Tag = TagType.Views });
                    e.Node.Nodes.Add(new TreeNode(
                        TagType.Procedures.ToString(),
                        new[] { new TreeNode() }
                        )
                    { Tag = TagType.Procedures });
                    break;
                case { Tag: DBEntity entity }:
                    dBEntity = entity;
                    e.Node.Nodes.Clear();
                    entity
                        .Columns
                        .ToList()
                        .ForEach(t => e.Node.Nodes.Add(new TreeNode(t.ToString())));

                    tsbSave.Enabled = true;
                    tsbSelect.Enabled = true;
                    break;
                case { Tag: Procedure procedure }:
                    e.Node.Nodes.Clear();

                    procedure
                        .Parameters
                        .ToList()
                        .ForEach(t => e.Node.Nodes.Add(new TreeNode(t.ToString())));
                    tbContent.Text = procedure.Definition;
                    break;
            }
            tvServer.EndUpdate();
        }
        private DBEntity? dBEntity;

        private void TvServer_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            ClearForm();
        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            var result = RepositoryFactory.Repository.ExecuteSqlScript(tbContent.Text);
            if (result.Success)
            {
                tbSuccess.Text = result.Message;
                tbFailure.Clear();
            }
            else
            {
                tbFailure.Text = result.Message;
                tbSuccess.Clear();
            }
        }
    }
}