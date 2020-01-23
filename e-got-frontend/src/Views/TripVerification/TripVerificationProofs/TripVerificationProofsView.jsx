import React from 'react';
import '../TripVerification.css'
import './TripVerificationProofsView.css'
import { Divider, Button, Grid, Image } from 'semantic-ui-react';
import * as paths from "../../../Common/paths"
import SegmentContainer from '../../../Components/SegmentContainer/SegmentContainer';

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

    render() {

        let { currentPhotoIndex, photos } = this.state

        let leftContent =
                photos.filter((x, i) => i % 2 === 0).map((photo, i) =>
                    <Button className="trip-verification-data--image-button" onClick={() => this.setState({currentPhotoIndex:  i * 2})}>
                        <Image src={photo} className="trip-verification-data--image-thumbnail"/>
                    </Button>
                )

        let rightContnent =
                photos.filter((x, i) => i % 2 === 1).map((photo, i) =>
                    <Button className="trip-verification-data--image-button" onClick={() => this.setState({currentPhotoIndex:  1 + i * 2})}>
                        <Image src={photo} className="trip-verification-data--image-thumbnail"/>
                    </Button>
                )

        return (
            <SegmentContainer headerContent="Dowody przebycia wycieczki" iconName='camera retro'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => history.push(paths.TRIP_VERIFICATION + paths.DATA)}
                rightButtonContent="Dalej" rightButtonOnClick={(history) => history.push(paths.TRIP_VERIFICATION + paths.DECISION)} >

                <Divider />

                <Grid columns='three'>
                    <Grid.Row>
                        <Grid.Column width="10">
                                <Image src={photos[currentPhotoIndex]} className="trip-verification--picked-photo"/>
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