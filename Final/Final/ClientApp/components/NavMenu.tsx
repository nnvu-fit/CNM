import * as React from 'react';
import { NavLink, Link } from 'react-router-dom';

export class NavMenu extends React.Component<{}, {}> {
    public render() {
        return <div className='main-nav'>
                <div className='navbar navbar-inverse'>
                <div className='navbar-header'>
                    <button type='button' className='navbar-toggle' data-toggle='collapse' data-target='.navbar-collapse'>
                        <span className='sr-only'>Toggle navigation</span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                    </button>
                    <Link className='navbar-brand' to={ '/' }>Final</Link>
                </div>
                <div className='clearfix'></div>
                <div className='navbar-collapse collapse'>
                    <ul className='nav navbar-nav row'>
                        <li>
                            <NavLink exact to="/login" activeClassName='active'>
                                Login
                            </NavLink>
                        </li>
                        <li>
                            <NavLink exact to="/register" activeClassName='active'>
                                Register
                            </NavLink>
                        </li>
                    </ul>
                </div>
            </div>
        </div>;
    }
}

