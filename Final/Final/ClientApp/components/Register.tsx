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

interface UserRegisterData {
    username: string;
    password: string;
    retype: string;
    typeCar: boolean;
}

class Register extends React.Component<UserProps, UserRegisterData> {
    constructor(props: UserProps) {
        super(props);
        this.state = {
            username: '',
            password: '',
            retype: '',
            typeCar: false
        }
    }

    public render() {
        return <div>
            <div className='col-sm-3'>
            </div>
            <div className='col-sm-9'>
                <h1>Register</h1>
                <div className="col-sm-6 col-md-6">
                    <div className="form-group">
                        <label htmlFor="register-username">Username</label>
                        <input type="text" className="form-control" id="register-username" value={this.state.username} onChange={(e) => { this.handleUsernameChange(e) }} placeholder="Username">
                        </input>
                    </div>
                    <div className="form-group">
                        <label htmlFor="register-password">Password</label>
                        <input type="password" className="form-control" id="register-password" value={this.state.password} onChange={(e) => { this.handlePasswordChange(e) }} placeholder="Password"></input>
                    </div>
                    <div className="form-group">
                        <label htmlFor="register-retype">Retype your password</label>
                        <input type="password" className="form-control" id="register-retype" value={this.state.retype} onChange={(e) => { this.handlePasswordRetypeChange(e) }} placeholder="Password"></input>
                    </div>
                    <div className="input-group mb-3">
                        <div className="input-group-prepend">
                            <div className="input-group-text">
                                <input type="checkbox" onChange={(e) => { this.handleCheckBoxChange(e) }} aria-label="Checkbox for following text input"></input>
                            </div>
                        </div>
                        <label>Tick your check box if you have vip car</label>
                    </div>
                    <button className="btn btn-primary" type="button" onClick={() => { this.handleRegisterClick() }}>
                        Register
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
    handlePasswordRetypeChange(e: any) {
        this.setState({ retype: e.target.value });
    }
    handleCheckBoxChange(e: any) {
        this.setState({ typeCar: e.target.checked });
    }

    handleRegisterClick() {

    }
}

export default connect(
    (state: ApplicationState) => state.user,
    UserStore.actionCreators
)(Register) as typeof Register;