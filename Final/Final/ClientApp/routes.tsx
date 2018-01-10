import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import Home from './components/Home';
import User from './components/User';
import Login from './components/Login';
import Register from './components/Register';
import cordinates from './components/cordinates';

export const routes = <Layout>
    <Route exact path='/' component={Home} />
    <Route exact path='/user' component={User} />
    <Route exact path='/login' component={Login} />
    <Route exact path='/register' component={Register} />
    <Route exact path='/cordinates' component={cordinates} />
</Layout>;
