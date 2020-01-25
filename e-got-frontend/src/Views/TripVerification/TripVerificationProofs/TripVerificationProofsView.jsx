import React from 'react';
import '../TripVerification.css'
import './TripVerificationProofsView.css'
import { Divider, Button, Grid, Image } from 'semantic-ui-react';
import * as paths from "../../../Common/paths"
import SegmentContainer from '../../../Components/SegmentContainer/SegmentContainer';
import axios from '../../../Common/axios';
import * as apiPaths from '../../../Common/apiPaths';

class TripVerificationProofsView extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            photos: [],
            currentPhotoIndex: 0
        }
    }

    componentDidMount() {
        axios() ({
            method: 'get',
            url: apiPaths.TRAVELED_TRIPS + apiPaths.GET + '/' + this.getTripId()
        })
        .then(response => {
            this.setState({
                photos: response.data.photos
            });
        })
        .catch(error => {
            console.log(error);
        })
    }

    getTripId() {
        var url = window.location.pathname;
        return url.substring(url.lastIndexOf('/') + 1);
    }

    render() {

        let { currentPhotoIndex, photos } = this.state

        let leftContent =
                photos.filter((x, i) => i % 2 === 0).map((photo, i) =>
                    <Button className="trip-verification-data--image-button" onClick={() => this.setState({currentPhotoIndex:  i * 2})}>
                        <Image src={apiPaths.IMG_ADRESS + '/' + photo} className="trip-verification-data--image-thumbnail"/>
                    </Button>
                )

        let rightContnent =
                photos.filter((x, i) => i % 2 === 1).map((photo, i) =>
                    <Button className="trip-verification-data--image-button" onClick={() => this.setState({currentPhotoIndex:  1 + i * 2})}>
                        <Image src={apiPaths.IMG_ADRESS + '/' + photo} className="trip-verification-data--image-thumbnail"/>
                    </Button>
                )

        return (
            <SegmentContainer headerContent="Dowody przebycia wycieczki" iconName='camera retro'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => history.push(paths.TRIP_VERIFICATION + paths.DATA + '/' + this.getTripId())}
                rightButtonContent="Dalej" rightButtonOnClick={(history) => history.push(paths.TRIP_VERIFICATION + paths.DECISION + '/' + this.getTripId())} >

                <Divider />

                <Grid columns='three'>
                    <Grid.Row>
                        <Grid.Column width="10">
                                <Image src={apiPaths.IMG_ADRESS + '/' + photos[currentPhotoIndex]} className="trip-verification--picked-photo"/>
                        </Grid.Column>
                        <Grid.Column width="3">
                            {leftContent}
                        </Grid.Column>
                        <Grid.Column width="3">
                            {rightContnent}
                        </Grid.Column>
                    </Grid.Row>
                </Grid>

            </SegmentContainer>
        )
    }
}
export default TripVerificationProofsView;