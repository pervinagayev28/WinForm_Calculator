using System;
using System.IO;

namespace calculator
{
    public partial class Form1 : Form
    {
        public static bool check { get; set; } = false;
        List<History> history = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tboxscreen.Text += "/";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tboxscreen.Text += "+";

        }

        private void button12_Click(object sender, EventArgs e)
        {
            tboxscreen.Text += 2;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            tboxscreen.Text += 6;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            tboxscreen.Text += 1;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tboxscreen.Text += 3;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            tboxscreen.Text += 4;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            tboxscreen.Text += 5;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            tboxscreen.Text += 7;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            tboxscreen.Text += 8;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            tboxscreen.Text += 9;

        }

        private void button14_Click(object sender, EventArgs e)
        {
            tboxscreen.Text += 0;

        }


        private void button16_Click(object sender, EventArgs e)
        {
            Label lbl_history = new();
            lbl_history.Location = new Point(78, 170);
            lbl_history.Size = new Size(193, 410);
            lbl_history.BackColor = Color.Black;
            lbl_history.ForeColor = Color.White;
            Button btn_history = new();
            btn_history.Location = new Point(78, 550);
            btn_history.Size = new Size(193, 30);
            btn_history.Text = "GO TO BACK";
            btn_history.Click += (s, e) =>
            {
                Controls.Remove(lbl_history);
                Controls.Remove(btn_history);
            };
            btn_history.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(lbl_history);
            Controls.Add(btn_history);
            lbl_history.BringToFront();
            btn_history.BringToFront();
            foreach (var item in history)
                lbl_history.Text += "\n------------------\nResult: " + item.number + " - " + item.date.ToString("dd,MM,yyyy");

        }
        private void CalculateResult()
        {
            List<int> X = new();
            List<int> divide = new();
            List<string> nums = new();
            string temp = default;
            foreach (var item in tboxscreen.Text)
            {
                bool check = true;
                try
                {
                    Convert.ToDouble(item.ToString());
                    check = true;
                }
                catch (Exception)
                {
                    if (item.ToString() != ".")
                        check = false;
                }
                if (check)
                {
                    temp += item.ToString();
                }
                else
                {
                    nums.Add(temp);
                    nums.Add(item.ToString());
                    temp = default;
                }
            }
            nums.Add(temp);
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == "X")
                {
                    var num = Convert.ToDouble(nums[i - 1]) * Convert.ToDouble(nums[i + 1]);
                    nums.Insert(i - 1, num.ToString());
                    nums.RemoveRange(i, 3);
                    i--;
                }
                if (nums[i] == "/")
                {
                    var num = Convert.ToDouble(nums[i - 1]) / Convert.ToDouble(nums[i + 1]);
                    nums.Insert(i - 1, num.ToString());
                    nums.RemoveRange(i, 3);
                }
            }
            double result = default;
            for (int i = 0; i < nums.Count; i++)
            {

                switch (nums[i])
                {
                    case "+":
                        if (i == 1)
                            result = Convert.ToDouble(nums[i - 1]) + Convert.ToDouble(nums[i + 1]);
                        else
                            result += Convert.ToDouble(nums[i + 1]);
                        break;
                    case "-":
                        if (i == 1)
                            result = Convert.ToDouble(nums[i - 1]) - Convert.ToDouble(nums[i + 1]);
                        else
                            result -= Convert.ToDouble(nums[i + 1]);
                        break;
                }

            }
            lbl_result.Text = Math.Round(result, 1).ToString();
            if (nums.Count == 1)
                lbl_result.Text = Math.Round(Convert.ToDouble(nums[0]), 1).ToString();

            history.Add(new History() { number = result.ToString(), date = DateTime.Now });
        }
        private void button15_Click(object sender, EventArgs e)
        {
            tboxscreen.Text += ".";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tboxscreen.Text += "X";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tboxscreen.Text += "-";

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

            if (tboxscreen.Text.Length > 1)
            {
                string temp = tboxscreen.Text.Substring(0, tboxscreen.Text.Length - 1);
                tboxscreen.Text = temp;
            }
            else
            {
                tboxscreen.Text = "";
                lbl_result.Text = "";
            }


        }

        private void tboxscreen_TextChanged(object sender, EventArgs e)
        {

            if (check && tboxscreen.Text.Length > 1)
            {
                CalculateResult();
                check = false;
            }
            if (tboxscreen.Text.Length > 1)
            {

                try
                {
                    Convert.ToDouble(tboxscreen.Text[tboxscreen.Text.Length - 1].ToString());
                    var text = tboxscreen.Text;
                    if(text.Contains("X")|| text.Contains("+")|| text.Contains("-")|| text.Contains("/"))
                        CalculateResult();
                }
                catch (Exception)
                {
                    if (tboxscreen.Text[tboxscreen.Text.Length - 1].ToString() != ".")
                        check = true;
                }

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}