using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolverWithUI
{
    public partial class SudokuSolver : Form
    {

        public SudokuSolver()
        {
            InitializeComponent();
        }

        private void SudokuSolver_Load(object sender, EventArgs e)
        {

        }

        private TextBox[] make_textbox_arr()
        {
            TextBox[] tb = {field1, field2, field3, field4, field5, field6, field7, field8, field9, field10,
                                field11, field12, field13, field14, field15, field16, field17, field18, field19, field20,
                                field21, field22, field23, field24, field25, field26, field27, field28, field29, field30,
                                field31, field32, field33, field34, field35, field36, field37, field38, field39, field40,
                                field41, field42, field43, field44, field45, field46, field47, field48, field49, field50,
                                field51, field52, field53, field54, field55, field56, field57, field58, field59, field60,
                                field61, field62, field63, field64, field65, field66, field67, field68, field69, field70,
                                field71, field72, field73, field74, field75, field76, field77, field78, field79, field80, field81 };
            return tb;
        }

        private int[] find_empty(int[][] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                for (int j = 0; j < b[0].Length; j++)
                {
                    if (b[i][j] == 0)
                    {
                        int[] res = { i, j };
                        return res;
                    }
                }
            }
            return null;
        }


        private bool isvalid(int[][] bo, int num, int[] pos) 
        {
            // check row
            for (int i = 0; i < bo[0].Length; i++)
            {
                if (bo[pos[0]][i] == num && pos[1] != i)
                {
                    return false;
                }
            }
            // check column
            for (int i = 0; i < bo.Length; i++)
            {
                if (bo[i][pos[1]] == num && pos[0] != i)
                {
                    return false;
                }
            }
            // check box
            int box_x = pos[1] / 3;
            int box_y = pos[0] / 3;
            for (int i = box_y*3;i< box_y *3+3; i++)
            {
                for (int j = box_x*3; j< box_x*3+3; j++)
                {
                    int[] a = { i, j };
                    if (bo[i][j] == num && a != pos)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool solve(int[][] bo)
        {
            int row = 0;
            int col = 0;
            int[] find = find_empty(bo);
            if (find == null)
            {
                return true;
            }
            else
            {
                row = find[0];
                col = find[1];
            }
            for (int i = 1; i < 10; i++)
            {
                if (isvalid(bo, i, find))
                {
                    bo[row][col] = i;
                    if (solve(bo))
                    {
                        return true;
                    }
                    bo[row][col] = 0;
                }
            }
            return false;
        }

        private int[][] make_board(TextBox[] tb)
        {
            int[][] board = new int[9][];
            for (int i = 0; i < 9; i++)
            {
                board[i] = new int[9];
                for (int j = 0; j < 9; j++)
                {
                    if (tb[i * 9 + j].Text == string.Empty)
                    {
                        board[i][j] = 0;
                    }
                    else
                    {
                        board[i][j] = Convert.ToInt32(tb[i * 9 + j].Text);
                    }
                }
            }

            return board;
        }

        private void print_board(int[][] bo, TextBox[] tb)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    tb[i * 9 + j].Text = Convert.ToString(bo[i][j]);
                }
            }
        }

        #region Input-Fields
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field1.Text, "[^0-9]") || field1.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field1.Text = field1.Text.Remove(field1.Text.Length - 1);
            }
        }

        private void field23_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field23.Text, "[^0-9]") || field23.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field23.Text = field23.Text.Remove(field23.Text.Length - 1);
            }
        }

        private void field2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field2.Text, "[^0-9]") || field2.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field2.Text = field2.Text.Remove(field2.Text.Length - 1);
            }
        }

        private void field81_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field81.Text, "[^0-9]") || field81.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field81.Text = field81.Text.Remove(field81.Text.Length - 1);
            }
        }

        private void field72_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field72.Text, "[^0-9]") || field72.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field72.Text = field72.Text.Remove(field72.Text.Length - 1);
            }
        }

        private void field63_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field63.Text, "[^0-9]") || field63.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field63.Text = field63.Text.Remove(field63.Text.Length - 1);
            }
        }

        private void field54_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field54.Text, "[^0-9]") || field54.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field54.Text = field54.Text.Remove(field54.Text.Length - 1);
            }
        }

        private void field45_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field45.Text, "[^0-9]") || field45.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field45.Text = field45.Text.Remove(field45.Text.Length - 1);
            }
        }

        private void field36_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field36.Text, "[^0-9]") || field36.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field36.Text = field36.Text.Remove(field36.Text.Length - 1);
            }
        }

        private void field27_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field27.Text, "[^0-9]") || field27.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field27.Text = field27.Text.Remove(field27.Text.Length - 1);
            }
        }

        private void field18_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field18.Text, "[^0-9]") || field18.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field18.Text = field18.Text.Remove(field18.Text.Length - 1);
            }
        }

        private void field9_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field9.Text, "[^0-9]") || field9.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field9.Text = field9.Text.Remove(field9.Text.Length - 1);
            }
        }

        private void field8_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field8.Text, "[^0-9]") || field8.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field8.Text = field8.Text.Remove(field8.Text.Length - 1);
            }
        }

        private void field6_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field6.Text, "[^0-9]") || field6.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field6.Text = field6.Text.Remove(field6.Text.Length - 1);
            }
        }

        private void field4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field4.Text, "[^0-9]") || field4.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field4.Text = field4.Text.Remove(field4.Text.Length - 1);
            }
        }

        private void field3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field3.Text, "[^0-9]") || field3.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field3.Text = field3.Text.Remove(field3.Text.Length - 1);
            }
        }

        private void field5_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field5.Text, "[^0-9]") || field5.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field5.Text = field5.Text.Remove(field5.Text.Length - 1);
            }
        }

        private void field7_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field7.Text, "[^0-9]") || field7.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field7.Text = field7.Text.Remove(field7.Text.Length - 1);
            }
        }

        private void field16_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field16.Text, "[^0-9]") || field16.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field16.Text = field16.Text.Remove(field16.Text.Length - 1);
            }
        }

        private void field25_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field25.Text, "[^0-9]") || field25.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field25.Text = field25.Text.Remove(field25.Text.Length - 1);
            }
        }

        private void field26_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field26.Text, "[^0-9]") || field26.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field26.Text = field26.Text.Remove(field26.Text.Length - 1);
            }
        }

        private void field35_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field35.Text, "[^0-9]") || field35.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field35.Text = field35.Text.Remove(field35.Text.Length - 1);
            }
        }

        private void field44_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field44.Text, "[^0-9]") || field44.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field44.Text = field44.Text.Remove(field44.Text.Length - 1);
            }
        }

        private void field53_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field53.Text, "[^0-9]") || field53.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field53.Text = field53.Text.Remove(field53.Text.Length - 1);
            }
        }

        private void field62_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field62.Text, "[^0-9]") || field62.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field62.Text = field62.Text.Remove(field62.Text.Length - 1);
            }
        }

        private void field71_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field71.Text, "[^0-9]") || field71.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field71.Text = field71.Text.Remove(field71.Text.Length - 1);
            }
        }

        private void field80_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field80.Text, "[^0-9]") || field80.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field80.Text = field80.Text.Remove(field80.Text.Length - 1);
            }
        }

        private void field79_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field79.Text, "[^0-9]") || field79.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field79.Text = field79.Text.Remove(field79.Text.Length - 1);
            }
        }

        private void field78_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field78.Text, "[^0-9]") || field78.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field78.Text = field78.Text.Remove(field78.Text.Length - 1);
            }
        }

        private void field76_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field76.Text, "[^0-9]") || field76.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field76.Text = field76.Text.Remove(field76.Text.Length - 1);
            }
        }

        private void field75_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field75.Text, "[^0-9]") || field75.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field75.Text = field75.Text.Remove(field75.Text.Length - 1);
            }
        }

        private void field74_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field74.Text, "[^0-9]") || field74.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field74.Text = field74.Text.Remove(field74.Text.Length - 1);
            }
        }

        private void field73_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field73.Text, "[^0-9]") || field73.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field73.Text = field73.Text.Remove(field73.Text.Length - 1);
            }
        }

        private void field77_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field77.Text, "[^0-9]") || field77.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field77.Text = field77.Text.Remove(field77.Text.Length - 1);
            }
        }

        private void field55_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field55.Text, "[^0-9]") || field55.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field55.Text = field55.Text.Remove(field55.Text.Length - 1);
            }
        }

        private void field46_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field46.Text, "[^0-9]") || field46.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field46.Text = field46.Text.Remove(field46.Text.Length - 1);
            }
        }

        private void field37_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field37.Text, "[^0-9]") || field37.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field37.Text = field37.Text.Remove(field37.Text.Length - 1);
            }
        }

        private void field28_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field28.Text, "[^0-9]") || field28.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field28.Text = field28.Text.Remove(field28.Text.Length - 1);
            }
        }

        private void field19_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field19.Text, "[^0-9]") || field19.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field19.Text = field19.Text.Remove(field19.Text.Length - 1);
            }
        }

        private void field10_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field10.Text, "[^0-9]") || field10.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field10.Text = field10.Text.Remove(field10.Text.Length - 1);
            }
        }

        private void field11_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field11.Text, "[^0-9]") || field11.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field11.Text = field11.Text.Remove(field11.Text.Length - 1);
            }
        }

        private void field20_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field20.Text, "[^0-9]") || field20.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field20.Text = field20.Text.Remove(field20.Text.Length - 1);
            }
        }

        private void field29_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field29.Text, "[^0-9]") || field29.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field29.Text = field29.Text.Remove(field29.Text.Length - 1);
            }
        }

        private void field38_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field38.Text, "[^0-9]") || field38.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field38.Text = field38.Text.Remove(field38.Text.Length - 1);
            }
        }

        private void field64_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field64.Text, "[^0-9]") || field64.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field64.Text = field64.Text.Remove(field64.Text.Length - 1);
            }
        }

        private void field56_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field56.Text, "[^0-9]") || field56.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field56.Text = field56.Text.Remove(field56.Text.Length - 1);
            }
        }

        private void field65_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field65.Text, "[^0-9]") || field65.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field65.Text = field65.Text.Remove(field65.Text.Length - 1);
            }
        }

        private void field66_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field66.Text, "[^0-9]") || field66.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field66.Text = field66.Text.Remove(field66.Text.Length - 1);
            }
        }

        private void field67_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field67.Text, "[^0-9]") || field67.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field67.Text = field67.Text.Remove(field67.Text.Length - 1);
            }
        }

        private void field68_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field68.Text, "[^0-9]") || field68.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field68.Text = field68.Text.Remove(field68.Text.Length - 1);
            }
        }

        private void field69_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field69.Text, "[^0-9]") || field69.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field69.Text = field69.Text.Remove(field69.Text.Length - 1);
            }
        }

        private void field70_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field70.Text, "[^0-9]") || field70.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field70.Text = field70.Text.Remove(field70.Text.Length - 1);
            }
        }

        private void field61_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field61.Text, "[^0-9]") || field61.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field61.Text = field61.Text.Remove(field61.Text.Length - 1);
            }
        }

        private void field60_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field60.Text, "[^0-9]") || field60.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field60.Text = field60.Text.Remove(field60.Text.Length - 1);
            }
        }

        private void field59_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field59.Text, "[^0-9]") || field59.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field59.Text = field59.Text.Remove(field2.Text.Length - 1);
            }
        }

        private void field58_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field58.Text, "[^0-9]") || field58.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field58.Text = field58.Text.Remove(field58.Text.Length - 1);
            }
        }

        private void field57_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field57.Text, "[^0-9]") || field57.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field57.Text = field57.Text.Remove(field57.Text.Length - 1);
            }
        }

        private void field48_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field48.Text, "[^0-9]") || field48.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field48.Text = field48.Text.Remove(field48.Text.Length - 1);
            }
        }

        private void field39_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field39.Text, "[^0-9]") || field39.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field39.Text = field39.Text.Remove(field39.Text.Length - 1);
            }
        }

        private void field30_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field30.Text, "[^0-9]") || field30.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field30.Text = field30.Text.Remove(field30.Text.Length - 1);
            }
        }

        private void field21_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field21.Text, "[^0-9]") || field21.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field21.Text = field21.Text.Remove(field21.Text.Length - 1);
            }
        }

        private void field12_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field12.Text, "[^0-9]") || field12.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field12.Text = field12.Text.Remove(field12.Text.Length - 1);
            }
        }

        private void field13_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field13.Text, "[^0-9]") || field13.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field13.Text = field13.Text.Remove(field13.Text.Length - 1);
            }
        }

        private void field14_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field14.Text, "[^0-9]") || field14.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field14.Text = field14.Text.Remove(field14.Text.Length - 1);
            }
        }

        private void field15_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field15.Text, "[^0-9]") || field15.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field15.Text = field15.Text.Remove(field15.Text.Length - 1);
            }
        }

        private void field24_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field24.Text, "[^0-9]") || field24.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field24.Text = field24.Text.Remove(field24.Text.Length - 1);
            }
        }

        private void field33_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field33.Text, "[^0-9]") || field33.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field33.Text = field33.Text.Remove(field33.Text.Length - 1);
            }
        }

        private void field34_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field34.Text, "[^0-9]") || field34.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field34.Text = field34.Text.Remove(field34.Text.Length - 1);
            }
        }

        private void field43_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field43.Text, "[^0-9]") || field43.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field43.Text = field43.Text.Remove(field43.Text.Length - 1);
            }
        }

        private void field52_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field52.Text, "[^0-9]") || field52.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field52.Text = field52.Text.Remove(field52.Text.Length - 1);
            }
        }

        private void field51_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field51.Text, "[^0-9]") || field51.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field51.Text = field51.Text.Remove(field51.Text.Length - 1);
            }
        }

        private void field42_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field42.Text, "[^0-9]") || field42.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field42.Text = field42.Text.Remove(field42.Text.Length - 1);
            }
        }

        private void field41_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field41.Text, "[^0-9]") || field41.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field41.Text = field41.Text.Remove(field41.Text.Length - 1);
            }
        }

        private void field50_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field50.Text, "[^0-9]") || field50.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field50.Text = field50.Text.Remove(field50.Text.Length - 1);
            }
        }

        private void field49_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field49.Text, "[^0-9]") || field49.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field49.Text = field49.Text.Remove(field49.Text.Length - 1);
            }
        }

        private void field40_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field40.Text, "[^0-9]") || field40.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field40.Text = field40.Text.Remove(field40.Text.Length - 1);
            }
        }

        private void field31_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field31.Text, "[^0-9]") || field31.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field31.Text = field31.Text.Remove(field31.Text.Length - 1);
            }
        }

        private void field32_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field32.Text, "[^0-9]") || field32.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field32.Text = field32.Text.Remove(field32.Text.Length - 1);
            }
        }

        private void field47_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field47.Text, "[^0-9]") || field47.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field47.Text = field47.Text.Remove(field47.Text.Length - 1);
            }
        }

        private void field22_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field22.Text, "[^0-9]") || field22.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field22.Text = field22.Text.Remove(field22.Text.Length - 1);
            }
        }

        private void field17_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(field17.Text, "[^0-9]") || field17.Text.Length > 1)
            {
                MessageBox.Show("Please enter only one digit.");
                field17.Text = field17.Text.Remove(field17.Text.Length - 1);
            }
        }
        #endregion

        #region stuff
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        private void button_reset_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes = make_textbox_arr();

            foreach (TextBox field in textBoxes)
            {
                if (field.Text.Length != 0)
                {
                    field.Text = field.Text.Remove(field.Text.Length - 1);
                }
            }
            
        }

        private void button_solve_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes = make_textbox_arr();
            int[][] board = make_board(textBoxes);
            solve(board);
            print_board(board, textBoxes);
        }
    }
}
