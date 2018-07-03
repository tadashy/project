using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPDATE_USER_MASETR
{
    public partial class UserMasterForm : Form
    {
        public UserMasterForm()
        {
            InitializeComponent();
        }
        public UserMasterForm(
            string userId,
            string userNm,
            string password,
            DateTime insertDate,
            string insertUserId,
            DateTime updateDate,
            string updateUserId,
            bool updateFlg
            )
        {
            InitializeComponent();
            this.textUserId.Text = userId;
            this.textUserName.Text = userNm;
            this.textPassword.Text = password;

            //変更の時はユーザIDテキストは非表示でラベルを表示する。
            this.textUserId.Visible = !updateFlg;
            this.label4.Visible = updateFlg;
            this.label4.Text = this.textUserId.Text;

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //選択したボタンを判定する
            if (MessageBox.Show("登録して宜しいですか？", "登録確認", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //親画面に戻る
                this.DialogResult = DialogResult.OK;

            }
            else
            {                
                //キャンセルの場合 なにもしない
                
            }
        }
    }
}
