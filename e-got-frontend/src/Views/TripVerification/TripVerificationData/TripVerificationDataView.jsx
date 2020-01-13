import React from 'react';
import './TripVerificationDataView.css';
import '../TripVerification.css'
import { Segment, Divider, Input, Button, Header, Icon, TextArea, Form } from 'semantic-ui-react';
import AppHeader from '../../../Components/AppHeader/AppHeader';
import { Route } from 'react-router';
import * as paths from '../../../Constants/paths'

class TripVerificationDataView extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            startDate: "27.10.2008",
            duration: "1",
            route: "Palenica Białczańska - Wodogrzmoty Mickiewicza - Schronisko PTTK nad Morksim Okiem" +
            "- Wodogrzmoty Mickiewicza - Palenica Białczańska",
            length: 12123,
            elevationGain: 550,
            points: 17
        }
    }

    render() {

        let { startDate, duration, route, length, elevationGain, points } = this.state

        return(
            <div className="trip-verification--container">
                <AppHeader />

                <Segment className="trip-verification--segment">
                    <Route render={({history}) => (
                        <Button primary content="Powrót" floated="left" className="trip-verification--button"
                            onClick={() => history.goBack()}/>
                    )} />
                    <Route render={({history}) => (
                        <Button primary content="Dalej" floated="right" className="trip-verification--button"
                            onClick={() => history.push(paths.TRIP_VERIFICATION + paths.PROOFS)}/>
                    )} />
                    <div>
                    <Icon style={{lineHeight: 'unset', verticalAlign: 'unset'}} name="map signs" size="big"/>
                    <Header icon as='h2'>
                        <Header.Content>Dane wycieczki</Header.Content>
                    </Header>
                    </div>
                    <Divider/>
                    <div>
                        <div className="trip-verification-data--segment-half">
                            <div className="trip-verification-data--input-wrapper">
                                <p className="trip-verification-data--label">Data rozpoczęcia</p>
                                <Input disabled className="trip-verification-data--input" defaultValue={startDate}/>

                                <p className="trip-verification-data--label">Czas trwania</p>
                                <Input selection disabled className="trip-verification-data--input"
                                placeholder={duration} label={{ basic: true, content: 'dni' }} labelPosition='right'/>

                                <p className="trip-verification-data--label">Trasa wycieczki</p>
                                <Form>
                                    <TextArea disabled className="trip-verification-data--input"
                                        placeholder={route}/>
                                </Form>
                            </div>
                        </div>
                        <div className="trip-verification-data--segment-half">
                            <div className="trip-verification-data--input-wrapper">
                                <p className="trip-verification-data--label">Długość</p>
                                <Input disabled className="trip-verification-data--input" defaultValue={length}
                                    label={{ basic: true, content: 'm' }} labelPosition='right'/>

                                <p className="trip-verification-data--label">Przewyższenie</p>
                                <Input disabled className="trip-verification-data--input" defaultValue={elevationGain}
                                    label={{ basic: true, content: 'm' }} labelPosition='right'/>

                                <p className="trip-verification-data--label">Punktacja</p>
                                <Input disabled className="trip-verification-data--input" defaultValue={points}/>

                            </div>
                        </div>
                    </div>
                </Segment>

            </div>
        )
    }
}
export default TripVerificationDataView;