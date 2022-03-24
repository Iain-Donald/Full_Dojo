# import the function that will return an instance of a connection
from mysqlconnection import connectToMySQL
from flask import flash
# model the class after the friend table from our database
class Recipe:
    def __init__( self , data ):
        self.id = data['id']
        self.name = data['name']
        self.description = data['description']
        self.instructions = data['instructions']
        self.user_id = data['user_id']
    # Now we use class methods to query our database
    @classmethod
    def get_all(cls):
        query = "SELECT * FROM recipes.recipes;"
        # make sure to call the connectToMySQL function with the schema you are targeting.
        results = connectToMySQL('recipes').query_db(query)
        # Create an empty list to append our instances of friends
        recipeList = []
        # Iterate over the db results and create instances of friends with cls.
        for recipes in results:
            recipeList.append( Recipe(recipes) )
        
        return recipeList

    @classmethod
    def save(cls, data ):
        query = "INSERT INTO recipes ( name , description , instructions, user_id ) VALUES ( %(name)s , %(description)s , %(instructions)s, %(user_id)s );"
        # data is a dictionary that will be passed into the save method from server.py
        return connectToMySQL('recipes').query_db( query, data )

    @classmethod
    def delete(cls, id ):
        query = "DELETE FROM recipes.recipes WHERE id="
        query = query + id + ";"
        print(query)
        # data is a dictionary that will be passed into the save method from server.py
        return connectToMySQL('recipes').query_db( query )


