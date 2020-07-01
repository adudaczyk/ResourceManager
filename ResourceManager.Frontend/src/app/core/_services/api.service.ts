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
    return this.http.get(localUrl + 'api/user/get-users');
  }

  getResources() {
    return this.http.get(localUrl + 'api/resource/get-resources');
  }

  register(data: []) {
    var body = JSON.stringify(data);
    return this.http.post(localUrl + 'api/user/register', body, {headers: this.headers})
  }

  auth(data: []) {
    var body = JSON.stringify(data);
    return this.http.post<any>(localUrl + 'api/auth/authenticate', body, {headers: this.headers})
  }

  resetPasswordStep1(data: []){
    var body = JSON.stringify(data);
    return this.http.post(localUrl + 'api/user/send-reset-password-link', body, {headers: this.headers})
  }

  resetPasswordStep2(data: []){
    var body = JSON.stringify(data);
    return this.http.post(localUrl + 'api/user/reset-password', body, {headers: this.headers})
  }

  verifyEmail(data: []){
    var body = JSON.stringify(data);
    return this.http.post(localUrl + 'api/user/verify-email', body, {headers: this.headers})
  }
}
