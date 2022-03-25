/* 
Parens Valid
Given an str that has parenthesis in it
return whether the parenthesis are valid
*/

const str1 = "Y(3(p)p(3)r)s";
const expected1 = true;

const str2 = "N(0(p)3";
const expected2 = false;
// Explanation: not every parenthesis is closed.

const str3 = "N(0)t ) 0(k";
const expected3 = false;
// Explanation: because the second ")" is premature: there is nothing open for it to close.

const str4 = "a(b))(c";
// const str4 = "a)b))(c";
const expected4 = false;
// Explanation: same number of opens and closes but the 2nd closing closes nothing.

/*
 * Determines whether the parenthesis in the given string are valid.
 * Each opening parenthesis must have exactly one closing parenthesis.
 * - Time: O(?).
 * - Space: O(?).
 * @param {string} str
 * @returns {boolean} Whether the parenthesis are valid.
 */
function parensValid(str) {
    newStr = '';
    for (var i = 0; i < str.length; i++){
        if(str[i] == '(' || str[i] == ')'){
            newStr += str[i];
        }
    }

    if(newStr.length % 2 != 0){
        return false;
    }

    var isValid = true;
    for(var i = 0; i < newStr.length / 2; i++){
        if (newStr[i] == newStr[newStr.length - 1 - i]){
            isValid = false;
        }
    }
    return isValid
}

console.log(parensValid(str1));
console.log(parensValid(str2));
console.log(parensValid(str3));
console.log(parensValid(str4));

// **

/* 
Braces Valid
Given a string sequence of parentheses, braces and brackets, determine whether it is valid. 
*/

const two_str1 = "W(a{t}s[o(n{ c}o)m]e )h[e{r}e]!";
const two_expected1 = true;

const two_str2 = "D(i{a}l[ t]o)n{e";
const two_expected2 = false;

const two_str3 = "A(1)s[O (n]0{t) 0}k";
const two_expected3 = false;

/**
 * Determines whether the string's braces, brackets, and parenthesis are valid
 * based on the order and amount of opening and closing pairs.
 * - Time: O(?).
 * - Space: O(?).
 * @param {string} str
 * @returns {boolean} Whether the given strings braces are valid.
 */
function bracesValid(str) {
    newStr = '';
    for (var i = 0; i < str.length; i++){
        if(str[i] == '(' || str[i] == ')' || str[i] == '[' || str[i] == ']' || str[i] == '{' || str[i] == '}'){
            newStr += str[i];
        }
        
    }

    for(var i = 0; i < newStr.length - 1; i++){
        var a = newStr[i];
        var b = newStr[i + 1];

        if(a == '('){
            if(b == '}' || b == ']'){
                return false;
            }
        }

        if(a == '['){
            if(b == '}' || b == ')'){
                return false;
            }
        }

        if(a == '{'){
            if(b == ')' || b == ']'){
                return false;
            }
        }
    }

    var lastCharacter = newStr[newStr.length - 1];
    if(lastCharacter == '(' || lastCharacter == '{' || lastCharacter == '['){
        return false;
    }

    return true;
}

console.log("\n\n" + bracesValid(two_str1));
console.log(bracesValid(two_str2));
console.log(bracesValid(two_str3));