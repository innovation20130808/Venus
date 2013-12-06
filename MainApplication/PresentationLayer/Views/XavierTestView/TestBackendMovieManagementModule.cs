using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySQLDriverCS;

namespace MainApplication.PresentationLayer.Views.XavierTestView
{
    public partial class TestBackendMovieManagementModule : Form
    {
        //SqlConnectionStringBuilder cn = new SqlConnectionStringBuilder();
        //SqlConnection sqlCN;

        public TestBackendMovieManagementModule()
        {
            InitializeComponent();
        }

        void ShowData()
        {
            try  //使用try...catch...敘述來補捉異動資料可能發生的例外 
            {
                MySQLConnection conn = null;
                conn = new MySQLConnection(new MySQLConnectionString("127.0.0.1", "venus", "root", "2uailgol", 3307).AsString);
                conn.Open();

                MySQLCommand commn = new MySQLCommand("set names big5", conn);
                commn.ExecuteNonQuery();

                string sql = "SELECT * FROM moviemanagement ORDER BY movieNo DESC";
                MySQLDataAdapter mda = new MySQLDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                mda.Fill(ds, "moviemanagement");
                dtGridView_movieManagement.DataSource = ds.Tables["moviemanagement"];

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ", 資料發生錯誤");
            }
        }

        private void TestBackendMovieManagementModule_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySQLConnection conn = null;
                conn = new MySQLConnection(new MySQLConnectionString("127.0.0.1", "venus", "root", "2uailgol", 3307).AsString);
                conn.Open();

                string sqlStr = "INSERT INTO MovieManagement(movieEngName, movieChiName, movieDegree, movieType, movieLength, movieDirector, movieActor, movieIntroduce, playStartDate, playEndDate, movieTrailer, picLink, updateUser, updateTime) "
                                    + "VALUES('" + txtBx_movieEnglishName.Text.ToString() + "','" + txtBx_movieChineseName.Text.ToString() + "','" + txtBx_movieGenre.Text.ToString() + "','" + txtBx_movieType.Text.ToString() + "','" + txtBx_movieLength.Text.ToString() + "','"
                                    + txtBx_movieDirector.Text.ToString() + "','" + txtBx_movieActor.Text.ToString() + "','" + txtBx_movieIntroduction.Text.ToString() + "','" + txtBx_playStartDate.Text.ToString() + "','" + "2013/12/03" + "','"
                                    + txtBx_movieTrailer.Text.ToString() + "','" + txtBx_picLink.Text.ToString() + "','" + "9523310" + "','" + "2013/12/03" + "')";

                MySQLCommand commn = new MySQLCommand(sqlStr, conn);
                commn.ExecuteNonQuery();

                MySQLCommand comn = new MySQLCommand("set names big5", conn);

                ShowData();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ", 資料發生錯誤");
            }
        }

        private void btn_deleteMovie_Click(object sender, EventArgs e)
        {
            try
            {
                MySQLConnection conn = null;
                conn = new MySQLConnection(new MySQLConnectionString("127.0.0.1", "venus", "root", "2uailgol", 3307).AsString);
                conn.Open();

                string sqlStr = "DELETE FROM MovieManagement WHERE movieEngName = '" + txtBx_movieEnglishName.Text.ToString() + "'";
                
                MySQLCommand commn = new MySQLCommand(sqlStr, conn);
                commn.ExecuteNonQuery();

                ShowData();

                conn.Close();

                txtBx_movieEnglishName.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ", 資料發生錯誤");
            }
        }

        private void btn_modifyMovie_Click(object sender, EventArgs e)
        {
            try
            {
                MySQLConnection conn = null;
                conn = new MySQLConnection(new MySQLConnectionString("127.0.0.1", "venus", "root", "2uailgol", 3307).AsString);
                conn.Open();

                string sqlStr = "UPDATE MovieManagement SET movieChiName = '" + txtBx_movieEnglishName.Text.ToString() + "', movieDegree ='" + txtBx_movieType.Text.ToString() + "', movieType ='" + txtBx_movieGenre.Text.ToString() + "', movieLength ='" + txtBx_movieLength.Text.ToString() + "', movieDirector ='" + txtBx_movieDirector.Text.ToString() + "', movieActor ='" + txtBx_movieActor.Text.ToString() + "', movieIntroduce ='" + txtBx_movieIntroduction.Text.ToString() + "', playStartDate ='" + txtBx_playStartDate.Text.ToString() + "', movieTrailer ='" + txtBx_movieTrailer.Text.ToString() + "', picLink ='" + txtBx_picLink.Text.ToString() + " WHERE movieEnglishName = '" + txtBx_movieEnglishName.Text.ToString() + "'";

                MySQLCommand commn = new MySQLCommand(sqlStr, conn);
                commn.ExecuteNonQuery();

                ShowData();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ", 資料發生錯誤");
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
