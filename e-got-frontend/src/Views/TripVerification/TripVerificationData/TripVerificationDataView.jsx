import React, { Fragment } from 'react';
import '../../../App.css';
import '../TripVerification.css'
import { Divider, TextArea, Form } from 'semantic-ui-react';
import * as paths from '../../../Common/paths'
import SegmentContainer from '../../../Components/SegmentContainer/SegmentContainer';
import TextInput from '../../../Components/Inputs/TextInput';
import CustomTextArea from '../../../Components/Inputs/CustomTextArea';

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
        let { startDate, duration, route, length, elevationGain, points } = this.state;

        return(
            <SegmentContainer headerContent="Dane wycieczki" iconName='list alternate outline'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => history.push(paths.HOME_VIEW)}
                rightButtonContent="Dalej" rightButtonOnClick={(history) => history.push(paths.TRIP_VERIFICATION + paths.PROOFS)} >

                <Divider />

                <div className="common--segment-half">
                    <div className="common--input-wrapper">
                        <TextInput header='Data rozpoczęcia' value={startDate} />
                        <TextInput header='Czas trwania' label='dni' value={duration} />
                        <Form>
                            <CustomTextArea header='Trasa wycieczki' placeholder={route}/>
                        </Form>
                    </div>
                </div>
                <div className="common--segment-half">
                    <div className="common--input-wrapper">
                        <TextInput header='Długość' value={length} label='m' />
                        <TextInput header='Przewyższenie' value={elevationGain} label='m' />
                        <TextInput header='Punktacja' value={points} />
                    </div>
                </div>

            </SegmentContainer>
        )
    }
}
export default TripVerificationDataView;