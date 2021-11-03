import { Component, OnInit } from '@angular/core';
import { TableService } from './services/table.service';
import { ZttnTableViewModel } from './viewModels/table/ZttnTableViewModel';

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
    this.tableService.getZttns(false).subscribe((response: ZttnTableViewModel[]) => {
      this.zttnData = response
        .map((row) => {
          return Object.values(row);
        });
      this.zttnColumns = Object.keys(response[0])
        .map((value) => {
          return value.toUpperCase();
        });
    });
  }
}