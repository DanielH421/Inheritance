namespace inheritance;

class Program
{

    static void Main(String[] args)
    {
        // I am very sorry to whoever reads this line. I am sure there is a better way.
        string[] lines = File.ReadAllLines("../../../res/employees.txt");

        List<Employee> employees = new List<Employee>();

        foreach (string line in lines)
        {
            employees.Add(getEmployee(line));
        }

        double total_pay = totalWeekly(employees);

        Employee highest_pay = getHighestPaid(employees);
        Employee lowest_pay = getLowestPaid(employees);

        

        double average = total_pay / employees.Count;

        Console.WriteLine($"The total weekly payout is ${total_pay}.");
        Console.WriteLine($"The average weekly pay is ${average}.");
        Console.WriteLine($"The highest paid employee is {highest_pay.Name} at ${highest_pay.GetWeeklyPay()} per week.");
        Console.WriteLine($"The lowest paid employee is {lowest_pay.Name} at ${highest_pay.GetWeeklyPay()} per week.");

        double[] count_results = rolePercentage(employees);

        Console.WriteLine($"The percentage of employees working as salaried is {count_results[0] * 100}%");
        Console.WriteLine($"The percentage of employees working as waged is {count_results[1] * 100}%");
        Console.WriteLine($"The percentage of employees working as part time is {count_results[2] * 100}%");



    }



    // given the line from the file, this functions splits it and returns the proper employee value
    static Employee getEmployee(string values)
    {
        // split and parse everything
        string[] split = values.Split(':');
        int type = (int)Char.GetNumericValue(split[0][0]);
        string id = split[0];
        string name = split[1];
        string address = split[2];
        string phone = split[3];
        long sin = long.Parse(split[4]);
        string dob = split[5];
        string dept = split[6];

        // Check the type from ID and return based on that
        if (type >= 0 && type <= 4)
        {
            double salary = double.Parse(split[7]);
            return new Salaried(id, name, address, phone, sin, dob, dept, salary);
        }
        else if (type >= 5 && type <= 7)
        {
            double rate = double.Parse(split[7]);
            double hours = double.Parse(split[8]);
            return new Wages(id, name, address, phone, sin, dob, dept, rate, hours);
        }
        else
        {
            double rate = double.Parse(split[7]);
            double hours = double.Parse(split[8]);
            return new PartTime(id, name, address, phone, sin, dob, dept, rate, hours);
        }

        // the employee's ID is null
        return null;
    }
    


    // loops through a list of employees and returns the highest paid
    static Employee getHighestPaid(List<Employee> employees)
    {
        Employee highest_pay = null;
        foreach (Employee employee in employees)
        {
            double weekly = employee.GetWeeklyPay();
            if (highest_pay == null)
            {
                highest_pay = employee;
            }
            else
            {
                if (highest_pay.GetWeeklyPay() < weekly)
                {
                    highest_pay = employee;
                }
            }
        }
        return highest_pay;
    }


    // loops through a list of employees and returns the lowest paid
    static Employee getLowestPaid(List<Employee> employees)
    {
        Employee lowest_pay = null;
        foreach(Employee employee in employees)
        {
            double weekly = employee.GetWeeklyPay();
            if (lowest_pay == null)
            {
                lowest_pay = employee;
            }
            else
            {
                if (lowest_pay.GetWeeklyPay() > weekly)
                {
                    lowest_pay = employee;
                }
            }
        }
        return lowest_pay;
    }


    // given a list of employees, total all of their weekly wages
    static double totalWeekly(List<Employee> employees)
    {
        double total_pay = 0;
        foreach (Employee employee in employees)
        {
            double weekly = employee.GetWeeklyPay();
            total_pay += weekly;
        }
        return total_pay;
    }

    
    // 0 = salary, 1 = wages, 2 = part time
    // given a list of employees, check the type and add to types total.
    // return array of doubles after doing some math to calculate percentage
    static double[] rolePercentage(List<Employee> employees)
    {
        int salary_count = 0;
        int wages_count = 0;
        int part_time_count = 0;

        foreach (Employee employee in employees)
        {
            if (employee.GetType() == typeof(Salaried))
            {
                salary_count++;
            }

            if (employee.GetType() == typeof(Wages))
            {
                wages_count++;
            }

            if (employee.GetType() == typeof(PartTime))
            {
                part_time_count++;
            }
        }

   
        // for some reason all of these need to be casted to double. this is kind of gross.
        return new double[] { ((double) salary_count / employees.Count), ((double) wages_count / employees.Count), ((double) part_time_count / employees.Count) };
    }

}