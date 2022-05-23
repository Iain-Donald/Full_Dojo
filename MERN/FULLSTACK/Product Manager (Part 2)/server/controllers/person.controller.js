const { Person } = require('../models/person.model');
const mongoose = require('mongoose');


module.exports.getByID = (request, response) => {
    Person.findOne({ _id: request.params.id })
        .then(oneSingleUser => response.json({ user: oneSingleUser }))
        .catch(err => response.json({ message: 'Something went wrong', error: err }));
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


// Product manager 3 //

module.exports.editPerson = (request, response) => {
    const {title, price, description } = request.body; //  \/ assign mongo element to request.body vars \/
    Person.findByIdAndUpdate( request.params.id, { 
        title: title,
        price: price,
        description: description
    })
        .then(person=>response.json(person))
        .catch(err=>response.json(err));
};

module.exports.deletePerson = (request, response) => {
    Person.findOneAndDelete( request.params.id )
        .then(console.log(request.params.id + " delete request sent"))
        .catch(err => response.json({ message: 'Something went wrong', error: err }));
};