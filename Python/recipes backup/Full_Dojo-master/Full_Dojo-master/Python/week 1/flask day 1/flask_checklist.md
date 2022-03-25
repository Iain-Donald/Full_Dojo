# pre-rec
installed globally on our machine
```

pip install pipenv
```

# Common Terminal Commands
## Git/Mac
1. ls : list all files and directories
2. cd : enter directory of given name (if unique directory typed so far, press tab to autofill)

3. cd .. : go up a dir

4. mkdir : create a directory ( ex. mkdir new_folder )

5. touch : create a file ( ex. touch server.py )

6. type null > 'name of document'

7. nano : edit file and actually write code if you want to

## CMD
1. dir : list all files and directories

2. cd : enter directory of given name (if unique directory typed so far, press tab to autofill)

3. cd .. : go up a dir

4. mkdir : create a directory ( ex. mkdir new_folder )

# checklist
 - create an assignment folder
 - go into that assignment folder
 - create our virtual environment
 ```
 pipenv install flask
 ```
  - look for: pipfile AND pipfile lock
    - warning: if you didn't 
   - Go into the virtual environment shell  
```
pipenv shell
(to exit virtual environment type 'exit')
```
   - touch server.py file

```py
from flask import Flask
app = Flask(__name__)# instance of flask app


#THIS WILL CHANGE!!! *******
#we're going to have multiple routes ex
#@app.route('/')
#def hello_world():#returning string "Hello World!"
#    return 'Hello World!'
#@app.route('/')
#def hello_world():#returning string "Hello World!"
#    return 'Hello World!'
#@app.route('/')
#def hello_world():#returning string "Hello World!"
#    return 'Hello World!'
#@app.route('/coffee')
#def coffee():
#    return 'I love coffee'

@app.route('/') #decorator, passing string into function called route
#server is going to be listening for route in URL
#listening for '/' (forward slash)

#difference between method and function - method is inside of a class and function is outside
def hello_world():#returning string "Hello World!"
    return 'Hello World!'

if __name__=="__main__":
    app.run(debug=True)
```

 - check the app make sure it is running

#create smthnsmthn
 ```# a cursor is the object we use to interact with the database
import pymysql.cursors
# this class will give us an instance of a connection to our database
class MySQLConnection:
    def __init__(self, db):
        # change the user and password as needed
        connection = pymysql.connect(host = 'localhost',
                                    user = 'root', 
                                    password = 'root', 
                                    db = db,
                                    charset = 'utf8mb4',
                                    cursorclass = pymysql.cursors.DictCursor,
                                    autocommit = True)
        # establish the connection to the database
        self.connection = connection
    # the method to query the database
    def query_db(self, query, data=None):
        with self.connection.cursor() as cursor:
            try:
                query = cursor.mogrify(query, data)
                print("Running Query:", query)
     
                cursor.execute(query, data)
                if query.lower().find("insert") >= 0:
                    # INSERT queries will return the ID NUMBER of the row inserted
                    self.connection.commit()
                    return cursor.lastrowid
                elif query.lower().find("select") >= 0:
                    # SELECT queries will return the data from the database as a LIST OF DICTIONARIES
                    result = cursor.fetchall()
                    return result
                else:
                    # UPDATE and DELETE queries will return nothing
                    self.connection.commit()
            except Exception as e:
                # if the query fails the method will return FALSE
                print("Something went wrong", e)
                return False
            finally:
                # close the connection
                self.connection.close() 
# connectToMySQL receives the database we're using and uses it to create an instance of MySQLConnection
def connectToMySQL(db):
    return MySQLConnection(db)

```