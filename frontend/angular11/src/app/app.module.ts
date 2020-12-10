import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AudiolibComponent } from './audiolib/audiolib.component';
import { ShowLibComponent } from './audiolib/show-lib/show-lib.component';
import { AddEditLibComponent } from './audiolib/add-edit-lib/add-edit-lib.component';
import { SampleComponent } from './sample/sample.component';
import { ShowSampComponent } from './sample/show-samp/show-samp.component';
import { AddEditSampComponent } from './sample/add-edit-samp/add-edit-samp.component';
import {SharedService} from './shared.service';

import {HttpClientModule} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    AudiolibComponent,
    ShowLibComponent,
    AddEditLibComponent,
    SampleComponent,
    ShowSampComponent,
    AddEditSampComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
