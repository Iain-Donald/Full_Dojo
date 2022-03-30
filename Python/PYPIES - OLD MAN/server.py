from operator import length_hint
from flask_bcrypt import Bcrypt
from flask import Flask, render_template, request, redirect, session
from mysqlconnection import connectToMySQL
from user import User
from car import Car
app = Flask(__name__)
app.secret_key = 'password123verysecure'
SESSION_TYPE = 'redis'
bcrypt = Bcrypt(app)

@app.route("/users")
def read_all():
    users = User.get_all()
    return render_template("read.html", users = users)

@app.route("/")
def new_user():
    
    return render_template("index.html")

@app.route("/save", methods=['POST', 'GET'])
def save():
    if (len(request.form['password']) < 1 or len(request.form['first_name']) < 1 or len(request.form['last_name']) < 1 or len(request.form['email']) < 1):
        error = "Error: One field was left blank"
        return render_template("index.html", error = error)

    if(str(request.form['confPass']) != str(request.form['password'])):
        error = "Error: Password does not match Confirm Password"
        return render_template("index.html", error = error)
    
    pw_hash = bcrypt.generate_password_hash(request.form['password'])
    data = {
        "first_name": request.form.get("first_name"),
        "last_name" : request.form.get("last_name"),
        "email" : request.form.get("email"),
        "password" : pw_hash
    }
    User.save(data)
    return redirect("/")

@app.route("/saveCar/<id>", methods=['POST', 'GET'])
def saveCar(id):
    linkText = "/mainPage2/" + id
    if (len(request.form['make']) < 1 or len(request.form['model']) < 1 or len(request.form['description']) < 1):
        session['error'] = "Error: One field was left blank"
        return redirect(linkText)

    data = {
        "make": request.form.get("make"),
        "model" : request.form.get("model"),
        "year" : request.form.get("year"),
        "description" : request.form.get("description"),
        "price" : -1,
        "user_id" : id
    }
    Car.disableChecks()
    Car.save(data)
    return redirect(linkText)

@app.route("/delete<i>")
def delete(i: int):
    Car.delete(i)
    linkText = "/mainPage2/" + i
    return redirect(linkText)

@app.route("/addVote<id>")
def addVote(id: int):
    cars = Car.get_all()
    for j in range(len(cars)):
        if (cars[j].year == None):
            Car.setZero(cars[j].id)
    Car.addVote(id)
    linkText = "/mainPage2/" + id
    return redirect(linkText)
            

@app.route("/login", methods=['POST', 'GET'])
def login():
    users = User.get_all()
    error = ""
    if len(request.form.get("email")) < 1 or len(request.form.get("email")) < 1:
        error = "Error: Email or Password left blank"
        return render_template("index.html", error = error)

    if(len(str(request.form.get("email"))) < 1 and len(str(request.form.get("password"))) < 1):
        error = "Error: Email or Password left blank"
    for i in range(len(users)):
        userHashedPW = users[i].password
        if(users[i].email == request.form.get("email") and bcrypt.check_password_hash(userHashedPW, request.form['pw'])):
                session['loggedin'] = True
                session['userID'] = users[i].id
                session['dictIndex'] = i
                redirectStr = ("/mainPage2/" + str(session['userID']))
                return redirect(redirectStr)

    return render_template("index.html", error = error)

@app.route("/logout")
def logout():
    session['loggedin'] = False
    return redirect("/")

@app.route("/mainPage/<id>")
def mainPage(id):
    users = User.get_all()
    cars = Car.get_all()
    return render_template("mainPage.html", users = users, cars = cars)

@app.route("/mainPage2/<id>")
def mainPage2(id):
    users = User.get_all()
    cars = Car.get_all()
    return render_template("mainPage2.html", id = id, users = users, cars = cars)

@app.route("/createCar/<id>")
def createCar(id):
    return render_template("createCar.html", id=id)

@app.route("/editCar/<user_id>")
def editCar(user_id):
    cars = Car.get_all()
    return render_template("editCar.html", id=user_id, cars = cars)

@app.route("/showCar/<id>")
def showCar(id):
    users = User.get_all()
    cars = Car.get_all()
    return render_template("show.html", id=id, cars = cars, users = users)

@app.route("/updateCar/<id>", methods=['POST', 'GET'])
def updateCar(id):
    data = {
        "make": request.form.get("make"),
        "model" : request.form.get("model"),
        "year" : request.form.get("year"),
        "description" : request.form.get("description"),
        "price" : -1,
        "user_id" : id
    }
    Car.disableChecks()
    Car.update(id, data)
    linkText = "/mainPage/" + id
    return redirect(linkText)

if __name__ == "__main__":
    app.run(debug=True)

