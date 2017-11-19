// A '.tsx' file enables JSX support in the TypeScript compiler, 
// for more information see the following page on the TypeScript wiki:
// https://github.com/Microsoft/TypeScript/wiki/JSX

import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Coordinates extends React.Component<RouteComponentProps<{}>, {}> {

    public getMap() {

    }

    public render() {
        return <div>
            <div id="map"></div>
        </div>;
    }
}
