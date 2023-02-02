class Speed: IFormattble {
    private int speed;
    private string format; //need to store the format as well


    public Speed(int _speed)
    {
        speed = _speed; //set the speed when inited
        format = "m/s"; //standard format
    }
    
    public change_format(string _format) {
        if (_format != "m/s" && _format != "knots") {
            throw new System.ArgumentException("Format must be either m/s or knots");
        }
        format = _format;
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

    public string GetType()
    {
        return type;
    }

    public void GetVesselInfo(string propertyName, int propertyValue)
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Year Built: {yearBuilt}");
        Console.WriteLine($"Type: {type}");
        Console.WriteLine($"{propertyName}: {propertyValue}");
    }
    

    public override string ToString() {
        return $"Vessel: {name}";
    }


}

class Ferry : Vessel {
    public int Passengers;

    public Ferry(string Name, string Year, int Passengers) : base(Name, Year, "Ferry")
    {
        Passengers = Passengers;
    }
}

class Tugboat : Vessel {
    private int maxForce;

    public Tugboat(string Name, string Year, int MaxForce) : base(Name, Year, "Tugboat")
    {
        maxForce = MaxForce;
    }
}

class submarine: Vessel {
    private int maxDepth;

    public submarine(string Name, string Year, int MaxDepth) : base(Name, Year, "Submarine")
    {
        maxDepth = MaxDepth;
    }

}





