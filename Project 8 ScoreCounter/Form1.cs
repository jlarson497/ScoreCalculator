using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_8_ScoreCounter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Global list to hold the scores
        List<int> sortedScoreList = new List<int>{ };
        List<int> scoreList = new List<int> { };


        //Add Score to the list, call clear the sortedList, and then call Sort List,
        //Which copies over the unsorted score list and then sorts it.  If  you call
        //sortlist without clearing the sortedList, you get duplicates
        private void AddScore()
        {
            int newScore = Convert.ToInt16(txtNewScore.Text);
            scoreList.Add(newScore);
            sortedScoreList.Clear();
            SortList();
        }

        //Total the scores
        private int TotalScores()
        {
            int totalScore = 0;
            foreach (int score in scoreList)
            {
                totalScore = totalScore + score;
            }

            return totalScore;
        }

        //Count the scores
        private int CountScores()
        {
            int count = scoreList.Count();
            return count;
        }
        //Average the scores
        private int AverageScores()
        {
            int totalScore = TotalScores();
            int numberOfScores = CountScores();
            int averageScore = totalScore / numberOfScores;

            return averageScore;
        }

        //method to clear a variable list
        private void ClearThisList(List<int> list)
        {
            list.Clear();
        }

        //Clears the list, and then the form
        private void ClearForm()
        {
            ClearThisList(scoreList);
            ClearThisList(sortedScoreList);
            txtNewScore.Clear();
            txtScoreCount.Clear();
            txtScoreTotal.Clear();
            txtAverage.Clear();
        }

        //updates the form with the correct values
        private void UpdateForm()
        {
            txtMax.Text = Convert.ToString(MaximumScore());
            txtMin.Text = Convert.ToString(MinimumScore());
            txtAverage.Text = Convert.ToString(AverageScores());
            txtScoreCount.Text = Convert.ToString(CountScores());
            txtScoreTotal.Text = Convert.ToString(TotalScores());

        }
        //gets the min score
        private int MinimumScore()
        {
            int minimum = scoreList.Min();
            return minimum;
        }
        //gets the max score
        private int MaximumScore()
        {
            int maximum = scoreList.Max();
            return maximum;
        }
        //sorts the global list
        private void SortList()
        {
            foreach (int score in scoreList)
            {
                sortedScoreList.Add(score);
            }

            sortedScoreList.Sort();
    
        }
        //displays an unsorted list
        private void DisplayUnsortedList()
        {
            string fullScoreList = "";
            foreach (int score in scoreList)
            {
                fullScoreList = fullScoreList + score.ToString() + "\n";
            }
            MessageBox.Show(fullScoreList, "Unsorted Scores");
        }

        //diplays a sorted list
        private void DisplaySortedList()
        {
            
            string fullScoreList = "";
            foreach (int score in sortedScoreList)
            {
                fullScoreList = fullScoreList + score.ToString() + "\n";
            }
            MessageBox.Show(fullScoreList, "Sorted Scores");
        }

        //Button click event handlers
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsValidForm())
            {
                return;
            }

            AddScore();
            UpdateForm();
            txtNewScore.Clear();
            txtNewScore.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnDisplayScores_Click(object sender, EventArgs e)
        {
            if (sortedScoreList.Count < 1)
            {
                MessageBox.Show("There are no scores to display", "Null Set");
                return;
            }
            DisplaySortedList();
        }

        private void btnDisplayUnsortedScores_Click(object sender, EventArgs e)
        {
            if (scoreList.Count < 1)
            {
                MessageBox.Show("There are no scores to display", "Null Set");
                return;
            }
            DisplayUnsortedList();
        }

        //Next Methods are all for data validation
        private bool IsPresent(TextBox textbox, string name)
        {
            if (textbox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textbox.Focus();
                return false;
            }

            return true;
        }

        private bool IsInt(TextBox textbox, string name)
        {
            int number = 0;
            if (int.TryParse(textbox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be an integer", "Entry Error");
                textbox.Clear();
                textbox.Focus();
                return false;
            }
        }

        private bool IsWithinRange(TextBox textbox, string name, int min, int max)
        {
            int number = Convert.ToInt16(textbox.Text);
            if (number > max || number < min)
            {
                MessageBox.Show(name + " must be between " + min.ToString() + " and " + max.ToString(), "Entry Error");
                textbox.Clear();
                textbox.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidForm()
        {
            return
                IsPresent(txtNewScore, "New Score") && IsInt(txtNewScore, "New Score") && IsWithinRange(txtNewScore, "New Score", 0, 100);

        }
        

    }
}
