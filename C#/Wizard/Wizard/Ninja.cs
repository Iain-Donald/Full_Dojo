using System;
class Ninja
{
    public string Name;
    public int Strength;
    public int Intelligence;
    public int Dexterity;
    private int health;
     
    public int Health
    {
        get { return health; }
    }
     
    public Ninja(string name)
    {
        Name = name;
        Strength = 3;
        Intelligence = 3;
        Dexterity = 175;
        health = 100;
    }
     
    public Ninja(string name, int str, int intel, int dex, int hp)
    {
        Name = name;
        Strength = str;
        Intelligence = intel;
        Dexterity = dex;
        health = hp;
    }
     
    // Build Attack method
    public int Attack(Ninja target)
    {
        Random r = new Random();
        int dmg = Dexterity * 5;
        if(20 > r.Next(0, 100)) dmg += 10;
        target.health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.health;
    }

    public int Steal(Wizard.Human target){
        int returnHealth = target.Health - 5;
        this.health += 5;
        return returnHealth;
    }
}

