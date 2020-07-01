import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../_services/api.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router  } from '@angular/router';
import { AuthenticationService } from '../../_services/authentication.service';
import { AlertService } from '../../_services/alert.service';

@Component({
    selector: 'app-reset-password-step1',
    templateUrl: './reset-password-step1.component.html',
    styleUrls: ['./reset-password-step1.component.css']
})
export class ResetPasswordStep1Component implements OnInit {

    resetPasswordForm: FormGroup;
    submitted = false;
    loading = false;

    constructor(
        private apiServive: ApiService,
        private router: Router,
        private authenticationService: AuthenticationService,
        private alertService: AlertService,) {
        
        // redirect to home if already logged in
        if (this.authenticationService.currentUserValue) {
            this.router.navigate(['/']);
        }
    }

    ngOnInit() {
        this.resetPasswordForm = new FormGroup({
            'email' : new FormControl(null, [Validators.required, Validators.email]),
        });
    }

    // convenience getter for easy access to form fields
    get f() { return this.resetPasswordForm.controls; }

    onSubmit() {
        this.submitted = true;

        if (this.resetPasswordForm.invalid) {
            return;
        }

        this.loading = true;

        this.apiServive.resetPasswordStep1(this.resetPasswordForm.value).subscribe(
            response => {
                this.alertService.success('Password reset link has been send to your email');
                this.loading = false;
            },
            error => {
                    this.alertService.error(error);
                    this.loading = false;
                })
    }

}