from flask import Flask, render_template, request, redirect, session
app = Flask(__name__)
app.secret_key = 'keep it secret, keep it safe'


def initSession():
  try:
    session['mainSession'] += 1
  except KeyError:
    session['mainSession'] = 1

def addTwo():
        session['mainSession'] += 1

def reset():
    session['mainSession'] = 0

@app.route('/')
def main():
    initSession()
    def addTwo():
        session['mainSession'] += 2
    return render_template('index.html')

@app.route('/addTwo')
def add():
    addTwo()
    return redirect('/')

@app.route('/reset')
def resetSession():
    reset()
    return redirect('/')

if __name__=="__main__":
    app.run(debug=True)

