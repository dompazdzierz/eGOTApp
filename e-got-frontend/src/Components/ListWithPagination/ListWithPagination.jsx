import React from 'react';
import './ListWithPagination.css';
import { Table, Pagination, Dropdown } from 'semantic-ui-react';


class ListWithPagination extends React.Component {

    render() {
        let { rowsNumber, rowsPerPage, tableHeaderContent, tableBodyContent, colSpan, currentPage, handlePaginationChange } = this.props

        let dropdownOptions =
        Array.from(Array(100).keys()).slice(1, Math.ceil(rowsNumber / rowsPerPage) + 1).map((i) => ({ key: i, text: i, value: i }))

        return(
            <Table style={{}}>
                <Table.Header>
                    {tableHeaderContent}
                </Table.Header>

                <Table.Body>
                    {tableBodyContent}
                </Table.Body>

                <Table.Footer>
                    <Table.Row>
                        <Table.HeaderCell colSpan={colSpan} style={{textAlign: 'center'}}>

                            <Pagination totalPages={Math.ceil(rowsNumber / rowsPerPage)}
                                boundaryRange={1} onPageChange={handlePaginationChange} activePage={currentPage}/>

                            <Dropdown className="list-with-pagination--dropdown" selection options={dropdownOptions}
                                    value={currentPage} onChange={handlePaginationChange} />

                        </Table.HeaderCell>
                    </Table.Row>
                </Table.Footer>
            </Table>
        )
    }
}
export default ListWithPagination;