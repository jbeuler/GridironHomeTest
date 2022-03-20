import { Component, OnInit } from '@angular/core';
import { ApplicationService } from 'src/app/shared/application.service';

@Component({
  selector: 'app-application-form',
  templateUrl: './application-form.component.html',
  styleUrls: ['./application-form.component.scss']
})
export class ApplicationFormComponent implements OnInit {

  constructor(public service:ApplicationService) { }

  ngOnInit(): void {
  }

}
