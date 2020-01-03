import React from 'react';
import './AppHeader.css';
import { Button } from 'semantic-ui-react';

class AppHeader extends React.Component {
    render() {

        let backgroundStyle = {
            backgroundColor: this.props.home ? 'transparent' : 'blue',
        }

        return(
            <div style={backgroundStyle} className="appheader--container">
                <Button className="appheader--button" icon="bars" size="massive" floated="left"/>
                <div className="appheader--text-container">eGOT</div>
                <Button className="appheader--button" icon="user" size="massive" floated="right"/>
            </div>
        )
    }
}
export default AppHeader;