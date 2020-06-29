import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../_services/api.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router  } from '@angular/router';
import { AuthenticationService } from '../../_services/authentication.service';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

    registerForm: FormGroup;

    constructor(
        private apiServive: ApiService,
        private router: Router,
        private authenticationService: AuthenticationService
        ) {
            // redirect to home if already logged in
        if (this.authenticationService.currentUserValue) {
            this.router.navigate(['/']);
        }
    }

    ngOnInit() {
        this.registerForm = new FormGroup({
            'firstName' : new FormControl(null, Validators.required),
            'lastName' : new FormControl(null, Validators.required),
            'phone' : new FormControl(null, Validators.required),
            'email' : new FormControl(null, [Validators.required, Validators.email]),
            'password' : new FormControl(null, [Validators.required, Validators.minLength(6)]),
        });
    }

    onSubmit() {
        this.apiServive.register(this.registerForm.value).subscribe(
            (response) => console.log(response),
            (error) => console.log(error)
            )
    }

}