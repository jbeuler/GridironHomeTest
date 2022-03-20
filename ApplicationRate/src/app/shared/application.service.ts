import { Injectable } from '@angular/core';
import { Application } from './application.model';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {
  constructor() { }

  formData:Application = new Application();
}
