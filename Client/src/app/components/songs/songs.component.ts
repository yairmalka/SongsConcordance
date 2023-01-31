import { Component, OnInit } from '@angular/core';
import { SongModel } from 'src/app/Models/song.model';
import { SongsService } from 'src/app/services/songs.service';

@Component({
  selector: 'app-songs',
  templateUrl: './songs.component.html',
  styleUrls: ['./songs.component.css']
})
export class SongsComponent implements OnInit {

    constructor (private mySongsService: SongsService) {}

public songs!: SongModel[];

 async ngOnInit() {

    try{
        this.songs = await this.mySongsService.getAllSongs();
    }

    catch(error){
        alert(error);
    }
  }

}
