class Ninja:

    def __init__( self , name ):
        self.name = name
        self.strength = 10
        self.speed = 5
        self.health = 100
    
    def show_stats( self ):
        print(f"Name: {self.name}\nStrength: {self.strength}\nSpeed: {self.speed}\nHealth: {self.health}\n")

    def attack( self , pirate, weapon ):
        weaponDamage = 0
        if(weapon == "star"):
            weaponDamage = 5
        elif(weapon == "short sword"):
            weaponDamage = 7
        pirate.health -= self.strength + weaponDamage
        return self

    def heal( self ):
        if(self.health > 75):
            self.health += 100 - self.health
        else:
            self.health += 35

    def returnType( self ):
        type = "ninja"
        return type