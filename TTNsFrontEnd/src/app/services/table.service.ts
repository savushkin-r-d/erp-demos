import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { ZttnTableCreateModel } from '../classes/models/zttnTableCreateModel';
import { SttnTableCreateModel } from '../classes/models/sttnTableCreateModel';
import { ZttnTableViewModel } from '../classes/models/zttnTableViewModel';
import { SttnTableViewModel } from '../classes/models/sttnTableViewModel';
import { SttnTableUpdateModel } from '../classes/models/sttnTableUpdateModel';

@Injectable({
  providedIn: 'root'
})

export class TableService {
  private rest_api = "http://localhost:5000/api";

  httpOptions = {
    headers: new HttpHeaders({
      'Content-type': 'application/json',
    })
  }

  constructor(private httpClient: HttpClient) { }

  getZttns(showDeleted: boolean = false): Observable<ZttnTableViewModel[]> {
    var api = this.rest_api + "/zttn/get-all";
    var data = this.httpClient.get<ZttnTableViewModel[]>(api + "/" + showDeleted, this.httpOptions);
    return data;
  }

  getSttnsBySysn(sysn: number, showDeleted: boolean = false): Observable<any[]> {
    var api = this.rest_api + "/sttn/get-by-sysn/" + sysn;
    var data = this.httpClient.get<any[]>(api + "/" + showDeleted, this.httpOptions);
    return data;
  }

  removeFromZttnByFId(fId: number): Observable<any[]> {
    var api = this.rest_api + "/zttn/delete/" + fId;
    var data = this.httpClient.delete<any[]>(api, this.httpOptions);
    return data;
  }

  removeFromSttnByFId(fId: number): Observable<any[]> {
    var api = this.rest_api + "/sttn/delete/" + fId;
    var data = this.httpClient.delete<any[]>(api, this.httpOptions);
    return data;
  }

  updateZttn(zttn: ZttnTableViewModel): Observable<ZttnTableViewModel> {
    var api = this.rest_api + "/zttn/update";
    var jsonData = JSON.stringify(zttn);
    var data = this.httpClient.put<ZttnTableViewModel>(api, jsonData, this.httpOptions);
    return data;
  }

  updateSttn(sttn: SttnTableUpdateModel): Observable<SttnTableViewModel> {
    var api = this.rest_api + "/sttn/update";
    var jsonData = JSON.stringify(sttn);
    var data = this.httpClient.put<SttnTableViewModel>(api, jsonData, this.httpOptions);
    return data;
  }

  createZttn(zttnCreateModel: any): Observable<ZttnTableViewModel> {
    var api = this.rest_api + "/zttn/create";
    var jsonData = JSON.stringify(zttnCreateModel);
    var data = this.httpClient.post<ZttnTableViewModel>(api, jsonData, this.httpOptions);
    return data;
  }

  createSttn(sttnCreateModel: any): Observable<SttnTableViewModel> {
    var api = this.rest_api + "/sttn/create";
    var jsonData = JSON.stringify(sttnCreateModel);
    var data = this.httpClient.post<SttnTableViewModel>(api, jsonData, this.httpOptions);
    return data;
  }
}
