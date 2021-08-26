import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@auth0/auth0-angular';
import { GetStartedComponent } from './Components/get-started/get-started.component';
import { MarketplaceComponent } from './Components/marketplace/marketplace.component';
import { MyAccountComponent } from './Components/my-account/my-account.component';

const routes: Routes = [
    {path: '', redirectTo:'', pathMatch: 'full'},
    {path: 'marketplace', component: MarketplaceComponent},
    {path: 'community', component: MarketplaceComponent},
    {path: 'get-started', component: GetStartedComponent},
    {path: 'my-account', component: MyAccountComponent, canActivate: [AuthGuard]}
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
