import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../api.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

    loginForm: FormGroup;

    constructor(private apiServive: ApiService) {}

    ngOnInit() {
        this.loginForm = new FormGroup({
            'email' : new FormControl(null, [Validators.required, Validators.email]),
            'password' : new FormControl(null, Validators.required)
        });
    }

    onSubmit() {
        this.apiServive.auth(this.loginForm.value).subscribe(
            (response) => console.log(response),
            (error) => console.log(error)
            )
    }

}