class Sensei extends Ninja {
    Sensei(name, health) {
        super(name, health);
        var speed = 3;
        var strength = 3;
        var wisdom = 10;
    }

    sayName() {
        return this.name;
    }

    showStats() {
        var stats = new Array(this.name, strength, speed, health);
        return stats;
    }

    drinkSake() {
        this.health += 10;
    }

    speakWisdom() {
        return "What one programmer can do in one month, two programmers can do in two months";
    }
}