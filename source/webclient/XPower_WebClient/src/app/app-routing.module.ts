import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HubControllerComponent } from './Hub/hub-controller/hub-controller.component';

//Path definitions for components that is used by routing
const routes: Routes = [
  { path: '', component: HubControllerComponent}
]

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
