import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { MainComponent } from './components/main/main.component';
import { LoginComponent } from './components/login/login.component';
import { AccountService } from './services/account.service';
import { RegistrateComponent } from './components/registrate/registrate.component';
import { UserResolver } from './resolvers/user/user.resolver';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    LoginComponent,
    RegistrateComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
      {
        path: '',
        resolve: {
          user: UserResolver
        },
        component: MainComponent,
        children:
        [
          {
            path: 'login',
            component: LoginComponent
          },
          {
            path: 'registrate',
            component: RegistrateComponent
          }
        ]
      }      
    ])
  ],
  providers: [
    AccountService,
    UserResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
