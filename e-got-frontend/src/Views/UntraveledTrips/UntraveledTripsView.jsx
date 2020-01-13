import React from 'react';
import './UntraveledTripsView.css';
import { Segment, Table, Button, Pagination, Dropdown } from 'semantic-ui-react';
import AppHeader from '../../Components/AppHeader/AppHeader';
import { Route } from 'react-router';

class UntraveledTripsView extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            currentPage: 1
        }
    }

    handlePaginationChange = (e, { activePage }) =>  {
        this.setState({ currentPage: activePage })
        console.log(this.state.currentPage)
    }

    render() {
        const trips = [
            { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
            { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
            { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
            { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
            { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
            { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
            { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
            { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
            { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
            { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
        ]

        const tripsPerPage = 6
        let tripsNumber = trips.length

        let tableContent =
        trips.slice(0 + (this.state.currentPage - 1) * tripsPerPage, tripsPerPage + (this.state.currentPage - 1) * tripsPerPage).map((trip) => (
            <Table.Row key={trip.id}>
                <Table.Cell>{trip.route}</Table.Cell>
                <Table.Cell>{trip.date}</Table.Cell>
                <Table.Cell>{trip.points}</Table.Cell>
                <Table.Cell>
                    <Button circular primary icon='pencil alternate'/>
                </Table.Cell>
                <Table.Cell>
                    <Button circular negative icon='trash alternate'/>
                </Table.Cell>
            </Table.Row>
        ))

        let dropdownOptions =
            Array.from(Array(10).keys()).slice(1).map((i) => ({ key: i, text: i, value: i }))

        return(
            <div className="untraveled-trips--container">
                <AppHeader />
                <Segment className="untraveled-trips--segment">

                    <Route render={({ history}) => (
                        <Button primary content="Powrót" floated="left" className="untraveled-trips--button"
                            onClick={() => history.goBack()}/>
                    )} />

                    <Table className="untraveled-trips--table">
                        <Table.Header>
                            <Table.Row>
                                <Table.HeaderCell>Nazwa wycieczki</Table.HeaderCell>
                                <Table.HeaderCell>Data</Table.HeaderCell>
                                <Table.HeaderCell>Punktacja</Table.HeaderCell>
                                <Table.HeaderCell></Table.HeaderCell>
                                <Table.HeaderCell></Table.HeaderCell>
                            </Table.Row>
                        </Table.Header>

                        <Table.Body>
                            {tableContent}
                        </Table.Body>

                        <Table.Footer>
                            <Table.Row>
                                <Table.HeaderCell colSpan='5' style={{textAlign: 'center'}}>
                                    <Pagination defaultActivePage={1} totalPages={Math.ceil(tripsNumber / tripsPerPage)}
                                    boundaryRange={1} onPageChange={this.handlePaginationChange} activePage={this.state.currentPage}/>
                                    <Dropdown className="untraveled-trips--dropdown" selection options={dropdownOptions}
                                    value={this.state.currentPage} onChange={(event, data) => this.setState({currentPage: data.value})} />
                                </Table.HeaderCell>
                            </Table.Row>
                        </Table.Footer>

                    </Table>
                </Segment>
            </div>
        )
    }
}
export default UntraveledTripsView;