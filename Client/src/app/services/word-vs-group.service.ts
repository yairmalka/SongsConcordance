import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { WordVsGroupModel } from '../Models/wordVsGroup.model';

@Injectable({
  providedIn: 'root'
})
export class WordVsGroupService {

  constructor(private myHttpClient: HttpClient) { }


public addWordsToGivenGroup(wordVsGroupModel: WordVsGroupModel):Promise<WordVsGroupModel>{

    const observable = this.myHttpClient.post<WordVsGroupModel>("https://localhost:7203/api/WordsVsGroups", wordVsGroupModel);
    return firstValueFrom(observable);
}

public getWordsVsGroupsByGroupID(groupId: number):Promise<WordVsGroupModel[]>
{
    const observable = this.myHttpClient.get<WordVsGroupModel[]>("https://localhost:7203/api/WordsVsGroups/getWordsVsGroupsByGroupID/" +groupId);
    return firstValueFrom(observable);
}

}
