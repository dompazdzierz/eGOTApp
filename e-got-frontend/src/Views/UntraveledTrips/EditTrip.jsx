import React from 'react';
import * as values from '../../Common/values'
import { Table, Button, Segment, Form, Input, TextArea } from 'semantic-ui-react';
import SegmentContainer from '../../Components/SegmentContainer/SegmentContainer';

class EditTrip extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            startDate: '',
            duration: '',
            name: '',
            errorName: null,
            errorStartDate: null,
            errorDuration: null,
            isValid: true
        }
    }

    onChange = e => {
        this.setState({ [e.target.name]: e.target.value })
    }

    onSubmit = () => {
        const dateRegexp = /^\s*(3[01]|[12][0-9]|0?[1-9])\.(1[012]|0?[1-9])\.((?:19|20)\d{2})\s*$/;

        if(this.state.startDate == '') {
            this.setState({ errorStartDate: values.ERROR_FIELD_EMPTY })
        }
        else if (!this.state.startDate.match(dateRegexp)) {
            this.setState({ errorStartDate: values.ERROR_FIELD_DATE })
        }
        else {
            this.setState({ errorStartDate: null })
        }

        if(this.state.duration == '') {
            this.setState({ errorDuration: values.ERROR_FIELD_EMPTY })
        }
        else {
            this.setState({ errorDuration: null })
        }

        if(this.state.name == '') {
            this.setState({ errorName: values.ERROR_FIELD_EMPTY })
        }
        else {
            this.setState({ errorName: null })
        }
    }

    render() {
        return(
            <SegmentContainer headerContent="Edycja wycieczki" iconName='edit'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => history.goBack()} >

                <Segment style={{height: '60vh', width: '40vw', margin: 'auto', marginTop: '30px', backgroundColor: '#F8FCFF'}}>
                    <Form>
                        <Form.TextArea label='Nazwa wycieczki' placeholder="Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza"
                            error={this.state.errorName} value={this.state.name} name="name" onChange={e => this.onChange(e)} />

                        <Form.Input label='Data rozpoczęcia wycieczki' placeholder="19.07.2008" error={this.state.errorStartDate}
                            value={this.state.startDate} name="startDate" onChange={e => this.onChange(e)} />

                        <Form.Input label='Czas trwania wycieczki' placeholder="2" error={this.state.errorDuration}
                            value={this.state.duration} name="duration" onChange={e => this.onChange(e)} type="number"/>

                        <Form.Button primary type="submit" onClick={this.onSubmit}>Zapisz</Form.Button>
                    </Form>
                </Segment>

            </SegmentContainer>
        )
    }
}
export default EditTrip;