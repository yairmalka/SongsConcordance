import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { WordModel } from '../Models/word.model';

@Injectable({
  providedIn: 'root'
})
export class WordsService {

  constructor(private myHttpClient: HttpClient) { }

    public getAllWords():Promise<WordModel[]>{
        const observable = this.myHttpClient.get<WordModel[]>("https://localhost:7203/api/words");
        return firstValueFrom(observable);
    }

  public getWordsOfOneSong(songId: number):Promise<WordModel[]>{
    const observable = this.myHttpClient.get<WordModel[]>("https://localhost:7203/api/words/getWordsOfOneSong/" + songId);
    return firstValueFrom(observable);
}

}
