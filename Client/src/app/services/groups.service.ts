import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { environment } from 'src/environments/environment';
import { GroupModel } from '../Models/group.model';

@Injectable({
  providedIn: 'root'
})
export class GroupsService {

  constructor(private myHttpClient: HttpClient) { }


public getAllGroups():Promise<GroupModel[]>{
        const observable = this.myHttpClient.get<GroupModel[]>(environment.groupsBaseUrl);
        return firstValueFrom(observable);
    }

public addGroup(group: GroupModel):Promise<GroupModel>{
    const observable = this.myHttpClient.post<GroupModel>(environment.groupsBaseUrl, group);
    return firstValueFrom(observable);
}    
}
