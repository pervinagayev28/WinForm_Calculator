namespace calculator
{
    public partial class Form1 : Form
    {
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
            btn_history.Location = new Point(78,550);
            btn_history.Size = new Size(193,30);
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
                lbl_history.Text += "\n------------------\nResult: "+item.number+" - "+item.date.ToString("dd,MM,yyyy");

        }

        private void button15_Click(object sender, EventArgs e)
        {
            List<List<string>> nums = new();
            List<string> operators = new();
            List<string> temp = new();
            for (int i = 0; i < tboxscreen.Text.Length; i++)
            {
                if (int.TryParse(tboxscreen.Text[i].ToString(), out int num))
                {
                    temp.Add(num.ToString());
                    if (i != tboxscreen.Text.ToString().Length - 1)
                    {
                        if (!int.TryParse(tboxscreen.Text[i + 1].ToString(), out _))
                        {
                            nums.Add(temp);
                            temp = new();
                        }
                    }
                    else
                    {
                        nums.Add(temp);
                        temp = new();
                    }
                }
                else
                    operators.Add(tboxscreen.Text[i].ToString());
            }
            long result = 0;
            for (int i = 0; i < nums.Count - 1; i++)
            {
                string num1 = default;
                string num2 = default;
                foreach (var item in nums[i])
                    num1 += item;

                foreach (var item in nums[i + 1])
                    num2 += item;

                switch (operators[i])
                {
                    case "X":
                        if (i == 0)
                            result = int.Parse(num1) * int.Parse(num2);
                        else
                            result *= int.Parse(num2);
                        break;
                    case "/":
                        try
                        {
                            if (i == 0)
                                result = int.Parse(num1) / int.Parse(num2);
                            else
                                result /= int.Parse(num2);
                        }
                        catch (Exception ex)
                        {
                            lbl_result.Text = " error by zero";
                            label1_Click_1(default, default);
                            continue;
                        }
                        break;
                    case "+":
                        if (i == 0)
                            result = int.Parse(num1) + int.Parse(num2);
                        else
                            result += int.Parse(num2);
                        break;
                    case "-":
                        if (i == 0)
                            result = int.Parse(num1) - int.Parse(num2);
                        else
                            result -= int.Parse(num2);
                        break;
                }
                lbl_result.Text = result.ToString();
            }
            history.Add(new History() {number= result.ToString(),date= DateTime.Now });
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
            if (tboxscreen.Text.Length != 0)
            {
                string temp = tboxscreen.Text.Substring(0, tboxscreen.Text.Length - 1);
                tboxscreen.Text = temp;
            }
            else
            {
                lbl_result.Text = "";
            }
        }
    }
}