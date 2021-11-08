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
  @Output() onRowClick: EventEmitter<number>;
  @Output() onChangedToggle: EventEmitter<boolean>;
  @Output() onRowDelete: EventEmitter<number>

  showDeleted: boolean;
  isLoaded: boolean;

  constructor() {
    this.columns = [];
    this.data = [];
    this.showDeleted = false;
    this.isLoaded = false;
    this.onRowClick = new EventEmitter();
    this.onChangedToggle = new EventEmitter();
    this.onRowDelete =new EventEmitter();
  }

  toggle(): void {
    this.showDeleted = !this.showDeleted;
    this.onChangedToggle.emit(this.showDeleted);
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.checkDataLoading(this.columns, this.data);
  }

  ngOnInit(): void {
    this.checkDataLoading(this.columns, this.data);
  }

  checkDataLoading(columns: string[], data: any[]): void {
    var tableIsNotEmpty = columns.length > 0 && data.length > 0;
    this.isLoaded = tableIsNotEmpty;;
  }

  raiseOnRowClick(value: any): void {
    this.onRowClick.emit(value);
  }
}
