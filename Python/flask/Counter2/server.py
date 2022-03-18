from flask import Flask, render_template, request, redirect, session
app = Flask(__name__)
app.secret_key = 'keep it secret, keep it safe'


def initSession():
    if 'mainSession' in session:
        session['mainSession'] += 1
    else:
        session['mainSession'] = 1

@app.route('/')
def main():
    initSession()
    return render_template('index.html')

@app.route('/addTwo')
def add():
    session['mainSession'] += 1
    return redirect('/')

@app.route('/reset')
def resetSession():
    session['mainSession'] = 0
    return redirect('/')

if __name__=="__main__":
    app.run(debug=True)

