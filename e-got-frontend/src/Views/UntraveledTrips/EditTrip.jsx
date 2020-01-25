import React from 'react';
import * as values from '../../Common/values'
import { Segment, Form, Label, Confirm } from 'semantic-ui-react';
import SegmentContainer from '../../Components/SegmentContainer/SegmentContainer';
import axios from '../../Common/axios';
import * as apiPaths from '../../Common/apiPaths';
import { Route } from 'react-router';

class EditTrip extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            title: null,
            startDate: null,
            endDate: null,
            changes: false,
            saved: false,
            open: false,
            content: "",
            errorTitle: null,
            errorStartDate: null,
            errorEndDate: null,
            isValid: true,
            successVisible: false
        }
    }

    componentDidMount() {
        axios() ({
            method: 'get',
            url: apiPaths.UNTRAVELED_TRIPS + apiPaths.GET + '/' + this.getTripId()
        })
        .then(response => {
            this.setState({
                title: response.data.title,
                startDate: response.data.startDate,
                endDate: response.data.endDate
            });
        })
        .catch(error => {
            console.log(error);
        })
    }

    capitalizeFirstLetter(string) {
        return string.charAt(0).toUpperCase() + string.slice(1);
    }

    getTripId() {
        var url = window.location.pathname;
        return url.substring(url.lastIndexOf('/') + 1);
    }

    openConfirm = () =>  {
        this.setState({
            open: true,
            content: "Czy chcesz anulować zmiany?"
        })
    }

    close = () => this.setState({ open: false })

    onChange = e => {
        this.setState({
            ['error' + this.capitalizeFirstLetter(e.target.name)]: null,
            [e.target.name]: e.target.value,
            changes: true
        })
    }

    handleDismiss = () => {
        this.setState({ successVisible: false })
    }

    saveTrip() {
        axios() ({
            method: 'post',
            url: apiPaths.UNTRAVELED_TRIPS + apiPaths.SET +
                '?id=' + this.getTripId() +
                '&title=' + this.state.title +
                '&startDate=' + this.state.startDate +
                '&endDate=' + this.state.endDate
        })
        .then(response => {
            console.log(response)
        })
        .catch(error => {
            console.log(error);
        })
    }

    onSubmit = () => {
        let isValid = true
        const dateRegexp = /^\s*(3[01]|[12][0-9]|0?[1-9])\.(1[012]|0?[1-9])\.((?:19|20)\d{2})\s*$/;

        if(this.state.startDate === '') {
            this.setState({ errorStartDate: values.ERROR_FIELD_EMPTY })
            isValid = false
        }
        else if (!this.state.startDate.match(dateRegexp)) {
            this.setState({ errorStartDate: values.ERROR_FIELD_DATE })
            isValid = false
        }
        else {
            this.setState({ errorStartDate: null })
        }

        if(this.state.duration === '') {
            this.setState({ errorDuration: values.ERROR_FIELD_EMPTY })
            isValid = false
        }
        else {
            this.setState({ errorDuration: null })
        }

        if(this.state.name === '') {
            this.setState({ errorName: values.ERROR_FIELD_EMPTY })
            isValid = false
        }
        else {
            this.setState({ errorName: null })
        }

        if(isValid) {
            this.saveTrip()
            this.setState({ saved: true, changes: false, successVisible: true })
        }
    }

    render() {
        let labelStyle = this.state.successVisible ? {} : {visibility: 'hidden'}

        return(
            <SegmentContainer headerContent="Edytuj wycieczkę" iconName='edit'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => {
                    this.state.changes ? this.openConfirm() : history.goBack()
                }}
            >

                <Segment style={{height: '60vh', width: '40vw', margin: 'auto', marginTop: '30px', backgroundColor: '#F8FCFF'}}>
                    <Form loading={!(this.state.title && this.state.startDate && this.state.endDate)}>
                        <Form.TextArea label='Nazwa wycieczki'
                            error={this.state.errorTitle} value={this.state.title} name="title" onChange={e => this.onChange(e)} />

                        <Form.Input label='Data rozpoczęcia wycieczki' placeholder="DD.MM.RRRR" error={this.state.errorStartDate}
                            value={this.state.startDate} name="startDate" onChange={e => this.onChange(e)} />

                        <Form.Input label='Czas trwania wycieczki' placeholder="DD.MM.RRRR" error={this.state.errorEndDate}
                            value={this.state.endDate} name="endDate" onChange={e => this.onChange(e)} />

                        <Form.Field style={{paddingLeft: '160px'}} inline>
                            <Form.Button primary type="submit" disabled={!this.state.changes} onClick={this.onSubmit}>Zapisz wycieczkę</Form.Button>
                            <Label
                                style={labelStyle}
                                pointing='left'
                                color='blue'
                                onRemove={this.handleDismiss}
                                content='Zapisano wycieczkę&nbsp;&nbsp;&nbsp;&nbsp;'
                                basic
                            />
                        </Form.Field>
                        
                    </Form>
                    <Route render={({ history }) => (
                        <Confirm
                            open={this.state.open}
                            content={this.state.content}
                            onCancel={this.close}
                            onConfirm={() => {
                                history.goBack()
                            }}
                            cancelButton='Nie'
                            confirmButton='Tak'
                        />
                    )} />
                </Segment>

            </SegmentContainer>
        )
    }
}
export default EditTrip;