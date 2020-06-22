import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

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
}
