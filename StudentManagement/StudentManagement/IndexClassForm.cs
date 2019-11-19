using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class IndexClassForm : Form
    {
        private ClassManagement Business;
        public IndexClassForm()
        {
            InitializeComponent();
            this.Business = new ClassManagement();
            this.Load += IndexClassForm_Load;
            this.btnCreate.Click += btnCreate_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.grdClasses.DoubleClick += grdClasses_DoubleClick;
        }

        void grdClasses_DoubleClick(object sender, EventArgs e)
        {
            var @class = (Class)this.grdClasses.SelectedRows[0].DataBoundItem;
            var updateForm = new UpdateClassForm(@class.id);
            updateForm.ShowDialog();
            this.LoadAllClasses();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.grdClasses.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Do you want to delete it", "Confirm", 
                    MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    var @class = (Class)this.grdClasses.SelectedRows[0].DataBoundItem;
                    this.Business.DeleteClass(@class.id);
                    MessageBox.Show("delete successfully");
                    this.Close();
                }
            }
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            var createForm = new CreateClassForm();
            createForm.ShowDialog();
            this.LoadAllClasses();
        }

        void IndexClassForm_Load(object sender, EventArgs e)
        {
            this.LoadAllClasses();
        }
        private void LoadAllClasses()
        {
            var classes = this.Business.GetClasses();
            this.grdClasses.DataSource = classes;
        }
    }
}
