import { Component, OnInit } from '@angular/core';
import { SttnTable } from "./classes/SttnTable";
import { ZttnTable } from "./classes/ZttnTable";
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

  reloadRecords(): void {
    this.zttn.toggle();
    this.zttn.loadAll();

    this.sttn.toggle();
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