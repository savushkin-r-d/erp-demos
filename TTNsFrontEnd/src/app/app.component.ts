import { Component, OnInit } from '@angular/core';
import { TableService } from './services/table.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  title = 'app';
  zttnTableName = "ZTTN";
  sttnTableName = "STTN";

  zttnColumns: string[] = [];
  zttnData: any[] = [];

  sttnColumns: string[] = [];
  sttnData: any[] = [];

  constructor(private tableService: TableService) { }

  ngOnInit(): void {
    this.initZttns();
  }

  getObjectValues(obj: any[]) : any[] {
    return obj.map((row) => {
      return Object.values(row);
    })
  }

  getObjectKeys(obj: any[]) : string[] {
    return Object.keys(obj).map((value) => {
          return value.toUpperCase();
        });
  }

  initZttns(): void {
    this.tableService.getZttns(false).subscribe((response: any[]) => {
      this.zttnData = this.getObjectValues(response);
      this.zttnColumns = this.getObjectKeys(response[0]);
    });
  }

  loadSttnBySysn(sysn: number): void {
    this.tableService.getSttnsBySysn(sysn).subscribe((response: any[]) => {
      this.sttnData = this.getObjectValues(response);
      this.sttnColumns = this.getObjectKeys(response[0]);
    });
  }
}