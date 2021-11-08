import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from "@angular/common/http";

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

  getZttns(showDeleted: boolean = false): Observable<any[]> {
    var api = this.rest_api + "/zttn/get-all";
    var data = this.httpClient.get<any[]>(api + "/" + showDeleted);
    return data;
  }

  getSttnsBySysn(sysn: number, showDeleted: boolean = false): Observable<any[]> {
    var api = this.rest_api + "/sttn/get-by-sysn/" + sysn;
    var data = this.httpClient.get<any[]>(api + "/" + showDeleted);
    return data;
  }
}
