import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-show-plst',
  templateUrl: './show-plst.component.html',
  styleUrls: ['./show-plst.component.css']
})
export class ShowPlstComponent implements OnInit {

  constructor(private service:SharedService) { }

  PlaylistList:any=[];

  ModalTitle:string;
  ActivateAddEditPlstComp:boolean=false;
  plst:any;

  PlaylistIdFilter:string="";
  PlaylistNameFilter:string="";
  PlaylistListWithoutFilter:any=[];

  ngOnInit(): void {
    this.refreshPlaylist();
  }

  addClick()
  {
    this.plst={
      PlaylistId:0,
      PlaylistName:"",
      CountOfSamp:0,
      PlaylistSize:0
    }
    this.ModalTitle = "Add Playlist";
    this.ActivateAddEditPlstComp=true;
  }

  editClick(item)
  {
    this.plst=item;
    this.ModalTitle="Edit Playlist";
    this.ActivateAddEditPlstComp=true;
  }

  deleteClick(item)
  {
    if(confirm('Are you shure?'))
    {
      this.service.deletePlaylist(item.PlaylistId).subscribe(data=>{
        alert(data.toString());
        this.refreshPlaylist();
      })
    }
  }

  closeClick()
  {
    this.ActivateAddEditPlstComp=false;
    this.refreshPlaylist();
  }

  refreshPlaylist()
  {
    this.service.getPlaylist();
    this.service.getPlaylist().subscribe(data=>{
      this.PlaylistList=data;
      this.PlaylistListWithoutFilter=data;
    });
  }

  FilterFn()
  {
    var PlaylistIdFilter = this.PlaylistIdFilter;
    var PlaylistNameFilter = this.PlaylistNameFilter;

    this.PlaylistList = this.PlaylistListWithoutFilter.filter(function (el){
      return el.PlaylistId.toString().toLowerCase().includes(
        PlaylistIdFilter.toString().trim().toLowerCase()
      )&&
      el.PlaylistName.toString().toLowerCase().includes(
        PlaylistNameFilter.toString().trim().toLowerCase()
      )
    });
  }

  sortResult(prop,asc){
    this.PlaylistList = this.PlaylistListWithoutFilter.sort(function(a,b){
      if(asc){
          return (a[prop]>b[prop])?1 : ((a[prop]<b[prop]) ?-1 :0);
      }else{
        return (b[prop]>a[prop])?1 : ((b[prop]<a[prop]) ?-1 :0);
      }
    })
  }

}
