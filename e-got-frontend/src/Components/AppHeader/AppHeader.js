import React, {createRef} from 'react';
import './AppHeader.css';
import { Button, Dropdown, Ref, Sticky } from 'semantic-ui-react';
import { Route } from "react-router-dom";
import * as paths from "../../Constants/paths"

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
                <Dropdown.Item>
                    Ustawienia
                </Dropdown.Item>
                <Dropdown.Item>
                    O aplikacji
                </Dropdown.Item>
            </Dropdown.Menu>

        let avatarMenu =
            <Dropdown.Menu style={menuStyle}>
                <Dropdown.Item>
                    Moja książeczka
                </Dropdown.Item>
                <Route render={({ history }) => (
                    <Dropdown.Item onClick={() => history.push(paths.UNTRAVELED_TRIPS) }>
                        Nieprzebyte wycieczki
                    </Dropdown.Item>
                )} />
                <Route render={({ history }) => (
                    <Dropdown.Item onClick={() => history.push(paths.TRIP_VERIFICATION + paths.DATA) }>
                        Weryfikacja wycieczki
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