import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { VacationComponent } from './vacation/vacation.component';
import { ProposalComponent } from './proposal/proposal.component';
import { MyProfileComponent } from './my-profile/my-profile.component';
import { VacationDetailsComponent } from './vacation/vacation-details/vacation-details.component';
import { NotificationPageComponent } from './shared/notification-page/notification-page.component';
import { WishListComponent } from './vacation/wish-list/wish-list.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  { path: 'home', component: HomeComponent },
  { path: 'vacation', component: VacationComponent },
  { path: 'vacation/details', component: VacationDetailsComponent},
  { path: 'home/vacation', component: VacationComponent },
  { path: 'proposal', component: ProposalComponent },
  { path: 'my-profile', component: MyProfileComponent },
  { path: 'my-profile/propose', component: ProposalComponent },
  { path: 'notification', component: NotificationPageComponent },
  { path: 'vacation/wishList', component: WishListComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes), RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
