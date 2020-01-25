import React from 'react';
import '../../../App.css';
import '../TripVerification.css'
import { Divider, Form } from 'semantic-ui-react';
import * as paths from '../../../Common/paths'
import SegmentContainer from '../../../Components/SegmentContainer/SegmentContainer';
import TextInput from '../../../Components/Inputs/TextInput';
import CustomTextArea from '../../../Components/Inputs/CustomTextArea';
import axios from '../../../Common/axios';
import * as apiPaths from '../../../Common/apiPaths';

class TripVerificationDataView extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            title: '',
            startDate: '',
            endDate: '',
            score: 0,
            length: 0,
            elevationGain: 0,
            route: '',
            photos: []
        }
    }

    componentDidMount() {
        axios() ({
            method: 'get',
            url: apiPaths.TRAVELED_TRIPS + apiPaths.GET + '/' + this.getTripId()
        })
        .then(response => {
            this.setState({
                title: response.data.title,
                startDate: response.data.startDate,
                endDate: response.data.endDate,
                score: response.data.score,
                length: response.data.length,
                elevationGain: response.data.elevationGain,
                route: response.data.route,
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
        let { startDate, endDate, score, length, elevationGain, route } = this.state;

        return(
            <SegmentContainer headerContent="Dane wycieczki" iconName='list alternate outline'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => history.push(paths.UNVERIFIED_TRIPS)}
                rightButtonContent="Dalej" rightButtonOnClick={(history) => history.push(paths.TRIP_VERIFICATION + paths.PROOFS + '/' + this.getTripId())} >

                <Divider />
                <Form>
                    <div className="common--segment-half">
                        <div className="common--input-wrapper">
                            <TextInput header='Data rozpoczęcia' value={startDate} />
                            <TextInput header='Data zakończenia' value={endDate} />
                            <CustomTextArea header='Trasa wycieczki' placeholder={route}/>
                        </div>
                    </div>
                    <div className="common--segment-half">
                        <div className="common--input-wrapper">
                            <TextInput header='Długość' value={length} label='m' />
                            <TextInput header='Przewyższenie' value={elevationGain} label='m' />
                            <TextInput header='Punktacja' value={score} />
                        </div>
                    </div>
                </Form>

            </SegmentContainer>
        )
    }
}
export default TripVerificationDataView;