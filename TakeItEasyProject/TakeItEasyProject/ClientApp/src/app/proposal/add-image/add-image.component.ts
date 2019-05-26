import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { UploadEvent, FileSystemFileEntry } from 'ngx-file-drop';


@Component({
  selector: 'app-add-image',
  templateUrl: './add-image.component.html',
  styleUrls: ['./add-image.component.scss']
})
export class AddImageComponent implements OnInit {

  private canvas: HTMLCanvasElement;
  public isInvalid: boolean;
  public isSaveEnabled: boolean;
  public errorText = '';
  private currentImageURL = './../../../assets/images/no-profile-image.png';
  public image: string;
  @Output() public uploadImage = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
    this.canvas = <HTMLCanvasElement>document.getElementById('circle');
    const context = this.canvas.getContext('2d');
    const picture = new Image();

    this.isSaveEnabled = true;
    picture.src = !this.image ? this.currentImageURL : this.image;
    picture.onload = () => {
      context.drawImage(picture, 0, 0, this.canvas.width, this.canvas.height);
    };
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
      this.getAndSetTheFileInBase64(file, event, this.image);
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

  getAndSetTheFileInBase64(file, event, picture: string): void {
    const reader = new FileReader();

    reader.onload =  () => {
      picture = reader.result.toString();
      this.uploadImage.emit(picture);
    };
    reader.readAsDataURL(file);
  }
}
