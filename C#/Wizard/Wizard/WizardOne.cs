using System;
class WizardOne
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
     
    public WizardOne(string name)
    {
        Name = name;
        Strength = 3;
        Intelligence = 25;
        Dexterity = 3;
        health = 50;
    }
     
    public WizardOne(string name, int str, int intel, int dex, int hp)
    {
        Name = name;
        Strength = str;
        Intelligence = intel;
        Dexterity = dex;
        health = hp;
    }
     
    // Build Attack method
    public int Attack(WizardOne target)
    {
        int dmg = Intelligence * 5;
        target.health -= dmg;
        this.health += dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.health;
    }

    public int Heal(Wizard.Human target){
        int returnHealth = target.Health - 10 * Intelligence;
        return returnHealth;
    }
}

