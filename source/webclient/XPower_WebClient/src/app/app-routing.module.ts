import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HubDevicesComponent } from './Pages/hub-devices/hub-devices.component';
import { IotDevicesComponent } from './Pages/iot-devices/iot-devices.component';
import { HubSearcherComponent } from './Pages/hub-searcher/hub-searcher.component';

//Path definitions for components that is used by routing
const routes: Routes = [
  { path: '', component: HubDevicesComponent},
  { path: 'iot', component: IotDevicesComponent},
  { path: 'hub-search', component: HubSearcherComponent},
]

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
