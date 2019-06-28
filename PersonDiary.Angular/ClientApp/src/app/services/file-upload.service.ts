import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse } from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable()
export class FileUploadService {

  private url = "/api/person/upload";

  constructor(private http: HttpClient) {
  }

  postFile(fileToUpload: File): Observable<boolean> {
    const endpoint = this.url;
    const formData: FormData = new FormData();
    formData.append('fileKey', fileToUpload, fileToUpload.name);
    return this.http
      .post(endpoint, formData)
      .map(() => { return true; });
      //.catch((e) => { });
  }

}
