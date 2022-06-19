namespace AntiSQLInjection
{
    public partial class Form1 : Form
    {
        static int dem =2;
        public Form1()
        {
            InitializeComponent();
            textBox2.MaxLength = 15;
            //textBox2.PasswordChar = '*';
            textBox2.UseSystemPasswordChar = true;
        }
        SQL t = new SQL();

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "") MessageBox.Show("Password Empty!");
            else
            {
                //var reader = t.execute($"SELECT * FROM Account WHERE ID = '{textBox1.Text}' AND '{textBox2}'");
                if(t.execute(textBox1.Text, textBox2.Text))
                {
                    MessageBox.Show("Login Success!");
                    this.Hide();
                    Form2 f = new Form2();
                    f.Show();

                }
                else
                {
                    MessageBox.Show("Login Error!");
                }
                
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //textBox2.PasswordChar = '*';
            if (dem % 2 == 0)
            {
                textBox2.UseSystemPasswordChar =false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
            dem++;

        }
    }
}