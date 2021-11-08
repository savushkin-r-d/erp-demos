import { TableService } from "../services/table.service";
import { BaseTable } from "./baseTable";


export class ZttnTable extends BaseTable {
    constructor(tableServiceDef: TableService) {
        super(tableServiceDef);
        this._tableName = "ZTTN";
    }

    loadAll(): void {
        this._tableService.getZttns(this._showDeleted).subscribe((response: any[]) => {
            this.initTableFromResponse(response);
        });
    }

    getSysnByRowId(rowId: number): number {
        if (rowId <= 0)
            return -1;
        var sysnCol = this._columns.indexOf("SYSN");
        if (sysnCol >= 0) {
            var row = this._data[rowId];
            return row[sysnCol];
        }
        else {
            return -1;
        }
    }
}
