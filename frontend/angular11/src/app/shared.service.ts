import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl="https://localhost:44371/api";
readonly FileUrl="https://localhost:44371/Files/";
readonly StreamUrl="http://192.168.1.106/";

  constructor(private http:HttpClient) { }

  getPlaylist():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Playlist');
  }
  addPlaylist(val:any){
    return this.http.post(this.APIUrl+'/Playlist', val);
  }
  updatePlaylist(val:any)
  {
    return this.http.put(this.APIUrl+'/Playlist', val);
  }
  deletePlaylist(val:any)
  {
    return this.http.delete(this.APIUrl+'/Playlist/'+val);
  }
  getSampList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Sample');
  }
  addSample(val:any)
  {
    return this.http.post(this.APIUrl+'/Sample', val);
  }
  updateSample(val:any)
  {
    return this.http.put(this.APIUrl+'/Sample', val);
  }
  deleteSample(val:any)
  {
    return this.http.delete(this.APIUrl+'/Sample/'+val);
  }
  removeSampleLink(val:any)
  {
    return this.http.put(this.APIUrl+'/Sample/RemoveSample', val);
  }
  getWirelessConn():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/WirelessConn');
  }
  addWirelessConn(val:any)
  {
    return this.http.post(this.APIUrl+'/WirelessConn', val);
  }
  updateWirelessConn(val:any)
  {
    return this.http.put(this.APIUrl+'/WirelessConn', val);
  }
  deleteWirelessConn(val:any)
  {
    return this.http.delete(this.APIUrl+'/WirelessConn/'+val);
  }
  uploadFile(val:any)
  {
    return this.http.post(this.APIUrl+'/Sample/UploadFile',val);
  }
  getAllSamples():Observable<any[]>
  {
    return this.http.get<any[]>(this.APIUrl+'/Playlist/getAllSamples');
  }
  updatePlaylistInfo(val:any)
  {
    return this.http.put(this.APIUrl+'/View/updatePlaylistInfo', val);
  }
  getAllPlaylistNames():Observable<any[]>
  {
    return this.http.get<any[]>(this.APIUrl+'/Sample/getAllPlaylistNames');
  }
  getSream():Observable<any[]>
  {
    return this.http.get<any[]>(this.StreamUrl);
  }
}
