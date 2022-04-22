using System;
class Samurai
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
     
    public Samurai(string name)
    {
        Name = name;
        Strength = 3;
        Intelligence = 3;
        Dexterity = 3;
        health = 200;
    }
     
    public Samurai(string name, int str, int intel, int dex, int hp)
    {
        Name = name;
        Strength = str;
        Intelligence = intel;
        Dexterity = dex;
        health = hp;
    }
     
    // Build Attack method
    public int Attack(Samurai target)
    {
        if(target.health < 50) target.health = 0;
        return target.health;
    }

    public int Meditate(Samurai target){
        target.health = 200;
        return target.health;
    }
}

