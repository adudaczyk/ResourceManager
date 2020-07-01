import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../_services/api.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router  } from '@angular/router';
import { AuthenticationService } from '../../_services/authentication.service';
import { AlertService } from '../../_services/alert.service';
import { MustMatch } from '../../_validators/must-match.validator';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

    registerForm: FormGroup;
    submitted = false;
    loading = false;

    constructor(
        private formBuilder: FormBuilder,
        private apiServive: ApiService,
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
        this.registerForm = this.formBuilder.group({
            'firstName' : [null, [Validators.required, Validators.minLength(3)]],
            'lastName' : [null, [Validators.required, Validators.minLength(3)]],
            'phone' : [null, [Validators.required]],
            'email' : [null, [Validators.required, Validators.email]],
            'password' : [null, [Validators.required, Validators.minLength(6)]],
            'confirmPassword' : [null, [Validators.required, Validators.minLength(6)]],
        }, {
            validator: MustMatch('password', 'confirmPassword')
        });
    }

    // convenience getter for easy access to form fields
    get f() { return this.registerForm.controls; }

    register() {
        this.submitted = true;

        if (this.registerForm.invalid) {
            return;
        }

        this.loading = true;

        this.apiServive.register(this.registerForm.value).subscribe(
            response => {
                this.router.navigate(['/auth']);
                this.alertService.success('A verification email has been sent to your inbox. You will need to click the activation link to complete your registration.');
            },
            error => {
                this.alertService.error(error);
                this.loading = false;
            })
    }

}