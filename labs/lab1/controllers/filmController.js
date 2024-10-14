const FilmModel = require('../models/filmModel');

exports.getFilms = (req, res) => {
    const films = FilmModel.getAllFilms();
    res.render('filmListView', { films });
};

exports.getFilm = (req, res) => {
    const films = FilmModel.getAllFilms();
    const id = req.params['id'];
    const film = films.find(x => x.id == id);
    res.render('filmView', { film });
};

exports.createFilm = (req, res) => {
    const newFilm = { id: Date.now(), name: req.body.name, email: req.body.email }; // DO
    FilmModel.addUser(newFilm);
    res.redirect('/');
};