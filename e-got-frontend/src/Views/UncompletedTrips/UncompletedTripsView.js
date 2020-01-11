import React from 'react';
import { Segment, Table } from 'semantic-ui-react';
import AppHeader from '../../Components/AppHeader/AppHeader';

class UncompletedTripsView extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
        }
    }


    render() {

        const trips = [
            { route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
        ]

        let containerStyle = {
            textAlign: 'center'
        }

        let segmentStyle = {
            height: '80vh',
            width: '80vw',
            display: 'inline-block'
        }

        return(
            <div style={containerStyle}>
                <AppHeader />
                <Segment style={segmentStyle}>
                    <Table>
                        <Table.Header>
                        <Table.Row>
                            <Table.HeaderCell>Nazwa wycieczki</Table.HeaderCell>
                            <Table.HeaderCell>Data</Table.HeaderCell>
                            <Table.HeaderCell>Punktacja</Table.HeaderCell>
                        </Table.Row>
                        </Table.Header>
                        <Table.Body>
                        {trips.map((trip) => (
                            <Table.Row key={trip.route}>
                                <Table.Cell>{trip.route}</Table.Cell>
                                <Table.Cell>{trip.date}</Table.Cell>
                                <Table.Cell>{trip.points}</Table.Cell>
                            </Table.Row>
                        ))}
                        </Table.Body>
                    </Table>
                </Segment>
            </div>
        )
    }
}
export default UncompletedTripsView;