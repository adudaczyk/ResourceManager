import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router  } from '@angular/router';
import { Injectable } from '@angular/core';
import { AlertService } from '../../_services/alert.service';
import { AuthenticationService } from '../../_services/authentication.service';
import { first } from 'rxjs/operators';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html'
})

@Injectable({providedIn: 'root'})
export class LoginComponent implements OnInit {

    loginForm: FormGroup;
    loading = false;
    submitted = false;

    constructor(
        private router: Router,
        private authenticationService: AuthenticationService,
        private alertService: AlertService
        ) {

        // redirect to home if already logged in
        if (this.authenticationService.currentUserValue) {
            this.router.navigate(['/']);
        }
    }

    ngOnInit() {
        this.loginForm = new FormGroup({
            'email': new FormControl(null, [Validators.required, Validators.email]),
            'password': new FormControl(null, Validators.required)
        });
    }

    login() {
        this.submitted = true;

        // reset alerts on submit
        this.alertService.clear();

        this.loading = true;
        this.authenticationService.login(this.loginForm.controls.email.value, this.loginForm.controls.password.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.router.navigate(['/admin']);
                },
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                });
    }

}