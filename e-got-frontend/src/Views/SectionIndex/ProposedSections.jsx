import React from 'react';
import { Table, Button, Confirm } from 'semantic-ui-react';
import ListWithPagination from '../../Components/ListWithPagination/ListWithPagination';
import SegmentContainer from '../../Components/SegmentContainer/SegmentContainer';
import axios from '../../Common/axios';
import * as apiPaths from '../../Common/apiPaths';
import NoDataSegment from '../../Components/NoDataSegment/NoDataSegment';

class ProposedSections extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            currentPage: 1,
            sectionsData: [],
            confirmOpen: false,
            confirmMessage: '',
            accept: false,
            idToAcceptOrReject: null
        }
    }

    componentDidMount() {
        axios() ({
            method: 'get',
            url: apiPaths.SECTIONS + apiPaths.GET_ALL + '?mountainRangeId=' + this.getRangeId() + '&status=' + false
        })
        .then(response => {
            this.setState({ sectionsData: response.data });
        })
        .catch(error => {
            console.log(error);
        })
    }

    handlePaginationChange = (_, data) =>  {
        this.setState({ currentPage: data.activePage ? data.activePage : data.value})
    }

    getRangeId = () => {
        var url = window.location.pathname;
        return url.substring(url.lastIndexOf('/') + 1);
    }

    openConfirm = (id, isAccept) => {
        this.setState({
            confirmOpen: true,
            confirmMessage: isAccept ? "Czy na pewno chcesz zaakceptować odcinek?" : "Czy na pewno chcesz odrzucić odcinek?",
            idToAcceptOrReject: id,
            accept: isAccept
        })
    }

    closeConfirm = () => {
        this.setState({ confirmOpen: false })
    }

    acceptOrRejectSection = () => {
        var newData = [...this.state.sectionsData]
        newData = newData.filter(x => x.id !== this.state.idToAcceptOrReject);

        this.setState({ confirmOpen: false, sectionsData: newData, idToAcceptOrReject: null })

        if(this.state.accept) {
            axios() ({
                method: 'post',
                url: apiPaths.SECTIONS + apiPaths.ACCEPT + '/' + this.state.idToAcceptOrReject
            })
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error);
            })
        } else {
            axios() ({
                method: 'delete',
                url: apiPaths.SECTIONS + apiPaths.REMOVE_ELEMENT + '/' + this.state.idToAcceptOrReject
            })
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.log(error);
            })
        }
    }

    render() {
        let { sectionsData } = this.state

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
                        <Button circular primary icon='check' onClick={() => this.openConfirm(section.id, true)}/>
                    </Table.Cell>
                    <Table.Cell>
                        <Button circular negative icon='times' onClick={() => this.openConfirm(section.id, false)}/>
                    </Table.Cell>
                </Table.Row>
            ))

        let content =
            sectionsData.length > 0 ?
            <ListWithPagination rowsNumber={sectionsData.length} rowsPerPage={6} tableHeaderContent={tableHeaderContent}
                handleDropdownChange={this.handleDropdownChange} tableBodyContent={tableBodyContent} colSpan={7}
                handlePaginationChange={this.handlePaginationChange} currentPage={this.state.currentPage} />
            :
            <NoDataSegment noDataMessage="W tej chwili nie ma żadnych zaproponowanych odcinków." />


        return(
            <SegmentContainer headerContent="Zaproponowane odcinki" iconName='pin'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => history.goBack()} >

                {content}

                <Confirm open={this.state.confirmOpen} onCancel={this.closeConfirm} onConfirm={this.acceptOrRejectSection}
                    content={this.state.confirmMessage} cancelButton="Anuluj"
                />

            </SegmentContainer>
        )
    }
}
export default ProposedSections;