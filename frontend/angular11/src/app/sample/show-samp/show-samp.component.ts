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

  SampleIdFilter:string="";
  SampleNameFilter:string="";
  SampleWithoutFilter:any=[];

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
      this.service.removeSampleLink(item).subscribe();
      this.service.updatePlaylistInfoOnDelete(item).subscribe();
      this.service.deleteSample(item.SampleId).subscribe(data=>{
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
      this.SampleWithoutFilter=data;  
    });
  }

  FilterFn()
  {
    var PlaylistIdFilter = this.SampleIdFilter;
    var PlaylistNameFilter = this.SampleNameFilter;

    this.SampleList = this.SampleWithoutFilter.filter(function (el){
      return el.SampleId.toString().toLowerCase().includes(
        PlaylistIdFilter.toString().trim().toLowerCase()
      )&&
      el.SampleName.toString().toLowerCase().includes(
        PlaylistNameFilter.toString().trim().toLowerCase()
      )
    });
  }

  sortResult(prop,asc){
    this.SampleList = this.SampleWithoutFilter.sort(function(a,b){
      if(asc){
          return (a[prop]>b[prop])?1 : ((a[prop]<b[prop]) ?-1 :0);
      }else{
        return (b[prop]>a[prop])?1 : ((b[prop]<a[prop]) ?-1 :0);
      }
    })
  }
}
