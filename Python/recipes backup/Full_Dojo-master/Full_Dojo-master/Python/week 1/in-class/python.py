str1 = "aaaabbcdddaabb"
str2 = ""
str3 = "a"
str4 = "bbcc"

two_str1 = "a3b2c1d3"
two_str2 = "a3b2c12d10"


def stringDecode(letters):
    output = ""
    for i in range(0, len(letters)):
        if(letters[i].isdigit):
            for i in range(int(letters[i])):
                output += letters[i - 1]


    return output


def stringEncode(letters):
    if(len(letters) == 0):
        return ""
    tempChar = letters[0]
    letterCount = 0
    maxLetterCount = letterCount
    outputString = ""

    for i in range(0, len(letters)):
        if (i == len(letters) - 1):
            letterCount += 1
            outputString += str(letters[i - 1]) + str(letterCount)
        elif (letters[i] == tempChar):
            letterCount += 1
        else:
            outputString += str(letters[i - 1]) + str(letterCount)
            tempChar = letters[i]
            if(letterCount > maxLetterCount):
                maxLetterCount = letterCount
            letterCount = 1

    if (maxLetterCount < 3):
        return(letters)
    
    return(outputString)

print(stringEncode(str1))
print(stringDecode(two_str1))