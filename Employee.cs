namespace inheritance;

public abstract class Employee
{
    private string _id;
    private string _name;
    private string _address;
    private string _phone;
    private long _sin;
    private string _dob;
    private string _dept;

    public string Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }

    public string Phone
    {
        get { return _phone; }
        set { _phone = value; }
    }

    public long Sin
    {
        get { return _sin; }
        set { _sin = value; }
    }

    public string Dob
    {
        get { return _dob; }
        set { _dob = value; }
    }
    
    public string Dept
    {
        get { return _dept; }
        set { _dept = value; }
    }

    public Employee(){}

    public Employee(string id, string name, string address, string phone, long sin, string dob, string dept)
    {
        _id = id;
        _name = name;
        _address = address;
        _phone = phone;
        _sin = sin;
        _dob = dob;
        _dept = dept;
    }

    public abstract double GetWeeklyPay();

    public string ToString()
    {
        return
            $"ID: {_id}, Name: {_name}, Address: {_address}, Phone: {_phone}, SIN: {_sin}, DOB: {_dob}, Dept: {_dept}";
    }
}