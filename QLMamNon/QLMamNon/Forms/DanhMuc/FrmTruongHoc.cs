using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLMamNon.Forms.Resource;
using MySql.Data.MySqlClient;
using QLMamNon.UserControls;
using QLMamNon.Facade;
using DevExpress.XtraGrid;

namespace QLMamNon.Forms.DanhMuc
{
    public partial class FrmTruongHoc : CRUDForm
    {
        public FrmTruongHoc()
        {
            InitializeComponent();

            this.TablePrimaryKey = "TruongId";
            this.FormKey = AppForms.FormDanhMucTruongHoc;
            this.InitForm(this.btnThem, this.btnChinhSua, this.btnXoa, this.btnLuu, this.btnHuyBo, this.gvMain, this.truongTableAdapter.Adapter);
        }

        private void FrmTruongHoc_Load(object sender, EventArgs e)
        {
            this.truongRowBindingSource.DataSource = this.truongTableAdapter.GetData();
            this.gvMain.OptionsEditForm.CustomEditFormLayout = new UCEditFormTruongHoc();
        }

        #region CRUD


        protected override void onSaving()
        {
            QLMamNon.Dao.QLMamNonDs.TruongDataTable truongTable = this.truongRowBindingSource.DataSource as QLMamNon.Dao.QLMamNonDs.TruongDataTable;
            DataTable table = truongTable.GetChanges();
            if (table != null)
            {
                this.DataAdapter.Update(table as QLMamNon.Dao.QLMamNonDs.HocSinhDataTable);
                truongTable.Merge(table);
            }
            truongTable.AcceptChanges();

            FormMainFacade.SetTrangThaiCaption(StatusCaptions.SavedCaption);
        }

        protected override void onDeleting()
        {
            if (this.GridViewMain.FocusedRowHandle < 0)
            {
                return;
            }

            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa Thông tin Học sinh được chọn không?", "Xóa Học sinh",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                this.GridViewMain.DeleteSelectedRows();
                FormMainFacade.SetTrangThaiCaption(StatusCaptions.DeletedCaption);
            }
        }

        protected override void onCanceling()
        {
            this.qLMamNonDs.HocSinh.RejectChanges();
            this.qLMamNonDs.HocSinh.AcceptChanges();

            FormMainFacade.SetTrangThaiCaption(StatusCaptions.CanceledCaption);
        }

        #endregion
    }
}