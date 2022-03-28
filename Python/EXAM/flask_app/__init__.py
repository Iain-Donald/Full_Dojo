from flask import Flask, render_template, request, redirect, session
from flask_app.config.mysqlconnection import connectToMySQL
from flask_app.models.user import User
from flask_app.models.car import Car
app = Flask(__name__)
app.secret_key = 'password123verysecure'
SESSION_TYPE = 'redis'