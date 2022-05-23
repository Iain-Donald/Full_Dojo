const mongoose = require('mongoose');

const PersonSchema = new mongoose.Schema({
    title: {type: String},
    price: {type: String},
    description: {type: String}
}, {timestamps: true});

module.exports.Person = mongoose.model("Person", PersonSchema);