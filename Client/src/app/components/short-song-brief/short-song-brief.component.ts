import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { concatWith } from 'rxjs';
import { PositionModel } from 'src/app/Models/position.model';
import { PositionsService } from 'src/app/services/positions.service';

@Component({
  selector: 'app-short-song-brief',
  templateUrl: './short-song-brief.component.html',
  styleUrls: ['./short-song-brief.component.css']
})
export class ShortSongBriefComponent implements OnInit {

    public briefOfText! : PositionModel[];
    public wordPosition! : PositionModel;
    public positionId!: number;
    public numOfWordsInTheInput! : number
  constructor(private myActivatedRoute: ActivatedRoute, private myPositionService: PositionsService) { }

  public async ngOnInit() {

    this.positionId = +this.myActivatedRoute.snapshot.params['positionId'];
    this.numOfWordsInTheInput = +this.myActivatedRoute.snapshot.params['numOfWords'];

        this.wordPosition = await this.myPositionService.getOneWordPosition(this.positionId);
        this.briefOfText = await this.myPositionService.getBriefOfWordPosition(this.positionId);
  }

  public toShow(currPositionId: number): boolean
  {
    if((currPositionId - this.positionId >= 0) && (currPositionId - this.positionId < this.numOfWordsInTheInput))
        return true;
    return false;
  }


}
