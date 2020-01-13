import React , { createRef } from 'react';
import '../TripVerification.css'
import './TripVerificationProofsView.css'
import { Segment, Divider, Button, Header, Icon, Grid, Image, Ref } from 'semantic-ui-react';
import { Route } from "react-router-dom";
import * as paths from "../../../Constants/paths"
import AppHeader from '../../../Components/AppHeader/AppHeader';

class TripVerificationProofsView extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            photos: [
                "http://www.gminakoscielisko.pl/uploads/files/images/popup_5763eebe7e2c1.jpg",
                "http://www.wiecznatulaczka.pl/wp-content/uploads/2019/12/Kozakov-21-995x498.jpg",
                "http://www.wiecznatulaczka.pl/wp-content/uploads/2019/12/Kozakov-1.jpg",
                "http://www.wiecznatulaczka.pl/wp-content/uploads/2019/12/Kozakov-2.jpg",
                "http://www.wiecznatulaczka.pl/wp-content/uploads/2019/12/Kozakov-4.jpg",
                "http://www.wiecznatulaczka.pl/wp-content/uploads/2019/12/Kozakov-5.jpg",
                "http://www.wiecznatulaczka.pl/wp-content/uploads/2019/12/Kozakov-6.jpg",
                "http://www.wiecznatulaczka.pl/wp-content/uploads/2019/12/Kozakov-7.jpg",
                "http://www.wiecznatulaczka.pl/wp-content/uploads/2019/12/Kozakov-8.jpg",
            ],
            currentPhotoIndex: 0
        }
    }

    contextRef = createRef()

    render() {

        let { currentPhotoIndex, photos } = this.state

        let leftContent =
                photos.filter((x, i) => i % 2 == 0).map((photo, i) =>
                    <Button className="trip-verification-data--image-button" onClick={() => this.setState({currentPhotoIndex: i})}>
                        <Image src={photo} className="trip-verification-data--image-thumbnail"/>
                    </Button>
                )

        let rightContnent =
                photos.filter((x, i) => i % 2 == 1).map((photo, i) =>
                    <Button className="trip-verification-data--image-button" onClick={() => this.setState({currentPhotoIndex: i})}>
                        <Image src={photo} className="trip-verification-data--image-thumbnail"/>
                    </Button>
                )


        return (
            <div className="trip-verification--container">
                <AppHeader />

                <Segment style={{width: "90vw"}} className="trip-verification--segment">
                    <Route render={({history}) => (
                        <Button primary content="Powrót" floated="left" className="trip-verification--button"
                            onClick={() => history.goBack()}/>
                    )} />

                    <Route render={({history}) => (
                        <Button primary content="Dalej" floated="right" className="trip-verification--button"
                            onClick={() => history.push(paths.TRIP_VERIFICATION + paths.DECISION)}/>
                    )} />

                    <Icon style={{linemaxHeight: 'unset', verticalAlign: 'unset'}} name="photo" size="big"/>
                    <Header icon as='h2'>
                        <Header.Content>Dowody przebycia wycieczki</Header.Content>
                    </Header>

                    <Divider/>

                    <Grid columns='three'>

                        <Grid.Row>
                                <Ref innerRef={this.contextRef}>

                                <Grid.Column width="10">
                                    <Image src={photos[currentPhotoIndex]}/>
                                </Grid.Column>
                                </Ref>

                                <Grid.Column width="3">
                                    {leftContent}
                                </Grid.Column>
                                <Grid.Column width="3">
                                    {rightContnent}
                                </Grid.Column>
                        </Grid.Row>
                    </Grid>

                </Segment>
            </div>
        )
    }
}
export default TripVerificationProofsView;