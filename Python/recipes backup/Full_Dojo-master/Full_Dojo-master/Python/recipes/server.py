from os import link
from flask import Flask, render_template, request, redirect, session
from mysqlconnection import connectToMySQL
from user import User
from recipe import Recipe
app = Flask(__name__)
app.secret_key = 'password123verysecure'

@app.route("/users")
def read_all():
    users = User.get_all()
    return render_template("read.html", users = users)

@app.route("/")
def new_user():
    
    return render_template("index.html")

@app.route("/save", methods=['POST', 'GET'])
def save():
    data = {
        "first_name": request.form.get("first_name"),
        "last_name" : request.form.get("last_name"),
        "email" : request.form.get("email"),
        "password" : request.form.get("password")
    }

    error = ""
    if (User.validate_pw(request.form.get("password"), request.form.get("confPass"))):
        error = ""
        User.save(data)
    else:
        error = "Error: Passwords don't match"
    return redirect("/")

@app.route("/saveRecipe/<id>", methods=['POST', 'GET'])
def saveRecipe(id):
    data = {
        "name": request.form.get("name"),
        "description" : request.form.get("description"),
        "instructions" : request.form.get("instructions"),
        "under30" : request.form.get("under30"),
        "date_made" : request.form.get("date_made"),
        "user_id" : id
    }
    Recipe.disableChecks()
    Recipe.save(data)
    linkText = "/mainPage/" + id
    return redirect(linkText)

@app.route("/delete<i>")
def delete(i: int):
    Recipe.delete(i)
    linkText = "/mainPage/" + i
    return redirect(linkText)
            

@app.route("/login", methods=['POST', 'GET'])
def login():
    users = User.get_all()
    error = ""
    for i in range(len(users)):
        if(users[i].email == request.form.get("email") and users[i].password == request.form.get("pw")):
            redirectStr = ("/mainPage/" + str(users[i].id))
            session['loggedin'] = True
            return redirect(redirectStr)
        else:
            error = "Error: User not found"
            return redirect("/")

@app.route("/logout")
def logout():
    session['loggedin'] = False
    return redirect("/")

@app.route("/mainPage/<id>")
def mainPage(id):
    users = User.get_all()
    recipes = Recipe.get_all()
    return render_template("mainPage.html", users = users, id = id, recipes = recipes)

@app.route("/createRecipe/<id>")
def createRecipe(id):
    return render_template("createRecipe.html", id=id)

@app.route("/editRecipe/<user_id>")
def editRecipe(user_id):
    recipes = Recipe.get_all()
    return render_template("editRecipe.html", id=user_id, recipes = recipes)

@app.route("/showRecipe/<id>")
def showRecipe(id):
    users = User.get_all()
    recipes = Recipe.get_all()
    return render_template("show.html", id=id, recipes = recipes, users = users)

@app.route("/updateRecipe/<id>", methods=['POST', 'GET'])
def updateRecipe(id):
    data = {
        "name": request.form.get("name"),
        "description" : request.form.get("description"),
        "instructions" : request.form.get("instructions"),
        "under30" : request.form.get("under30"),
        "date_made" : request.form.get("date_made"),
        "user_id" : id
    }
    Recipe.disableChecks()
    Recipe.update(id, data)
    linkText = "/mainPage/" + id
    return redirect(linkText)

###<p>{{recipes[(id|int) - 1].name}}</p>
if __name__ == "__main__":
    app.run(debug=True)

