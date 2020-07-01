import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AlertComponent } from './core/_components/alert.component';
import { AdminComponent } from './core/admin/admin.component';
import { AdminUsersComponent } from './core/admin/users/users.component';
import { AdminResourcesComponent } from './core/admin/resources/resources.component';
import { LoginComponent } from './core/authorization/login/login.component';
import { RegisterComponent } from './core/authorization/register/register.component';
import { ResetPasswordStep1Component } from './core/authorization/reset-password-step1/reset-password-step1.component';
import { ResetPasswordStep2Component } from './core/authorization/reset-password-step2/reset-password-step2.component';

import { JwtInterceptor, ErrorInterceptor, appInitializer } from './core/_helpers';
import { AuthenticationService } from './core/_services/authentication.service'

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ResetPasswordStep1Component,
    ResetPasswordStep2Component,
    AdminComponent,
    AdminUsersComponent,
    AdminResourcesComponent,
    AlertComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    { provide: APP_INITIALIZER, useFactory: appInitializer, multi: true, deps: [AuthenticationService] },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
