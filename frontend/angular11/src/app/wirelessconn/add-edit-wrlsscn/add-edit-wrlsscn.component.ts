import { Component, OnInit, Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-wrlsscn',
  templateUrl: './add-edit-wrlsscn.component.html',
  styleUrls: ['./add-edit-wrlsscn.component.css']
})
export class AddEditWrlsscnComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() wirl:any;
    WirelessConnId:string;
    WirelessConnSSID:string;
    WirelessConnPassword:string;
    WirelessConnMode:string;
    WirelessConnDesc:string;


  ngOnInit(): void {
    this.WirelessConnId=this.wirl.WirelessConnId;
    this.WirelessConnSSID=this.wirl.WirelessConnSSID;
    this.WirelessConnPassword=this.wirl.WirelessConnPassword;
    this.WirelessConnMode=this.wirl.WirelessConnMode;
    this.WirelessConnDesc=this.wirl.WirelessConnDesc;
  }

  addWirelessConn()
  {
    var val = {WirelessConnId:this.WirelessConnId,
              WirelessConnSSID:this.WirelessConnSSID,
              WirelessConnPassword:this.WirelessConnPassword,
              WirelessConnMode:this.WirelessConnMode,
              WirelessConnDesc:this.WirelessConnDesc};
    this.service.addWirelessConn(val).subscribe(res=>{
      alert(res.toString());
    })
  }

  updateWirelessConn()
  {
    var val = {WirelessConnId:this.WirelessConnId,
              WirelessConnSSID:this.WirelessConnSSID,
              WirelessConnPassword:this.WirelessConnPassword,
              WirelessConnMode:this.WirelessConnMode,
              WirelessConnDesc:this.WirelessConnDesc};
    this.service.updateWirelessConn(val).subscribe(res=>{
      alert(res.toString());
    });
  }

}
