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


        //Add Score to the list
        private void AddScore()
        {
            int newScore = Convert.ToInt16(txtNewScore.Text);
            scoreList.Add(newScore);
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
            txtAverage.Text = Convert.ToString(AverageScores());
            txtScoreCount.Text = Convert.ToString(CountScores());
            txtScoreTotal.Text = Convert.ToString(TotalScores());

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
            MessageBox.Show(fullScoreList);
        }
        //diplays a sorted list
        private void DisplaySortedList()
        {
            SortList();
            string fullScoreList = "";
            foreach (int score in sortedScoreList)
            {
                fullScoreList = fullScoreList + score.ToString() + "\n";
            }
            MessageBox.Show(fullScoreList);

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
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
            DisplaySortedList();
        }

        private void btnDisplayUnsortedScores_Click(object sender, EventArgs e)
        {
            DisplayUnsortedList();
        }

        

    }
}
