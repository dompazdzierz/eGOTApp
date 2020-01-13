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

    handlePaginationChange = (_, { activePage }) =>  {
        this.setState({ currentPage: activePage })
    }

    //TODO: przenieść dane do state'a, przenieść csski do jakichś dzielonych, dotyczących listy, będzie to kilka razy użyte jeszcze pewnie :p

    render() {
        const rows = [
            { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
            { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
            { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
            { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
            { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
            { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
            { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
        ]

        const rowsPerPage = 6
        let rowsNumber = rows.length

        let dropdownOptions =
        Array.from(Array(10).keys()).slice(1, Math.ceil(rowsNumber / rowsPerPage) + 1).map((i) => ({ key: i, text: i, value: i }))

        let tableHeaderContent =
            <Table.Row>
                <Table.HeaderCell>Nazwa wycieczki</Table.HeaderCell>
                <Table.HeaderCell>Data</Table.HeaderCell>
                <Table.HeaderCell>Punktacja</Table.HeaderCell>
                <Table.HeaderCell></Table.HeaderCell>
                <Table.HeaderCell></Table.HeaderCell>
            </Table.Row>


        let tableBodyContent =
            rows.slice(0 + (this.state.currentPage - 1) * rowsPerPage, rowsPerPage + (this.state.currentPage - 1) * rowsPerPage).map((trip) => (
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
                            {tableHeaderContent}
                        </Table.Header>

                        <Table.Body>
                            {tableBodyContent}
                        </Table.Body>

                        <Table.Footer>
                            <Table.Row>
                                <Table.HeaderCell colSpan='5' style={{textAlign: 'center'}}>

                                    <Pagination defaultActivePage={1} totalPages={Math.ceil(rowsNumber / rowsPerPage)}
                                        boundaryRange={1} onPageChange={this.handlePaginationChange} activePage={this.state.currentPage}/>

                                    <Dropdown className="untraveled-trips--dropdown" selection options={dropdownOptions}
                                        value={this.state.currentPage} onChange={(_, {value}) => this.setState({currentPage: value})} />

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