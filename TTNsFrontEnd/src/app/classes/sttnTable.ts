import { TableService } from "../services/table.service";
import { BaseTable } from "./baseTable";

export class SttnTable extends BaseTable {
    _loadedSysn : number;

    constructor(private tableServiceDef: TableService) {
        super(tableServiceDef);
        this._tableName = "STTN";
        this._loadedSysn = -1;
    }

    loadBySysn(sysn: number): void {
        this._tableService.getSttnsBySysn(sysn, this._showDeleted).subscribe((response: any[]) => {
            this.initTableFromResponse(response);
            this._loadedSysn = sysn;
        });
    }
}
