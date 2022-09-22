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
import { BrowserWebBluetooth} from '@manekinekko/angular-web-bluetooth'
import {MatGridListModule} from '@angular/material/grid-list';
//import {MatDialogModule} from "@angular/material";

@NgModule({
  declarations: [
    AppComponent,
    HubComponent,
    HubControllerComponent,
    HubSearcherComponent
  ],
  imports: [
    BrowserModule,
    MatGridListModule,
    ServiceWorkerModule.register('ngsw-worker.js', {
      enabled: environment.production,
      // Register the ServiceWorker as soon as the application is stable
      // or after 30 seconds (whichever comes first).
      registrationStrategy: 'registerWhenStable:30000'
    }),
    BrowserAnimationsModule,
    AppRoutingModule
  ],
  providers: [BrowserWebBluetooth],
  bootstrap: [AppComponent]
})
export class AppModule { }
