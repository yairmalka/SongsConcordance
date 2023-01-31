import { Component, OnInit } from '@angular/core';
import { SongAndPositionModel } from 'src/app/Models/songAndPosition.model';
import { LinguisticExpressionsService } from 'src/app/services/linguistic-expressions.service';

@Component({
  selector: 'app-search-expression',
  templateUrl: './search-expression.component.html',
  styleUrls: ['./search-expression.component.css']
})
export class SearchExpressionComponent{

    public songAndPosition! : SongAndPositionModel[];
    public expression!: string;
    public numOfWordsInTheExpression!: number;
    public clicked: boolean = false;

  constructor(private myExpression: LinguisticExpressionsService) { }


  public async searchExpression()
  {
    try{
        this.clicked = true;
        this.songAndPosition = await this.myExpression.SearchExpression(this.expression);
        const split = this.expression.split(' ');
        this.numOfWordsInTheExpression = split.length;
    }
    catch(err){
        alert(err);
    }
  }
}
