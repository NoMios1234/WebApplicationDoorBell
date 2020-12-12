import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-show-wrlsscn',
  templateUrl: './show-wrlsscn.component.html',
  styleUrls: ['./show-wrlsscn.component.css']
})
export class ShowWrlsscnComponent implements OnInit {

  constructor(private service:SharedService) { }

  WirelessList:any=[];

  ModalTitle:string;
  ActivateAddEditWirelessComp:boolean=false;
  wirl:any;

  WirelessIdFilter:string="";
  WirelessSSIDFilter:string="";
  WirelessWithoutFilter:any=[];

  ngOnInit(): void {
    this.refreshWirelessList();
  }

  addClick()
  {
    this.wirl={
      WirelessConnId:0,
      WirelessConnSSID:"",
      WirelessConnPassword:"",
      WirelessConnMode:"",
      WirelessConnDesc:"",
    }
    this.ModalTitle = "Add Wi-Fi";
    this.ActivateAddEditWirelessComp=true;
  }

  editClick(item)
  {
    this.wirl=item;
    this.ModalTitle="Edit Wi-Fi";
    this.ActivateAddEditWirelessComp=true;
  }

  deleteClick(item)
  {
    if(confirm('Are you shure?'))
    {
      this.service.deleteWirelessConn(item.WirelessConnId).subscribe(res=>{
        this.refreshWirelessList();
      });
    }
  }

  closeClick()
  {
    this.ActivateAddEditWirelessComp=false;
    this.refreshWirelessList();
  }

  refreshWirelessList(){
    this.service.getWirelessConn().subscribe(data=>{
      this.WirelessList=data;   
      this.WirelessWithoutFilter=data;  
    });
  }

  FilterFn()
  {
    var WirelessconnIdFilter = this.WirelessIdFilter;
    var WirelessconnSSIDFilter = this.WirelessSSIDFilter;

    this.WirelessList = this.WirelessWithoutFilter.filter(function (el){
      return el.WirelessConnId.toString().toLowerCase().includes(
        WirelessconnIdFilter.toString().trim().toLowerCase()
      )&&
      el.WirelessConnSSID.toString().toLowerCase().includes(
        WirelessconnSSIDFilter.toString().trim().toLowerCase()
      )
    });
  }

  sortResult(prop,asc){
    this.WirelessList = this.WirelessWithoutFilter.sort(function(a,b){
      if(asc){
          return (a[prop]>b[prop])?1 : ((a[prop]<b[prop]) ?-1 :0);
      }else{
        return (b[prop]>a[prop])?1 : ((b[prop]<a[prop]) ?-1 :0);
      }
    })
  }
}
