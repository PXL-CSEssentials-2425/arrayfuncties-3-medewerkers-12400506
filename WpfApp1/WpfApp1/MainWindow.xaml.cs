using System.Printing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] _medewerkers = {"Kristof","Sander","Koen"};
        private string[] _medewerkersNummers = {"M01","M02","M03"};
        private decimal[] _medewerkersSalarissen = {0,0,0};
        StringBuilder _sb = new StringBuilder();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            salaryTextBox.IsEnabled = false;
            updateButton.IsEnabled = false;
            salaryTextBox.Clear();
            OutPut();

        }

        private void OutPut()
        {
            namenListBox.Items.Clear();
            for (int i = 0; i < _medewerkersNummers.Length; i++)
            {
                _sb.AppendLine($" {_medewerkersNummers[i]} : {_medewerkers[i]} : {_medewerkersSalarissen[i]:c}");
                string result = _sb.ToString();
                ListBoxItem item = new ListBoxItem();
                namenListBox.Items.Add(result);
                _sb.Clear();
            }
        }

        private void namenListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateButton.IsEnabled = true;
            salaryTextBox.IsEnabled = true;

            if (namenListBox.SelectedIndex >= 0)
            {
                int amount = namenListBox.SelectedIndex;
                salaryTextBox.Text = _medewerkersSalarissen[amount].ToString();
            }
            else
            {
                salaryTextBox.Text = string.Empty;
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            int amount = namenListBox.SelectedIndex;


                if (amount >= 0 && amount < _medewerkersSalarissen.Length)
                {
                    if (decimal.TryParse(salaryTextBox.Text, out decimal newSalary))
                    {

                        _medewerkersSalarissen[amount] = newSalary;
                        namenListBox.Items.Clear();
                        OutPut();
                    }
                    else
                    {
                    MessageBox.Show("Kan tekst niet omzetten naar salaris");
                    }
                }

            Window_Loaded(sender, e);
        }
    }
}