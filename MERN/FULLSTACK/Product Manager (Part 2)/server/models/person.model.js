const mongoose = require('mongoose');

const PersonSchema = new mongoose.Schema({
    title: {type: String},
    price: {type: String},
    description: {type: String}
}, {timestamps: true});

module.exports.Person = mongoose.model("Person", PersonSchema);

module.exports.findAllUsers = (request, response) => {
    this.Person.find()
        .then(all => response.json({ message: all }))
        .catch(err => response.json({ message: 'Something went wrong', error: err }));
}

/*module.exports.index = (request, response) => {
    response.json({
        message: "Hello World"
    });
}*/