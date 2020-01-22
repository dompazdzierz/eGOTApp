import React from 'react';
import { Divider, TextArea, Form } from 'semantic-ui-react';
import * as paths from '../../Common/paths'
import * as apiPaths from '../../Common/apiPaths'
import SegmentContainer from '../../Components/SegmentContainer/SegmentContainer';
import TextInput from '../../Components/Inputs/TextInput';
import axios from '../../Common/axios';

class SectionEdit extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            startLocation: '',
            endLocation: '',
            length: 0,
            elevationGain: 0,
            score: 0,
            status: false,
            mountainRange: ''
        }
    }

    componentDidMount() {
        axios() ({
            method: 'get',
            url: apiPaths.SECTIONS + apiPaths.GET + '/' + this.getRangeId()
        })
        .then(response => {
            console.log(response)
            this.setState({
                startLocation: response.data.startLocation,
                endLocation: response.data.endLocation,
                length: response.data.length,
                elevationGain: response.data.elevationGain,
                score: response.data.score,
                status: response.data.status,
                mountainRange: response.data.mountainRange
            });
        })
        .catch(error => {
            console.log(error);
        })
    }

    getRangeId = () => {
        var url = window.location.pathname;
        return url.substring(url.lastIndexOf('/') + 1);
    }

    onChange = e => this.setState({ [e.target.name]: e.target.value })

    render() {

        return(
            <SegmentContainer headerContent="Edycja wycieczki" iconName='edit'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => history.goBack()}
                 >

                <Divider />

                <div className="trip-verification-data--segment-half">
                    <div className="trip-verification-data--input-wrapper">
                        <TextInput header='Data rozpoczęcia' />
                        <TextInput header='Czas trwania' label='dni' />

                        <p className="trip-verification--label">Trasa wycieczki</p>
                        <Form>
                            <TextArea disabled className="trip-verification-data--input"
                                />
                        </Form>
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

            </SegmentContainer>
        )
    }
}
export default SectionEdit;