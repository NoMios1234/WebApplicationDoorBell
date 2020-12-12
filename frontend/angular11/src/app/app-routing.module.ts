import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CameraComponent } from './camera/camera.component';
import { PlaylistComponent } from './playlist/playlist.component';
import { SampleComponent } from './sample/sample.component';
import { WirelessconnComponent } from './wirelessconn/wirelessconn.component';


const routes: Routes = [
  {path:'playlist',component:PlaylistComponent},
  {path:'sample',component:SampleComponent},
  {path:'wirelesscon',component:WirelessconnComponent},
  {path:'camera',component:CameraComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
