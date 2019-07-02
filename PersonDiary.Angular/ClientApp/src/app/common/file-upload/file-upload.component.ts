import { Component, Input, ViewChild, ElementRef } from '@angular/core';
import { HttpEventType  } from '@angular/common/http'
import { FileUploadService } from '../../services/file-upload.service';
import { Router } from '@angular/router';

const HttpStatusOk: number = 200;

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent {
  @Input() PersonId: number;
  @Input() HasFile: boolean;
  public progress: number;
  public success_message: string;
  public warning_message: string;

  @ViewChild("file") file: ElementRef;

  constructor(private fileservice: FileUploadService, private router: Router) {

  }

  upload(files) {
    if (files[0].name.indexOf(".doc") == -1) {
      this.warning_message = "Only .doc/.docx file types allowed";
      return;
    }
    this.fileservice.postFile(this.PersonId,files).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress)
        this.progress = Math.round(100 * event.loaded / event.total);
      else if (event.type === HttpEventType.Response) {
        if ((<any>event.body).messages.length == 0) {
          this.warning_message = null;
          this.success_message = "File uploaded successfully";
          this.HasFile = true;
        } else {
          this.warning_message = "Upload failed";
          this.success_message = null;
        };
        
      }
    });
  }

  browse() {
    this.success_message = null;
    this.file.nativeElement.click();
  }
  deleteFile() {
    this.fileservice.deleteFile(this.PersonId).subscribe(data => {
      if (data.messages.length == 0){
        this.HasFile = false;
      }
    });
    
  }


}

