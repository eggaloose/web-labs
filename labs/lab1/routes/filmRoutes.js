const express = require('express');
const router = express.Router();
const filmController = require('../controllers/filmController');

router.get('/', filmController.getFilms);
router.get('/:id', filmController.getFilm);
router.post('/create', filmController.createFilm);

module.exports = router;
