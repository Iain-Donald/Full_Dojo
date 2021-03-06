from ast import ClassDef
from operator import length_hint
from flask_bcrypt import Bcrypt
from flask import Flask, render_template, request, redirect, session
from mysqlconnection import connectToMySQL
from user import User
from painting import Painting
import re
app = Flask(__name__)
app.secret_key = 'password123verysecure'
SESSION_TYPE = 'redis'
bcrypt = Bcrypt(app)

@app.route("/")
def new_user():
    
    return render_template("index.html")

@app.route("/save", methods=['POST', 'GET'])
def save():
    if (len(request.form['password']) < 1 or len(request.form['first_name']) < 1 or len(request.form['last_name']) < 1 or len(request.form['email']) < 1):
        session['error'] = "Error: One or more field(s) was left blank"
        return render_template("index.html")

    if(str(request.form['confPass']) != str(request.form['password'])):
        session['error'] = "Error: Passwords don't match"
        return render_template("index.html")
    
    pw_hash = bcrypt.generate_password_hash(request.form['password'])
    data = {
        "first_name": request.form.get("first_name"),
        "last_name" : request.form.get("last_name"),
        "email" : request.form.get("email"),
        "password" : pw_hash
    }
    User.save(data)
    return redirect("/")

@app.route("/savePainting/<id>", methods=['POST', 'GET'])
def savePainting(id):
    linkText = "/mainPage2/" + id
    if (len(request.form['title']) < 1 or len(request.form['description']) < 1 or len(request.form['price']) < 1):
        session['error'] = "Error: One field was left blank"
        return render_template("createPainting.html", id=id)

    session['error'] = ""

    data = {
        "title": request.form.get("title"),
        "description" : request.form.get("description"),
        "price" : request.form.get("price"),
        "user_id" : id
    }
    Painting.disableChecks()
    Painting.save(data)
    return redirect(linkText)

@app.route("/delete<id>")
def delete(id):
    paintings = Painting.get_all()
    id = int(id)
    deleteID = paintings[id].id
    Painting.delete(deleteID)
    linkText = "/mainPage2/" + str(id)
    return redirect(linkText)
            

@app.route("/login", methods=['POST', 'GET'])
def login():
    users = User.get_all()
    if len(request.form.get("email")) < 1 or len(request.form.get("email")) < 1:
        session['error'] = "Error: Email or Password left blank"
        return render_template("index.html")

    if(len(str(request.form.get("email"))) < 1 and len(str(request.form.get("password"))) < 1):
        session['error'] = "Error: Email or Password left blank"
    for i in range(len(users)):
        userHashedPW = users[i].password
        email = request.form.get("email")
        if(isEmail(email)):
            if(users[i].email == email and bcrypt.check_password_hash(userHashedPW, request.form['pw'])):
                session['loggedin'] = True
                session['userID'] = users[i].id
                session['dictIndex'] = i
                session['error'] = ""
                redirectStr = ("/mainPage2/" + str(session['userID']))
                return redirect(redirectStr)
        else:
            session['error'] = "Invalid Email"
            return render_template("index.html")

    return render_template("index.html")

@app.route("/logout")
def logout():
    session['loggedin'] = False
    session.clear()
    return redirect("/")

@app.route("/mainPage2/<id>")
def mainPage2(id):
    if not 'userID' in session:
        return redirect('/')
    
    users = User.get_all()
    paintings = Painting.get_all()
    return render_template("mainPage2.html", id = id, users = users, paintings = paintings, artists = getArtists())

@app.route("/createPainting/<id>")
def createPainting(id):
    if not 'userID' in session:
        return redirect('/')
    return render_template("createPainting.html", id=id)

@app.route("/editPainting/<user_id>")
def editPainting(user_id):
    if not 'userID' in session:
        return redirect('/')
    paintings = Painting.get_all()
    return render_template("editPainting.html", id=user_id, paintings = paintings)

@app.route("/showPainting/<id>")
def showPainting(id):
    if not 'userID' in session:
        return redirect('/')
    users = User.get_all()
    paintings = Painting.get_all()
    return render_template("show.html", id=id, paintings = paintings, users = users)

@app.route("/updatePainting/<id>", methods=['POST', 'GET'])
def updatePainting(id):
    if not 'userID' in session:
        return redirect('/')
    if (len(request.form['title']) < 1 or len(request.form['description']) < 1 or len(request.form['price']) < 1):
        session['error'] = "Error: One field was left blank"
        return render_template("editPainting.html", id=id)
    data = {
        "title": request.form.get("title"),
        "description" : request.form.get("description"),
        "price" : request.form.get("price"),
        "user_id" : id
    }
    session['error'] = ""
    
    Painting.update(id, data)
    linkText = "/mainPage2/" + id
    return redirect(linkText)


def isEmail(email):
    EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
    is_valid = True
        # test whether a field matches the pattern
    if not EMAIL_REGEX.match(email): 
        session['error'] = 'Invalid email address!'
        is_valid = False
    return is_valid

def getArtists():
    return Painting.getArtists()

if __name__ == "__main__":
    app.run(debug=True)

