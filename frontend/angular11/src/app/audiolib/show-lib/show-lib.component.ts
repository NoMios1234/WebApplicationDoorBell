import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-show-lib',
  templateUrl: './show-lib.component.html',
  styleUrls: ['./show-lib.component.css']
})
export class ShowLibComponent implements OnInit {

  constructor(private service:SharedService) { }

  AudioLibList:any=[];

  ModalTitle:string;
  ActivateAddEditLibComp:boolean=false;
  lib:any;

  AudioLibIdFilter:string="";
  AudioLibNameFilter:string="";
  AudioLibListWithoutFilter:any=[];

  ngOnInit(): void {
    this.refreshLibList();
  }

  addClick()
  {
    this.lib={
      Id:0,
      Name:"",
      Count:0,
      Size:0,
      PlayModeId:0

    }
    this.ModalTitle = "Add AudioLib";
    this.ActivateAddEditLibComp=true;
  }

  editClick(item)
  {
    this.lib=item;
    this.ModalTitle="Edit AudioLib";
    this.ActivateAddEditLibComp=true;
  }

  deleteClick(item)
  {
    if(confirm('Are you shure?'))
    {
      this.service.deleteAudiolib(item.Id).subscribe(data=>{
        alert(data.toString());
        this.refreshLibList();
      })
    }
  }

  closeClick()
  {
    this.ActivateAddEditLibComp=false;
    this.refreshLibList();
  }

  refreshLibList()
  {
    this.service.getLibList().subscribe(data=>{
      this.AudioLibList=data;
      this.AudioLibListWithoutFilter=data;
    });
  }

  FilterFn()
  {
    var AudioLibIdFilter = this.AudioLibIdFilter;
    var AudioLibNameFilter = this.AudioLibNameFilter;

    this.AudioLibList = this.AudioLibListWithoutFilter.filter(function (el){
      return el.Id.toString().toLowerCase().includes(
        AudioLibIdFilter.toString().trim().toLowerCase()
      )&&
      el.Name.toString().toLowerCase().includes(
        AudioLibNameFilter.toString().trim().toLowerCase()
      )
    });
  }

  sortResult(prop,asc){
    this.AudioLibList = this.AudioLibListWithoutFilter.sort(function(a,b){
      if(asc){
          return (a[prop]>b[prop])?1 : ((a[prop]<b[prop]) ?-1 :0);
      }else{
        return (b[prop]>a[prop])?1 : ((b[prop]<a[prop]) ?-1 :0);
      }
    })
  }

}
