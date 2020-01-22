import React from 'react';
import * as paths from '../../Common/paths';
import { Table, Button } from 'semantic-ui-react';
import ListWithPagination from '../../Components/ListWithPagination/ListWithPagination';
import SegmentContainer from '../../Components/SegmentContainer/SegmentContainer';
import * as apiPaths from '../../Common/apiPaths';
import NoDataSegment from '../../Components/NoDataSegment/NoDataSegment';
import axios from '../../Common/axios';
import { Route } from 'react-router';

class MountainRange extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            currentPage: 1,
            rangeName: '',
            sectionsData: []
        }
    }

    componentDidMount() {
        axios() ({
            method: 'get',
            url: apiPaths.MOUNTAIN_RANGES + apiPaths.GET + '/' + this.getRangeId()
        })
        .then(response => {
            this.setState({rangeName: response.data.name});
        })
        .catch(error => {
            console.log(error);
        })

        axios() ({
            method: 'get',
            url: apiPaths.SECTIONS + apiPaths.GET_ALL + '?mountainRangeId=' + this.getRangeId() + '&status=' + true
        })
        .then(response => {
            this.setState({sectionsData: response.data});
        })
        .catch(error => {
            console.log(error);
        })

        document.getElementById('left-btn-sec').style.width = '200px';
    }

    getRangeId = () => {
        var url = window.location.pathname;
        return url.substring(url.lastIndexOf('/') + 1);
    }

    handlePaginationChange = (_, data) =>  {
        this.setState({ currentPage: data.activePage ? data.activePage : data.value})
    }

    render() {
        let { sectionsData } = this.state
        console.log(sectionsData)
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
            sectionsData.slice(0 + (this.state.currentPage - 1) * rowsPerPage, rowsPerPage + (this.state.currentPage - 1) * rowsPerPage).map((section) => (
                <Table.Row key={section.id}>
                    <Table.Cell>{section.startLocation}</Table.Cell>
                    <Table.Cell>{section.endLocation}</Table.Cell>
                    <Table.Cell>{section.score}</Table.Cell>
                    <Table.Cell>{section.length}</Table.Cell>
                    <Table.Cell>{section.elevationGain}</Table.Cell>
                    <Table.Cell>
                        <Route render={({ history }) => (
                            <Button onClick={() => history.push(paths.SECTION_EDIT + '/' + section.id)} circular primary icon='pencil alternate'/>
                        )} />
                    </Table.Cell>
                    <Table.Cell>
                        <Button circular negative icon='trash alternate'/>
                    </Table.Cell>
                </Table.Row>
            ))

        let content =
            sectionsData.length > 0 ?
            <ListWithPagination rowsNumber={sectionsData.length} rowsPerPage={6} tableHeaderContent={tableHeaderContent}
                handleDropdownChange={this.handleDropdownChange} tableBodyContent={tableBodyContent} colSpan={7}
                handlePaginationChange={this.handlePaginationChange} currentPage={this.state.currentPage} />
            :
            <NoDataSegment noDataMessage="Nie ma jeszcze dodanych odcinków dla tego pasma górskiego." />

        return(
            <SegmentContainer headerContent={this.state.rangeName} iconName='map'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => history.goBack()}
                rightButtonContent="Dodaj odcinek" rightButtonOnClick={(history) => history.push(paths.HOME_VIEW)}
                rightSecButtonContent="Zaproponowane odcinki" rightSecButtonOnClick={(history) => history.push(paths.PROPOSED_SECTIONS)} >

                {content}

            </SegmentContainer>
        )
    }
}
export default MountainRange;