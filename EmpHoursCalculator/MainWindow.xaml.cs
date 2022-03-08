using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EmpHoursCalculator
{
    public partial class MainWindow
    {
        private ObservableCollection<Employee> ListOfEmployees = new ObservableCollection<Employee>();
        private enum ShiftType
        {
            [Display(Name = "Day Shift")]
            DayShift,
            [Display(Name = "Night Shift")]
            NightShift,
            [Display(Name = "Split Shift")]
            SplitShift
        };
        public MainWindow()
        {
            InitializeComponent();
            lstNames.ItemsSource = ListOfEmployees;
            empShiftTypeInput.ItemsSource = Enum.GetValues(typeof(ShiftType)).Cast<ShiftType>();
        }




        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name;
            int hours;
            int shiftType;

            name = empNameInput.Text;
            hours = int.Parse(empHoursInput.Text);
            shiftType = (int)empShiftTypeInput.SelectedValue;




            if (name != null && hours != null && shiftType != null)
            {
                Employee dayEmp = new Employee(name, hours);

                ListOfEmployees.Add(dayEmp);

            }
        }
    }
}
