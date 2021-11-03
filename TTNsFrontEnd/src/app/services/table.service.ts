import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { ZttnTableViewModel } from '../viewModels/table/ZttnTableViewModel';

@Injectable({
  providedIn: 'root'
})

export class TableService {
  private rest_api = "http://localhost:5000/api";

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private httpClient: HttpClient) { }

  getZttns(showDeleted: boolean): Observable<ZttnTableViewModel[]> {
    var data = null;

    var api = this.rest_api + "/zttn/get-all";
    if (showDeleted) {
      data = this.httpClient.get<ZttnTableViewModel[]>(api + "/" + showDeleted);
    }
    else {
      data = this.httpClient.get<ZttnTableViewModel[]>(api);
    }

    return data;
  }

  getSttnsBySysn(sysn: number): Observable<any[]> {
    var data = this.httpClient.get<any[]>(this.rest_api + "/sttn/get-by-sysn/" + sysn);
    return data;
  }
}
