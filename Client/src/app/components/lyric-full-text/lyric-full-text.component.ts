import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PositionModel } from 'src/app/Models/position.model';
import { SongModel } from 'src/app/Models/song.model';
import { PositionsService } from 'src/app/services/positions.service';
import { SongsService } from 'src/app/services/songs.service';



@Component({
  selector: 'app-lyric-full-text',
  templateUrl: './lyric-full-text.component.html',
  styleUrls: ['./lyric-full-text.component.css']
})
export class LyricFullTextComponent implements OnInit {

public wordsOfOneSong! : PositionModel[];
public song! : SongModel;

    constructor(
         private myActivatedRoute: ActivatedRoute,
         private mySongsService: SongsService,
         private myPositionService: PositionsService) { }

  async ngOnInit() {

    const songId = +this.myActivatedRoute.snapshot.params['songId'];
    this.song = await this.mySongsService.getOneSong(songId);
    this.wordsOfOneSong = await this.myPositionService.getAllPositionsOfOneSong(songId);
  }

}
