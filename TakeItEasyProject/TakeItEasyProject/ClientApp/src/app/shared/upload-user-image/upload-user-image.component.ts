import { Component, OnInit, Input, SimpleChanges } from '@angular/core';
import { UploadEvent, FileSystemFileEntry } from 'ngx-file-drop';
import { User } from '../models/User';

@Component({
  selector: 'app-upload-user-image',
  templateUrl: './upload-user-image.component.html',
  styleUrls: ['./upload-user-image.component.scss']
})
export class UploadUserImageComponent implements OnInit {

  private canvas: HTMLCanvasElement;
  public isInvalid: boolean;
  public isSaveEnabled: boolean;
  public errorText = '';
  private currentImageURL = './../../../assets/images/no-profile-image.png';
  @Input() public user: User;

  constructor() { }

  ngOnChanges(changes: SimpleChanges) {
    // tslint:disable-next-line:forin
    for (const propName in changes) {
      const change = changes[propName];
      if ((change.currentValue || change.previousValue) && propName === 'user') {
        console.log("haha");
      }
    }
  }

  ngOnInit(): void {
    this.canvas = <HTMLCanvasElement>document.getElementById('circle');
    const context = this.canvas.getContext('2d');
    const image = new Image();

    this.isSaveEnabled = true;
    image.src = !this.user.image ? this.currentImageURL : this.user.image;
    image.onload = () => {
      context.drawImage(image, 0, 0, this.canvas.width, this.canvas.height);
    };

    console.log(this.user);
  }

  onFileDropped(filesDroped: UploadEvent): void {
    const droppedFile = filesDroped.files[0];
    if (!droppedFile.fileEntry.isFile) {
      this.isInvalid = true;
      this.errorText = 'The maximum size can you upload is: one megabyte';
      return;
    } else {
      const fileEntry = droppedFile.fileEntry as FileSystemFileEntry;
      fileEntry.file((file: File) => {
        this.handleFile(file);
      });
    }
  }

  takeFileFromBrowse(event): void {
    this.handleFile(event.target.files[0]);
  }

  handleFile(file: File): void {
    if (!this.isImage(file)) {
      this.isInvalid = true;
      this.errorText = 'You should introduce a: jpg, png or jpeg file!';
      return;
    } else if (file.size > 1048576) {
      this.isInvalid = true;
      this.errorText = 'The maximum size can you upload is: one megabyte';
      return;
    } else {
      this.errorText = '';
      this.isInvalid = false;
      this.drawImage(file);
      this.getAndSetTheFileInBase64(file, event, this.user);
    }
  }

  drawImage(file) {
    const fileReader = new FileReader();
    fileReader.onload = () => {
      this.currentImageURL = fileReader.result.toString();
      this.canvas = <HTMLCanvasElement>document.getElementById('circle');
      const context = this.canvas.getContext('2d');
      context.clearRect(0, 0, this.canvas.width, this.canvas.height);
      const image = new Image();
      image.src = this.currentImageURL;
      image.onload = () => {
        context.drawImage(image, 0, 0, this.canvas.width, this.canvas.height);
      };
    };
    fileReader.readAsDataURL(file);
  }

  isImage(file: File): boolean {
    return ['image/png', 'image/jpeg', 'image/jpg'].includes(
      file.type.toString().trim()
    );
  }

  getAndSetTheFileInBase64(file, event, locUser: User): void {
    const reader = new FileReader();

    reader.onload = function (event) {
      locUser.image = reader.result.toString();
      console.log(locUser);
    };
    reader.readAsDataURL(file);
  }

}
