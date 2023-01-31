import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom, Observable } from 'rxjs';
import { SongModel } from '../Models/song.model';
import { StatisticalDataModel } from '../Models/statisticalData.model';

@Injectable({
  providedIn: 'root'
})
export class SongsService {


    constructor (private myHttpClient: HttpClient){}

    public getAllSongs():Promise<SongModel[]>
    {
        const observable = this.myHttpClient.get<SongModel[]>("https://localhost:7203/api/songs");
        return firstValueFrom(observable);
    }

    public editPartialSong(songModel: SongModel)
    {
        const observable = this.myHttpClient.patch<SongModel>("https://localhost:7203/api/Songs/"+ songModel.songId, songModel);
        return firstValueFrom(observable);
    }

    public getOneSong(songId: number):Promise<SongModel>{
        const observable = this.myHttpClient.get<SongModel>("https://localhost:7203/api/songs/" + songId);
        return firstValueFrom(observable);
    }

   
    public addSong(songFile: File): Observable<Object>{
        const formData = new FormData();
        formData.append("userSongFile", songFile);
        const headers = new HttpHeaders().append('content-Disposition', 'multipart/form-data');
        return this.myHttpClient.post<SongModel[]>("https://localhost:7203/api/Songs", formData, {headers});
  
            
    }

    public loadAllTables():Promise<boolean>{
        const observable = this.myHttpClient.get<boolean>("https://localhost:7203/api/Songs/loadAllTables");
        return firstValueFrom(observable);
    }
    
    public findSongsByData(songModel: SongModel, wordsFromText: string):Promise<SongModel[]>
    {
        let year = songModel.year;
        if(songModel.year == undefined)
            year = -1;
         const observable = this.myHttpClient.get<SongModel[]>
        ("https://localhost:7203/api/Songs/findSongsByData?Artist=" + songModel.artist +"&Title=" + songModel.title +"&Year=" 
                + year +"&Album=" + songModel.album +"&Genre=" + songModel.genre +"&WordsFromText=" + wordsFromText);
        return firstValueFrom(observable);      
    }

    public getSongLyricByID(songID: number):Promise<string>{
        const observable = this.myHttpClient.get("https://localhost:7203/api/Songs/getSongLyricByID/" + songID,
        {responseType: 'text'});
        return firstValueFrom(observable);
    }
    
    public getSongStatisticalData(songID: number):Promise<StatisticalDataModel>
    {
        const observable = this.myHttpClient.get<StatisticalDataModel>("https://localhost:7203/api/Songs/getSongStatisticalData/" + songID);
        return firstValueFrom(observable);
    }

}

