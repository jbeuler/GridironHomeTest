import { Component, OnInit } from '@angular/core';
import { Application } from '../shared/application.model';
import { ApplicationService } from '../shared/application.service';
import { faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-applications',
  templateUrl: './applications.component.html',
  styleUrls: ['./applications.component.scss']
})

export class ApplicationsComponent implements OnInit {

  faTrashAlt = faTrashAlt;

  constructor(public service:ApplicationService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord:Application){
    this.service.formData = Object.assign({},{...selectedRecord, effectiveDate: formatDate(selectedRecord.effectiveDate,'yyyy-MM-dd','en_US')});
  }

  onDelete(id:number){
    if(confirm('Are you sure ?')) {
      this.service.deleteApplication(id).subscribe(
        res => {
          this.service.refreshList();
          this.toastr.success('Successfully deleted!');
        },
        err => {
          console.log(err);
        }
      )
    }
   }

}
