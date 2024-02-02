namespace inheritance;

public class Wages : Employee
{
    public double rate { get; set; }
    public double hours { get; set; }
    
    public Wages() {}
    
    public Wages(string _id, string _name, string _address, string _phone, long _sin, string _dob, string _dept, double _rate, double _hours)
        : base(_id, _name, _address, _phone, _sin, _dob, _dept)
    {
        this.rate = _rate;
        this.hours = _hours;
    }


    public double GetPay()
    {
        return this.hours * this.rate;
    }

    public string ToString()
    {
        return base.ToString() + $"{base.ToString()}, Rate: {rate}, Hours: {hours}";
    }
}