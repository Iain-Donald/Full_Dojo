from classes import Character
from classes.ninja import Ninja
from classes.pirate import Pirate

player1Name = input("P1: What is the name of your character?")
player1Character = input("P1: Are you a pirate or a ninja?")

if(player1Character == "pirate"):
    player1 = Pirate(player1Name)
else:
    player1 = Ninja(player1Name)

player1.show_stats()

player2Name = input("P2: What is the name of your character?")
player2Character = input("P2: Are you a pirate or a ninja?")

if(player2Character == "pirate"):
    player2 = Pirate(player2Name)
else:
    player2 = Ninja(player2Name)

player2.show_stats()

print("---- game start ----")

#heal or attack players
def action(inputAction, offensivePlayer, player, weapon):
    if(inputAction == "heal"):
        offensivePlayer.heal()
    elif(inputAction == "attack"):
        offensivePlayer.attack(player, weapon)

#initialize action variable
inputAction = ""
weapon = ""

player1Display = (f'P1 ( {player1.returnType()} ):')
player2Display = (f'P2 ( {player2.returnType()} ):')


while(player1.health > 0 and player2.health > 0):
    #ask player 1 for action
    print(player1Display)
    inputAction = input("Attack or heal?")
    if(inputAction == "attack"):
        if(player1.returnType() == 'ninja'):
            weapon = input("Choose a weapon (short sword, star)")
        else:
            weapon = input("Choose a weapon (saber, pistol)")

    action(inputAction, player1, player2, weapon)

    #ask player 2 for action
    print(player2Display)
    inputAction = input("P2: Attack or heal?")
    if(inputAction == "attack"):
        if(player2.returnType() == 'ninja'):
            weapon = input("P2: Choose a weapon (short sword, star)")
        else:
            weapon = input("P2: Choose a weapon (saber, pistol)")
        
    action(inputAction, player2, player1, weapon)

    #show stats at end of each round
    player1.show_stats()
    player2.show_stats()

#say which player died
if(player1.health < 1):
    print(player1Name + " has died")
elif(player2.health < 1):
    print(player2Name + " has died")