import React from 'react';
import * as values from '../../Common/values'
import { Table, Button, Segment, Form, Input, TextArea } from 'semantic-ui-react';
import SegmentContainer from '../../Components/SegmentContainer/SegmentContainer';

class EditTrip extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            startDate: 0,
            duration: 0,
            name: '',
            errorName: null,
            errorStartDate: null,
            errorDuration: null,
            isValid: true
        }
    }

    onSubmit = () => {
        const dateRegexp = /^\d{1,2}\.\d{1,2}\.\d{4}$/;

        if(this.state.startDate == '') {
            this.setState({ errorStartDate: values.ERROR_FIELD_EMPTY })
        }
        else if (!this.state.startDate.match(dateRegexp)) {
            this.setState({ errorStartDate: values.ERROR_FIELD_DATE })
        }

        if(this.state.startDate == '') {
            this.setState({ errorStartDate: values.ERROR_FIELD_EMPTY })
        }

        if(this.state.startDate == '') {
            this.setState({ errorStartDate: values.ERROR_FIELD_EMPTY })
        }

    }

    render() {
        return(
            <SegmentContainer headerContent="Edycja wycieczki" iconName='edit'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => history.goBack()} >

                <Segment style={{height: '60vh', width: '40vw', margin: 'auto', marginTop: '30px', backgroundColor: '#F8FCFF'}}>
                    <Form>
                        <Form.TextArea label='Nazwa wycieczki' placeholder="Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza"
                            error={this.state.errorName}/>
                        <Form.Input label='Data rozpoczęcia wycieczki' placeholder="19.07.2008" error={this.state.errorStartDate}/>
                        <Form.Input label='Czas trwania wycieczki' placeholder="2" error={this.state.errorDuration}/>
                        <Form.Button primary type="submit" onClick={this.onSubmit}>Zapisz</Form.Button>
                    </Form>
                </Segment>

            </SegmentContainer>
        )
    }
}
export default EditTrip;