abstract class Ingredient {
    protected string name;
    protected string quantity;

    public Ingredient(string name, string quantity) {
        this.name = name;
        this.quantity = quantity;
    }

    public string GetName() {
        return name;
    }

    public string GetQuantity() {
        return quantity;
    }

    public void SetQuantity(string newQuantity) {
        quantity = newQuantity;
    }

    public abstract void Display();

    public virtual string GetIngredientType() {
        return "Ingredient";
    }
}

class DryGood : Ingredient {
    public DryGood(string name, string quantity) : base(name, quantity) {
    }

    public override void Display() {
        Console.WriteLine(name + " - " + quantity);
    }

    public override string GetIngredientType() {
        return "Dry Good";
    }
}

class Produce : Ingredient {
    private string freshness;

    public Produce(string name, string quantity, string freshness) : base(name, quantity) {
        this.freshness = freshness;
    }

    public string GetFreshness() {
        return freshness;
    }

    public override void Display() {
        Console.WriteLine(name + " - " + quantity + " (" + freshness + ")");
    }

    public override string GetIngredientType() {
        return "Produce";
    }
}

class Dairy : Ingredient {
    public Dairy(string name, string quantity) : base(name, quantity) {
    }

    public override void Display() {
        Console.WriteLine(name + " - " + quantity);
    }

    public override string GetIngredientType() {
        return "Dairy";
    }
}

class Spice : Ingredient {
    private bool isOrganic;

    public Spice(string name, string quantity, bool isOrganic) : base(name, quantity) {
        this.isOrganic = isOrganic;
    }

    public bool IsOrganic() {
        return isOrganic;
    }

    public override void Display() {
        string organic = isOrganic ? "Organic" : "Regular";
        Console.WriteLine(name + " - " + quantity + " (" + organic + ")");
    }

    public override string GetIngredientType() {
        return "Spice";
    }
}