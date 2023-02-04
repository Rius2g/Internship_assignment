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

    //basic stuff, following C# docs
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
        //need to check if the year/name/type is valid if not throw an exception
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
        //set the info since it is valid
        _name = name;
        _yearBuilt = year;
        _type = type;
        _speed = new Speed(speed);
    }

    public string GetName() //returns the name of the vessel need this because the name is private
    {
        return _name;
    }

    public string GetYearBuilt() //returns the year the vessel was built because the year is private
    {
        return _yearBuilt;
    }

    public string GetVesselType() //returns the type of vessel because the type is private
    {
        return _type;
    }

    public string GetSpeed(string format) //returns the speed of the vessel because the speed is private
    {
        return _speed.ToString(format);
    }

    public virtual void GetVesselInfo() //prints out all the info from th ToString function
    {
        Console.WriteLine(ToString());
    }
    
    public override string ToString() //returns all the info about the vessel
    { 
        return $"Vessel: [{_name}] Year Built: [{_yearBuilt}] Type: [{_type}] Speed: [{_speed}]";
    }

    }

class Ferry : Vessel {
    public int Passengers; //new info

//inherit the base class and set all Ferry class objects to Ferry type
    public Ferry(string name, string year, int passengers, int speed) : base(name, year, "Ferry", speed) 
    {
        Passengers = passengers; //set the new info
    }

    public int GetPassengers() //function to return the new info
    {
        return Passengers;
    }

    public override string ToString()
    {        //inherit the base function
        return $"{base.ToString()} Passengers: [{Passengers}]"; //add the new info to the base function
    }

    }

class Tugboat : Vessel {
    private int _maxForce; //new info

    //constructor to set the new info with type as Tugboat set in stone.
    public Tugboat(string name, string year, int maxForce, int speed) : base(name, year, "Tugboat", speed) 
    {
        _maxForce = maxForce; //set the new info
    }

    public int GetMaxForce() //function to return the new info
    {
        return _maxForce;
    }


    public override string ToString()
    {
        return $"{base.ToString()} MaxForce: [{_maxForce}]"; //add the new info to the base function 
    }

    }

class Submarine: Vessel {
    private int _maxDepth; //new info

    //constructor to set the new info with type as Submarine set in stone.
    public Submarine(string name, string year, int maxDepth, int speed) : base(name, year, "Submarine", speed)
    {
        _maxDepth = maxDepth; //set the new info
    }

    public int GetMaxDepth() //function to return the new info, need this since the info is private
    {
        return _maxDepth;
    }


    public override string ToString()
    {    //inherit the base function
        return $"{base.ToString()} Max Depth: [{_maxDepth}] "; //add the new info to the base function
    }

    }

}
