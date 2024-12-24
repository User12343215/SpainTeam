using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SpainTeam
{
    public partial class Form1 : Form
    {
        private readonly TeamService teamSv;
        private readonly PlayerService playerSv;
        private readonly MatchService matchSv;
        private System.Windows.Forms.DataGridView dataGridView1;
        private bool isAscending = true;
        public Form1()
        {
            InitializeComponent();
            teamSv = new TeamService();
            playerSv = new PlayerService();
            matchSv = new MatchService();

            dataGridView1.ReadOnly = true;
            dataGridView1.AutoGenerateColumns = true;
            LoadTeams();


        }

        private void LoadTeams()
        {
            var allTeams = teamSv.GetAllTeams();
            dataGridView1.DataSource = allTeams;
        }

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = SearchBar.Text.ToLower();
            var allTeams = teamSv.GetAllTeams();

            var searchResults = allTeams.Where(team =>
                team.TeamName.ToLower().Contains(searchQuery) ||
                team.City.ToLower().Contains(searchQuery)).ToList();

            dataGridView1.DataSource = searchResults;
        }

        private void SortByName_Click(object sender, EventArgs e)
        {
            var sortedTeams = teamSv.GetAllTeams()
                .OrderBy(t => t.TeamName)
            .ToList();

            dataGridView1.DataSource = sortedTeams;
        }

        private void SortByCity_Click(object sender, EventArgs e)
        {
            var sortedTeams = teamSv.GetAllTeams()
                .OrderBy(t => t.City)
            .ToList();

            dataGridView1.DataSource = sortedTeams;
        }

        private void SortByWins_Click(object sender, EventArgs e)
        {
            var sortedTeams = teamSv.GetAllTeams()
                .OrderByDescending(t => t.Wins)
            .ToList();

            dataGridView1.DataSource = sortedTeams;
        }

        private void SortByDraws_Click(object sender, EventArgs e)
        {
            var sortedTeams = teamSv.GetAllTeams()
                .OrderByDescending(t => t.Draws)
            .ToList();

            dataGridView1.DataSource = sortedTeams;
        }

        private void SortByLose_Click(object sender, EventArgs e)
        {
            var sortedTeams = teamSv.GetAllTeams()
                .OrderByDescending(t => t.Losses)
                .ToList();

            dataGridView1.DataSource = sortedTeams;
        }

        private void SortByGoals_Click(object sender, EventArgs e)
        {
            var sortedTeams = teamSv.GetAllTeams()
                .OrderByDescending(t => t.GoalsScored)
                .ToList();

            dataGridView1.DataSource = sortedTeams;
        }

        private void SortByConceded_Click(object sender, EventArgs e)
        {
            var sortedTeams = teamSv.GetAllTeams()
                .OrderByDescending(t => t.GoalsConceded)
                .ToList();

            dataGridView1.DataSource = sortedTeams;
        }

        private void addteam_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("������ ���� �������");

            string teamName = Interaction.InputBox("������ ����� �������: ", "SpainCommand");
            string city = Interaction.InputBox("������ ����: ", "SpainCommand");

            var existingTeam = teamSv.GetAllTeams().FirstOrDefault(t => t.TeamName.Equals(teamName, StringComparison.OrdinalIgnoreCase) && t.City.Equals(city, StringComparison.OrdinalIgnoreCase));

            if (existingTeam != null)
            {
                MessageBox.Show("������� ��� ���� � �������.");
            }
            else
            {
                int wins = int.Parse(Interaction.InputBox("������ ������� �������: ", "SpainCommand"));
                int losses = int.Parse(Interaction.InputBox("������ ������� �������: ", "SpainCommand"));
                int draws = int.Parse(Interaction.InputBox("������ ������� ����: ", "SpainCommand"));
                int goalsScored = int.Parse(Interaction.InputBox("������ ������� ������� ����: ", "SpainCommand"));
                int goalsConceded = int.Parse(Interaction.InputBox("������ ������� ���������� ����: ", "SpainCommand"));

                var newTeam = new Team
                {
                    TeamName = teamName,
                    City = city,
                    Wins = wins,
                    Losses = losses,
                    Draws = draws,
                    GoalsScored = goalsScored,
                    GoalsConceded = goalsConceded
                };

                teamSv.AddTeam(newTeam);
                MessageBox.Show("������� ������ ������.");
                LoadTeams();
            }
        }

        private void deleteteam_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("��������� �������.");

            string teamName = Interaction.InputBox("������ ����� ������� ��� ���������: ", "SpainCommand");
            string city = Interaction.InputBox("������ ����: ", "SpainCommand");

            var teamToDelete = teamSv.GetAllTeams().FirstOrDefault(t => t.TeamName.Equals(teamName, StringComparison.OrdinalIgnoreCase) && t.City.Equals(city, StringComparison.OrdinalIgnoreCase));

            if (teamToDelete != null)
            {
                MessageBox.Show($"�������� �������: {teamToDelete.TeamName} � ���� {teamToDelete.City}");
                string confirmation = Interaction.InputBox("�� �������, �� ������ �������� �� �������? (y/n): ", "SpainCommand").ToLower();

                if (confirmation == "y")
                {
                    teamSv.DeleteTeam(teamToDelete);
                    MessageBox.Show("������� ������ ��������.");
                    LoadTeams();
                }
                else
                {
                    MessageBox.Show("��������� ���������.");
                }
            }
            else
            {
                MessageBox.Show("������� �� ��������.");
            }
        }

        private void updateteam_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("���� ����� ������� �������.");

            string teamName = Interaction.InputBox("������ ����� ������� ��� �����������: ", "SpainCommand");
            string city = Interaction.InputBox("������ ����: ", "SpainCommand");

            var teamToUpdate = teamSv.GetAllTeams().FirstOrDefault(t => t.TeamName.Equals(teamName, StringComparison.OrdinalIgnoreCase) && t.City.Equals(city, StringComparison.OrdinalIgnoreCase));

            if (teamToUpdate != null)
            {
                MessageBox.Show($"�������� �������: {teamToUpdate.TeamName} � ���� {teamToUpdate.City}");

                teamToUpdate.Wins = int.Parse(Interaction.InputBox("������ ���� ������� �������: ", "SpainCommand"));
                teamToUpdate.Losses = int.Parse(Interaction.InputBox("������ ���� ������� �������: ", "SpainCommand"));
                teamToUpdate.Draws = int.Parse(Interaction.InputBox("������ ���� ������� ����: ", "SpainCommand"));
                teamToUpdate.GoalsScored = int.Parse(Interaction.InputBox("������ ���� ������� ������� ����: ", "SpainCommand"));
                teamToUpdate.GoalsConceded = int.Parse(Interaction.InputBox("������ ���� ������� ���������� ����: ", "SpainCommand"));

                teamSv.UpdateTeam(teamToUpdate);
                MessageBox.Show("��� ������� ������ ��������.");
                LoadTeams();
            }
            else
            {
                MessageBox.Show("������� �� ��������.");
            }
        }


        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            List<Team> sortedTeams = new List<Team>();

            if (isAscending)
            {
                sortedTeams = columnName switch
                {
                    "TeamName" => teamSv.GetAllTeams().OrderBy(t => t.TeamName).ToList(),
                    "City" => teamSv.GetAllTeams().OrderBy(t => t.City).ToList(),
                    "Wins" => teamSv.GetAllTeams().OrderBy(t => t.Wins).ToList(),
                    "Losses" => teamSv.GetAllTeams().OrderBy(t => t.Losses).ToList(),
                    "Draws" => teamSv.GetAllTeams().OrderBy(t => t.Draws).ToList(),
                    "GoalsScored" => teamSv.GetAllTeams().OrderBy(t => t.GoalsScored).ToList(),
                    "GoalsConceded" => teamSv.GetAllTeams().OrderBy(t => t.GoalsConceded).ToList(),
                    _ => teamSv.GetAllTeams()
                };
            }
            else
            {
                sortedTeams = columnName switch
                {
                    "TeamName" => teamSv.GetAllTeams().OrderByDescending(t => t.TeamName).ToList(),
                    "City" => teamSv.GetAllTeams().OrderByDescending(t => t.City).ToList(),
                    "Wins" => teamSv.GetAllTeams().OrderByDescending(t => t.Wins).ToList(),
                    "Losses" => teamSv.GetAllTeams().OrderByDescending(t => t.Losses).ToList(),
                    "Draws" => teamSv.GetAllTeams().OrderByDescending(t => t.Draws).ToList(),
                    "GoalsScored" => teamSv.GetAllTeams().OrderByDescending(t => t.GoalsScored).ToList(),
                    "GoalsConceded" => teamSv.GetAllTeams().OrderByDescending(t => t.GoalsConceded).ToList(),
                    _ => teamSv.GetAllTeams()
                };
            }

            isAscending = !isAscending;
            dataGridView1.DataSource = sortedTeams;
        }
    }
}
