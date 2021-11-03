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

  constructor(private tableService: TableService) { }

  ngOnInit(): void {
    this.tableService.getZttns(false).subscribe((response: any[]) => {
      this.zttnData = response;
      this.zttnColumns = Object.keys(this.zttnData[0])
        .map((value) => {
          return value.toUpperCase();
        });
    });
  }
}