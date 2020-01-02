import React from 'react';
import './AppHeader.css';
import { Button, Header } from 'semantic-ui-react';

class AppHeader extends React.Component {
    render() {
        return(
            <div className="appheader--container">
                <Button className="appheader--button" icon="bars" size="massive" floated="left"/>
                <Header>STEFAN</Header>
                <Button className="appheader--button" icon="user" size="massive" floated="right"/>
            </div>
        )
    }
}
export default AppHeader;