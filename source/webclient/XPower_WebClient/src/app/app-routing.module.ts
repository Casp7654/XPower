import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HubDevicesComponent } from './Pages/hub-devices/hub-devices.component';
import { IotDevicesComponent } from './Pages/iot-devices/iot-devices.component';
import { HubSearcherComponent } from './Pages/hub-searcher/hub-searcher.component';
import { RegisterUserComponent } from './Pages/register-user/register-user.component';
import { LoginUserComponent } from './Pages/login-user/login-user.component';
import { AuthguardService } from './Services/authguard.service';

//Path definitions for components that is used by routing
const routes: Routes = [
  { path: '', redirectTo: "/login", pathMatch: "full" },
  { path: "home", component: HubDevicesComponent, canActivate: [AuthguardService] },
  { path: 'iot', component: IotDevicesComponent, canActivate: [AuthguardService] },
  { path: 'hub-search', component: HubSearcherComponent, canActivate: [AuthguardService] },
  { path: 'register-user', component: RegisterUserComponent },
  { path: 'login', component: LoginUserComponent }
]

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
