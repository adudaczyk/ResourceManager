import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../_services/api.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertService } from '../../_services/alert.service';
import { MustMatch } from '../../_validators/must-match.validator';

@Component({
    selector: 'app-reset-password-step2',
    templateUrl: './reset-password-step2.component.html',
    styleUrls: ['./reset-password-step2.component.css']
})
export class ResetPasswordStep2Component implements OnInit {

    resetPasswordForm: FormGroup;
    submitted = false;
    loading = false;
    email = "";
    token = "";

    constructor(
        private formBuilder: FormBuilder,
        private apiServive: ApiService,
        private router: Router,
        private alertService: AlertService,
        private activatedRoute: ActivatedRoute) {

            activatedRoute.queryParams.subscribe((params) => 
        {
            this.token = params.token,
            this.email = params.email
        });
    }

    ngOnInit() {
        this.resetPasswordForm = this.formBuilder.group({
            'password' : [null, [Validators.required, Validators.minLength(6)]],
            'confirmPassword' : [null, [Validators.required, Validators.minLength(6)]],
            'resetpasswordtoken' : [this.token],
            'email' : [this.email]
        }, {
            validator: MustMatch('password', 'confirmPassword')
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
        
        this.apiServive.resetPasswordStep2(this.resetPasswordForm.value).subscribe(
            response => {
            this.router.navigate(['/auth']);
            this.alertService.success('Password has been changed successfully.');
        },
        error => {
            this.alertService.error(error);
            this.loading = false;
        })
    }

}