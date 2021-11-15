import { TableService } from "../services/table.service";
import { BaseTable } from "./baseTable";
import { StaticHelper } from "./staticHelper";
import { ZttnTableViewModel } from "./viewModels/zttnTableViewModel";

export class ZttnTable extends BaseTable {
    constructor(tableServiceDef: TableService) {
        super(tableServiceDef);
        this._tableName = "ZTTN";
    }

    loadAll(): void {
        this._tableService.getZttns(this._showDeleted).subscribe({
            next: data => {
                this.initTableFromResponse(data);
                this._typeSpecificData = data;
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

        var sysnCol = this._columns.indexOf("sysn");
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
            var indexOfFId = this._columns.indexOf("f_ID");
            var fId = row[indexOfFId];
            this._tableService.removeFromZttnByFId(fId).subscribe({
                next: () => {
                    this._data.splice(rowId, 1);
                },
                error: error => {
                    console.log(error);
                }
            });
        }
    }

    updateZttn(event: any): void {
        var data = event.data;
        var rowId = event.rowId;
        var zttn = this.generateObjectAsAny(this._typeSpecificData[rowId], data);
        this._tableService.updateZttn(zttn).subscribe({
            next: receivedData => {
                this._typeSpecificData[rowId] = receivedData;
                this._data[rowId] = Object.values(receivedData);
            },
            error: error => {
                console.log(error);
            }
        });
    }

    private generateObjectAsAny(typeSpecificObject: any, data: any): any {
        var objAsAny = typeSpecificObject;
        for (var i = 0; i < this._columns.length; i++) {
            var columnName = this._columns[i];
            objAsAny[columnName] = data[i];
        }

        return objAsAny;
    }
}
