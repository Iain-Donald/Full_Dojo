from mysqlconnection import connectToMySQL
from flask import flash
class Recipe:
    def __init__( self , data ):
        self.id = data['id']
        self.name = data['name']
        self.description = data['description']
        self.instructions = data['instructions']
        self.under30 = data['under30']
        self.date_made = data['date_made']

    @classmethod
    def get_all(cls):
        query = "SELECT * FROM recipes.recipes;"

        results = connectToMySQL('recipes').query_db(query)

        recipeList = []

        for recipes in results:
            recipeList.append( Recipe(recipes) )
        
        return recipeList

    @classmethod
    def save(cls, data ):
        query = "INSERT INTO recipes ( name , description , instructions, under30, date_made, users_id ) VALUES ( %(name)s , %(description)s , %(instructions)s, %(under30)s, %(date_made)s, %(user_id)s );"

        return connectToMySQL('recipes').query_db( query, data )

    @classmethod
    def delete(cls, id ):
        query = "DELETE FROM recipes.recipes WHERE id="
        query = query + id + ";"
        print(query)

        return connectToMySQL('recipes').query_db( query )

    @classmethod
    def update(cls, id, data ):
        query = "UPDATE recipes.recipes "
        query = query + "SET name = %(name)s, description = %(description)s, instructions = %(instructions)s, under30 = %(under30)s, date_made = %(date_made)s"
        query = query + " WHERE id=" + id + ";"
        print(query)

        return connectToMySQL('recipes').query_db( query, data )

    @classmethod
    def disableChecks(cls):
        query = "SET FOREIGN_KEY_CHECKS = 0;"
        print(query)

        return connectToMySQL('recipes').query_db( query )


