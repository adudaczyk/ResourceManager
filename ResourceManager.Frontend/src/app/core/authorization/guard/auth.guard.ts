import { CanActivate, Router } from '@angular/router';
import { LoginComponent } from '../login/login.component';
import { Injectable } from '@angular/core';

@Injectable({providedIn: 'root'})
export class AuthGuard implements CanActivate {

    constructor(private loginService: LoginComponent, private router: Router) {}

    canActivate() {
        const currentUser = this.loginService.currentUserValue;
        if(currentUser)  {
            return true;
        }
        this.router.navigate(['/auth']);
        return false;
      }

    
}