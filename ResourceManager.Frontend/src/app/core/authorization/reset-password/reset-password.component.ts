import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../api.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
    selector: 'app-reset-password',
    templateUrl: './reset-password.component.html'
})
export class ResetPasswordComponent implements OnInit {

    resetPasswordForm: FormGroup;

    constructor(private apiServive: ApiService) {
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