const mongoose = require('mongoose');
const express = require('express');
var cors = require('cors');
const bodyParser = require('body-parser');
const logger = require('morgan');
const Data = require('./data');

const API_PORT = 3001;
const app = express();
app.use(cors());
const router = express.Router();

app.set('port', process.env.PORT || 3001);

//please put your MongoDB url here
const dbRoute =
  'mongodb+srv://[user]:[password]@accountinformation-9mvjv.mongodb.net/test?retryWrites=true&w=majority';

mongoose.connect(dbRoute, { useNewUrlParser: true });

let db = mongoose.connection;
db.once('open', () => console.log('You have connected to MongoDB successfully! :)'));
db.on('error', console.error.bind(console, 'Ops, connection failed:'));

app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());
app.use(logger('dev'));

router.get('/authenticate', (req, res) => {
  Data.find((err, data) => 
  {  
    console.log(data);
    if (err) return res.json({ success: false, error: err });
        return res.json({ success: true, data: data});
  });
});

router.post('/signup', (req, res) => {
  console.log(req.body);

  let data = new Data();

  const { userName,password } = req.body;


  data.userName = userName;
  data.password = password;
  data.save((err) => {
    if (err) return res.json({ success: false, error: err });
    return res.json({ success: true });
  });
});

app.use('/api', router);
app.listen(API_PORT, () => console.log(`NOw on PORT ${API_PORT}`));