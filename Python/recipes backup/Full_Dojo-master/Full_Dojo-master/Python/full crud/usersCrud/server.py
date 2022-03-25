from flask import Flask, render_template, request, redirect
from mysqlconnection import connectToMySQL
from user import User
app = Flask(__name__)

@app.route("/users")
def read_all():
    users = User.get_all()
    return render_template("read.html", users = users)

@app.route("/showUser<i>")
def show(i: int):
    users = User.get_all()
    return render_template("show.html", users = users, index = i)

@app.route("/new", methods=['POST', 'GET'])
def new_user():
    data = {
        "first_name": request.form.get("first_name"),
        "last_name" : request.form.get("last_name"),
        "email" : request.form.get("email")
    }
    User.save(data)
    return render_template("create.html")

@app.route("/delete<i>")
def delete(i: int):
    User.delete(i)
    return redirect("/users")

@app.route("/editSQL<i>", methods=['POST', 'GET'])
def edit(i: int):
    data = {
        "id": i,
        "first_name": request.form.get("first_name"),
        "last_name" : request.form.get("last_name"),
        "email" : request.form.get("email")
    }
    User.edit(data)
    return render_template("edit.html", index = i)

@app.route("/")
def index():
    return render_template("index.html")
            
if __name__ == "__main__":
    app.run(debug=True)

