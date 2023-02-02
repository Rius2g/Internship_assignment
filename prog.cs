class Vessel {
    private string name;
    private string yearBuilt;

    public Vessel(string Name, string Year);

    public string GetName();
    public string GetYearBuilt();

    public override string ToString() {
        return $"Vessel: {name}";
    }
}

class Ferry : Vessel {
    public int Passengers;
}

class Tugboat : Vessel {
    private int maxForce;
}

class submarine: Vessel {
    private int maxDepth;
}





