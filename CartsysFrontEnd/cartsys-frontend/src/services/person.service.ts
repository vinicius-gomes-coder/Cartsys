import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { enviroment } from '../enviroment/enviroment';

export interface PersonModel {
  id: number;  
  name: string;
  age: number;
  address: string;
  email: string;
}

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  private apiUrl = enviroment.apiUrl;

  constructor(private http: HttpClient) { }

  getAllPersons(): Observable<PersonModel[]> {
    return this.http.get<PersonModel[]>(this.apiUrl + 'Person');
  }

  createPerson(person: PersonModel): Observable<PersonModel> {
    return this.http.post<PersonModel>(this.apiUrl + 'Person', person);
  }

  deletePerson(personId: number): Observable<unknown> {
    return this.http.delete(this.apiUrl + 'Person/' + personId);
  }
}
