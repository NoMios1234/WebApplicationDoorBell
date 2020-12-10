import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { from } from 'rxjs';

import {AudiolibComponent} from './audiolib/audiolib.component';
import {SampleComponent} from './sample/sample.component';


const routes: Routes = [
  {path:'audiolib',component:AudiolibComponent},
  {path:'sample',component:SampleComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
