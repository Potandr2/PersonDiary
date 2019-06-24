import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Upload, Host } from '../entities/entities';

@Component({
  selector: 'app-upload-list',
  templateUrl: './upload-list.component.html'
})
export class UploadListComponent {
  public uploads: Upload[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Upload[]>(baseUrl + 'api/Upload/').subscribe(result => {
      this.uploads = result;
    }, error => console.error(error));
  }
}
