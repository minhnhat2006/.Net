using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using DevExpress.XtraBars;
using MySql.Data.MySqlClient;

namespace QLThuChi
{
    public partial class FrmHome
    {
        public const string SettingSoDuBanDau = "sodubandau";

        #region Setting

        private QLThuChi.Dao.ThuChi.settingRow[] rowSoDubanDau;


        private void LoadSetting()
        {
            rowSoDubanDau = (QLThuChi.Dao.ThuChi.settingRow[])this.thuChi.setting.Select("name='" + SettingSoDuBanDau + "'");

            if (rowSoDubanDau != null && rowSoDubanDau.Length > 0)
            {
                this.txtSettingSoDu.EditValue = Decimal.Parse(rowSoDubanDau[0].Value);
            }
        }

        private void LuuSetting(object sender, ItemClickEventArgs e)
        {
            if (this.isSettingTab())
            {
                if (this.ValidateSettingFields())
                {
                    if (rowSoDubanDau != null && rowSoDubanDau.Length > 0)
                    {
                        rowSoDubanDau[0].Value = this.txtSettingSoDu.EditValue.ToString();
                    }
                    else
                    {
                        this.thuChi.setting.AddsettingRow(SettingSoDuBanDau, this.txtSettingSoDu.EditValue.ToString());
                        rowSoDubanDau = (QLThuChi.Dao.ThuChi.settingRow[])this.thuChi.setting.Select("name='" + SettingSoDuBanDau + "'");
                    }

                    this.userBindingSource.EndEdit();
                    this.thuChi.setting.GetChanges();
                    this.settingTableAdapter.Update(this.thuChi.setting);
                    this.thuChi.setting.AcceptChanges();
                }
            }
        }

        private bool ValidateSettingFields()
        {
            bool isSoDuBanDau = Validate_EmptyStringRule(txtSettingSoDu);
            return isSoDuBanDau;
        }

        #endregion
    }
}
