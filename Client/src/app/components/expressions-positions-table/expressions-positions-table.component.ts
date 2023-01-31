import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SongAndPositionModel } from 'src/app/Models/songAndPosition.model';
import { LinguisticExpressionsService } from 'src/app/services/linguistic-expressions.service';

@Component({
  selector: 'app-expressions-positions-table',
  templateUrl: './expressions-positions-table.component.html',
  styleUrls: ['./expressions-positions-table.component.css']
})
export class ExpressionsPositionsTableComponent implements OnInit {

    public expressionsLocations! : SongAndPositionModel[];
    public numOfWordsInTheExpression!: number;
    public expressionId! :number;
    public expression! : any;

  constructor(private myExpService: LinguisticExpressionsService, private myActivatedRoute: ActivatedRoute) { }

  public async ngOnInit() {
    this.expressionId = +this.myActivatedRoute.snapshot.params['expressionId'];
    try{
        this.expressionsLocations = await this.myExpService.getFullDataOfExpression(this.expressionId);
       this.expression = await (await this.myExpService.getOneLinguisticExpression(this.expressionId)).expressionValue;
       const split = this.expression.split(' ');
        this.numOfWordsInTheExpression = split.length;
    }
    catch(err){
        alert(err);
    }
  }

}
