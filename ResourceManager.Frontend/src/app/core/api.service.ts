import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const localUrl = 'https://localhost:44320/';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  headers: HttpHeaders = new HttpHeaders({'content-type' : 'application/json'});

  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get(localUrl + 'api/User/GetUsers');
  }

  getResources() {
    return this.http.get(localUrl + 'api/Resources/GetResources');
  }

  postUser(data: []) {
    var body = JSON.stringify(data);
    return this.http.post(localUrl + 'api/User', body, {headers: this.headers})
  }

  auth(data: []) {
    var body = JSON.stringify(data);
    return this.http.post(localUrl + 'api/Auth', body, {headers: this.headers})
  }
}
