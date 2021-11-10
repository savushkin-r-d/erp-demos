import { TableService } from "../services/table.service";
import { BaseTable } from "./baseTable";
import { StaticHelper } from 'src/app/classes/staticHelper';

export class SttnTable extends BaseTable {
    _loadedSysn : number;

    constructor(private tableServiceDef: TableService) {
        super(tableServiceDef);
        this._tableName = "STTN";
        this._loadedSysn = StaticHelper.resetSysnValue;
    }

    loadBySysn(sysn: number): void {
        this._tableService.getSttnsBySysn(sysn, this._showDeleted).subscribe({
            next: data => {
                this.initTableFromResponse(data);
                this._loadedSysn = sysn;
            },
            error: error => {
                this._loadedSysn = StaticHelper.resetSysnValue;
                console.log(error);
            }
        });
    }

    removeByRowId(event: any): void {
        var rowId = event;
        var correctRowId = rowId >= StaticHelper.minRowId;
        if (correctRowId) {
            var row = this._data[rowId];
            var indexOfFId = this._columns.indexOf("F_ID");
            var fId = row[indexOfFId];
            this._tableService.removeFromSttnByFId(fId).subscribe({
                next: data => {
                    this._data.splice(rowId, 1);
                },
                error: error => {
                    console.log(error);
                }
            });
        }
    }
}
