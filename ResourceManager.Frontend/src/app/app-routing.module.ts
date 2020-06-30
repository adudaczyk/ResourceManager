import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AdminComponent } from '../app/core/admin/admin.component';
import { LoginComponent } from './core/authorization/login/login.component';
import { RegisterComponent } from './core/authorization/register/register.component';
import { ResetPasswordStep1Component } from './core/authorization/reset-password-step1/reset-password-step1.component';
import { ResetPasswordStep2Component } from './core/authorization/reset-password-step2/reset-password-step2.component';
import { AuthGuard } from './core/_helpers/auth.guard';


const routes: Routes = [
  { path: '', redirectTo: '/admin', pathMatch: 'full' },
  { path: 'auth', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'reset-password-step1', component: ResetPasswordStep1Component },
  { path: 'reset-password-step2', component: ResetPasswordStep2Component },
  { path: 'admin', component: AdminComponent, canActivate: [AuthGuard] },

  // otherwise redirect to home
  { path: '**', redirectTo: '/admin' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
