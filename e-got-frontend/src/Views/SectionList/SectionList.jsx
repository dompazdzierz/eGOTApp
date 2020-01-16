import React from 'react';
import * as paths from '../../Common/paths';
import { Table, Button } from 'semantic-ui-react';
import ListWithPagination from '../../Components/ListWithPagination/ListWithPagination';
import SegmentContainer from '../../Components/SegmentContainer/SegmentContainer';

class SectionList extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            currentPage: 1,
            rows: [
                { id: 0, startPoint: 'Palenica Białczańska', endPoint: 'Wodogrzmoty Mickiewicza', points: '18' },
                { id: 1, startPoint: 'Palenica Białczańska', endPoint: 'Wodogrzmoty Mickiewicza', points: '18' },
                { id: 2, startPoint: 'Palenica Białczańska', endPoint: 'Wodogrzmoty Mickiewicza', points: '18' },
                { id: 3, startPoint: 'Palenica Białczańska', endPoint: 'Wodogrzmoty Mickiewicza', points: '18' },
                { id: 4, startPoint: 'Palenica Białczańska', endPoint: 'Wodogrzmoty Mickiewicza', points: '18' },
                { id: 5, startPoint: 'Palenica Białczańska', endPoint: 'Wodogrzmoty Mickiewicza', points: '18' },
                { id: 6, startPoint: 'Palenica Białczańska', endPoint: 'Wodogrzmoty Mickiewicza', points: '18' }
            ]
        }
    }

    componentDidMount() {
        document.getElementById('left-btn-sec').style.width = '200px';
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
                <Table.HeaderCell></Table.HeaderCell>
                <Table.HeaderCell></Table.HeaderCell>
            </Table.Row>

        let tableBodyContent =
            rows.slice(0 + (this.state.currentPage - 1) * rowsPerPage, rowsPerPage + (this.state.currentPage - 1) * rowsPerPage).map((trip) => (
                <Table.Row key={trip.id}>
                    <Table.Cell>{trip.startPoint}</Table.Cell>
                    <Table.Cell>{trip.endPoint}</Table.Cell>
                    <Table.Cell>{trip.points}</Table.Cell>
                    <Table.Cell>
                        <Button circular primary icon='pencil alternate'/>
                    </Table.Cell>
                    <Table.Cell>
                        <Button circular negative icon='trash alternate'/>
                    </Table.Cell>
                </Table.Row>
            ))

        return(
            <SegmentContainer headerContent="Tatry Wysokie - T.01" iconName='map'
                leftButtonContent="Powrót" leftButtonOnClick={(history) => history.push(paths.HOME_VIEW)}
                rightButtonContent="Dodaj odcinek" rightButtonOnClick={(history) => history.push(paths.HOME_VIEW)}
                rightSecButtonContent="Zaproponowane odcinki" rightSecButtonOnClick={(history) => history.push(paths.HOME_VIEW)} >

                    <ListWithPagination rowsNumber={rows.length} rowsPerPage={6} tableHeaderContent={tableHeaderContent}
                        handleDropdownChange={this.handleDropdownChange} tableBodyContent={tableBodyContent} colSpan={5}
                        handlePaginationChange={this.handlePaginationChange} currentPage={this.state.currentPage} />

            </SegmentContainer>
        )
    }
}
export default SectionList;