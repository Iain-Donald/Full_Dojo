
const two_obj1 = { name: "Zaphod", charm: "high", morals: "dicey" };
const two_expected1 = { Zaphod: "name", high: "charm", dicey: "morals" };

const two_obj2 = { name: "Zaphod", charm: "high", morals: ["dicey", 'something'] };
const two_expected2 = { Zaphod: "name", high: "charm", dicey: "morals", something: "morals" };

const two_obj3 = { name: "Zaphod", charm: "high", morals: "dicey", something: "dicey" };
const two_expected3 = { Zaphod: "name", high: "charm", dicey: ["morals", "something"] };


function swap(obj){
    var inverted = {};
    for(var key in obj){
        console.log(Array.isArray(obj[key]));
        if(Array.isArray(obj[key])){

        } else {
            inverted[obj[key]] = key;
        }
    }
    return inverted;
}

console.log(swap(two_obj1))
console.log(swap(two_obj2))
console.log(swap(two_obj3))