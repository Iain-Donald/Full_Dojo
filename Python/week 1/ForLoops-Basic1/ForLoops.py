print("basic")
from pyclbr import Function
from time import process_time_ns


for i in range(151):
    print(i)

print("multiples of five")
for i in range(5, 1001, 5):
    print(i)

print("counting, the dojo way")
for i in range(1, 101):
    if(i % 5 == 0):
        if(i % 10 == 0):
            print("Coding Dojo")
        else:
            print("Coding")
    else:
        print(i)

print("whoa. that sucker's huge")
sum = 0
for i in range(1, 500000, 2):
    sum += i
print("Sum", sum)

print("countdown by fours")
for i in range(2018, 0, -4):
    print(i)

print("flexible counter")
def flexCounter(low, high, mult):
    for i in range(low, high + 1):
        if(i % mult == 0):
            print(i)

flexCounter(2, 9, 3)