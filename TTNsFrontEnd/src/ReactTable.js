import React from 'react';
import { useTable } from 'react-table';
import './ReactTable.css';

function ReactTable({onCellClickCallback, columns, data}) {
    const {
        getTableProps,
        getTableBodyProps,
        headerGroups,
        rows,
        prepareRow,
    } = useTable({ columns, data })

    return(
        <div className="overflowY">
            <table {...getTableProps()}>
            <thead>
                {headerGroups.map(headerGroup => (
                <tr {...headerGroup.getHeaderGroupProps()}>
                    {headerGroup.headers.map(column => (
                    <th {...column.getHeaderProps()}>{column.render('Header')}</th>
                    ))}
                </tr>
                ))}
            </thead>
            <tbody {...getTableBodyProps()}>
                {rows.map((row, i) => {
                prepareRow(row)
                return (
                    <tr {...row.getRowProps()}>
                    {row.cells.map(cell => {
                        return <td onClick={() => { onCellClickCallback(row.values.sysn)}} {...cell.getCellProps()}>{cell.render('Cell')}</td>
                    })}
                    </tr>
                )
                })}
            </tbody>
            </table>
        </div>
        );
}

export default ReactTable;