import { Component } from '@angular/core';
import { Injectable, NgZone } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  public constructor(private _http: Http, private _zone: NgZone){}

  title= 'Akka Test UI';
  
  private _baseUIUrl: string = 'http://localhost:12346/api';
  private _baseAPIUrl: string = 'http://localhost:12345/api';

  public UIHealthCheck: string;
  public APIHealthCheck: string;
  public APIHealthCheckAkka: string;
  public FooBar: string;
  public FooBarDelayed: string;
  public FooBarChildren: string;

  public uiHealthCheck(){
    this._http.get(`${this._baseUIUrl}/HealthCheck`).map(response => response.text()).subscribe(data => {
                this._zone.run(() => {
                  this.UIHealthCheck = data;
                });                
            }, error => console.log('Could not do healthcheck for UI'));
  }

  public apiHealthCheck(){
    this._http.get(`${this._baseAPIUrl}/HealthCheck`).map(response => response.text()).subscribe(data => {
                this._zone.run(() => {
                  this.APIHealthCheck = data;
                });                
            }, error => console.log('Could not do healthcheck with akka for API'));
  }

  public apiHealthCheckAkka(){
    this._http.get(`${this._baseAPIUrl}/HealthCheck/withAkka`).map(response => response.text()).subscribe(data => {
                this._zone.run(() => {
                  this.APIHealthCheckAkka = data;
                });                
            }, error => console.log('Could not do healthcheck for API'));
  }

  public fooBar(messageBox: string){
    this._http.get(`${this._baseAPIUrl}/foobar/` + messageBox).map(response => response.text()).subscribe(data => {
                this._zone.run(() => {
                  this.FooBar = data;
                });                
            }, error => console.log('Could not do foobar message for API'));
  }

  public fooBarDelayed(messageBoxDelayed: string){
    this._http.get(`${this._baseAPIUrl}/foobar/delay/` + messageBoxDelayed).map(response => response.text()).subscribe(data => {
                this._zone.run(() => {
                  this.FooBarDelayed = data;
                });                
            }, error => console.log('Could not do foobar delay message for API'));
  }

  public fooBarChildren(messageBoxDelayed: string){
    this._http.get(`${this._baseAPIUrl}/foobar/children`).map(response => response.text()).subscribe(data => {
                this._zone.run(() => {
                  this.FooBarChildren = data;
                });                
            }, error => console.log('Could not do foobar children message for API'));
  }
}

