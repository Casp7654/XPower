import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HubControllerComponent } from './Hub/hub-controller/hub-controller.component';
import { IotDevicesComponent } from './Pages/iot-devices/iot-devices.component';

//Path definitions for components that is used by routing
const routes: Routes = [
  { path: '', component: HubControllerComponent},
  { path: 'iot', component: IotDevicesComponent}
]

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
