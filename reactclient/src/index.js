import React from 'react';
//import ReactDOM from 'react-dom';
import 'bootstrap/dist/css/bootstrap.css';
import App from './App';


import { createRoot } from 'react-dom/client';

const container = document.getElementById('root');
const root = createRoot(container);
root.render(<App tab="home" />);


//ReactDOM.render(<App />, document.getElementById('root'));

