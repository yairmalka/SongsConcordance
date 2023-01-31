import { Component, Input, OnInit } from '@angular/core';
import { LinguisticExpressionModel } from 'src/app/Models/linguisticExpression.model';
import { LinguisticExpressionsService } from 'src/app/services/linguistic-expressions.service';


@Component({
  selector: 'app-linguistic-expressions',
  templateUrl: './linguistic-expressions.component.html',
  styleUrls: ['./linguistic-expressions.component.css']
})
export class LinguisticExpressionsComponent implements OnInit {

    public expressions! : LinguisticExpressionModel[];
    
    @Input()
    public countOfSongs! : number;
  constructor(private myExpressionService: LinguisticExpressionsService) { }

 public async ngOnInit() {


    try{
        this.expressions = await this.myExpressionService.getAllExpressions();
    }

    catch(err){
        alert(err);
    }

  }

  public async ngOnDestroy(){
    try{
        this.expressions = await this.myExpressionService.getAllExpressions();
    }

    catch(err){
        alert(err);
    }
  }

}
