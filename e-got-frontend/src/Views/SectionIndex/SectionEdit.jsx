import React from 'react';
import { Divider, Button } from 'semantic-ui-react';
import '../TripVerification/TripVerificationData/TripVerificationDataView.css'
import '../TripVerification/TripVerification.css'
import * as apiPaths from '../../Common/apiPaths'
import SegmentContainer from '../../Components/SegmentContainer/SegmentContainer'
import TextInput from '../../Components/Inputs/TextInput'
import CustomDropdown from '../../Components/Dropdown/CustomDropdown'
import axios from '../../Common/axios'

class SectionEdit extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            startLocationId: 2,
            endLocationId: 0,
            length: 0,
            elevationGain: 0,
            score: 0,
            status: false,
            mountainRangeId: 0,
            locationsData: [],
            mountainRangesData: []
        }
    }

    componentDidMount() {
        axios() ({
            method: 'get',
            url: apiPaths.SECTIONS + apiPaths.GET + '/' + this.getSectionId()
        })
        .then(response => {
            this.setState({
                startLocationId: response.data.startLocationId,
                endLocationId: response.data.endLocationId,
                length: response.data.length,
                elevationGain: response.data.elevationGain,
                score: response.data.score,
                status: response.data.status,
                mountainRangeId: response.data.mountainRangeId
            });
        })
        .catch(error => {
            console.log(error);
        })

        axios() ({
            method: 'get',
            url: apiPaths.LOCATIONS + apiPaths.GET_ALL
        })
        .then(response => {
            this.setState({
                locationsData: response.data.map(location => {
                    return {
                        key: location.Id,
                        value: location.Id,
                        text: location.Name
                    }
                })
            });
        })
        .catch(error => {
            console.log(error);
        })

        axios() ({
            method: 'get',
            url: apiPaths.MOUNTAIN_RANGES + apiPaths.GET_ALL
        })
        .then(response => {
            this.setState({
                mountainRangesData: response.data.map(mountainRange => {
                    return {
                        key: mountainRange.id,
                        value: mountainRange.id,
                        text: mountainRange.name
                    }
                })
            });
        })
        .catch(error => {
            console.log(error);
        })
    }

    getSectionId() {
        var url = window.location.pathname;
        return url.substring(url.lastIndexOf('/') + 1);
    }

    onChange = e => this.setState({ [e.target.name]: e.target.value })

    saveSection() {
        axios() ({
            method: 'post',
            url: apiPaths.SECTIONS + apiPaths.SET +
                '?id=' + this.getSectionId() +
                '&startLocationId=' + this.state.startLocationId +
                '&endLocationId=' + this.state.endLocationId +
                '&length=' + this.state.length +
                '&elevationGain=' + this.state.elevationGain +
                '&score=' + this.state.score +
                '&mountainRangeId=' + this.state.mountainRangeId
        })
        .then(response => {
            console.log(response)
        })
        .catch(error => {
            console.log(error);
        })
    }

    render() {
        return(
            <SegmentContainer headerContent="Edycja odcinka" iconName='edit'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => history.goBack()}
                 >

                <Divider />

                <div className="trip-verification-data--segment-half">
                    <div className="trip-verification-data--input-wrapper">
                        <CustomDropdown
                            header='Punkt początkowy'
                            placeholder='Wybierz punkt początkowy'
                            options={this.state.locationsData}
                            initialValue={this.state.startLocationId}
                            onChange={value => {
                                this.setState({startLocationId: value})
                            }}
                        />
                        <CustomDropdown
                            header='Punkt końcowy'
                            placeholder='Wybierz punkt końcowy'
                            options={this.state.locationsData}
                            initialValue={this.state.endLocationId}
                            onChange={value => {
                                this.setState({endLocationId: value})
                            }}
                        />
                        <CustomDropdown
                            header='Grupa górska'
                            placeholder='Wybierz grupę górską'
                            options={this.state.mountainRangesData}
                            initialValue={this.state.mountainRangeId}
                            onChange={value => {
                                this.setState({mountainRangeId: value})
                            }}
                        />
                    </div>
                </div>
                <div className="trip-verification-data--segment-half">
                    <div className="trip-verification-data--input-wrapper">
                        <TextInput onChange={this.onChange} type="number" min={1} max={20000} header='Długość' 
                            value={this.state.length} name='length' label='m' />
                        <TextInput onChange={this.onChange} type="number" min={1} max={1000} header='Przewyższenie' 
                            value={this.state.elevationGain} name='elevationGain' label='m' />
                        <TextInput header='Punktacja' value={this.state.score} />
                    </div>
                </div>

                <Button
                    primary
                    content={'Zapisz odcinek'}
                    onClick={() => {
                        this.saveSection()
                        // history.goBack() TODO
                    }}
                />

            </SegmentContainer>
        )
    }
}
export default SectionEdit;