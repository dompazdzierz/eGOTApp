import React from 'react';
import './AppHeader.css';
import { Button, Dropdown } from 'semantic-ui-react';

class AppHeader extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
        }
    }

    handleClick = () => {
        console.log("XDD")
    }

    render() {

        let backgroundStyle = {
            backgroundColor: this.props.home ? 'transparent' : 'blue',
            textAlign: 'center'
        }

        let menuStyle = {
            marginTop: '10px'
        }

        let avatarMenu =
            <Dropdown.Menu style={menuStyle}>
                <Dropdown.Item>
                    Ustawienia
                </Dropdown.Item>
            </Dropdown.Menu>


        return(
            <div style={backgroundStyle}>

                <Button className="appheader--button" size="massive" floated="left">
                    <Dropdown icon="bars" direction="right">
                            <Dropdown.Menu style={menuStyle}>
                                <Dropdown.Item>
                                    Ustawienia
                                </Dropdown.Item>
                                <Dropdown.Item>
                                    O aplikacji
                                </Dropdown.Item>
                            </Dropdown.Menu>
                    </Dropdown>
                </Button>

                <div className="appheader--text-container">eGOT</div>

                <Button className="appheader--button"  size="massive" floated="right">
                    <Dropdown icon="user" direction="left">
                        {avatarMenu}
                    </Dropdown>
                </Button>

            </div>
        )
    }
}
export default AppHeader;