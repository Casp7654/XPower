import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { HubSearcherComponent } from './Pages/hub-searcher/hub-searcher.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatButtonModule } from '@angular/material/button'
import { MatDividerModule } from '@angular/material/divider';
import { IotDevicesComponent } from './Pages/iot-devices/iot-devices.component';
import { SocketComponent } from './Components/socket/socket.component';
import { HeaderComponent } from './Navigation/header/header.component';
import { MatListModule } from '@angular/material/list';
import { SidenavListComponent } from './Navigation/sidenav-list/sidenav-list.component'
import { BrowserWebBluetooth} from '@manekinekko/angular-web-bluetooth'
import { MatFormFieldModule, MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input'
import { FormBuilder, FormGroup,ReactiveFormsModule  } from '@angular/forms';
import { HubDevicesComponent } from './Pages/hub-devices/hub-devices.component';
import { HubComponent } from './Components/hub/hub.component';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { MqttModule, IMqttServiceOptions } from "ngx-mqtt";
import { RegisterUserComponent } from './Pages/register-user/register-user.component';

export const MQTT_SERVICE_OPTIONS: IMqttServiceOptions = {
  hostname: 'broker.emqx.io',
  port: 8083,
  path: '/mqtt'
}

@NgModule({
  declarations: [
    AppComponent,
    HubSearcherComponent,
    IotDevicesComponent,
    SocketComponent,
    HeaderComponent,
    SidenavListComponent,
    HubDevicesComponent,
    HubComponent,
    RegisterUserComponent
  ],
  imports: [
    BrowserModule,
    MatGridListModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatGridListModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
    MatDividerModule,
    MatSidenavModule,
    MatButtonModule,
    MatListModule,
    ServiceWorkerModule.register('ngsw-worker.js', {
      enabled: environment.production,
      // Register the ServiceWorker as soon as the application is stable
      // or after 30 seconds (whichever comes first).
      registrationStrategy: 'registerWhenStable:30000'
    }),
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    MqttModule.forRoot(MQTT_SERVICE_OPTIONS)
  ],
  providers: [
    BrowserWebBluetooth,
    FormBuilder,
    HttpClient
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
