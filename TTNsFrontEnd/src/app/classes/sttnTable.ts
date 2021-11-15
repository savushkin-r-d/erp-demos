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
                this._typeSpecificData = data;
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

    updateSttn(event: any) : void {
        var data = event.data;
        var rowId = event.rowId;
        var sttn = this.generateObjectAsAny(this._typeSpecificData[rowId], data);
        this._tableService.updateSttn(sttn).subscribe({
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
        // 1 - skipped sysn first column
        for (var i = 1; i < this._columns.length; i++) {
            var columnName = this._columns[i];
            objAsAny[columnName] = data[i];
        }

        return objAsAny;
    }
}
