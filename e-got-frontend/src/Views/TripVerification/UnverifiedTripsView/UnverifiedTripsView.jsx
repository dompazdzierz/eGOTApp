import React from 'react';
import * as paths from '../../../Common/paths'
import { Table, Button } from 'semantic-ui-react';
import ListWithPagination from '../../../Components/ListWithPagination/ListWithPagination';
import SegmentContainer from '../../../Components/SegmentContainer/SegmentContainer';
import axios from '../../../Common/axios';
import * as apiPaths from '../../../Common/apiPaths';
import { Route } from 'react-router';
import NoDataSegment from '../../../Components/NoDataSegment/NoDataSegment';

class UnverifiedTripsView extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            currentPage: 1,
            tripsData: []
        }
    }

    componentDidMount() {
        axios() ({
            method: 'get',
            url: apiPaths.TRAVELED_TRIPS + apiPaths.GET_ALL
        })
        .then(response => {
            this.setState({ tripsData: response.data });
        })
        .catch(error => {
            console.log(error);
        })
    }

    handlePaginationChange = (_, data) => {
        this.setState({ currentPage: data.activePage ? data.activePage : data.value})
    }

    handleBackClick = history => {
        history.push(paths.HOME_VIEW)
    }

    render() {
        let { tripsData } = this.state
        const rowsPerPage = 6

        let tableHeaderContent =
            <Table.Row>
                <Table.HeaderCell>Nazwa wycieczki</Table.HeaderCell>
                <Table.HeaderCell>Data</Table.HeaderCell>
                <Table.HeaderCell>Punktacja</Table.HeaderCell>
                <Table.HeaderCell></Table.HeaderCell>
            </Table.Row>


        let tableBodyContent =
            tripsData.slice(0 + (this.state.currentPage - 1) * rowsPerPage, rowsPerPage + (this.state.currentPage - 1) * rowsPerPage).map((trip) => (
                <Table.Row key={trip.id}>
                    <Table.Cell>{trip.title}</Table.Cell>
                    <Table.Cell>{trip.startDate}</Table.Cell>
                    <Table.Cell>{trip.score}</Table.Cell>
                    <Table.Cell>
                        <Route render={({ history }) => (
                            <Button circular primary icon='edit outline' onClick={() => history.push(paths.TRIP_VERIFICATION + paths.DATA + '/' + trip.id)}/>
                        )} />
                    </Table.Cell>
                </Table.Row>
            ))
        
        let content =
            tripsData.length > 0 ?
            <ListWithPagination rowsNumber={tripsData.length} rowsPerPage={6} tableHeaderContent={tableHeaderContent} handleDropdownChange={this.handleDropdownChange}
                    tableBodyContent={tableBodyContent} colSpan={4} handlePaginationChange={this.handlePaginationChange} currentPage={this.state.currentPage}/>
            :
            <NoDataSegment noDataMessage="Brak niezweryfikowanych wycieczek." />

        return(
            <SegmentContainer headerContent="Niezweryfikowane wycieczki" iconName='list alternate outline'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => history.goBack()} >

                {content}

            </SegmentContainer>
        )
    }
}
export default UnverifiedTripsView;