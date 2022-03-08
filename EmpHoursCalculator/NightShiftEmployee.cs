
namespace EmpHoursCalculator
{
    class NightShiftEmployee : Employee
    {
        public NightShiftEmployee(string _employeeName, int _empHours) : base(_employeeName, _empHours)
        {

        }
        //Calculates Breaks Based of Night Shift
        public override int CalculateBreaks(int hoursWorked)
        {
            int breakTime = hoursWorked * 15;

            int numberOf = (hoursWorked * 60) / 240;

            int additionalMinutes = numberOf * 30;

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
