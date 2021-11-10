import { Component, OnInit } from '@angular/core';
import { SttnTable } from "./classes/sttnTable";
import { ZttnTable } from "./classes/zttnTable";
import { TableService } from './services/table.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  title = 'app';
  zttn: ZttnTable;
  sttn: SttnTable;

  constructor(private tableService: TableService) {
    this.zttn = new ZttnTable(tableService);
    this.sttn = new SttnTable(tableService);
  }

  toggleRecords(): void {
    this.zttn.toggle();
    this.sttn.toggle();

    this.reloadRecords();
  }

  reloadRecords(): void {
    this.zttn.loadAll();
    this.sttn.loadBySysn(this.sttn._loadedSysn);
  }

  ngOnInit(): void {
    this.zttn.loadAll();
  }

  loadSttnsByZttnSysn(rowId: number): void {
    var sysn = this.zttn.getSysnByRowId(rowId);
    this.sttn.loadBySysn(sysn);
  }
}