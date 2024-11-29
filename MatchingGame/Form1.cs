namespace MatchingGame
{
    public partial class Form1 : Form
    {
        Label firstClicked = null;
        Label secondClicked = null;
        Random random = new Random();
        List<string> icons = new List<string>()
        
        {
            "!", "!", "N", "N", ",", ",", "k", "k", "b", "b", "v", "v", "w", "w", "z", "z"
        };

        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {   
                Label iconlabel = control as Label;
                

                if (iconlabel != null)
                {
                    
                    int randomNumber = random.Next(icons.Count);
                    iconlabel.Text = icons[randomNumber];
                    icons.RemoveAt(randomNumber);
                    iconlabel.ForeColor = iconlabel.BackColor;
                }
                
            }
        }
        public Form1()
        {
            InitializeComponent();

            AssignIconsToSquares();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            


            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;

                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;
                timer1.Start();

                CheckForWinner();
                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            timer1.Stop();

            if (firstClicked != null) {

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel1 = control as Label;

                if (iconLabel1 != null)
                {
                    if (iconLabel1.ForeColor == iconLabel1.BackColor)
                        return;
                }
            }

            MessageBox.Show("you matched all the icons!", "Congratulations");
            Close();
        }
    }
}
