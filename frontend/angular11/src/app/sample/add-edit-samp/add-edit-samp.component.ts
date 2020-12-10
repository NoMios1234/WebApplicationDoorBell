import { Component, OnInit, Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-samp',
  templateUrl: './add-edit-samp.component.html',
  styleUrls: ['./add-edit-samp.component.css']
})
export class AddEditSampComponent implements OnInit {

  constructor(private service:SharedService) { }
  
  @Input() samp:any;
    Id:string;
    Name:string;
    Size:string;
    AudioLibId:string;

  ngOnInit(): void {
    this.Id=this.samp.Id;
    this.Name=this.samp.Name;
    this.Size=this.samp.Size;
    this.AudioLibId=this.samp.AudioLibId;
  }

  addSample()
  {
    var val = {Id:this.Id,
              Name:this.Name,
              Size:this.Size,
              AudioLibId:this.AudioLibId};
    this.service.addSample(val).subscribe(res=>{
      alert(res.toString());
    })
  }
  updateSample()
  {
    var val = {Id:this.Id,
              Name:this.Name,
              Size:this.Size,
              AudioLibId:this.AudioLibId};
      this.service.updateSample(val).subscribe(res=>{
        alert(res.toString());
      })
  }

  
}
