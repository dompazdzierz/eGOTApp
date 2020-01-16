import React from 'react';
import * as paths from '../../../Common/paths'
import { Table, Button } from 'semantic-ui-react';
import ListWithPagination from '../../../Components/ListWithPagination/ListWithPagination';
import SegmentContainer from '../../../Components/SegmentContainer/SegmentContainer';

class UnverifiedTripsView extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            currentPage: 1,
            rows: [
                { id: 1, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
                { id: 2, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
                { id: 3, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
                { id: 4, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
                { id: 5, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
                { id: 6, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' },
                { id: 7, route: 'Wycieczka 1: Palenica Białczańska - Wodogrzmoty Mickiewicza', date: '17.08.2019', points: '18' }
            ]
        }
    }

    handlePaginationChange = (_, data) => {
        this.setState({ currentPage: data.activePage ? data.activePage : data.value})
    }

    handleVerifyClick = id => {
        console.log(id)
    }

    handleBackClick = history => {
        history.push(paths.HOME_VIEW)
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
            </Table.Row>


        let tableBodyContent =
            rows.slice(0 + (this.state.currentPage - 1) * rowsPerPage, rowsPerPage + (this.state.currentPage - 1) * rowsPerPage).map((trip) => (
                <Table.Row key={trip.id}>
                    <Table.Cell>{trip.route}</Table.Cell>
                    <Table.Cell>{trip.date}</Table.Cell>
                    <Table.Cell>{trip.points}</Table.Cell>
                    <Table.Cell>
                        <Button onClick={() => this.handleVerifyClick(trip.id)} circular primary icon='edit outline'/>
                    </Table.Cell>
                </Table.Row>
            ))

        return(
            <SegmentContainer headerContent="Niezweryfikowane wycieczki" iconName='list alternate outline'
                leftButtonContent="Powrót" leftButtonOnClick={this.handleBackClick} >

                <ListWithPagination rowsNumber={rows.length} rowsPerPage={6} tableHeaderContent={tableHeaderContent} handleDropdownChange={this.handleDropdownChange}
                    tableBodyContent={tableBodyContent} colSpan={4} handlePaginationChange={this.handlePaginationChange} currentPage={this.state.currentPage}/>

            </SegmentContainer>
        )
    }
}
export default UnverifiedTripsView;