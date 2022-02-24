var countpositives = 0;
var numbers = [3, 4, -2, 7, 16, -8, 0];

for(var i = 0; i < numbers.length; i++) if(numbers[i] > 0) countpositives ++;

console.log("there are " + countpositives + " positive values");