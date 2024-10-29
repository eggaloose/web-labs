class FilmModel {
    constructor() {
        this.films = [{ id: 1, 
            name: 'Fight Club',
            director: 'David Fincher',
            description: 'The film tells the story of an alienated office worker and a charismatic nihilist who start an underground club at which disaffected young men violently fight each other',
            rate: 9,
            review: 'Good film'
         }];
    }

    getAllFilms() {
        return this.films;
    }

    addFilm(film) {
        this.films.push(film);
    }
}

module.exports = new FilmModel();
