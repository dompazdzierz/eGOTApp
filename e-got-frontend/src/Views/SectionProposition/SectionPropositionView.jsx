import React from 'react';
import './SectionPropositionView.css';
import { Segment, Divider, Input, Button, DropdownSearchInput, Dropdown, Header, Icon } from 'semantic-ui-react';
import AppHeader from '../../Components/AppHeader/AppHeader';
import { Route } from 'react-router';

class SectionPropositionView extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            startLocation: "",
            endLocation: "",
            mountainRange: "",
            length: 0,
            elevationGain: 0,
            points: 0
        }
    }

    render() {
        return(
            <div className="section-proposition--container">
                <AppHeader />

                <Segment className="section-proposition--segment">
                    <Route render={({ history}) => (
                        <Button primary content="Powrót" floated="left" className="section-proposition--button"
                            onClick={() => history.goBack()}/>
                    )} />
                    <Route render={({ history}) => (
                        <Button primary content="Dalej" floated="right" className="section-proposition--button"
                            />
                    )} />
                    <Header icon as='h2'>
                        <Icon name="map signs" size="small"/>
                        <Header.Content>Dane wycieczki</Header.Content>
                    </Header>
                    <Divider style={{marginTop: '3vh'}}/>
                    <div style={{marginTop: '20px'}}>
                        <div className="section-proposition--segment-half">
                            <div className="section-proposition--input-wrapper">
                                <p>Data</p>
                                <Input disabled size="big" className="section-proposition--input"
                                defaultValue="17.06.2019"/>
                                <Input disabled size="big" className="section-proposition--input"></Input>
                                <Input disabled size="big" className="section-proposition--input"></Input>
                            </div>
                        </div>
                        <div className="section-proposition--segment-half">
                            <div className="section-proposition--input-wrapper">
                                <p>Data</p>
                                <Input disabled size="big" className="section-proposition--input"
                                defaultValue="17.06.2019"/>
                                <Input disabled size="big" className="section-proposition--input"></Input>
                                <Input disabled size="big" className="section-proposition--input"></Input>
                            </div>
                        </div>
                    </div>
                </Segment>

            </div>
        )
    }
}
export default SectionPropositionView;