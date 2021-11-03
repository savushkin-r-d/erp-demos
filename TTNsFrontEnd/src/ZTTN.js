import React from 'react'
import ReactTable from './ReactTable';

class ZTTNComponent extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            getAllUrl: "http:\\\\localhost:5000\\api\\zttn\\get-all",
            getSttnBySysn: "http:\\\\localhost:5000\\api\\sttn\\get-by-sysn",
            zttnItems: [],
            zttnColumns: [],
            zttnJsonKeys: [],
            zttnIsLoaded: false,
            lastSelectedSysn: -1,
            sttnColumns: [],
            sttnJsonKeys: [],
            sttnItems: [],
            sttnIsLoaded: false
        };
    }

    componentDidMount() {
        fetch(this.state.getAllUrl)
        .then(x => x.json())
        .then((result) => {
            this.setState({
                zttnJsonKeys: Object.keys(result[0]),
                zttnItems: result
            })

            var columnsSettings = [ ];
            this.state.zttnJsonKeys.forEach(function(item, index, array) {
                columnsSettings[index] = { Header: item.toUpperCase(), accessor: item };
            });
            this.setState({
                zttnColumns: columnsSettings,
                zttnIsLoaded: true
            });
        });
    }

    zttnClickCellCallback = (sysn) => {
        if (this.state.lastSelectedSysn !== sysn && sysn > 0)
        {
            this.setState({lastSelectedSysn: sysn})

            fetch(this.state.getSttnBySysn + "\\" + sysn)
            .then(x => x.json())
            .then((result) => {
                this.setState({
                    sttnJsonKeys: Object.keys(result[0]),
                    sttnItems: result
                })
            })

            var columnsSettings = [ ];
            this.state.sttnJsonKeys.forEach(function(item, index, array) {
                columnsSettings[index] = { Header: item.toUpperCase(), accessor: item };
            });
            this.setState({
                sttnColumns: columnsSettings,
                sttnIsLoaded: true
            });
        }
    }

    render(){
            if (!this.state.zttnIsLoaded)
            {
                return <div>Loading data...</div>;
            }
            else
            {
                return(
                    <>
                    <h5>Zttn table:</h5>
                    <i>Request to ZTTN_API table: {this.state.getAllUrl}</i>
                    <ReactTable onCellClickCallback={this.zttnClickCellCallback} columns={this.state.zttnColumns}
                        data={this.state.zttnItems}/>
                    <h5>Sttn table:</h5>
                    { this.state.lastSelectedSysn > 0 && this.state.sttnIsLoaded ?
                        <><i>Request to STTN_API table: {this.state.getSttnBySysn + "\\" + this.state.lastSelectedSysn}</i>
                        <ReactTable columns={this.state.sttnColumns} data={this.state.sttnItems} /></>:
                      null }
                    </>
                );
            }
    }
}

export default ZTTNComponent;

/* The component loads linked data from STTN table by SYSN value. SYSN take from ZTTN after click on table row*/