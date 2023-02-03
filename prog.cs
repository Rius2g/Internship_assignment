namespace speed {

class Speed: IFormattble {
    private int speed;
    private string format; //need to store the format as well


    public Speed(int _speed)
    {
        speed = _speed; //set the speed when inited
        format = "m/s"; //standard format
    }
    
    public change_format() {
        if (format == "m/s") {
            format = "knots";
        } else {
            format = "m/s";
        }
    }

    public string ToString(string format) {
        if (format == "m/s") {
            return $"{speed} m/s";
        } 
        else {
            return $"{speed * 1,943} m/s";
        }
    }
}
}

namespace vessels {
class Vessel {
    private string name;
    private string yearBuilt;

    private string type;

    private Speed speed;

    public Vessel(string Name, string Year, string Type)
    {

        var current_year = DateTime.Now.Year;
        if (Name == null || Name == "")
        {
            throw new System.ArgumentException("Name cannot be null");
        }
        if (Year == null || Year == "")
        {
            throw new System.ArgumentException("Year cannot be null or empty");
        }
        if (int.Parse(Year) + 20 < current_year)
        {
            throw new System.ArgumentException("Vessel is too old");
        }
        if (Type == null || Type == "")
        {
            throw new System.ArgumentException("Type cannot be null or empty");
        }
        name = Name;
        yearBuilt = Year;
        type = Type;
        speed = new Speed(0);
    }

    public string GetName() 
    {
        return name;
    }

    public string GetYearBuilt() 
    {
        return yearBuilt;
    }

    public string GetType() //function to return the type
    {
        return type;
    }

    public void GetVesselInfo()
    {
        Console.WriteLine($"Name: {GetName()}");
        Console.WriteLine($"Year Built: {GetYearBuilt()}");
        Console.WriteLine($"Type: {GetType()}");
    }
    
    public override string ToString() {
        return $"Vessel: {name}";
    }

    }

class Ferry : Vessel {
    public int Passengers; //new info

//inherit the base class and set all Ferry class objects to Ferry typ
    public Ferry(string Name, string Year, int Passengers) : base(Name, Year, "Ferry") 
    {
        Passengers = Passengers; //set the new info
    }

    public int GetPassengers() //function to return the new info
    {
        return Passengers;
    }

    public void GetVesselInfo() //simply inherit the base function and add the new info
    {
        base.GetVesselInfo(); //inherit the base function
        Console.WriteLine($"Passengers: {GetPassengers()}"); //add the new info
    }

    }

class Tugboat : Vessel {
    private int maxForce; //new info

    public Tugboat(string Name, string Year, int MaxForce) : base(Name, Year, "Tugboat")
    {
        maxForce = MaxForce; //set the new info
    }

    public int GetMaxForce() //function to return the new info
    {
        return maxForce;
    }

    public void GetVesselInfo() //simply inherit the base function and add the new info
    {
        base.GetVesselInfo(); //inherit the base function
        Console.WriteLine($"Max Force: {GetMaxForce()}"); //add the new info
    }

    }

class submarine: Vessel {
    private int maxDepth; //new info

    public submarine(string Name, string Year, int MaxDepth) : base(Name, Year, "Submarine")
    {
        maxDepth = MaxDepth; //set the new info
    }

    public int GetMaxDepth() //function to return the new info
    {
        return maxDepth;
    }

    public void GetVesselInfo() //simply inherit the base function and add the new info
    {
        base.GetVesselInfo(); //inherit the base function
        Console.WriteLine($"Max Depth: {GetMaxDepth()}"); //add the new info to the function
    }

    }

}