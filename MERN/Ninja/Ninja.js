class Ninja {
    constructor(name, health) {
        this.name = name;
        this.health = health;
        this.speed = 3;
        this.strength = 3;
    }

    sayName() {
        return this.name;
    }

    showStats() {
        console.log("Name: ", this.name, "Health: ", this.health, "Speed: ", this.speed, "Strength: ", this.strength);
    }

    drinkSake() {
        this.health += 10;
    }
}

const firstNinja = new Ninja("Samurai", 100);
firstNinja.showStats();

class Sensei extends Ninja {
    constructor(name, health) {
        super(name, health);
        this.speed = 3;
        this.strength = 3;
        this.wisdom = 10;
    }

    sayName() {
        return this.name;
    }

    showStats() {
        console.log("Name: ", this.name, "Health: ", this.health, "Speed: ", this.speed, "Strength: ", this.strength);
    }

    drinkSake() {
        this.health += 10;
    }

    speakWisdom() {
        return "What one programmer can do in one month, two programmers can do in two months";
    }
}

const firstSensei = new Sensei("2nd Ninja", 90);
firstSensei.showStats();