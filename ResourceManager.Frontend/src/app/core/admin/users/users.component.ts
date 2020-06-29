import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../_services/api.service';

@Component({
    selector: 'app-admin-users',
    templateUrl: './users.component.html'
})
export class AdminUsersComponent {

    users: any = [];

    constructor(private apiServive: ApiService) {
    }

    ngOnInit() {
        this.getUsers();
    }

    getUsers() {
        this.apiServive.getUsers().subscribe(data=>{
          this.users = data;
        }, error => {
            console.log(error);
          })
      }
}