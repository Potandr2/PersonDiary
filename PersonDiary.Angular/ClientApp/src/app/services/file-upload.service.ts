import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule, HttpRequest, HttpEventType, HttpResponse, HttpParams, HttpEvent, HttpResponseBase } from '@angular/common/http'
import { Observable } from 'rxjs';



@Injectable()
export class FileUploadService {

  private url = "api/personfile";

  constructor(private http: HttpClient) {
  }

  postFile(PersonId:number,files:any): Observable<any> {
    if (files.length === 0)
      return;

    const formData = new FormData();

    for (let file of files)
      formData.append(file.name, file);

    const params = new HttpParams().set('json', JSON.stringify({ PersonId: PersonId }));
    const uploadReq = new HttpRequest('POST', this.url, formData, {
      reportProgress: true,
      params: params
    });

    return this.http.request(uploadReq);    
  }

  getFile(id: number): Observable<any> {
    return this.http.get(this.url + '/' + id, { responseType: 'blob' });
  }
  deleteFile(id: number): Observable<any> {
    return this.http.delete(this.url + '/' + id);
  }


}
