import React from 'react';
import * as paths from '../../Common/paths';
import { Table, Button, Segment } from 'semantic-ui-react';
import ListWithPagination from '../../Components/ListWithPagination/ListWithPagination';
import SegmentContainer from '../../Components/SegmentContainer/SegmentContainer';
import { Route } from 'react-router';

class UntraveledTripsView extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            currentPage: 1,
            rows: [
                { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
                { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
                { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
                { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
                { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
                { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
                { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' }
            ]
        }
    }

    handlePaginationChange = (_, data) =>  {
        this.setState({ currentPage: data.activePage ? data.activePage : data.value})
    }

    render() {
        let { rows } = this.state

        const rowsPerPage = 6

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
                        <Route render={({ history }) => (
                            <Button circular primary icon='pencil alternate' onClick={() => history.push(paths.EDIT_TRIP + '/' + trip.id)}/>
                        )} />
                    </Table.Cell>
                    <Table.Cell>
                        <Button circular negative icon='trash alternate'/>
                    </Table.Cell>
                </Table.Row>
            ))

        return(
            <SegmentContainer headerContent="Nieprzebyte wycieczki" iconName='list alternate outline'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => history.push(paths.HOME_VIEW)} >

                    <ListWithPagination rowsNumber={rows.length} rowsPerPage={6} tableHeaderContent={tableHeaderContent}
                        handleDropdownChange={this.handleDropdownChange} tableBodyContent={tableBodyContent} colSpan={5}
                        handlePaginationChange={this.handlePaginationChange} currentPage={this.state.currentPage} />

            </SegmentContainer>
        )
    }
}
export default UntraveledTripsView;