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
  @Output() onRowDelete: EventEmitter<number>;
  @Output() onRowCreate: EventEmitter<any>;
  @Output() onRowUpdate: EventEmitter<any>;

  showDeleted: boolean;
  isLoaded: boolean;
  selectedRowId: number;
  updateRow: boolean;
  createRow: boolean;
  updatingRow: any;

  constructor() {
    this.columns = [];
    this.data = [];
    this.showDeleted = false;
    this.isLoaded = false;
    this.onRowClick = new EventEmitter();
    this.onChangedToggle = new EventEmitter();
    this.onRowDelete = new EventEmitter();
    this.selectedRowId = StaticHelper.resetRowId;
    this.updateRow = false;
    this.createRow = false;
    this.onRowCreate = new EventEmitter();
    this.onRowUpdate = new EventEmitter();
    this.updatingRow = [];
  }

  valueChanged(event: any, cellId: number) {
    this.updatingRow[cellId] = event.target.value;
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
    if (this.selectedRowId != -1) {
      this.onRowUpdate.emit({ data: this.updatingRow, rowId: this.selectedRowId });
    }
    else {
      this.onRowCreate.emit();
    }

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
    this.updatingRow = Object.assign(this.updatingRow, this.data[this.selectedRowId]);
  }

  updateRowOff(): void {
    this.updateRow = false;
    this.updatingRow = [];
  }

  resetSelectedRow(): void {
    this.selectedRowId = StaticHelper.resetRowId;
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
    var rowChanged = this.selectedRowId != rowId;
    var createOrEditRow = this.updateRow || this.createRow;
    if (rowChanged && createOrEditRow) {
      this.cancelCreatingRecord();
      this.cancelUpdatingRecord();
    }

    this.selectedRowId = rowId;
    this.onRowClick.emit(rowId);
  }

  deleteSelectedRow(event: any) {
    var rowSelected = this.selectedRowId > StaticHelper.resetRowId;
    if (rowSelected) {
      this.onRowDelete.emit(this.selectedRowId);
      this.resetSelectedRow();
    }
  }
}
