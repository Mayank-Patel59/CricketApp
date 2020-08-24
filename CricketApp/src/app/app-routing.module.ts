import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import  { AppComponent } from './app.component'
import  { CricketComponent } from '../app/cricket/cricket.component'

const routes: Routes = [
  {
    path: 'cricket',
    component: AppComponent
  },
  {
    path: 'cricket1',
    component: CricketComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
