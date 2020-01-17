import React from 'react';
import * as paths from '../../Common/paths';
import { Table, Button } from 'semantic-ui-react';
import ListWithPagination from '../../Components/ListWithPagination/ListWithPagination';
import SegmentContainer from '../../Components/SegmentContainer/SegmentContainer';
import { Route } from 'react-router';

class MountainSystems extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            currentPage: 1,
            rows: [
                { id: 0, mountainSystem: 'Tatry i Podtatrze', mountainRange: 'Tatry Wysokie' },
                { id: 1, mountainSystem: 'Tatry i Podtatrze', mountainRange: 'Tatry Wysokie' },
                { id: 2, mountainSystem: 'Tatry i Podtatrze', mountainRange: 'Tatry Wysokie' },
                { id: 3, mountainSystem: 'Tatry i Podtatrze', mountainRange: 'Tatry Wysokie' },
                { id: 4, mountainSystem: 'Tatry i Podtatrze', mountainRange: 'Tatry Wysokie' },
                { id: 5, mountainSystem: 'Tatry i Podtatrze', mountainRange: 'Tatry Wysokie' },
                { id: 6, mountainSystem: 'Tatry i Podtatrze', mountainRange: 'Tatry Wysokie' }
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
                <Table.HeaderCell>Punkt początkowy</Table.HeaderCell>
                <Table.HeaderCell>Punkt końcowy</Table.HeaderCell>
                <Table.HeaderCell></Table.HeaderCell>
            </Table.Row>

        let tableBodyContent =
            rows.slice(0 + (this.state.currentPage - 1) * rowsPerPage, rowsPerPage + (this.state.currentPage - 1) * rowsPerPage).map((trip) => (
                <Table.Row key={trip.id}>
                    <Table.Cell>{trip.mountainSystem}</Table.Cell>
                    <Table.Cell>{trip.mountainRange}</Table.Cell>
                    <Table.Cell>
                        <Route render={({ history }) => (
                            <Button circular primary icon='arrow right' onClick={() => history.push(paths.SECTION_LIST)}/>
                        )} />
                    </Table.Cell>
                </Table.Row>
            ))

        return(
            <SegmentContainer headerContent="Spis odcinków punktowanych" iconName='map'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => history.push(paths.SECTION_LIST)} >

                    <ListWithPagination rowsNumber={rows.length} rowsPerPage={6} tableHeaderContent={tableHeaderContent}
                        handleDropdownChange={this.handleDropdownChange} tableBodyContent={tableBodyContent} colSpan={3}
                        handlePaginationChange={this.handlePaginationChange} currentPage={this.state.currentPage} />

            </SegmentContainer>
        )
    }
}
export default MountainSystems;