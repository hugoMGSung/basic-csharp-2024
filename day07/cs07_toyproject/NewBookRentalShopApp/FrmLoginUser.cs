using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace NewBookRentalShopApp
{
    public partial class FrmLoginUser : MetroForm
    {
        private bool isNew = false; // UPDATE(false), INSERT(true)

        public FrmLoginUser()
        {
            InitializeComponent();
        }

        private void FrmLoginUser_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;
            TxtUserIdx.Text = TxtUserId.Text = TxtPassword.Text = string.Empty;
            TxtUserIdx.ReadOnly = true;
            TxtUserId.Focus(); // 순번은 자동증가하기때문에 입력불가
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var md5Hash = MD5.Create();  // MD5 암호화용 객체 생성
            var valid = true;
            var errMsg = "";

            // 입력검증(Validation Check), 아이디, 패스워드를 안넣으면 
            if (string.IsNullOrEmpty(TxtUserId.Text))
            {
                errMsg += "사용자아이디를 입력하세요.\n";
                valid = false;
            }

            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                errMsg += "패스워드를 입력하세요.";
                valid = false;
            }

            if (valid == false)
            {
                MetroMessageBox.Show(this.Parent.Parent, errMsg, "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    conn.Open();

                    var query = "";
                    if (isNew) // INSERT이면
                    {
                        query = @"INSERT INTO usertbl
                                        ( userId
                                        , [password]
		                                )
                                   VALUES
                                        ( @userId
                                        , @password
		                                )";
                    }
                    else  // UPADATE
                    {
                        query = @"UPDATE usertbl
                                 SET userId = @userId
                                   , [password] = @password
                               WHERE userIdx = @userIdx";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (isNew == false) // update시는 @userIdx 파라미터 필요!
                    {
                        SqlParameter prmUserIdx = new SqlParameter("@userIdx", TxtUserIdx.Text);
                        cmd.Parameters.Add(prmUserIdx);
                    }

                    SqlParameter prmUserId = new SqlParameter("@userId", TxtUserId.Text);
                    SqlParameter prmPassword = new SqlParameter("@password", Helper.Common.GetMd5Hash(md5Hash, TxtPassword.Text)); // 암호화 끝.
                    // Command에 Parameter를 연결해줘야 함!
                    cmd.Parameters.Add(prmUserId);
                    cmd.Parameters.Add(prmPassword);

                    var result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        // this 메시지박스의 부모창이 누구냐, FrmLoginUser
                        MetroMessageBox.Show(this.Parent.Parent, "저장성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroMessageBox.Show(this.Parent.Parent, "저장실패!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this.Parent.Parent, $"오류  : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            TxtUserIdx.Text = TxtUserId.Text = TxtPassword.Text = string.Empty; // 입력, 수정, 삭제 이후에는 모든 입력값을 지워줘야 함
            RefreshData();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtUserIdx.Text))  // 사용자아이디순번이 없으면 
            {
                MetroMessageBox.Show(this.Parent.Parent, "삭제할 사용자를 선택하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var answer = MetroMessageBox.Show(this.Parent.Parent, "정말 삭제하시겠습니까?", "삭제여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();
                var query = @"DELETE FROM usertbl WHERE userIdx = @userIdx ";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmUserIdx = new SqlParameter("@userIdx", TxtUserIdx.Text);
                cmd.Parameters.Add(prmUserIdx);

                var result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MetroMessageBox.Show(this.Parent.Parent, "삭제성공!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
                else
                {
                    MetroMessageBox.Show(this.Parent.Parent, "삭제실패!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

            TxtUserIdx.Text = TxtUserId.Text = TxtPassword.Text = string.Empty; // 입력, 수정, 삭제 이후에는 모든 입력값을 지워줘야 함
            RefreshData(); // 데이터그리드 재조회
        }

        // 데이터그리뷰에 데이터를 새로부르기
        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();

                var query = @"SELECT userIdx
                                   , userId
                                   , [password]
                                   , lastLoginDateTime
                                FROM usertbl";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "usertbl");

                DgvResult.DataSource = ds.Tables[0];
                DgvResult.ReadOnly = true; // 수정불가
                DgvResult.Columns[0].HeaderText = "사용자순번";
                DgvResult.Columns[1].HeaderText = "사용자아이디";
                DgvResult.Columns[2].HeaderText = "패스워드";
                DgvResult.Columns[3].HeaderText = "마지막로그인날짜";
            }
        }

        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) // 아무것도 선택하지 않으면 -1
            {
                var selData = DgvResult.Rows[e.RowIndex]; // 내가 선택한 인덱스값
                TxtUserIdx.Text = selData.Cells[0].Value.ToString();
                TxtUserIdx.ReadOnly = true;
                TxtUserId.Text = selData.Cells[1].Value.ToString();
                TxtPassword.Text = selData.Cells[2].Value.ToString();

                isNew = false;  // UPDATE
            }
        }

        
    }
}
