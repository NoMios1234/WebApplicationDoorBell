import { Component, OnInit, Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-plst',
  templateUrl: './add-edit-plst.component.html',
  styleUrls: ['./add-edit-plst.component.css']
})
export class AddEditPlstComponent implements OnInit {

  constructor(private service:SharedService) { }
  
  @Input() plst:any;
    PlaylistId:string;
    PlaylistName:string;
    CountOfSamp:string;
    PlaylistSize:string;
    
  ngOnInit(): void {
    
    this.PlaylistId=this.plst.Id;
      this.PlaylistName=this.plst.Name;
      this.CountOfSamp=this.plst.Count;
      this.PlaylistSize=this.plst.Size;

  }

  addPlaylist()
  {
    var val = {PlaylistId:this.PlaylistId,
              PlaylistName:this.PlaylistName,
              CountOfSamp:0,
              PlaylistSize:0
              };
    this.service.addPlaylist(val).subscribe(res=>{
      alert(res.toString());
    })
  }
  updatePlaylist()
  {
    var val = {PlaylistId:this.PlaylistId,
              PlaylistName:this.PlaylistName,
              CountOfSamp:this.CountOfSamp,
              PlaylistSize:this.PlaylistSize
              };
      this.service.updatePlaylist(val).subscribe(res=>{
        alert(res.toString());
      })
  }
}
