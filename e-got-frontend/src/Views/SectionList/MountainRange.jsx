import React from 'react';
import * as paths from '../../Common/paths';
import { Table, Button, Header, Icon, Segment } from 'semantic-ui-react';
import ListWithPagination from '../../Components/ListWithPagination/ListWithPagination';
import SegmentContainer from '../../Components/SegmentContainer/SegmentContainer';
import * as apiPaths from '../../Common/apiPaths';
import NoDataSegment from '../../Components/NoDataSegment/NoDataSegment';

const axios = require('axios');

const axiosInstance = axios.create({
    baseURL: apiPaths.API_ADRESS
});

class MountainRange extends React.Component {
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
            rows.slice(0 + (this.state.currentPage - 1) * rowsPerPage, rowsPerPage + (this.state.currentPage - 1) * rowsPerPage).map((section) => (
                <Table.Row key={section.id}>
                    <Table.Cell>{section.start_location}</Table.Cell>
                    <Table.Cell>{section.end_location}</Table.Cell>
                    <Table.Cell>{section.score}</Table.Cell>
                    <Table.Cell>{section.length}</Table.Cell>
                    <Table.Cell>{section.elevation_gain}</Table.Cell>
                    <Table.Cell>
                        <Button circular primary icon='pencil alternate'/>
                    </Table.Cell>
                    <Table.Cell>
                        <Button circular negative icon='trash alternate'/>
                    </Table.Cell>
                </Table.Row>
            ))

            let content =
            rows.length > 0 ?
            <ListWithPagination rowsNumber={rows.length} rowsPerPage={6} tableHeaderContent={tableHeaderContent}
                handleDropdownChange={this.handleDropdownChange} tableBodyContent={tableBodyContent} colSpan={7}
                handlePaginationChange={this.handlePaginationChange} currentPage={this.state.currentPage} />
            :
            <NoDataSegment noDataMessage="Nie ma jeszcze dodanych odcinków dla tego pasma górskiego." />


        return(

            <SegmentContainer headerContent={this.props.location.data} iconName='map'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => history.goBack()}
                rightButtonContent="Dodaj odcinek" rightButtonOnClick={(history) => history.push(paths.HOME_VIEW)}
                rightSecButtonContent="Zaproponowane odcinki" rightSecButtonOnClick={(history) => history.push(paths.PROPOSED_SECTIONS)} >

                {content}

            </SegmentContainer>
        )
    }
}
export default MountainRange;