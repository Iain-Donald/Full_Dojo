from flask_app.config.mysqlconnection import connectToMySQL
class Burger:
    def __init__(self,data):
        self.id = data['id']
        self.name = data['name']
        self.bun = data['bun']
        self.meat = data['meat']
        self.calories = data['calories']
        self.created_at = data['created_at']
        self.updated_at = data['updated_at']

class User:
    def __init__( self , data ):
        self.id = data['id']
        self.first_name = data['first_name']
        self.last_name = data['last_name']
        self.email = data['email']
        self.password = data['password']
    @classmethod
    def get_all(cls):
        query = "SELECT * FROM users;"
        results = connectToMySQL('cars').query_db(query)
        usersList = []
        for users in results:
            usersList.append( User(users) )
        
        return usersList

    @classmethod
    def save(cls, data ):
        query = "INSERT INTO cars.users ( first_name , last_name , email, password ) VALUES ( %(first_name)s , %(last_name)s , %(email)s , %(password)s );"
        return connectToMySQL('cars').query_db( query, data )

    @classmethod
    def delete(cls, id ):
        query = "DELETE FROM cars.users WHERE id="
        query = query + id + ";"
        print(query)
        return connectToMySQL('cars').query_db( query )


    @staticmethod
    def validate_pw(pw, confPw):
        is_valid = True
        if (pw != confPw):
            is_valid = False
        return is_valid


