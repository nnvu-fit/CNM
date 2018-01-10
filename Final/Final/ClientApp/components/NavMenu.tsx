import * as React from 'react';
import { NavLink, Link } from 'react-router-dom';

export class NavMenu extends React.Component<{}, {}> {
    public render() {
        return <nav className='navbar navbar-expand-md navbar-dark bg-dark'>

                <a className='navbar-brand' href='/'>Final</a>
                <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className='collapse navbar-collapse' id="navbarsExampleDefault">
                    <ul className='navbar-nav col-sm-2 ml-auto row'>
                        <li className="nav-item">
                            <NavLink className="btn btn-primary" exact to="/login" activeClassName='active'>
                                    Login
                            </NavLink>
                        </li>
                        <li className="nav-item">
                            <NavLink className="btn btn-outline-secondary" exact to="/register" activeClassName='active'>
                                    Register
                            </NavLink>
                        </li>
                    </ul>
                </div>
        </nav>;
    }
}

