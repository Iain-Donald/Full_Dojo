from mysqlconnection import connectToMySQL
from flask import flash
from user import User
class Painting:
    def __init__( self , data ):
        self.id = data['id']
        self.title = data['title']
        self.description = data['description']
        self.price = data['price']
        self.user_id = data['user_id']

    @classmethod
    def get_all(cls):
        query = "SELECT * FROM painting JOIN user ON painting.user_id = user.id;"

        results = connectToMySQL('artistpaintings').query_db(query)

        paintingList = []

        for artistpaintings in results:
            paintingList.append( Painting(artistpaintings) )
        
        return paintingList

    @classmethod
    def save(cls, data ):
        query = "INSERT INTO artistpaintings.painting ( title , description, price, user_id ) VALUES ( %(title)s , %(description)s, %(price)s, %(user_id)s );"

        return connectToMySQL('artistpaintings').query_db( query, data )

    @classmethod
    def delete( cls, id ):
        query = "DELETE FROM artistpaintings.painting WHERE id="
        query = query + str(id) + ";"

        return connectToMySQL('artistpaintings').query_db( query )

    @classmethod
    def update(cls, id, data ):
        query = "UPDATE artistpaintings.painting "
        query = query + "SET title = %(title)s, description = %(description)s, price = %(price)s"
        query = query + " WHERE id=" + id + ";"
        print(query)

        return connectToMySQL('artistpaintings').query_db( query, data )

    @classmethod
    def getArtists( cls ):
        query = "SELECT * FROM user LEFT JOIN painting ON user.id = painting.user_id ORDER BY painting.id;"
        results = connectToMySQL('artistpaintings').query_db(query)
        artistList = []
        for first_name in results:
            artistList.append(User(first_name))
        return artistList

    @classmethod
    def disableChecks(cls):
        query = "SET FOREIGN_KEY_CHECKS = 0;"
        print(query)

        return connectToMySQL('artistpaintings').query_db( query )

    #@classmethod
    #def addVote(cls, id ):
    #    id = int(id)
    #    query = "UPDATE artistpaintings.painting "
    #    query = query + "SET year = year + 1"
    #    query = query + " WHERE paintingid=" + str(id) + ";"
    #    print(query)
#
    #    return connectToMySQL('artistpaintings').query_db( query )

    @classmethod
    def setZero(cls, id ):
        id = int(id)
        query = "UPDATE artistpaintings.painting "
        query = query + "SET year = 0"
        query = query + " WHERE id=" + str(id) + ";"
        print(query)

        return connectToMySQL('artistpaintings').query_db( query )

