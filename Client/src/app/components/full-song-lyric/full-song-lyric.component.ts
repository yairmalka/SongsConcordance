import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SongModel } from 'src/app/Models/song.model';
import { SongsService } from 'src/app/services/songs.service';

@Component({
  selector: 'app-full-song-lyric',
  templateUrl: './full-song-lyric.component.html',
  styleUrls: ['./full-song-lyric.component.css']
})
export class FullSongLyricComponent implements OnInit {

    public songLyric! : string;
    public songModel!: SongModel;
  constructor(private myActivatedRoute: ActivatedRoute,private mySongsService: SongsService) { }

  async ngOnInit() {

    const songID = +this.myActivatedRoute.snapshot.params['songId'];
    this.songModel = await this.mySongsService.getOneSong(songID);
    this.songLyric = await this.mySongsService.getSongLyricByID(songID);
  }

}
