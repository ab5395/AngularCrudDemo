import { Component } from '@angular/core';
import { FormControl, FormBuilder, Validators } from '@angular/forms';
import { Http } from '@angular/http';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { TemplateRef } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Myapp';

  // public modalRef: BsModalRef; // {1}
  // constructor(private modalService: BsModalService) {} // {2}

  // public openModal(template: TemplateRef<any>) {
  //   this.modalRef = this.modalService.show(template); // {3}
  // }
}
