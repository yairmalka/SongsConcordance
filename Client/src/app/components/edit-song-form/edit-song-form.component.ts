import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SongModel } from 'src/app/Models/song.model';
import { SongsService } from 'src/app/services/songs.service';

@Component({
  selector: 'app-edit-song-form',
  templateUrl: './edit-song-form.component.html',
  styleUrls: ['./edit-song-form.component.css']
})
export class EditSongFormComponent implements OnInit {

    public songToEdit!: SongModel;

  constructor(private myActivatedRoute: ActivatedRoute, private mySongService: SongsService,
    private myRouter: Router) { }

  async ngOnInit(){
    try{
    const songId = +this.myActivatedRoute.snapshot.params['songId'];
    this.songToEdit = await this.mySongService.getOneSong(songId);
    }
    catch(err){
        alert(err);
    }

  }

  public async editPartialSong()
  {
      try{
          await this.mySongService.editPartialSong(this.songToEdit);
          this.myRouter.navigateByUrl("/songs");
      }
      catch(err){
          alert(err);
      }
  }


}
