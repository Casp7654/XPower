import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HubControllerComponent } from './Hub/hub-controller/hub-controller.component';
import { IotDevicesComponent } from './Pages/iot-devices/iot-devices.component';
import { HubSearcherComponent } from './Hub/hub-searcher/hub-searcher.component';

//Path definitions for components that is used by routing
const routes: Routes = [
  { path: '', component: HubControllerComponent},
  { path: 'iot', component: IotDevicesComponent},
  { path: 'hub-search', component: HubSearcherComponent},
]

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
