import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-show-samp',
  templateUrl: './show-samp.component.html',
  styleUrls: ['./show-samp.component.css']
})
export class ShowSampComponent implements OnInit {

  constructor(private service:SharedService) { }

  SampleList:any=[];

  ModalTitle:string;
  ActivateAddEditSampComp:boolean=false;
  samp:any;

  ngOnInit(): void {
    this.refreshSampleList();
  }

  addClick()
  {
    this.samp={
      SampleId:0,
      SampleName:"",
      SampleSize:0,
      SampleLink:"",
      PlaylistName:"",
    }
    this.ModalTitle = "Add Sample";
    this.ActivateAddEditSampComp=true;
  }

  editClick(item)
  {
    this.samp=item;
    this.ModalTitle="Edit Sample";
    this.ActivateAddEditSampComp=true;
  }

  deleteClick(item)
  {
    if(confirm('Are you shure?'))
    {
      this.service.deleteSample(item.SampleId).subscribe(data=>{
        alert(data.toString());
        this.refreshSampleList();
      })
    }
  }

  closeClick()
  {
    this.ActivateAddEditSampComp=false;
    this.refreshSampleList();
  }

  refreshSampleList()
  {
    this.service.getSampList().subscribe(data=>{
      this.SampleList=data;
    });
  }

}
