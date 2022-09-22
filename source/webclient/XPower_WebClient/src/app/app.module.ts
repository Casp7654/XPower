import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HubComponent } from './Hub/hub/hub.component';
import { HubControllerComponent } from './Hub/hub-controller/hub-controller.component';
import { AppRoutingModule } from './app-routing.module';
import { HubSearcherComponent } from './Hub/hub-searcher/hub-searcher.component';

import {MatGridListModule} from '@angular/material/grid-list';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import { IotComponent } from './IoT/iot/iot.component';
import { IotControllerComponent } from './IoT/iot-controller/iot-controller.component';


@NgModule({
  declarations: [
    AppComponent,
    HubComponent,
    HubControllerComponent,
    HubSearcherComponent,
    IotComponent,
    IotControllerComponent
  ],
  imports: [
    BrowserModule,
    MatGridListModule,
    MatToolbarModule,
    MatIconModule,
    ServiceWorkerModule.register('ngsw-worker.js', {
      enabled: environment.production,
      // Register the ServiceWorker as soon as the application is stable
      // or after 30 seconds (whichever comes first).
      registrationStrategy: 'registerWhenStable:30000'
    }),
    BrowserAnimationsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
