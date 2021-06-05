import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-cam',
  templateUrl: './show-cam.component.html',
  styleUrls: ['./show-cam.component.css']
})
export class ShowCamComponent implements OnInit {

  constructor(private service:SharedService) { }

  ModalTitle:string;

  ActivateAddEditCamComp:boolean=false;

  ngOnInit(): void {
  }

  startStream()
  {
    this.service.StreamUrl;
    this.ModalTitle = "Camera";
    this.ActivateAddEditCamComp=true;
  }

  closeClick()
  {
    this.ActivateAddEditCamComp=false;
  }

}
