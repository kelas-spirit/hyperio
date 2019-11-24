import * as React from 'react';
import { NavLink, Link } from 'react-router-dom';

import { RouteComponentProps } from 'react-router-dom';


var redBox = {
    color: 'red',
    border: 'solid red 1px',
    fontSize: '130%'
}

export default class Home extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>Hello, world!</h1>

            <div className="hello">
                <h3></h3>
                <ul>
                    <li>1: Add a menu item "Hello" to the left side and display</li>
                    <li>2: Move the inline style of this red box to an external css file and try to make the box nicer</li>
                    <li>3: Display the server time here: { this.getServerTime()} </li>
                </ul>
            </div>

            <p>Welcome to your new single-page application, built with:</p>
            <ul>
                <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
                <li><a href='https://facebook.github.io/react/'>React</a>, <a href='http://redux.js.org'>Redux</a>, and <a href='http://www.typescriptlang.org/'>TypeScript</a> for client-side code</li>
                <li><a href='https://webpack.github.io/'>Webpack</a> for building and bundling client-side resources</li>
                <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
            </ul>
            <p>To help you get started, we've also set up:</p>
            <ul>
                <li><strong>Client-side navigation</strong>. For example, click <em>Counter</em> then <em>Back</em> to return here.</li>
                <li><strong>Webpack dev middleware</strong>. In development mode, there's no need to run the <code>webpack</code> build tool. Your client-side resources are dynamically built on demand. Updates are available as soon as you modify any file.</li>
                <li><strong>Hot module replacement</strong>. In development mode, you don't even need to reload the page after making most changes. Within seconds of saving changes to files, rebuilt React components will be injected directly into your running application, preserving its live state.</li>
                <li><strong>Efficient production builds</strong>. In production mode, development-time features are disabled, and the <code>webpack</code> build tool produces minified static CSS and JavaScript files.</li>
                <li><strong>Server-side prerendering</strong>. To optimize startup time, your React application is first rendered on the server. The initial HTML and state is then transferred to the browser, where client-side code picks up where the server left off.</li>
            </ul>
        </div>;
    }
    refresh() {
        
            var currentTime = new Date();

            var currentHours = currentTime.getHours();
            var currentMinutes = currentTime.getMinutes();
            var currentSeconds = currentTime.getSeconds();
            return currentHours + ":" + currentMinutes + ":" + currentSeconds;
        
    }
    state = {
        time: new Date().toLocaleString(),
    }
    getServerTime() {
        return new Date().toLocaleString();
    }
    intervalID: any;
    componentDidMount() {
        this.intervalID = setInterval(
            () => this.tick(),
            1000
        );
    }
    componentWillUnmount() {
        clearInterval(this.intervalID);
    }
    tick() {
        this.setState({
            time: new Date().toLocaleString()
        });
    }
}
