using System;

class FoodItem {
    private string name;
    private string category;
    private string quantity;

    public FoodItem(string name, string category, string quantity) {
        this.name = name;
        this.category = category;
        this.quantity = quantity;
    }

    public string GetName() {
        return name;
    }

    public string GetCategory() {
        return category;
    }

    public string GetQuantity() {
        return quantity;
    }

    public void SetQuantity(string newQuantity) {
        quantity = newQuantity;
    }

    public void Display() {
        Console.WriteLine(name + " | " + category + " | " + quantity);
    }
}