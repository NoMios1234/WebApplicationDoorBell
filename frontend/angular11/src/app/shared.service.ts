import { Injectable } from '@angular/core';
import { from } from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl="https://localhost:44371/api";
readonly FileUrl="https://localhost:44371/Photos";

  constructor(private http:HttpClient) { }

  getLibList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/audiolibs');
  }
  addAudiolib(val:any)
  {
    return this.http.post(this.APIUrl+'/Audiolibs', val);
  }
  updateAudiolib(val:any)
  {
    return this.http.put(this.APIUrl+'/Audiolibs', val);
  }
  deleteAudiolib(val:any)
  {
    return this.http.delete(this.APIUrl+'/Audiolibs/'+val);
  }

  getSampList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/samples');
  }
  addSample(val:any)
  {
    return this.http.post(this.APIUrl+'/Samples', val);
  }
  updateSample(val:any)
  {
    return this.http.put(this.APIUrl+'/Samples', val);
  }
  deleteSample(val:any)
  {
    return this.http.delete(this.APIUrl+'/Samples/'+val);
  }

  UploadFile(val:any)
  {
    return this.http.post(this.APIUrl+'/Samples/SaveFile',val);
  }
  getAllPlayModes():Observable<any[]>
  {
    return this.http.get<any[]>(this.APIUrl+'Audiolibs/getAllPlayModes');
  }
}
