const { Person } = require('../models/person.model');

module.exports.index = (request, response) => {
    response.json({
        message: "Hello World"
    });
}

module.exports.createPerson = (request, response) => {
    const {title, price, description } = request.body;
    Person.create({
        title, 
        price,
        description
    })
        .then(person=>response.json(person))
        .catch(err=>response.json(err));
}