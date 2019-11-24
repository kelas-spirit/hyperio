import { RouteComponentProps } from 'react-router-dom';
import * as React from "react";
import * as ReactDOM from "react-dom";




 export default class Hello extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>Hello</h1>

            <p>This is my first React Component ;).</p>
            <p>p.s. Angular, don't be jealous. It's for testing purpose :D </p>

            
        </div>;
    }
}