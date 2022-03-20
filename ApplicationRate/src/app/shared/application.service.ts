import { Injectable } from '@angular/core';
import { Application } from './application.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {
  constructor(private http:HttpClient) { }

  formData:Application = new Application();

  postApplication() {
    return this.http.post(`${environment.apiBaseUrl}/Applications`, this.formData);
  }
}
