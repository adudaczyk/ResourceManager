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
    return this.http.get(localUrl + 'api/Resource/GetResources');
  }

  register(data: []) {
    var body = JSON.stringify(data);
    return this.http.post(localUrl + 'api/User/Register', body, {headers: this.headers})
  }

  auth(data: []) {
    var body = JSON.stringify(data);
    return this.http.post<any>(localUrl + 'api/User/Authenticate', body, {headers: this.headers})
  }

  resetPasswordStep1(data: []){
    var body = JSON.stringify(data);
    return this.http.post(localUrl + 'api/User/SendResetPasswordLink', body, {headers: this.headers})
  }

  resetPasswordStep2(data: []){
    var body = JSON.stringify(data);
    return this.http.post(localUrl + 'api/User/ResetPassword', body, {headers: this.headers})
  }

  verifyEmail(data: []){
    var body = JSON.stringify(data);
    return this.http.post(localUrl + 'api/User/VerifyEmail', body, {headers: this.headers})
  }
}
