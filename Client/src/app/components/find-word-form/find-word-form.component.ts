import { Component, OnInit } from '@angular/core';
import { SongAndPositionModel } from 'src/app/Models/songAndPosition.model';
import { PositionsService } from 'src/app/services/positions.service';

@Component({
  selector: 'app-find-word-form',
  templateUrl: './find-word-form.component.html',
  styleUrls: ['./find-word-form.component.css']
})
export class FindWordFormComponent {

    public wordIndex!: number;
    public sentenceNumber! : number;
    public verseNumber! : number;
    public wordsByIndexFound! : SongAndPositionModel[];
    public clicked: boolean = false;

  constructor(private myPositionService: PositionsService) { }
  
  public async findWordByIndex()
  {
    this.clicked = true;
    try{
     this.wordsByIndexFound = await this.myPositionService.findWordByIndex(this.wordIndex, this.sentenceNumber, this.verseNumber);

    }
    catch(err){
        alert("err");
    }
  }
    

}
