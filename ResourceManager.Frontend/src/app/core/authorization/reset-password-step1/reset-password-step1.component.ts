import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../_services/api.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router  } from '@angular/router';
import { AuthenticationService } from '../../_services/authentication.service';

@Component({
    selector: 'app-reset-password-step1',
    templateUrl: './reset-password-step1.component.html'
})
export class ResetPasswordStep1Component implements OnInit {

    resetPasswordForm: FormGroup;

    constructor(
        private apiServive: ApiService,
        private router: Router,
        private authenticationService: AuthenticationService) {
        
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

    onSubmit() {
        this.apiServive.resetPasswordStep1(this.resetPasswordForm.value).subscribe(
            (response) => console.log(response),
            (error) => console.log(error)
            )
    }

}