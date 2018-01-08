import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';

export class NavMenu extends React.Component<{}, {}> {
    public render() {
        return <nav className="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
            <a className="navbar-brand" href="#">Final</a>
            <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#topbar" aria-expanded="false" aria-label="Toggle navigation">
                <span className="navbar-toggler-icon"></span>
            </button>
            <div className="collapse navbar-collapse" id="topbar">
                <div className="my-2 my-lg-0 ml-auto">
                    <form className="form-inline">
                        <input type="text" className="form-control mx-sm-3" id="login-username" placeholder="username"></input>
                        <input type="password" className="form-control mx-sm-3" id="login-password" placeholder="password"></input>
                        <button type="submit" className="btn btn-primary">Sign in</button>
                    </form>
                </div>
            </div>
        </nav>
        ;
    }
}
