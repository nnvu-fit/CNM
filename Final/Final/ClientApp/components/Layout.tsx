import * as React from 'react';
import { NavMenu } from './NavMenu';

export interface LayoutProps {
    children?: React.ReactNode;
}

export class Layout extends React.Component<LayoutProps, {}> {
    public render() {
        return <div>
            <header>
                < NavMenu />
            </header>

            <main className="container" role="main">
                {this.props.children}
            </main>
        </div>
        ;
    }
}