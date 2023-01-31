import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom, lastValueFrom } from 'rxjs';
import { PositionModel } from '../Models/position.model';
import { SongAndPositionModel } from '../Models/songAndPosition.model';

@Injectable({
  providedIn: 'root'
})
export class PositionsService {


constructor(private myHttpClient: HttpClient){}

public getAllWordsPositions():Promise<PositionModel[]>
{
    const observable = this.myHttpClient.get<PositionModel[]>("https://localhost:7203/api/positions");
    return firstValueFrom(observable);
}

public getOneWordPosition(positionID: number):Promise<PositionModel>
{
const observable = this.myHttpClient.get<PositionModel>("https://localhost:7203/api/positions/" + positionID);
return firstValueFrom(observable);
}

public findWordByIndex(wordIndex: number, sentenceNumber:number ,verseNumber: number):Promise<SongAndPositionModel[]>{
const observable = this.myHttpClient.get<SongAndPositionModel[]>("https://localhost:7203/api/Positions/findWordByIndex/WordIndex/"+ wordIndex +"/SentenceNumber/" + sentenceNumber +"/VerseNumber/" +verseNumber);
return firstValueFrom(observable);
}

public getBriefOfWordPosition(positionID: number):Promise<PositionModel[]>
{
    const observable = this.myHttpClient.get<PositionModel[]>("https://localhost:7203/api/Positions/getBrief/" + positionID);
    return firstValueFrom(observable);
}

public getAllPositionsOfOneSong(songID: number):Promise<PositionModel[]>
{
    const observable = this.myHttpClient.get<PositionModel[]>("https://localhost:7203/api/Positions/getAllThePositionsOfOneSong/" + songID);
    return firstValueFrom(observable);
}

}