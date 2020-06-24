import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class PokeService {

    constructor(
        private httpClient: HttpClient
    ) {}

    public getPokeData(): Observable<any> {
        return this.httpClient.get<any>('http://localhost:7071/api/GetPokemon')
    }
}