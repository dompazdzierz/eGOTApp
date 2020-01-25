import React from 'react';
import * as paths from '../../Common/paths';
import { Table, Button, Confirm } from 'semantic-ui-react';
import ListWithPagination from '../../Components/ListWithPagination/ListWithPagination';
import SegmentContainer from '../../Components/SegmentContainer/SegmentContainer';
import { Route } from 'react-router';
import axios from '../../Common/axios';
import * as apiPaths from '../../Common/apiPaths';
import NoDataSegment from '../../Components/NoDataSegment/NoDataSegment';

class UntraveledTripsView extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            currentPage: 1,
            tripsData: [],
            confirmOpen: false,
            idToDelete: null
        }
    }

    componentDidMount() {
        axios() ({
            method: 'get',
            url: apiPaths.UNTRAVELED_TRIPS + apiPaths.GET_TOURIST + '/0'
        })
        .then(response => {
            this.setState({ tripsData: response.data });
        })
        .catch(error => {
            console.log(error);
        })
    }

    handlePaginationChange = (_, data) =>  {
        this.setState({ currentPage: data.activePage ? data.activePage : data.value})
    }

    openConfirm = id => {
        this.setState({ confirmOpen: true, idToDelete: id })
    }

    closeConfirm = () => {
        this.setState({ confirmOpen: false })
    }

    deleteTrip = () => {
        var newData = [...this.state.tripsData]
        newData = newData.filter(x => x.id !== this.state.idToDelete);

        this.setState({ confirmOpen: false, tripsData: newData, idToDelete: null })

        axios() ({
            method: 'delete',
            url: apiPaths.UNTRAVELED_TRIPS + apiPaths.REMOVE_ELEMENT + '/' + this.state.idToDelete
        })
        .then(response => {
            console.log(response)
        })
        .catch(error => {
            console.log(error);
        })
    }

    render() {
        let { tripsData } = this.state
        const rowsPerPage = 6

        let tableHeaderContent =
            <Table.Row>
                <Table.HeaderCell>Nazwa wycieczki</Table.HeaderCell>
                <Table.HeaderCell>Data</Table.HeaderCell>
                <Table.HeaderCell>Czas trwania</Table.HeaderCell>
                <Table.HeaderCell>Punktacja</Table.HeaderCell>
                <Table.HeaderCell></Table.HeaderCell>
                <Table.HeaderCell></Table.HeaderCell>
            </Table.Row>

        let tableBodyContent =
            tripsData.slice(0 + (this.state.currentPage - 1) * rowsPerPage, rowsPerPage + (this.state.currentPage - 1) * rowsPerPage).map((trip) => (
                <Table.Row key={trip.id}>
                    <Table.Cell>{trip.title}</Table.Cell>
                    <Table.Cell>{trip.startDate}</Table.Cell>
                    <Table.Cell>{trip.endDate}</Table.Cell>
                    <Table.Cell>{trip.score}</Table.Cell>
                    <Table.Cell>
                        <Route render={({ history }) => (
                            <Button circular primary icon='pencil alternate' onClick={() => history.push(paths.EDIT_TRIP + '/' + trip.id)}/>
                        )} />
                    </Table.Cell>
                    <Table.Cell>
                        <Button circular negative icon='trash alternate' onClick={() => this.openConfirm(trip.id)}/>
                    </Table.Cell>
                </Table.Row>
            ))

        let content =
            tripsData.length > 0 ?
            <ListWithPagination rowsNumber={tripsData.length} rowsPerPage={6} tableHeaderContent={tableHeaderContent}
                handleDropdownChange={this.handleDropdownChange} tableBodyContent={tableBodyContent} colSpan={6}
                handlePaginationChange={this.handlePaginationChange} currentPage={this.state.currentPage} />
            :
            <NoDataSegment noDataMessage="Brak nieprzebytych wycieczek." />

        return(
            <SegmentContainer headerContent="Nieprzebyte wycieczki" iconName='list alternate outline'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => history.goBack()} >

                {content}

                <Confirm open={this.state.confirmOpen} onCancel={this.closeConfirm} onConfirm={this.deleteTrip}
                    content="Czy na pewno chcesz usunąć wycieczkę?" cancelButton="Anuluj"
                />

            </SegmentContainer>
        )
    }
}
export default UntraveledTripsView;