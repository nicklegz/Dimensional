import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { TopToolbarComponent } from './Components/top-toolbar/top-toolbar.component';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule} from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { FlexLayoutModule } from '@angular/flex-layout';
import { LoginFormComponent } from './Components//login-form/login-form.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTabsModule } from '@angular/material/tabs';
import { MatSidenavModule } from '@angular/material/sidenav';
import { FontAwesomeModule, FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faBars } from '@fortawesome/free-solid-svg-icons/faBars';
import { BottomToolbarComponent } from './Components/bottom-toolbar/bottom-toolbar.component';
import { MarketplaceComponent } from './Components/marketplace/marketplace.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { LeftSidenavComponent } from './Components/left-sidenav/left-sidenav.component';
import { LeftSidenavService } from './Services/left-sidenav.service';
import { MatListModule } from '@angular/material/list';
import { MatTreeModule } from '@angular/material/tree';
import { faSearch, faStar, faTimes } from '@fortawesome/free-solid-svg-icons';
import { LandingPageComponent } from './Components/landing-page/landing-page.component';
import {CdkTreeModule} from '@angular/cdk/tree';
import { GetStartedComponent } from './Components/get-started/get-started.component';
import { AuthModule } from '@auth0/auth0-angular';
import { HttpClientModule } from '@angular/common/http';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { MyAccountComponent } from './Components/my-account/my-account.component';

@NgModule({
  declarations: [
    AppComponent,
    TopToolbarComponent,
    LoginFormComponent,
    BottomToolbarComponent,
    MarketplaceComponent,
    LeftSidenavComponent,
    LandingPageComponent,
    GetStartedComponent,
    MyAccountComponent
    ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatCardModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    FlexLayoutModule,
    MatFormFieldModule,
    MatInputModule,
    MatTabsModule,
    MatSidenavModule,
    FontAwesomeModule,
    MatGridListModule,
    MatListModule,
    MatTreeModule,
    CdkTreeModule,
    AuthModule.forRoot({
      domain: 'nicklegz.us.auth0.com',
      clientId: 'xYdy7XnvkCdtQGPQ10nFpLJO2qkJSa2A'
    }),
    HttpClientModule,
    MatProgressBarModule,
    MatCheckboxModule
  ],
  providers: [LeftSidenavService],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(library: FaIconLibrary){
    library.addIcons(faBars);
    library.addIcons(faTimes);
    library.addIcons(faSearch);
  }
}

