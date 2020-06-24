import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const localUrl = 'https://localhost:44320/';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get(localUrl + 'api/User/GetUsers');
  }

  getResources() {
    return this.http.get(localUrl + 'api/Resources/GetResources');
  }

  postUser(data: []) {
    var headers = new HttpHeaders({'content-type' : 'application/json'});
    var body = JSON.stringify(data);
    return this.http.post(localUrl + 'api/User', body, {headers: headers})
  }
}
