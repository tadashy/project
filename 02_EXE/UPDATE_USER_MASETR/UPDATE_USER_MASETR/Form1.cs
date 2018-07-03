using System;
using System.Windows.Forms;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace UPDATE_USER_MASETR
{
    public partial class Form1 : Form
    {
        public bool updateFlg = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: このコード行はデータを 'userMasterDataSet11.USER_MASTER' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.uSER_MASTERTableAdapter.Fill(this.userMasterDataSet11.USER_MASTER);

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //登録画面表示
            AddData();
        }

        private void AddData()
        {
            //登録画面の生成
            UserMasterForm frmUser = new UserMasterForm();

            //登録画面のモーダル表示
            DialogResult drRet = frmUser.ShowDialog();

            if (drRet == DialogResult.OK)
            {
                String userId = frmUser.textUserId.Text;
                String userName = frmUser.textUserName.Text;
                String password = frmUser.textPassword.Text;

                // DB接続
                using (OracleConnection conn = new OracleConnection("user id = tadashy; password = tadashy; data source = tadashy"))
                {

                    // Oracleへのコネクションの確立
                    conn.Open();

                    // ============================================================
                    // 何か処理する（select/update/delete etc...）
                    // ============================================================
                    // トランザクションの開始
                    OracleTransaction txn = conn.BeginTransaction();

                    string sql = "INSERT INTO USER_MASTER(USER_ID, USER_NAME, PASSWORD, INSERT_DATE, INSERT_USER, UPDATE_DATE, UPDATE_USER) VALUES('" + userId + "','" + userName + "', '" + password + "', sysdate, 'test', sysdate, 'test')";
                    OracleCommand myCmd = new OracleCommand(sql, conn);

                    // SQL の実行（リターン値は操作したレコード数）
                    myCmd.ExecuteNonQuery();

                    txn.Commit(); //コミット またはロールバック txn.Rollback()

                    // 接続を閉じる
                    conn.Close();

                    // DataSetの内容をDataGridViewに反映
                    this.uSER_MASTERTableAdapter.Fill(this.userMasterDataSet11.USER_MASTER);

                }

            }

        }

        private void 追加AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //登録画面表示
            AddData();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            //画面を閉じる
            this.Close();
        }

        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //画面を閉じる
            this.Close();
        }

        private void UpdateData()
        {
            int nowRow = dgv.CurrentRow.Index;
            string oldUserId = dgv.Rows[nowRow].Cells[0].Value.ToString();
            string oldUserNm = dgv.Rows[nowRow].Cells[1].Value.ToString();
            string oldPassword = dgv.Rows[nowRow].Cells[2].Value.ToString();
            DateTime oldInsertDate = DateTime.Parse(dgv.Rows[nowRow].Cells[3].Value.ToString());
            string oldInsertUserId = dgv.Rows[nowRow].Cells[4].Value.ToString();
            DateTime oldUpdateDate = DateTime.Parse(dgv.Rows[nowRow].Cells[5].Value.ToString());
            string oldUpdateUserId = dgv.Rows[nowRow].Cells[6].Value.ToString();

            UserMasterForm frmUser = new UserMasterForm(
                oldUserId,
                oldUserNm,
                oldPassword,
                oldInsertDate,
                oldInsertUserId,
                oldUpdateDate,
                oldUpdateUserId,
                updateFlg
                );

            DialogResult drRet = frmUser.ShowDialog();

            if (drRet == DialogResult.OK)
            {
                String userId = frmUser.textUserId.Text;
                String userName = frmUser.textUserName.Text;
                String password = frmUser.textPassword.Text;

                // DB接続
                using (OracleConnection conn = new OracleConnection("user id = tadashy; password = tadashy; data source = tadashy"))
                {

                    // Oracleへのコネクションの確立
                    conn.Open();

                    // ============================================================
                    // 何か処理する（select/update/delete etc...）
                    // ============================================================
                    // トランザクションの開始
                    OracleTransaction txn = conn.BeginTransaction();

                    string sql = "UPDATE USER_MASTER SET USER_NAME = '" + userName +"' , PASSWORD = '" + password + "' , UPDATE_DATE = SYSDATE , UPDATE_USER = 'test' WHERE USER_ID = '" + oldUserId +"'";
                    OracleCommand myCmd = new OracleCommand(sql, conn);

                    // SQL の実行（リターン値は操作したレコード数）
                    myCmd.ExecuteNonQuery();

                    txn.Commit(); //コミット またはロールバック txn.Rollback()

                    // 接続を閉じる
                    conn.Close();

                    // DataSetの内容をDataGridViewに反映
                    this.uSER_MASTERTableAdapter.Fill(this.userMasterDataSet11.USER_MASTER);

                }

            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            updateFlg = true;
            UpdateData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
           
            //選択したボタンを判定する
            if (MessageBox.Show("削除して宜しいですか？", "削除確認", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //OKの場合
                DeleteData();
            }

            
        }

        private void DeleteData()
        {
            int nowRow = dgv.CurrentRow.Index;
            string oldUserId = dgv.Rows[nowRow].Cells[0].Value.ToString();

            // DB接続
            using (OracleConnection conn = new OracleConnection("user id = tadashy; password = tadashy; data source = tadashy"))
            {

                // Oracleへのコネクションの確立
                conn.Open();

                // ============================================================
                // 何か処理する（select/update/delete etc...）
                // ============================================================
                // トランザクションの開始
                OracleTransaction txn = conn.BeginTransaction();

                string sql = "DELETE FROM USER_MASTER WHERE USER_ID = '" + oldUserId + "'";
                OracleCommand myCmd = new OracleCommand(sql, conn);

                // SQL の実行（リターン値は操作したレコード数）
                myCmd.ExecuteNonQuery();

                txn.Commit(); //コミット またはロールバック txn.Rollback()

                // 接続を閉じる
                conn.Close();

                // DataSetの内容をDataGridViewに反映
                this.uSER_MASTERTableAdapter.Fill(this.userMasterDataSet11.USER_MASTER);

            }

        }
    }
}
