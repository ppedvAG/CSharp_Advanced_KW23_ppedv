namespace EventHandlersInWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBox1.Text = "Hallo liebe Teilnehmer";
            

            this.listBox1.Items.Add("A");
            this.listBox1.Items.Add("B");
            this.listBox1.Items.Add("C");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'ö')
                MessageBox.Show("Ein ö wurde gedrückt");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Text = textBox1.Text;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}