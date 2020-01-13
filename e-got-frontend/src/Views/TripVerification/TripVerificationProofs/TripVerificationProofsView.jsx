import React from 'react';
import '../TripVerification.css'
import { Segment, Divider, Button, Header, Icon, Grid, Image } from 'semantic-ui-react';
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

                    <Grid columns='three'>
                        <Grid.Row>
                            <Grid.Column width="8">
                                <Image src="http://www.gminakoscielisko.pl/uploads/files/images/popup_5763eebe7e2c1.jpg"/>
                            </Grid.Column>
                            <Grid.Column width="4">
                                <Image src="https://ocdn.eu/pulscms-transforms/1/irwk9kpTURBXy81YzFiZjYzNTZhNTAwYzNhNTAyMDM3ZmZjNzNlZmYwMy5qcGeUlQMAe80GQM0DhJMFzQMUzQG8lQfZMi9wdWxzY21zL01EQV8vMjMzN2M5ZmQ2YjkzMWVlNmNiMGQyM2RjYmEyNThhOWQucG5nAMIAkwmmYmM0NTZkBoGhMAE/najciekawsze-szlaki-w-tatrach-najpiekniejsze-widoki.jpg"/>
                            </Grid.Column>
                            <Grid.Column width="4">
                                <Button style={{padding: '0px'}}>
                                    <Image
                                        src="https://ocdn.eu/pulscms-transforms/1/irwk9kpTURBXy81YzFiZjYzNTZhNTAwYzNhNTAyMDM3ZmZjNzNlZmYwMy5qcGeUlQMAe80GQM0DhJMFzQMUzQG8lQfZMi9wdWxzY21zL01EQV8vMjMzN2M5ZmQ2YjkzMWVlNmNiMGQyM2RjYmEyNThhOWQucG5nAMIAkwmmYmM0NTZkBoGhMAE/najciekawsze-szlaki-w-tatrach-najpiekniejsze-widoki.jpg"
                                    />
                                </Button>
                            </Grid.Column>
                        </Grid.Row>
                    </Grid>
                </Segment>
            </div>
        )
    }
}
export default TripVerificationProofsView;