from flask import Flask, render_template  # Import Flask to allow us to create our app
app = Flask(__name__)    # Create a new instance of the Flask class called "app"
@app.route('/')          # The "@" decorator associates this route with the function immediately following
def hello_world():
    return 'Hello World!'  # Return the string 'Hello World!' as a response

@app.route('/success')
def success():
  return "success"

@app.route('/hello/<name>') # for a route '/hello/____' anything after '/hello/' gets passed as a variable 'name'
def hello(name):
    print(name)
    return "Hello, " + name

@app.route('/<x>/<y>') # for a route '/hello/____' anything after '/hello/' gets passed as a variable 'name'
def printXY(x, y):
    print(x, y)
    return "Hello, " + x + y

@app.route('/<x>') # for a route '/hello/____' anything after '/hello/' gets passed as a variable 'name'
def printX(x):
    print(x)
    return "Hello, " + x

@app.route('/page')
def printPage():
    return render_template('index.html', num = 5) 

if __name__=="__main__":   # Ensure this file is being run directly and not from a different module    
    app.run(debug=True)    # Run the app in debug mode.

