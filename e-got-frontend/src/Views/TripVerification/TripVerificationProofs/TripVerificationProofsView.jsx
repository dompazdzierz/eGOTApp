import React from 'react';
import '../TripVerification.css'
import { Segment, Divider, Button, Header, Icon } from 'semantic-ui-react';
import { Route } from "react-router-dom";
import * as paths from "../../../Constants/paths"
import AppHeader from '../../../Components/AppHeader/AppHeader';

class TripVerificationProofsView extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
        }
    }

    render() {

        return (
            <div className="trip-verification--container">
                <AppHeader />

                <Segment className="trip-verification--segment">
                    <Route render={({history}) => (
                        <Button primary content="Powrót" floated="left" className="trip-verification--button"
                            onClick={() => history.goBack()}/>
                    )} />

                    <Route render={({history}) => (
                        <Button primary content="Dalej" floated="right" className="trip-verification--button"
                            onClick={() => history.push(paths.TRIP_VERIFICATION + paths.DECISION)}/>
                    )} />

                    <Icon style={{lineHeight: 'unset', verticalAlign: 'unset'}} name="photo" size="big"/>
                    <Header icon as='h2'>
                        <Header.Content>Dowody przebycia wycieczki</Header.Content>
                    </Header>

                    <Divider/>

                    <div>

                    </div>
                </Segment>
            </div>
        )
    }
}
export default TripVerificationProofsView;