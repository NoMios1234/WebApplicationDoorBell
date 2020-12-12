import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SampleComponent } from './sample/sample.component';
import { ShowSampComponent } from './sample/show-samp/show-samp.component';
import { AddEditSampComponent } from './sample/add-edit-samp/add-edit-samp.component';
import { SharedService } from './shared.service';

import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule,ReactiveFormsModule}  from '@angular/forms';
import { PlaylistComponent } from './playlist/playlist.component';
import { ShowPlstComponent } from './playlist/show-plst/show-plst.component';
import { AddEditPlstComponent } from './playlist/add-edit-plst/add-edit-plst.component';
import { WirelessconnComponent } from './wirelessconn/wirelessconn.component';
import { ShowWrlsscnComponent } from './wirelessconn/show-wrlsscn/show-wrlsscn.component';
import { AddEditWrlsscnComponent } from './wirelessconn/add-edit-wrlsscn/add-edit-wrlsscn.component';
import { CameraComponent } from './camera/camera.component';
import { ShowCamComponent } from './camera/show-cam/show-cam.component';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';


@NgModule({
  declarations: [
    AppComponent,
    SampleComponent,
    ShowSampComponent,
    AddEditSampComponent,
    PlaylistComponent,
    ShowPlstComponent,
    AddEditPlstComponent,
    WirelessconnComponent,
    ShowWrlsscnComponent,
    AddEditWrlsscnComponent,
    CameraComponent,
    ShowCamComponent
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    TranslateModule.forRoot({
      loader:{
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps:[HttpClient]
      }
    })

  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function HttpLoaderFactory(http: HttpClient){
  return new TranslateHttpLoader(http);
}


