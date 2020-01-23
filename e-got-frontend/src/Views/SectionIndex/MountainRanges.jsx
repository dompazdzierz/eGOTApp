import React from 'react';
import * as paths from '../../Common/paths';
import * as apiPaths from '../../Common/apiPaths';
import { Table, Button } from 'semantic-ui-react';
import ListWithPagination from '../../Components/ListWithPagination/ListWithPagination';
import SegmentContainer from '../../Components/SegmentContainer/SegmentContainer';
import { Route } from 'react-router';
import axios from '../../Common/axios';

class MountainRanges extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            currentPage: 1,
            rows: []
        }
    }

    componentDidMount() {
        axios() ({
            method: 'get',
            url: apiPaths.MOUNTAIN_RANGES + apiPaths.GET_ALL
        })
        .then(response => {
            console.log(response.data)
            this.setState({rows: response.data});
        })
        .catch(error => {
            console.log(error);
        })
    }

    handlePaginationChange = (_, data) =>  {
        this.setState({ currentPage: data.activePage ? data.activePage : data.value})
    }

    render() {
        let { rows } = this.state

        const rowsPerPage = 6

        let tableHeaderContent =
            <Table.Row>
                <Table.HeaderCell>Łańcuch górski</Table.HeaderCell>
                <Table.HeaderCell>Pasmo górskie</Table.HeaderCell>
                <Table.HeaderCell></Table.HeaderCell>
            </Table.Row>

        let tableBodyContent =
            rows.slice(0 + (this.state.currentPage - 1) * rowsPerPage, rowsPerPage + (this.state.currentPage - 1) * rowsPerPage).map((trip) => (
                <Table.Row key={trip.id}>
                    <Table.Cell>{trip.mountainSystemName}</Table.Cell>
                    <Table.Cell>{trip.name}</Table.Cell>
                    <Table.Cell>
                        <Route render={({ history }) => (
                            <Button circular primary icon='arrow right' onClick={() => history.push(paths.MOUNTAIN_RANGE + '/' + trip.id)}/>
                        )} />
                    </Table.Cell>
                </Table.Row>
            ))

        return(
            <SegmentContainer headerContent="Spis odcinków punktowanych" iconName='map'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => history.push(paths.HOME_VIEW)} >

                    <ListWithPagination rowsNumber={rows.length} rowsPerPage={6} tableHeaderContent={tableHeaderContent}
                        handleDropdownChange={this.handleDropdownChange} tableBodyContent={tableBodyContent} colSpan={3}
                        handlePaginationChange={this.handlePaginationChange} currentPage={this.state.currentPage} />

            </SegmentContainer>
        )
    }
}

export default MountainRanges;
