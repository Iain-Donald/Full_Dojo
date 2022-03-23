from flask import Flask, render_template, request, redirect
from mysqlconnection import connectToMySQL
# import the class from friend.py
from user import User
app = Flask(__name__)

@app.route("/users")
def read_all():
    # call the get all classmethod to get all friends
    users = User.get_all()
    print(users, flush=True)
    return render_template("read.html", users = users)

@app.route("/new", methods=['POST', 'GET'])
def new_user():
    # First we make a data dictionary from our request.form coming from our template.
    # The keys in data need to line up exactly with the variables in our query string.

    

    data = {
        "first_name": request.form.get("first_name"),
        "last_name" : request.form.get("last_name"),
        "email" : request.form.get("email")
    }
    # We pass the data dictionary into the save method from the Friend class.
    User.save(data)
    # Don't forget to redirect after saving to the database.
    return render_template("create.html")

@app.route("/")
def index():
    # call the get all classmethod to get all friends
    return render_template("index.html")
            
if __name__ == "__main__":
    app.run(debug=True)

