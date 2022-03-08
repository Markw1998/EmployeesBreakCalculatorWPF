
namespace EmpHoursCalculator
{
    class SplitShiftEmployee : Employee
    {
        public SplitShiftEmployee(string _employeeName, int _empHours) : base(_employeeName, _empHours)
        {
        }
        //Calculates Breaks Based of Split Shift
        public override int CalculateBreaks(int hoursWorked)
        {
            int breakTime = hoursWorked * 10;

            int numberOf = (hoursWorked * 60) / 180;

            int additionalMinutes = numberOf * 20;

            //Setting property to use to populate Break Entitlment Text Box
            this.EmpBreakTime = breakTime + additionalMinutes;

            // Break out and return the value
            return breakTime + additionalMinutes;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
