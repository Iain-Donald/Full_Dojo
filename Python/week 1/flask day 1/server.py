from flask import Flask
app = Flask(__name__)# instance of flask app

@app.route('/')

def hello_world():#returning string "Hello World!"
    return 'Hello World!'


#keep this at the bottom (won't register routes below this function)
if __name__=="__main__":
    app.run(debug=True)