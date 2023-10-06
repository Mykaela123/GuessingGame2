using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessingGame2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       public  bool playAgain = false;

        public int currentHintIndex = 0;

        public int score = 0;

        string[] hints =
         {
                "This dark wizard who is the primary antagonist throughout the Harry Potter series. ",
                "What magical creature guards the entrance to Professor Dumbledore's office?",
                "The main trio of Harry, Ron, and Hermione often enjoys this beverage in the Hogwarts dining hall. It can make you feel warm and cozy.",
                " This spell is used to summon an object to the caster's hand. What is the incantation for this spell?",
                "Which Hogwarts house values traits such as bravery, chivalry, and courage?",
                "The train that takes students to Hogwarts departs from this platform at King's Cross Station. What is the platform number?",
                "This magical object, given to Harry by Professor Dumbledore, can be used to view the memories of the person who placed them in it.",
                "Hagrid's beloved pet is a magical creature that resembles a giant spider. What is the name of this creature?",
                "This location is the hidden entrance to the wizarding bank, Gringotts. It's guarded by a fierce dragon. What is the name of this place?",
                "The sport played on broomsticks in the wizarding world is called what?"
            };
        private Random random = new Random();



        private void RandomizeHints()
        {
            currentHintIndex = random.Next(0, hints.Length);
            string randomHints = hints[currentHintIndex];
            lblHint.Text = randomHints;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAnswer.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close(); 
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            RandomizeHints();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string[] answers =
                    {
             "Voldemort",
             "Phoenix ",
             " Butterbeer",
             "Accio",
             "Gryfindor",
             "Platform 9 3/4",
             "Pensieve",
             "Aragog",
             "Diagon Alley",
             "Quidditch"
            };

            string userAnswer = txtAnswer.Text.Trim();
            if (currentHintIndex >= 0 && currentHintIndex < answers.Length)
            {
                string correctAnswer = answers[currentHintIndex].Trim();
                if (userAnswer.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase))
                {
                    score++;
                    DialogResult response = MessageBox.Show("Correct!Your score is : " + score + " You are as smart as Hermonie.", "Answer", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (response == DialogResult.OK)
                    {
                        currentHintIndex++;


                        if (currentHintIndex < hints.Length)
                        {
                            RandomizeHints();
                        }
                    }
                }
                else
                {
                    DialogResult response = MessageBox.Show("Incorrect!Your final score is : " + score, "Answer", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (response == DialogResult.OK)
                    {
                        DialogResult playAgainInput = MessageBox.Show("Would you like to try again?", "Game Over!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (playAgainInput == DialogResult.Yes)
                        {
                            playAgain = true;
                        }
                    }
                }
            }
        }
    }
}
