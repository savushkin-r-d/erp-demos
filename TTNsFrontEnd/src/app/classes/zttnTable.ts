import { TableService } from "../services/table.service";
import { BaseTable } from "./baseTable";
import { StaticHelper } from "./staticHelper";

export class ZttnTable extends BaseTable {
    constructor(tableServiceDef: TableService) {
        super(tableServiceDef);
        this._tableName = "ZTTN";
    }

    loadAll(): void {
        this._tableService.getZttns(this._showDeleted).subscribe({
            next: data => {
                this.initTableFromResponse(data);
            },
            error: error => {
                console.log(error);
            }
        });
    }

    getSysnByRowId(rowId: number): number {
        if (rowId < StaticHelper.minRowId) {
            return StaticHelper.resetSysnValue;
        }

        var sysnCol = this._columns.indexOf("SYSN");
        if (sysnCol >= StaticHelper.minColumnId) {
            var row = this._data[rowId];
            return row[sysnCol];
        }
        else {
            return StaticHelper.resetSysnValue;
        }
    }

    removeByRowId(event: any): void {
        var rowId = event;
        var correctRowId = rowId >= StaticHelper.minRowId;
        if (correctRowId) {
            var row = this._data[rowId];
            var indexOfFId = this._columns.indexOf("F_ID");
            var fId = row[indexOfFId];
            this._tableService.removeFromZttnByFId(fId).subscribe({
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
