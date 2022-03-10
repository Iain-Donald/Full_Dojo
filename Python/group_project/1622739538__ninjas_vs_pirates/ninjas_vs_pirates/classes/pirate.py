import random
class Pirate:

    def __init__( self , name ):
        self.name = name
        self.strength = 15
        self.speed = 3
        self.health = 100

    def show_stats( self ):
        print(f"Name: {self.name}\nStrength: {self.strength}\nSpeed: {self.speed}\nHealth: {self.health}\n")

    def attack ( self , ninja, weapon ):
        weaponDamage = 0
        if(weapon == "saber"):
            weaponDamage = 10
        elif(weapon == "pistol"):
            weaponDamage = random.randint(1, 30)

        ninja.health -= self.strength + weaponDamage
        return self

    def heal( self ):
        if(self.health > 75):
            self.health += 100 - self.health
        else:
            self.health += 25

    def returnType( self ):
        type = "pirate"
        return type
        


