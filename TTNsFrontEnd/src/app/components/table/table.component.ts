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
  updateRow: boolean;
  createRow: boolean;

  constructor() {
    this.columns = [];
    this.data = [];
    this.showDeleted = false;
    this.isLoaded = false;
    this.onRowClick = new EventEmitter();
    this.onChangedToggle = new EventEmitter();
    this.onRowDelete = new EventEmitter();
    this.selectedRow = StaticHelper.resetRowId;
    this.updateRow = false;
    this.createRow = false;
  }

  createRecord(): void {
    this.resetSelectedRow();
    this.updateRowOff();
    this.createRowOn();
  }

  cancelCreatingRecord(): void {
    this.createRowOff();
  }

  updateRecord(): void {
    this.createRowOff();
    this.updateRowOn();
  }

  cancelUpdatingRecord(): void {
    this.updateRowOff();
  }

  saveRecord(): void {
    this.updateRowOff();
    this.createRowOff();
  }

  createRowOn(): void {
    this.createRow = true;
  }

  createRowOff(): void {
    this.createRow = false;
  }

  updateRowOn(): void {
    this.updateRow = true;
  }

  updateRowOff(): void {
    this.updateRow = false;
  }

  resetSelectedRow(): void {
    this.selectedRow = StaticHelper.resetRowId;
  }

  showDeletedRowsRadioButton(): void {
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
    var rowChanged = this.selectedRow != rowId;
    var createOrEditRow = this.updateRow || this.createRow;
    if (rowChanged && createOrEditRow) {
      this.cancelCreatingRecord();
      this.cancelUpdatingRecord();
    }

    this.selectedRow = rowId;
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
