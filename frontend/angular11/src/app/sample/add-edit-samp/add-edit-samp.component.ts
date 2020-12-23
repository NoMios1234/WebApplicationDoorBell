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
    SampleId:string;
    SampleName:string;
    SampleSize:string;
    SampleLink:string;
    PlaylistName:string;

    PlaylistList:any[];
 

  ngOnInit(): void {
    this.loadPlaylistList();
  }

  loadPlaylistList()
  {
    this.service.getAllPlaylistNames().subscribe((data:any)=>{
      this.PlaylistList = data;

      this.SampleId=this.samp.SampleId;
      this.SampleName=this.samp.SampleName;
      this.SampleSize=this.samp.SampleSize;
      this.SampleLink=this.service.FileUrl+this.SampleName;
      this.PlaylistName=this.samp.PlaylistName;
    });   
  }

  addSample()
  {
    var val = {SampleId:this.SampleId,
              SampleName:this.SampleName,
              SampleSize:this.SampleSize,
              SampleLink:this.SampleLink,
              PlaylistName:this.PlaylistName};
    this.service.addSample(val).subscribe(res=>{
      alert(res.toString());
    })
    this.updatePlaylistInfo();
  }
  updateSample()
  {
    var val = {SampleId:this.SampleId,
              SampleName:this.SampleName,
              SampleSize:this.SampleSize,
              SampleLink:this.SampleLink,
              PlaylistName:this.PlaylistName};
    this.service.updateSample(val).subscribe(res=>{
      alert(res.toString());
    })
    this.updatePlaylistInfo();
  }

  uploadFile(event)
  {
    var file = event.target.files[0];
    const formData:FormData=new FormData();
    formData.append('uploadFile',file,file.name);

    this.service.uploadFile(formData).subscribe((data:any)=>{
      this.SampleName = data.toString();
      this.SampleSize = file.size;
      this.SampleLink = this.service.FileUrl+this.SampleName;
    })
    document.getElementsByClassName('UploadF')[0].setAttribute("style", "display: block;") 
  }

  updatePlaylistInfo()
  {
    var val = {SampleId:this.SampleId,
      SampleName:this.SampleName,
      SampleSize:this.SampleSize,
      SampleLink:this.SampleLink,
      PlaylistName:this.PlaylistName};
      this.service.updatePlaylistInfoOnAdd(val).subscribe();
  }
  
}
