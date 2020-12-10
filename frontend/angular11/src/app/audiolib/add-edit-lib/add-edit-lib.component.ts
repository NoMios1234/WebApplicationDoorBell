import { Component, OnInit, Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-lib',
  templateUrl: './add-edit-lib.component.html',
  styleUrls: ['./add-edit-lib.component.css']
})
export class AddEditLibComponent implements OnInit {

  constructor(private service:SharedService) { }
  
  @Input() lib:any;
    Id:string;
    Name:string;
    Count:string;
    Size:string;
    PlayModeId:string;

    //PlayModesList:any[];

  ngOnInit(): void {
    //this.loadPlayModeList();
    this.Id=this.lib.Id;
    this.Name=this.lib.Name;
    this.Count=this.lib.Count;
    this.Size=this.lib.Size;
    this.PlayModeId=this.lib.PlayModeId;
  }

  /*loadPlayModeList()
  {
    this.service.getAllPlayModeNames().subscribe((data:any)=>{
      this.PlayModesList=data;

      this.Id=this.lib.Id;
      this.Name=this.lib.Name;
      this.Count=this.lib.Count;
      this.Size=this.lib.Size;
      this.PlayModeId=this.lib.PlayModeId;

    })
  }*/

  addAudiolib()
  {
    var val = {Id:this.Id,
              Name:this.Name,
              Count:this.Count,
              Size:this.Size,
              PlayModeId:this.PlayModeId};
    this.service.addAudiolib(val).subscribe(res=>{
      alert(res.toString());
    })
  }
  updateAudiolib()
  {
    var val = {Id:this.Id,
              Name:this.Name,
              Count:this.Count,
              Size:this.Size,
              PlayModeId:this.PlayModeId};
      this.service.updateAudiolib(val).subscribe(res=>{
        alert(res.toString());
      })
  }
}
