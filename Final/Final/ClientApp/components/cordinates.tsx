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

class Cordinates extends React.Component<UserProps, {}> {
    map: any;
    geocodeAddr: 'https://maps.googleapis.com/maps/api/geocode/json?address=';
    keyApi: 'AIzaSyBl6Hi5lkO6nGm5-J4M11jk-IUcF8TtDrc';

    config: {
        apiKey: "AIzaSyBzGZtw4pzqGcT5bISFeEiZDNfi1pCbDrE",
        authDomain: "barg-9f201.firebaseapp.com",
        databaseURL: "https://barg-9f201.firebaseio.com",
        projectId: "barg-9f201",
        storageBucket: "barg-9f201.appspot.com",
        messagingSenderId: "594787136476"
    };

    LocationsList = [];
    Markers = [];
    MarkerInfos = [];
    currentLocation: any;
    currentMarker: any;
    currentInfo: any;
    currentID: any;

    DriverList = [];
    DriverMarkers = [];
    DriverInfos = [];
    currentDriver: any;
    currentDriverMarker: any;
    currentDriverInfo: any;
    currentDriverID: any;

    DriverBarg: any;
    CallBarg: any;
    

    constructor(props: UserProps) {
        super(props);
    }

    public render() {
        return <div className="row">
            <nav className="col-sm-3 col-md-3 d-none d-sm-block bg-light sidebar" id="SideBar">
                <div className="scrollbar">
                    <div className="Button-control-list">
                        <button type="button" className="btn btn-primary" onClick={() => { this.getLocationList() }} id="GetAllLocations">
                            Get List of Location
                        </button>
                    </div>
                </div>
                <div id="Location-List">
                    <script id="Location-template" type="text/x-handlebars-template">
                        <div className="Location-detail">
                            {{#each this}}
                    <div className="btn-group" role="group" aria-label="Basic example">
                                <button type="button" className="btn btn-primary mark" data-id={{@key}}>{{@key}}</button>
                            <button type="button" className="btn btn-secondary update" data-id={{@key}}>Update</button>
                    </div>
                    {{/each}}
                </div>
              </script>
        </div>

            </nav>
        </div>;
    }

    getLocationList() {
        console.log("asdasd");
    }
}

export default connect(
    (state: ApplicationState) => state.user,
    UserStore.actionCreators
)(Cordinates) as typeof Cordinates;