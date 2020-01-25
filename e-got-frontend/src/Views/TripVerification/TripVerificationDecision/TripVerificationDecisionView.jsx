import React from 'react';
import '../TripVerification.css'
import './TripVerificationDecisionView.css'
import { Divider, Button, TextArea, Confirm } from 'semantic-ui-react';
import * as paths from "../../../Common/paths"
import SegmentContainer from '../../../Components/SegmentContainer/SegmentContainer';
import axios from '../../../Common/axios';
import * as apiPaths from '../../../Common/apiPaths';
import { Route } from 'react-router';

class TripVerificationDecisionView extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            value: "",
            open: false,
            content: "",
            verified: null,
            wasPositiveClicked: false
        }
    }

    getTripId() {
        var url = window.location.pathname;
        return url.substring(url.lastIndexOf('/') + 1);
    }

    handleTextAreaChange = (_, object) => {
        this.setState({value: object.value})
    }

    openConfirm = (wasPositiveClicked) =>  {
        this.setState({
            open: true,
            content: wasPositiveClicked ? "Jesteś pewien, że chcesz pozytywnie zweryfikować tę wycieczkę?"
             : "Jesteś pewien, że chcesz negatywnie zweryfikować tę wycieczkę?",
            wasPositiveClicked: wasPositiveClicked
        })
    }

    //TODO: Do zdefiniowania są dwa onConfirmy: jeden dla pozytywnej weryfikacji, drugi dla negatywnej

    confirm = (history) => {
        this.setState({ open: false })

        if(this.state.wasPositiveClicked) {
            axios() ({
                method: 'post',
                url: apiPaths.TRAVELED_TRIPS + apiPaths.ACCEPT + '/' + this.getTripId()
            })
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error);
            })
        } else {
            axios() ({
                method: 'post',
                url: apiPaths.TRAVELED_TRIPS + apiPaths.REJECT + '/' + this.getTripId()
            })
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error);
            })
        }

        history.push(paths.UNVERIFIED_TRIPS)
    }

    close = () => this.setState({ open: false })

    render() {

        let { value } = this.state

        return (
            <SegmentContainer headerContent="Decyzja dotycząca weryfikacji" iconName='check square outline'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => history.push(paths.TRIP_VERIFICATION + paths.PROOFS + '/' + this.getTripId())} >

                    <Divider/>

                    <p className="trip-verification--label">Komentarz</p>
                    <TextArea className="trip-verification-decision--text-area" value={value} onChange={this.handleTextAreaChange} />

                    <Button primary basic content="Odrzuć" className="trip-verification-decision--button"
                       onClick={() => this.openConfirm(false)} />

                    <Button primary content="Zatwierdź" className="trip-verification-decision--button"
                        onClick={() => this.openConfirm(true)} />

                    <Route render={({ history }) => (
                        <Confirm
                            open={this.state.open}
                            content={this.state.content}
                            onCancel={this.close}
                            onConfirm={() => this.confirm(history)}
                            cancelButton='Anuluj'
                            confirmButton='Kontynuuj'
                        />
                    )}/>

            </SegmentContainer>
        )
    }
}
export default TripVerificationDecisionView;