import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SongModel } from 'src/app/Models/song.model';
import { StatisticalDataModel } from 'src/app/Models/statisticalData.model';
import { SongsService } from 'src/app/services/songs.service';

@Component({
  selector: 'app-statistical-data',
  templateUrl: './statistical-data.component.html',
  styleUrls: ['./statistical-data.component.css']
})
export class StatisticalDataComponent implements OnInit {

    public songModel: SongModel;
    public statisticalDataModel: StatisticalDataModel;
    public wordAvgLength: number;
    public versesArrayFromOneToLength: number[] = [];
    public sentenceArrayFromOneToLength: number[] = [];


  constructor(private myActivatedRoute: ActivatedRoute, private mySongService: SongsService) { }

  public async ngOnInit() {
    const songId = this.myActivatedRoute.snapshot.params['songId'];
    this.songModel = await this.mySongService.getOneSong(songId);
    this.statisticalDataModel = await this.mySongService.getSongStatisticalData(songId);
    this.wordAvgLength = this.fixTheNumber(this.statisticalDataModel.wordsAvgLength);
    this.fillTheVersesArrayInNumbers();
    this.fillTheSentencesArrayWithNumbers();
  }


  public fillTheVersesArrayInNumbers()
  {
    for(let i = 0; i < this.statisticalDataModel.howMuchWordsInVerses.length; i++)
        this.versesArrayFromOneToLength[i] = i+1;
  }

  public fillTheSentencesArrayWithNumbers()
  {
    for(let i = 0; i < this.statisticalDataModel.howMuchWordsInSentences.length; i++)
        this.sentenceArrayFromOneToLength[i] = i+1;
  }

  public fixTheNumber(num: number): number{
    num =  +num.toFixed(2);
    return num;
  }

}
