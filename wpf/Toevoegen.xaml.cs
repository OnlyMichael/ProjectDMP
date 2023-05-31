using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Policy;
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

namespace wpf
{
    /// <summary>
    /// Interaction logic for Toevoegen.xaml
    /// </summary>
    public partial class Toevoegen : UserControl
    {
        public Toevoegen()
        {
            InitializeComponent();
        }
    }

    public partial class EmployeesCrudView : UserControl
    {
        private EmployeeRepository employeeRepository = new EmployeeRepository();
        private JobRepository jobRepository = new JobRepository();
        private PublisherRepository publishersRepository = new PublisherRepository();

        public EmployeesCrudView()
        {
            InitializeComponent();
            GetData();
        }

        private void GetData()
        {
            lbEmployees.ItemsSource = employeeRepository.OphalenEmployeesPublishersJobs();
            cbJob.ItemsSource = jobRepository.OphalenJobs();
            cbJob.SelectedValuePath = "Id";
            cbPublisher.ItemsSource = publishersRepository.OphalenPublishers();
            cbPublisher.SelectedValuePath = "Id";
        }

        private void btnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (lbEmployees.SelectedItem != null)
            {
                if (MessageBox.Show("Ben je zeker?", "Bevestiging verwijderen", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    // Verwijder employee
                    if (employeeRepository.DeleteEmployee(((Employee)lbEmployees.SelectedItem).Id))
                    {
                        MessageBox.Show("Employee werd verwijderd");
                        GetData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Je moet een employee selecteren!");
            }
        }

        private void SetData(int employeeId)
        {
            //Get employee
            Employee emp = employeeRepository.OphalenEmployeeViaPK(employeeId);

            if (emp != null)
            {
                txtEmpId.Text = emp.Id.ToString();
                txtAchternaam.Text = emp.LastName;
                txtVoornaam.Text = emp.FirstName;
                cbJob.SelectedValue = emp.JobId;
                cbPublisher.SelectedValue = emp.PublisherId;
                dpHireDate.Text = emp.HireDate.ToShortDateString();
            }
        }

        private void lbEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbEmployees.SelectedItem != null)
            {
                SetData(((Employee)lbEmployees.SelectedItem).Id);
            }
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            Save(true);
        }

        private void Save(bool isInsert)
        {
            string error = Valideer();
            Employee emp = new Employee()
            {
                Id = isInsert ? 0 : int.Parse(txtEmpId.Text),
                FirstName = txtVoornaam.Text,
                LastName = txtAchternaam.Text,
                JobId = ((Job)cbJob.SelectedItem).Id,
                PublisherId = ((Publisher)cbPublisher.SelectedItem).Id,
                HireDate = dpHireDate.SelectedDate.Value
            };

            if (string.IsNullOrEmpty(error))
            {
                if (isInsert)
                {
                    employeeRepository.InsertEmployee(emp);
                }
                else
                {
                    employeeRepository.UpdateEmployee(emp);
                }
                GetData();
                ResetForm();
            }
            else
            {
                MessageBox.Show(error);
            }
        }

        private string Valideer()
        {
            string fout = "";

            if (cbJob.SelectedItem == null)
            {
                fout += "Je moet verplicht een job selecteren" + Environment.NewLine;
            }
            if (cbPublisher.SelectedItem == null)
            {
                fout += "Je moet verplicht een publisher selecteren" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtVoornaam.Text))
            {
                fout += "Voornaam is verplicht" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtAchternaam.Text))
            {
                fout += "Achernaaam is verplicht" + Environment.NewLine;
            }
            if (!dpHireDate.SelectedDate.HasValue)
            {
                fout += "Huur datum is verplicht" + Environment.NewLine;
            }

            return fout;
        }

        private void ResetForm()
        {
            txtEmpId.Text = "";
            txtVoornaam.Text = "";
            txtAchternaam.Text = "";
            cbJob.SelectedItem = null;
            cbPublisher.SelectedItem = null;
            dpHireDate.SelectedDate = null;
        }
    }
}