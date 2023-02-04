using System.Globalization;
using System;

class Speed: IFormattable {
    
    private int _speed;

    public Speed(int speed)
    {
        _speed = speed; //set the speed when initialized
    }
    
   public decimal Ms {
        get { return _speed; }
    }

    public decimal Knots {
        get { return _speed * 1.94384m; }
    }

    public override string ToString()
    {
        return this.ToString("knots", CultureInfo.CurrentCulture);
    }

    public string ToString(string format)
    {
        return this.ToString(format, CultureInfo.CurrentCulture);
    }

    public string ToString(string format, IFormatProvider provider) {
        if(String.IsNullOrEmpty(format)) {
            format = "m/s";
        }
        if (provider == null) provider = CultureInfo.CurrentCulture;
        switch(format){
            case "m/s":
                return _speed.ToString(provider) + " m/s";
            case "knots":
                return (_speed * 1.94384).ToString(provider) + " knots";
            default:
                throw new ArgumentException(String.Format("The {0} format string is not supported.", format));
        }
    }
    }

namespace Vessels {
class Vessel {
    private string _name;
    private string _yearBuilt;

    private string _type;

    private Speed _speed;

    public Vessel(string name, string year, string type, int speed)
    {

        var currentYear = DateTime.Now.Year;
        if (String.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name cannot be null or empty");
        }
        if (String.IsNullOrEmpty(year))
        {
            throw new ArgumentException("Year cannot be null or empty");
        }
        if (int.Parse(year) + 20 < currentYear)
        {
            throw new ArgumentException("Vessel is too old");
        }
        if (String.IsNullOrEmpty(type))
        {
            throw new ArgumentException("Type cannot be null or empty");
        }
        _name = name;
        _yearBuilt = year;
        _type = type;
        _speed = new Speed(speed);
    }

    public string GetName() 
    {
        return _name;
    }

    public string GetYearBuilt()
    {
        return _yearBuilt;
    }

    public string GetVesselType()
    {
        return _type;
    }

    public string GetSpeed(string format)
    {
        return _speed.ToString(format);
    }

    public virtual void GetVesselInfo()
    {
        Console.WriteLine($"Name: {GetName()}");
        Console.WriteLine($"Year Built: {GetYearBuilt()}");
        Console.WriteLine($"Type: {GetType()}");
    }
    
    public override string ToString() {
        return $"Vessel: {_name}";
    }

    }

class Ferry : Vessel {
    public int Passengers; //new info

//inherit the base class and set all Ferry class objects to Ferry typ
    public Ferry(string name, string year, int passengers, int speed) : base(name, year, "Ferry", speed) 
    {
        Passengers = passengers; //set the new info
    }

    public int GetPassengers() //function to return the new info
    {
        return Passengers;
    }

    public override void GetVesselInfo() //simply inherit the base function and add the new info
    {
        base.GetVesselInfo(); //inherit the base function
        Console.WriteLine($"Passengers: {GetPassengers()}"); //add the new info
    }

    }

class Tugboat : Vessel {
    private int _maxForce; //new info

    public Tugboat(string name, string year, int maxForce, int speed) : base(name, year, "Tugboat", speed)
    {
        _maxForce = maxForce; //set the new info
    }

    public int GetMaxForce() //function to return the new info
    {
        return _maxForce;
    }

    public override void GetVesselInfo() //simply inherit the base function and add the new info
    {
        base.GetVesselInfo(); //inherit the base function
        Console.WriteLine($"Max Force: {GetMaxForce()}"); //add the new info
    }

    }

class Submarine: Vessel {
    private int _maxDepth; //new info

    public Submarine(string name, string year, int maxDepth, int speed) : base(name, year, "Submarine", speed)
    {
        _maxDepth = maxDepth; //set the new info
    }

    public int GetMaxDepth() //function to return the new info
    {
        return _maxDepth;
    }

    public override void GetVesselInfo() //simply inherit the base function and add the new info
    {
        base.GetVesselInfo(); //inherit the base function
        Console.WriteLine($"Max Depth: {GetMaxDepth()}"); //add the new info to the function
    }

    }

}
