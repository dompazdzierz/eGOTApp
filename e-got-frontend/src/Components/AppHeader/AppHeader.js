import React from 'react';
import './AppHeader.css';
import { Button, Dropdown, Sticky } from 'semantic-ui-react';
import { Route } from "react-router-dom";
import * as paths from "../../Common/paths"

class AppHeader extends React.Component {

    render() {

        let backgroundStyle = {
            backgroundColor: this.props.home ? 'transparent' : '#2185d0',
            textAlign: 'center'
        }

        let menuStyle = {
            marginTop: '10px'
        }

        let barsMenu =
            <Dropdown.Menu style={menuStyle}>
                <Dropdown.Item disabled>
                    Ustawienia
                </Dropdown.Item>
                <Dropdown.Item disabled>
                    O aplikacji
                </Dropdown.Item>
            </Dropdown.Menu>

        let avatarMenu =
            <Dropdown.Menu style={menuStyle}>
                <Route render={({ history }) => (
                    <Dropdown.Item onClick={() => history.push(paths.UNTRAVELED_TRIPS) }>
                        Nieprzebyte wycieczki
                    </Dropdown.Item>
                )} />
                <Route render={({ history }) => (
                    <Dropdown.Item onClick={() => history.push(paths.UNVERIFIED_TRIPS) }>
                        Niezweryfikowane wycieczki
                    </Dropdown.Item>
                )} />
                <Route render={({ history }) => (
                    <Dropdown.Item onClick={() => history.push(paths.MOUNTAIN_RANGES) }>
                        Spis odcinków punktowanych
                    </Dropdown.Item>
                )} />
                <Route render={({ history }) => (
                    <Dropdown.Item onClick={() => history.push(paths.SECTION_PROPOSE) }>
                        Zaproponuj odcinek
                    </Dropdown.Item>
                )} />
            </Dropdown.Menu>


        return (
            <Sticky context={this.contextRef}>
                <div style={backgroundStyle}>
                    <Button className="appheader--button" size="massive" floated="left">
                        <Dropdown icon="bars" direction="right">
                            {barsMenu}
                        </Dropdown>
                    </Button>

                    <div className="appheader--text-container">e-GOT</div>

                    <Button className="appheader--button"  size="massive" floated="right">
                        <Dropdown icon="user" direction="left">
                            {avatarMenu}
                        </Dropdown>
                    </Button>
                </div>
            </Sticky>
        )
    }
}
export default AppHeader;