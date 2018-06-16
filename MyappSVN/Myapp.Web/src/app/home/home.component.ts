import { Component, OnInit } from '@angular/core';
import { Http  } from '@angular/http';
import { TestApi } from '../shared/api.urls';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  value = {};
  constructor(private http: Http) { }

  ngOnInit() {
  }
  getValues() {
    this.http.get(TestApi.getValues).subscribe
                 ( response => this.value = response.json());
  }
}
