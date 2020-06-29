import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../_services/api.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router  } from '@angular/router';
import { AuthenticationService } from '../../_services/authentication.service';

@Component({
    selector: 'app-reset-password',
    templateUrl: './reset-password.component.html'
})
export class ResetPasswordComponent implements OnInit {

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
        this.apiServive.resetPassword(this.resetPasswordForm.value).subscribe(
            (response) => console.log(response),
            (error) => console.log(error)
            )
    }

}