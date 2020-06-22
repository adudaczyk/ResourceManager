import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../api.service';

@Component({
    selector: 'app-admin-resources',
    templateUrl: './resources.component.html'
})
export class AdminResourcesComponent {

    resources: any = [];

    constructor(private apiServive: ApiService) {
    }

    ngOnInit() {
        this.getResources();
    }

    getResources() {
        this.apiServive.getResources().subscribe(data=>{
            this.resources = data;
          }, error => {
              console.log(error);
            })
    }
}