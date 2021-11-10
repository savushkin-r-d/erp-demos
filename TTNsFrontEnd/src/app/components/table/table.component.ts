import { Component, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { StaticHelper } from 'src/app/classes/staticHelper';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent implements OnInit, OnChanges {
  @Input() tableName!: string;
  @Input() columns!: string[];
  @Input() data!: any[];
  @Output() onRowClick: EventEmitter<number>;
  @Output() onChangedToggle: EventEmitter<boolean>;
  @Output() onRowDelete: EventEmitter<number>

  showDeleted: boolean;
  isLoaded: boolean;
  selectedRow: number;

  constructor() {
    this.columns = [];
    this.data = [];
    this.showDeleted = false;
    this.isLoaded = false;
    this.onRowClick = new EventEmitter();
    this.onChangedToggle = new EventEmitter();
    this.onRowDelete = new EventEmitter();
    this.selectedRow = StaticHelper.resetRowId;
  }

  resetSelectedRow(): void {
    this.selectedRow = StaticHelper.resetRowId;
  }

  toggle(): void {
    this.showDeleted = !this.showDeleted;
    this.onChangedToggle.emit(this.showDeleted);
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.checkDataLoading(this.columns, this.data);
    this.resetSelectedRow();
  }

  ngOnInit(): void {
    this.checkDataLoading(this.columns, this.data);
    this.resetSelectedRow();
  }

  checkDataLoading(columns: string[], data: any[]): void {
    var tableIsNotEmpty = columns.length > 0 && data.length > 0;
    this.isLoaded = tableIsNotEmpty;;
  }

  raiseOnRowClick(event: any, rowId: number): void {
    var unselectRow = this.selectedRow == rowId;
    if (unselectRow) {
      this.resetSelectedRow();
    }
    else {
      this.selectedRow = rowId;
    }

    this.onRowClick.emit(rowId);
  }

  deleteSelectedRow(event: any) {
    var rowSelected = this.selectedRow > StaticHelper.resetRowId;
    if (rowSelected) {
      this.onRowDelete.emit(this.selectedRow);
      this.resetSelectedRow();
    }
  }
}
