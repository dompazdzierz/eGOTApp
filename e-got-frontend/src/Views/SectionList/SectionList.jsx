import React from 'react';
import * as paths from '../../Common/paths';
import { Table, Button } from 'semantic-ui-react';
import ListWithPagination from '../../Components/ListWithPagination/ListWithPagination';
import SegmentContainer from '../../Components/SegmentContainer/SegmentContainer';
import * as apiPaths from '../../Common/apiPaths';

const axios = require('axios');

const axiosInstance = axios.create({
    baseURL: apiPaths.API_ADRESS
});

class SectionList extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            currentPage: 1,
            rows: []
        }
    }

    componentDidMount() {
        document.getElementById('left-btn-sec').style.width = '200px';

        axiosInstance({
            method: 'get',
            url: apiPaths.SECTION + apiPaths.GET_ALL + "?mountain_range=" + this.props.location.data
        })
        .then(response => {
            console.log(response.data)
            this.setState({rows: response.data});
        })
        .catch(error => {
            console.log(error.response.data);
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
                <Table.HeaderCell>Punkt początkowy</Table.HeaderCell>
                <Table.HeaderCell>Punkt końcowy</Table.HeaderCell>
                <Table.HeaderCell>Punktacja</Table.HeaderCell>
                <Table.HeaderCell>Długość</Table.HeaderCell>
                <Table.HeaderCell>Przewyższenie</Table.HeaderCell>
                <Table.HeaderCell></Table.HeaderCell>
                <Table.HeaderCell></Table.HeaderCell>
            </Table.Row>

        let tableBodyContent =
            rows.slice(0 + (this.state.currentPage - 1) * rowsPerPage, rowsPerPage + (this.state.currentPage - 1) * rowsPerPage).map((trip) => (
                <Table.Row key={trip.id}>
                    <Table.Cell>{trip.start_location}</Table.Cell>
                    <Table.Cell>{trip.end_location}</Table.Cell>
                    <Table.Cell>{trip.score}</Table.Cell>
                    <Table.Cell>{trip.length}</Table.Cell>
                    <Table.Cell>{trip.elevation_gain}</Table.Cell>
                    <Table.Cell>
                        <Button circular primary icon='pencil alternate'/>
                    </Table.Cell>
                    <Table.Cell>
                        <Button circular negative icon='trash alternate'/>
                    </Table.Cell>
                </Table.Row>
            ))

        return(
            <SegmentContainer headerContent={this.props.location.data} iconName='map'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => history.goBack()}
                rightButtonContent="Dodaj odcinek" rightButtonOnClick={(history) => history.push(paths.HOME_VIEW)}
                rightSecButtonContent="Zaproponowane odcinki" rightSecButtonOnClick={(history) => history.push(paths.PROPOSED_SECTIONS)} >

                    <ListWithPagination rowsNumber={rows.length} rowsPerPage={6} tableHeaderContent={tableHeaderContent}
                        handleDropdownChange={this.handleDropdownChange} tableBodyContent={tableBodyContent} colSpan={5}
                        handlePaginationChange={this.handlePaginationChange} currentPage={this.state.currentPage} />

            </SegmentContainer>
        )
    }
}
export default SectionList;