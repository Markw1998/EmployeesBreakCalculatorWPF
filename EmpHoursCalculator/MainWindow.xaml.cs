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


        private void calcButton_Click(object sender, RoutedEventArgs e)
        {
            string name;
            int hours;
            int shiftType;

            name = empNameInput.Text;
            hours = int.Parse(empHoursInput.Text);
            shiftType = (int)empShiftTypeInput.SelectedValue;


            switch (shiftType)
            {
                case 0:
                    Employee dayEmp = new Employee(name, hours);

                    dayEmp.CalculateBreaks(hours);

                    ListOfEmployees.Add(dayEmp);

                    entitlementBox.Text = dayEmp.EmpBreakTime.ToString() + " minutes";

                    ClearValues();

                    break;
                case 1:
                    Employee nightEmp = new NightShiftEmployee(name, hours);

                    nightEmp.CalculateBreaks(hours);

                    ListOfEmployees.Add(nightEmp);

                    entitlementBox.Text = nightEmp.EmpBreakTime.ToString() + " minutes";

                    ClearValues();

                    break;

                case 2:

                    Employee splitEmp = new SplitShiftEmployee(name, hours);

                    splitEmp.CalculateBreaks(hours);

                    ListOfEmployees.Add(splitEmp);

                    entitlementBox.Text = splitEmp.EmpBreakTime.ToString() + " minutes";

                    ClearValues();

                    break;

                default:
                    ClearValues();
                    break;
            }
        }
        private void ClearValues()
        {
            empNameInput.Clear();
            empHoursInput.Clear();
            empShiftTypeInput.SelectedIndex = -1;

        }

        private void clearList_Click(object sender, RoutedEventArgs e)
        {
            this.ListOfEmployees.Clear();
        }
    }
}
