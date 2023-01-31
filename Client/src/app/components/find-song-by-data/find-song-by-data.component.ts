import { Component, OnInit } from '@angular/core';
import { SongModel } from 'src/app/Models/song.model';
import { SongsService } from 'src/app/services/songs.service';

@Component({
  selector: 'app-find-song-by-data',
  templateUrl: './find-song-by-data.component.html',
  styleUrls: ['./find-song-by-data.component.css']
})
export class FindSongByDataComponent {

    public userInputSongModel = new SongModel();
    public wordsFromText! : string;
    public listOfSongs! :SongModel[];
  
    constructor(private mySongService: SongsService ) { }

    public async searchSongByData()
    {
        try{
            if(this.userInputSongModel.artist == undefined)
                this.userInputSongModel.artist = "";
                if(this.userInputSongModel.title == undefined)
                this.userInputSongModel.title = "";
                if(this.userInputSongModel.album == undefined)
                this.userInputSongModel.album = "";
                if(this.userInputSongModel.genre == undefined)
                this.userInputSongModel.genre = ""; 
                if(this.wordsFromText == undefined)
                    this.wordsFromText = "";
             this.listOfSongs = await this.mySongService.findSongsByData(this.userInputSongModel, this.wordsFromText);
             if(this.listOfSongs.length == 0)
                alert("no matches found");
        }
        catch(err){
            alert(err);
        }
    }



}
