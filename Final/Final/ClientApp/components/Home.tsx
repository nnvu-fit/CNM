import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Home extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div className="starter-template">
            <br /> <br /> <br />
            <form className="col-sm-5">
                <h1 className="mx-auto">Register</h1>
                <div className="form-group row">
                    <label className="col-sm-2 col-form-label" htmlFor="Register-InputUsername1">Username</label>
                    <div className="col-sm-10">
                        <input type="text" className="form-control" id="Register-InputUsername1" aria-describedby="usernameHelp" placeholder="Username"></input>
                        <small id="usernameHelp" className="form-text text-muted">We'll never share your email with anyone else.</small>
                    </div>
                </div>

                <div className="form-group row">
                    <label className="col-sm-2 col-form-label" htmlFor="Register-InputUsername1">Password</label>
                    <div className="col-sm-10">
                        <input type="password" className="form-control" id="Register-InputUsername1" aria-describedby="usernameHelp" placeholder="Password"></input>
                    </div>
                </div>

                <div className="form-group row">
                    <label className="col-sm-2 col-form-label" htmlFor="Register-InputUsername1">Retype</label>
                    <div className="col-sm-10">
                        <input type="password" className="form-control" id="Register-InputUsername1" aria-describedby="usernameHelp" placeholder="Retype"></input>
                    </div>
                </div>
                <br />
                <button type="submit" className="btn btn-primary">Sign up</button>
            </form>
        </div>;
    }
}
