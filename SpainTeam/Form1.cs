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
            MessageBox.Show("Додати нову команду");

            string teamName = Interaction.InputBox("Введіть назву команди: ", "SpainCommand");
            string city = Interaction.InputBox("Введіть місто: ", "SpainCommand");

            var existingTeam = teamSv.GetAllTeams().FirstOrDefault(t => t.TeamName.Equals(teamName, StringComparison.OrdinalIgnoreCase) && t.City.Equals(city, StringComparison.OrdinalIgnoreCase));

            if (existingTeam != null)
            {
                MessageBox.Show("Команда вже існує у додатку.");
            }
            else
            {
                int wins = int.Parse(Interaction.InputBox("Введіть кількість перемог: ", "SpainCommand"));
                int losses = int.Parse(Interaction.InputBox("Введіть кількість поразок: ", "SpainCommand"));
                int draws = int.Parse(Interaction.InputBox("Введіть кількість нічиїх: ", "SpainCommand"));
                int goalsScored = int.Parse(Interaction.InputBox("Введіть кількість забитих голів: ", "SpainCommand"));
                int goalsConceded = int.Parse(Interaction.InputBox("Введіть кількість пропущених голів: ", "SpainCommand"));

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
                MessageBox.Show("Команду успішно додано.");
                LoadTeams();
            }
        }

        private void deleteteam_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Видалення команди.");

            string teamName = Interaction.InputBox("Введіть назву команди для видалення: ", "SpainCommand");
            string city = Interaction.InputBox("Введіть місто: ", "SpainCommand");

            var teamToDelete = teamSv.GetAllTeams().FirstOrDefault(t => t.TeamName.Equals(teamName, StringComparison.OrdinalIgnoreCase) && t.City.Equals(city, StringComparison.OrdinalIgnoreCase));

            if (teamToDelete != null)
            {
                MessageBox.Show($"Знайдена команда: {teamToDelete.TeamName} з міста {teamToDelete.City}");
                string confirmation = Interaction.InputBox("Ви впевнені, що хочете видалити цю команду? (y/n): ", "SpainCommand").ToLower();

                if (confirmation == "y")
                {
                    teamSv.DeleteTeam(teamToDelete);
                    MessageBox.Show("Команду успішно видалено.");
                    LoadTeams();
                }
                else
                {
                    MessageBox.Show("Видалення скасовано.");
                }
            }
            else
            {
                MessageBox.Show("Команду не знайдено.");
            }
        }

        private void updateteam_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Зміна даних існуючої команди.");

            string teamName = Interaction.InputBox("Введіть назву команди для редагування: ", "SpainCommand");
            string city = Interaction.InputBox("Введіть місто: ", "SpainCommand");

            var teamToUpdate = teamSv.GetAllTeams().FirstOrDefault(t => t.TeamName.Equals(teamName, StringComparison.OrdinalIgnoreCase) && t.City.Equals(city, StringComparison.OrdinalIgnoreCase));

            if (teamToUpdate != null)
            {
                MessageBox.Show($"Знайдена команда: {teamToUpdate.TeamName} з міста {teamToUpdate.City}");

                teamToUpdate.Wins = int.Parse(Interaction.InputBox("Введіть нову кількість перемог: ", "SpainCommand"));
                teamToUpdate.Losses = int.Parse(Interaction.InputBox("Введіть нову кількість поразок: ", "SpainCommand"));
                teamToUpdate.Draws = int.Parse(Interaction.InputBox("Введіть нову кількість нічиїх: ", "SpainCommand"));
                teamToUpdate.GoalsScored = int.Parse(Interaction.InputBox("Введіть нову кількість забитих голів: ", "SpainCommand"));
                teamToUpdate.GoalsConceded = int.Parse(Interaction.InputBox("Введіть нову кількість пропущених голів: ", "SpainCommand"));

                teamSv.UpdateTeam(teamToUpdate);
                MessageBox.Show("Дані команди успішно оновлено.");
                LoadTeams();
            }
            else
            {
                MessageBox.Show("Команду не знайдено.");
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
