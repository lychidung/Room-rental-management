using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_Phòng_Trọ.Models;

namespace Project_Phòng_Trọ
{
    public partial class fContract : Form
    {
        Contract contract;
        EFDbContext db = new EFDbContext();
        public fContract()
        {
            InitializeComponent();
        }

        private void clearText()
        {
            checkStatus.Checked = true;
            lblTotalAmount.Text = null;
            dtStartDate.Text = DateTime.UtcNow.ToString();
            dtEndDate.Text = DateTime.UtcNow.ToString();
        }

        internal void UpdateLabel(Contract d)
        {
            dtStartDate.Text = d.CreateDate.ToShortDateString();
            dtEndDate.Text = d.EndDate.ToShortDateString();
            checkStatus.Checked = d.Status;
            lblTotalAmount.Text = d.TotalAmount.ToString("0,0") + "đ";
            cbRoom.SelectedValue = d.RoomID;
            cbStaff.SelectedValue = d.StaffID;
        }

        private void LoadCbContract()
        {
            cbRoom.DisplayMember = "RoomName";
            cbRoom.ValueMember = "RoomID";
            cbRoom.DataSource = db.Rooms.Where(c => c.Status == true).Select(c => new { c.RoomID, c.RoomName }).ToList();

            cbStaff.DisplayMember = "StaffName";
            cbStaff.ValueMember = "StaffID";
            cbStaff.DataSource = db.Staffs.Select(c => new { c.StaffID, c.StaffName }).ToList();

            cbRoom.Text = null;
            cbStaff.Text = null;
        }

        private void LoadContract()
        {
            DataGridView1.DataSource = db.Contracts.Select(c => new
            {
                c.ContractID,
                c.RoomID,
                c.StaffID,
                c.CreateDate,
                c.EndDate,
                c.TotalAmount,
                c.Status
            }).ToList();
            DataGridView1.ClearSelection();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fContract_Load(object sender, EventArgs e)
        {
            LoadContract();
            LoadCbContract();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                DataGridView1.ClearSelection();
                btnDeleteContract.Enabled = false;
                clearText();
                LoadCbContract();
                return;
            }
            btnDeleteContract.Enabled = true;
            DataGridView1.CurrentRow.Selected = true;
            long ContractID = Convert.ToInt32(DataGridView1.Rows[e.RowIndex].Cells["ContractID"].Value);
            List<Contract> result = db.Contracts.Where(s => s.ContractID == ContractID).ToList();
            foreach (Contract d in result)
            {
                UpdateLabel(d);
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (DataGridView1.Focused)
            {
                int index = DataGridView1.CurrentRow.Index;
                long ContractID = Convert.ToInt64(DataGridView1.Rows[index].Cells["ContractID"].Value);
                List<Contract> result = db.Contracts.Where(s => s.ContractID == ContractID).ToList();
                foreach (Contract d in result)
                {
                    UpdateLabel(d);
                }
            }
        }

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            if (btnDeleteContract.Enabled == true)
            {
                btnDeleteContract.Enabled = false;
                DataGridView1.ClearSelection();
                clearText();
                LoadCbContract();
            }
            else
            {
                if (Convert.ToDateTime(dtStartDate.Value.ToShortDateString()) > Convert.ToDateTime(dtEndDate.Value.ToShortDateString()))
                {
                    toolTip1.Show("Ngày kết thúc hợp đồng không hợp lệ?");
                    dtEndDate.Focus();
                    return;
                }
                if (dtEndDate.Value.Date.Subtract(dtStartDate.Value.Date).TotalDays < 180)
                {
                    toolTip1.Show("Tống tháng thuê phòng phải >= 6?");
                    dtEndDate.Focus();
                    return;
                }
                if (cbRoom.SelectedIndex == -1)
                {
                    toolTip1.Show("Hãy thêm phòng?");
                    cbRoom.Focus();
                    return;
                }
                if (cbStaff.SelectedIndex == -1)
                {
                    toolTip1.Show("Hãy thêm nhân viên?");
                    cbStaff.Focus();
                    return;
                }
                try
                {
                    contract = new Contract();
                    contract.CreateDate = DateTime.UtcNow.Date;
                    contract.EndDate = dtEndDate.Value.Date;
                    contract.StaffID = Convert.ToInt64(cbStaff.SelectedValue);
                    contract.RoomID = Convert.ToInt64(cbRoom.SelectedValue);
                    contract.TotalAmount = Convert.ToDecimal(lblTotalAmount.Text);
                    contract.Status = checkStatus.Checked;
                    db.Contracts.Add(contract);
                    db.SaveChanges();
                    toolTip1.Show("Thêm thành công.");
                    clearText();
                    LoadContract();
                    LoadCbContract();
                }
                catch (Exception ex)
                {
                    toolTip1.Show("Thêm thất bại? Error: " + ex.Message);
                }
            }
        }

        private void cbRoom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            long RoomID = Convert.ToInt64(cbRoom.SelectedValue);
            var room = db.Rooms.Single(o => o.RoomID == RoomID);
            lblTotalAmount.Text = room.RoomPrice.ToString();
        }

        private void btnDeleteContract_Click(object sender, EventArgs e)
        {
            Contract contract;
            try
            {
                int index = DataGridView1.CurrentRow.Index;
                long ContractID = Convert.ToInt64(DataGridView1.Rows[index].Cells["ContractID"].Value);
                contract = db.Contracts.Single(s => s.ContractID == ContractID);
                if (toolTip2.Show("Bạn muốn xóa hợp đồng #" + contract.ContractID + " ra khỏi danh sách", "Xóa") == DialogResult.Yes)
                {
                    db.Contracts.Remove(contract);
                    db.SaveChanges();
                    btnDeleteContract.Enabled = false;
                    clearText();
                    LoadContract();
                    LoadCbContract();
                }
            }
            catch (Exception ex)
            {
                toolTip1.Show("Lỗi, chưa xóa được? Error: " + ex.Message);
            }
        }
    }
}
