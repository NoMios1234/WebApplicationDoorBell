import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PlaylistComponent } from './playlist/playlist.component';

import { SampleComponent } from './sample/sample.component';
import { WirelessconnComponent } from './wirelessconn/wirelessconn.component';


const routes: Routes = [
  {path:'wirelesscon',component:WirelessconnComponent},
  {path:'sample',component:SampleComponent},
  {path:'playlist',component:PlaylistComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
