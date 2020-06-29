import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './core/authorization/login/login.component';
import { RegisterComponent } from './core/authorization/register/register.component';
import { ResetPasswordComponent } from './core/authorization/reset-password/reset-password.component';
import { AdminComponent } from './core/admin/admin.component';
import { AdminUsersComponent } from './core/admin/users/users.component';
import { AdminResourcesComponent } from './core/admin/resources/resources.component';
import { AlertComponent } from './core/_components/alert.component';
import { JwtInterceptor } from './core/_helpers/jwt.interceptor';
import { ErrorInterceptor } from './core/_helpers/error.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ResetPasswordComponent,
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
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
