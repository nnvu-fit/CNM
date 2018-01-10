import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as UserStore from '../store/User';
import 'isomorphic-fetch';


type UserProps =
    UserStore.UserState
    & typeof UserStore.actionCreators
    & RouteComponentProps<{}>;

interface UserLoginData {
    username: string;
    password: string;
}

class Login extends React.Component<UserProps, UserLoginData> {
    constructor(props: UserProps) {
        super(props);
        this.state = { username: '', password: '' };
    }



    public render() {
        return <div className="row">
            <div className='col-sm-3'>
            </div>
            <div className='col-sm-9'>
                <h1>Login</h1>
                <div className="col-sm-6 col-md-6">
                    <div className="form-group">
                        <label htmlFor="login-username">Username</label>
                        <input type="text" className="form-control" id="login-username" value={this.state.username} onChange={(e) => { this.handleUsernameChange(e) }} placeholder="Username">
                        </input>
                    </div>
                    <div className="form-group">
                        <label htmlFor="login-password">Password</label>
                        <input type="password" className="form-control" id="login-password" value={this.state.password} onChange={(e) => { this.handlePasswordChange(e) }} placeholder="Password"></input>
                    </div>
                    <button className="btn btn-primary" type="button" onClick={() => { this.handleLoginClick() }}>
                        Login
                    </button>
                </div>
            </div>
        </div>;
    }

    handleUsernameChange(e: any) {
        this.setState({ username: e.target.value });
    }

    handlePasswordChange(e: any) {
        this.setState({ password: e.target.value });
    }

    handleLoginClick() {
        var ID;
        var ws;
        fetch('/api/Login', {
            method: 'POST',
            headers: new Headers(),
            body: {
                Username: this.state.username,
                Password: this.state.password
            }
        }).then(function (data) { return data.json(); })
            .then(function (data) {
                if (data.logined == 1) {
                    ID = data.ID;
                    ws = data.WorkSpace;
                }
                else {
                    ID = null;
                    ws = null;
                }
            });
        if (ID && ws)
            this.props.SetID(ID, ws);
    }
}

export default connect(
    (state: ApplicationState) => state.user,
    UserStore.actionCreators
)(Login) as typeof Login;