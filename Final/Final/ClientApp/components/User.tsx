import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as UserStore from '../store/User';

type UserProps =
    UserStore.UserState
    & typeof UserStore.actionCreators
    & RouteComponentProps<{}>;

class User extends React.Component<UserProps, {}> {
    
    public render() {
        console.log(this.props.UserID);
        return <div>
            <h1> User </h1>

            <h3>User ID: <strong>{this.props.UserID}</strong></h3>

            <button onClick={() => { this.props.SetID("123") }}>Set ID by 123</button>

            <button onClick={() => { this.props.RemoveID() }}>Remove ID</button>
        </div>;
    }
}

export default connect(
    (state: ApplicationState) => state.user,
    UserStore.actionCreators
)(User) as typeof User;