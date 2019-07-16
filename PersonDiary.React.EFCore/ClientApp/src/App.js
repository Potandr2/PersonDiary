import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import Persons from './components/Persons';
import Person from './components/Person';
import Lifeevents from './components/Lifeevents';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/counter' component={Counter} />
    <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
    <Route path='/persons/:startDateIndex?' component={Persons} />
    <Route path='/person/:id' component={Person} />
  </Layout>
);
