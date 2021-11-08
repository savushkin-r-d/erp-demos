import { Component, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent implements OnInit, OnChanges {
  @Input() tableName!: string;
  @Input() columns!: string[];
  @Input() data!: any[];
  @Output() onRowClick: EventEmitter<any> = new EventEmitter();

  isLoaded = false;
  constructor() {
    this.columns = [];
    this.data = [];
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.isLoaded = this.checkDataLoading(this.columns, this.data);
  }

  ngOnInit(): void {
    this.isLoaded = this.checkDataLoading(this.columns, this.data);
  }

  checkDataLoading(columns: string[], data: any[]): any {
    if (columns.length > 0 && data.length > 0) {
      return true;
    }
    else {
      return false;
    }
  }

  getSysn(rowId: number): void {
    var rowData = this.data[rowId];
    var sysnIndex = this.columns.indexOf("SYSN");
    var findSysn = sysnIndex >= 0;
    if (findSysn) {
      var sysn = rowData[sysnIndex];
      this.raiseOnRowClick(sysn);
    }
  }

  raiseOnRowClick(value: any): void {
    this.onRowClick.emit(value);
  }
}
