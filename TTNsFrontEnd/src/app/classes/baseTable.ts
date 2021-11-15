import { TableService } from "../services/table.service";

export class BaseTable {
    _columns: string[];
    _data: any[];
    _tableName: string;
    _tableService: TableService;
    protected _showDeleted: boolean;
    protected _typeSpecificData: any[];

    constructor(tableService: TableService) {
        this._columns = [];
        this._data = [];
        this._tableName = "";
        this._tableService = tableService;
        this._showDeleted = false;
        this._typeSpecificData = [];
    }

    initTableFromResponse(response: any[]): void {
        if (response.length > 0) {
            if (this._columns.length <= 0) {
                this.setColumnsFromResponse(response);
            }
            this.setDataFromResponse(response);
        }
        else {
            this._data = [];
        }
    }

    setDataFromResponse(response: any[]): void {
        this._data = this.getObjectValues(response);
    }

    setColumnsFromResponse(response: any[]): void {
        this._columns = this.getObjectKeys(response[0]);
    }

    getObjectValues(obj: any[]): any[] {
        return obj.map((row) => {
            return Object.values(row);
        })
    }

    getObjectKeys(obj: any[]): string[] {
        return Object.keys(obj);
    }

    toggle() {
        this._showDeleted = !this._showDeleted;
    }
}