namespace inheritance;

public class Salaried : Employee
{
    private double _salary;

    public double salary
    {
        get { return _salary; }
        set { this._salary = value; }
    }
    
    public Salaried() {}
    
    public Salaried(string _id, string _name, string _address, string _phone, long _sin, string _dob, string _dept, double _salary)
        : base(_id, _name, _address, _phone, _sin, _dob, _dept)
    {
        this.salary = _salary;
    }


    public double GetPay()
    {
        return this.salary;
    }

    public string ToString()
    {
        return base.ToString() + $"{base.ToString()}, Salary: {salary}";
    }
}