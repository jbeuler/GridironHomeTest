import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Application } from 'src/app/shared/application.model';
import { ApplicationService } from 'src/app/shared/application.service';

@Component({
  selector: 'app-application-form',
  templateUrl: './application-form.component.html',
  styleUrls: ['./application-form.component.scss']
})
export class ApplicationFormComponent implements OnInit {

  constructor(public service:ApplicationService, private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
   if(this.service.formData.id == 0) {
     this.insertRecord(form);
   } else {
     this.updateRecord(form);
   }
  }

 

  insertRecord(form:NgForm){
    this.service.postApplication().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Submitted successfully!');
      },
      err => {
        console.log(err);
      }
    )
  }

  updateRecord(form:NgForm){
    this.service.putApplication().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Successfully updated!');
      },
      err => {
        console.log(err);
      }
    )
  }

  resetForm(form:NgForm) {
    form.form.reset();
    this.service.formData = new Application();
  }

}
