const express = require('express');
var bodyParser = require('body-parser');

const app = express();
const userRoutes = require('./routes/filmRoutes');
const privacyRouter = require('./routes/privacyRouter');
const aboutRouterRouter = require('./routes/aboutRouter');

app.use(bodyParser.json());
app.use(bodyParser.urlencoded());

app.use(bodyParser.urlencoded({ extended: true }));

app.set('view engine', 'ejs');
app.use('/about', aboutRouterRouter);
app.use('/privacy', privacyRouter);
app.use('/', userRoutes);

app.listen(3000, () => {
    console.log('Server is running on port 3000');
});
