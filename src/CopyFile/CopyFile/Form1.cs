namespace CopyFile
{
    public partial class Form1 : Form
    {
        private readonly Context _context = new Context();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
                MessageBox.Show("title is empty");

            if (!Directory.Exists(textBox2.Text))
                MessageBox.Show("SourcePath does not exist");

            if (!Directory.Exists(textBox3.Text))
                MessageBox.Show("TargetPath does not exist");

            else
            {
                var filepath = new FilePath()
                {
                   Title =textBox1.Text,
                   SourcePath = textBox2.Text,
                   TargetPath = textBox3.Text
                };

                _context.FilePath.Add(filepath);
                _context.SaveChanges();

                MessageBox.Show("submited successfully");
                Helper.ClearTextBoxes(this);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}