import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout'; //remplace ton navigation je crois
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import Banque from './components/Banque.js';

import './custom.css'

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
        <Route path='/Banque' component={Banque} /> 
    </Layout>
);
