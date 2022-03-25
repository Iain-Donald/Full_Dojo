var out = "";
for(var i = 0; i <= 100; i++){
    if (i % 3 == 0){
        out += "Fizz";
        if (i % 5 == 0){
            out += "Buzz";
        }
    } else if (i % 5 == 0){
        out += "Buzz";
    } else {
        out += i;
    }
    console.log(out);
    out = "";
}