import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LinguisticExpressionModel } from 'src/app/Models/linguisticExpression.model';
import { LinguisticExpressionsService } from 'src/app/services/linguistic-expressions.service';

@Component({
  selector: 'app-add-expression-form',
  templateUrl: './add-expression-form.component.html',
  styleUrls: ['./add-expression-form.component.css']
})
export class AddExpressionFormComponent {

    public expression = new LinguisticExpressionModel();

  constructor(private myExpressionService: LinguisticExpressionsService, private myRouter: Router) { }

    public async addExpression()
    {
        try{
        await this.myExpressionService.addExpression(this.expression);
        alert(this.expression.expressionValue + " has added successfully");
        this.myRouter.navigateByUrl("/linguistic-expressions");
        }
        catch(err)
        {
            alert(err);
        }
    }

}
