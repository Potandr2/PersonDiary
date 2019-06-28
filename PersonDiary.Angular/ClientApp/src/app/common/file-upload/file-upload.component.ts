import { Component, Input } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse, HttpParams } from '@angular/common/http'
import { FileUploadService } from '../../services/file-upload.service';


@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html'
})
export class FileUploadComponent {
  @Input() PersonId: number;
  public progress: number;
  public message: string;

  private url: string = `api/personfile`;
  constructor(private http: HttpClient) { }

  upload(files) {
    if (files.length === 0)
      return;

    const formData = new FormData();

    for (let file of files)
      formData.append(file.name, file);

    const params = new HttpParams().set('json', JSON.stringify({ PersonId: this.PersonId }));
    const uploadReq = new HttpRequest('POST', this.url, formData, {
      reportProgress: true,
      params:params
    });

    this.http.request(uploadReq).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress)
        this.progress = Math.round(100 * event.loaded / event.total);
      else if (event.type === HttpEventType.Response)
        this.message = event.body.toString();
    });
  }

}

