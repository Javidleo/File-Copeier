namespace CopyFile
{
    public partial class Form2 : Form
    {
        private readonly Context _context = new Context();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _context.FilePath.ToList();

            // Set your desired AutoSize Mode:
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Now that DataGridView has calculated it's Widths; we can now store each column Width values.
            for (int i = 0; i <= dataGridView1.Columns.Count - 1; i++)
            {
                // Store Auto Sized Widths:
                int colw = dataGridView1.Columns[i].Width;

                // Remove AutoSizing:
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                // Set Width to calculated AutoSize value:
                dataGridView1.Columns[i].Width = colw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
                MessageBox.Show("title is empty");
            else
            {
                var filePath = _context.FilePath.FirstOrDefault(i => i.Title == textBox1.Text);

                if (IsDirectoryEmpty(filePath.SourcePath))
                    MessageBox.Show("noting to copy");

                if (!Directory.Exists(filePath.TargetPath))
                    MessageBox.Show("cannot found target directory");

                else
                {
                    Copy(filePath.SourcePath, filePath.TargetPath);

                    MessageBox.Show("Copy Successfully");
                }
            }
        }

        private void Copy(string sourcePath, string targetPath)
        {
            DirectoryInfo source = new DirectoryInfo(sourcePath);
            DirectoryInfo target = new DirectoryInfo(targetPath);

            var targetfiles = target.GetFiles();
            


            foreach (FileInfo fileinfo in source.GetFiles())
            {
                if(!targetfiles.Select(i=> i.Name).Contains(fileinfo.Name))
                    fileinfo.CopyTo(Path.Combine(target.ToString(), fileinfo.Name), true);
            }
        }

        private bool IsDirectoryEmpty(string path)
        => !Directory.EnumerateFileSystemEntries(path).Any();

        private void button3_Click(object sender, EventArgs e)
        {
            var form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
