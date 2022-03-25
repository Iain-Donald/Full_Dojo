"""x = [ [5,2,3], [10,8,9] ] 
students = [
    {'first_name':  'Michael', 'last_name' : 'Jordan'},
    {'first_name' : 'John', 'last_name' : 'Rosales'}
]
sports_directory = {
    'basketball' : ['Kobe', 'Jordan', 'James', 'Curry'],
    'soccer' : ['Messi', 'Ronaldo', 'Rooney']
}
z = [ {'x': 10, 'y': 20} ]

print("---- Q1, 3 ----")
x[1][0] = 15
print(x[1][0])

print("---- Q1, 3 ----")
students[0]['last_name'] = 'bryant'
print(students[0]['last_name'])

print("---- Q1, 3 ----")
sports_directory['soccer'][0] = 'Andres'
print(sports_directory['soccer'][0])

print("---- Q1, 4 ----")
z[0]['y'] = 30
print(z[0]['y'])

"""


print("---- Q2 ----")

def iterateDictionary(some_list):
    for i in range(len(some_list)):
        print('first_name -', some_list[i]['first_name'], ', last_name -', some_list[i]['last_name'])

students = [
        {'first_name':  'Michael', 'last_name' : 'Jordan'},
        {'first_name' : 'John', 'last_name' : 'Rosales'},
        {'first_name' : 'Mark', 'last_name' : 'Guillen'},
        {'first_name' : 'KB', 'last_name' : 'Tonel'}
    ]
iterateDictionary(students) 
# should output: (it's okay if each key-value pair ends up on 2 separate lines;
# bonus to get them to appear exactly as below!)
#first_name - Michael, last_name - Jordan
#first_name - John, last_name - Rosales
#first_name - Mark, last_name - Guillen
#first_name - KB, last_name - Tonel

print("---- Q3 ----")


def iterateDictionary2(key_name, some_list):
    for i in range(len(some_list)):
        print(some_list[i][key_name])


iterateDictionary2('first_name', students)
iterateDictionary2('last_name', students)

print("---- Q4 ----")

dojo = {
   'locations': ['San Jose', 'Seattle', 'Dallas', 'Chicago', 'Tulsa', 'DC', 'Burbank'],
   'instructors': ['Michael', 'Amy', 'Eduardo', 'Josh', 'Graham', 'Patrick', 'Minh', 'Devon']
}

def printInfo(some_dict):
    for i in range(len(some_dict)):
        name = list(some_dict.keys())[i - 1]
        length = len(some_dict[name])
        print("\n" ,length, name)
        for j in range(length):
            print(some_dict[name][j])

printInfo(dojo)