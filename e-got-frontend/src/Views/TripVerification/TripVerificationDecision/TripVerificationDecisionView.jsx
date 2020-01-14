import React from 'react';
import '../TripVerification.css'
import './TripVerificationDecisionView.css'
import { Segment, Divider, Button, Header, Icon, TextArea, Confirm } from 'semantic-ui-react';
import { Route } from "react-router-dom";
import * as paths from "../../../Common/paths"
import AppHeader from '../../../Components/AppHeader/AppHeader';

class TripVerificationDecisionView extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            value: "",
            open: false,
            content: ""
        }
    }

    handleTextAreaChange = (_, object) => {
        this.setState({value: object.value})
    }

    openConfirm = (wasPositiveClicked) =>  {
        this.setState({
            open: true,
            content: wasPositiveClicked ? "Jesteś pewien, że chcesz pozytywnie zweryfikować tę wycieczkę?"
             : "Jesteś pewien, że chcesz negatywnie zweryfikować tę wycieczkę?"
        })
    }

    //TODO: Do zdefiniowania są dwa onConfirmy: jeden dla pozytywnej weryfikacji, drugi dla negatywnej

    close = () => this.setState({ open: false })

    render() {

        let { value } = this.state

        return (
            <div className="trip-verification--container">
                <AppHeader />

                <Segment style={{width: "90vw"}} className="trip-verification--segment">
                    <Route render={({history}) => (
                        <Button primary content="Powrót" floated="left" className="trip-verification--button"
                            onClick={() => history.push(paths.TRIP_VERIFICATION + paths.PROOFS)}/>
                    )} />

                    <Route render={({history}) => (
                        <Button primary content="Dalej" floated="right" className="trip-verification--button"
                            style={{visibility: 'hidden'}}/>
                    )} />

                    <div>
                        <Icon style={{linemaxHeight: 'unset', verticalAlign: 'unset'}} name="file outline" size="big"/>
                        <Header icon as='h2'>
                            <Header.Content>Decyzja</Header.Content>
                        </Header>
                    </div>

                    <Divider/>

                    <p className="trip-verification--label">Komentarz</p>
                    <TextArea className="trip-verification-decision--text-area" value={value} onChange={this.handleTextAreaChange} />

                    <Button primary basic content="Odrzuć" className="trip-verification-decision--button"
                       onClick={() => this.openConfirm(false)} />

                    <Button primary content="Zatwierdź" className="trip-verification-decision--button"
                        onClick={() => this.openConfirm(true)} />

                    <Confirm
                       open={this.state.open}
                       content={this.state.content}
                       onCancel={this.close}
                       onConfirm={this.close}
                       cancelButton='Anuluj'
                       confirmButton='Kontynuuj'
                     />

                </Segment>
            </div>
        )
    }
}
export default TripVerificationDecisionView;