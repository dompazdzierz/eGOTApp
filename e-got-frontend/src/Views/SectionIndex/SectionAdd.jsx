import React from 'react';
import '../../App.css'
import { Divider, Confirm, Form, Label, Button } from 'semantic-ui-react';
import * as apiPaths from '../../Common/apiPaths'
import SegmentContainer from '../../Components/SegmentContainer/SegmentContainer'
import TextInput from '../../Components/Inputs/TextInput'
import axios from '../../Common/axios'
import { Route } from 'react-router';
import CustomDropdown from '../../Components/Inputs/CustomDropdown';
import * as values from '../../Common/values'

class SectionEdit extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            startLocationId: null,
            endLocationId: null,
            length: null,
            elevationGain: null,
            score: 0,
            status: false,
            mountainRangeId: null,
            locationsData: null,
            mountainRangesData: null,
            changes: false,
            saved: false,
            open: false,
            content: "",
            errorStartLocation: null,
            errorEndLocation: null,
            errorMountainRange: null,
            errorLength: null,
            errorElevationGain: null,
            isValid: true,
            successVisible: false
        }
    }

    componentDidMount() {
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

    capitalizeFirstLetter(string) {
        return string.charAt(0).toUpperCase() + string.slice(1);
    }

    openConfirm = () =>  {
        this.setState({
            open: true,
            content: "Czy chcesz anulować zmiany?"
        })
    }

    close = () => this.setState({ open: false })

    calculateScore() {
        let score = Math.round(this.state.length / 1000) + Math.round(this.state.elevationGain / 100)
        this.setState({ score: score })
    }

    onSectionDimensionsChange = e => {
        this.setState(
            {
                ['error' + this.capitalizeFirstLetter(e.target.name)]: null,
                [e.target.name]: e.target.value,
                changes: true
            },
            () => this.calculateScore()
        )
    }

    handleDismiss = () => {
        this.setState({ successVisible: false })
    }

    addSection() {
        axios() ({
            method: 'post',
            url: apiPaths.SECTIONS + apiPaths.ADD_ELEMENT +
                '?startLocationId=' + this.state.startLocationId +
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

    onSubmit = () => {
        let isValid = true

        if(!this.state.startLocationId) {
            this.setState({ errorStartLocation: values.ERROR_FIELD_EMPTY })
            isValid = false
        } else {
            this.setState({ errorStartLocation: null })
        }

        if(!this.state.endLocationId) {
            this.setState({ errorEndLocation: values.ERROR_FIELD_EMPTY })
            isValid = false
        } else {
            this.setState({ errorEndLocation: null })
        }

        if(!this.state.mountainRangeId) {
            this.setState({ errorMountainRange: values.ERROR_FIELD_EMPTY })
            isValid = false
        } else {
            this.setState({ errorMountainRange: null })
        }

        if(!this.state.length) {
            this.setState({ errorLength: values.ERROR_FIELD_EMPTY })
            isValid = false
        } else if(this.state.length <= 0) {
            this.setState({ errorLength: values.ERROR_FIELD_INVALID_NUMBER })
            isValid = false
        } else {
            this.setState({ errorLength: null })
        }

        if(!this.state.elevationGain) {
            this.setState({ errorElevationGain: values.ERROR_FIELD_EMPTY })
            isValid = false
        } else if(this.state.elevationGain <= 0) {
            this.setState({ errorElevationGain: values.ERROR_FIELD_INVALID_NUMBER })
            isValid = false
        } else {
            this.setState({ errorElevationGain: null })
        }

        if(isValid) {
            this.addSection()
            this.setState({ saved: true, changes: false, successVisible: true })
        }
    }

    render() {
        let labelStyle = this.state.successVisible ? {} : {visibility: 'hidden'}

        return(
            <SegmentContainer headerContent="Dodaj odcinek" iconName='plus'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => {
                    this.state.changes ? this.openConfirm() : history.goBack()
                }}
            >
            <Divider />
            <Form loading={!(this.state.locationsData && this.state.mountainRangesData)}>
                <div className="common--segment-half">
                    <div className="common--input-wrapper">
                        <Form.Field className="common--form-field">
                            <CustomDropdown
                                header='Punkt początkowy'
                                placeholder='Wybierz punkt początkowy'
                                options={this.state.locationsData}
                                initialValue={this.state.startLocationId}
                                onChange={value => {
                                    this.setState({startLocationId: value, changes: true, errorStartLocation: null})
                                }}
                                error={this.state.errorStartLocation}
                            />
                        </Form.Field>
                        <Form.Field className="common--form-field">
                            <CustomDropdown
                                header='Punkt końcowy'
                                placeholder='Wybierz punkt końcowy'
                                options={this.state.locationsData}
                                initialValue={this.state.endLocationId}
                                onChange={value => {
                                    this.setState({endLocationId: value, changes: true, errorEndLocation: null})
                                }}
                                error={this.state.errorEndLocation}
                            />
                        </Form.Field>
                        <Form.Field className="common--form-field">
                            <CustomDropdown
                                header='Grupa górska'
                                placeholder='Wybierz grupę górską'
                                options={this.state.mountainRangesData}
                                initialValue={this.state.mountainRangeId}
                                onChange={value => {
                                    this.setState({mountainRangeId: value, changes: true, errorMountainRange: null})
                                }}
                                error={this.state.errorMountainRange}
                            />
                        </Form.Field>
                    </div>
                </div>
                <div className="common--segment-half">
                    <div className="common--input-wrapper">
                        <Form.Field className="common--form-field">
                            <TextInput
                                style={{float: 'right'}}
                                control={TextInput}
                                onChange={this.onSectionDimensionsChange}
                                type="number"
                                header='Długość'
                                value={this.state.length}
                                name='length'
                                error={this.state.errorLength}
                            />
                        </Form.Field>
                        <Form.Field className="common--form-field">
                            <TextInput
                                control={TextInput}
                                onChange={this.onSectionDimensionsChange}
                                type="number"
                                header='Przewyższenie'
                                value={this.state.elevationGain}
                                name='elevationGain'
                                error={this.state.errorElevationGain}
                            />
                        </Form.Field>
                        <Form.Field
                            className="common--form-field"
                            control={TextInput}
                            header='Punktacja'
                            value={this.state.score}
                        />
                    </div>
                </div>

                <Form.Field style={{paddingLeft: '160px'}} inline>
                    <Button
                        primary
                        type="submit"
                        onClick={this.onSubmit}
                        content={'Dodaj odcinek'}
                    />
                    <Label
                        style={labelStyle}
                        pointing='left'
                        color='blue'
                        onRemove={this.handleDismiss}
                        content='Dodano odcinek&nbsp;&nbsp;&nbsp;&nbsp;'
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
            </SegmentContainer>
        )
    }
}
export default SectionEdit;