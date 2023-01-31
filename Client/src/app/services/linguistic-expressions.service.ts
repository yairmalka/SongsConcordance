import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { LinguisticExpressionModel } from '../Models/linguisticExpression.model';
import { PositionModel } from '../Models/position.model';
import { SongAndPositionModel } from '../Models/songAndPosition.model';

@Injectable({
  providedIn: 'root'
})
export class LinguisticExpressionsService {

  constructor(private myHttpClient: HttpClient) { }

  public getAllExpressions():Promise<LinguisticExpressionModel[]>
  {
    const observable = this.myHttpClient.get<LinguisticExpressionModel[]>("https://localhost:7203/api/LinguisticExpressions");
    return firstValueFrom(observable);
  }

  public getOneLinguisticExpression(expressionId: number): Promise<LinguisticExpressionModel>
  {
    const observable = this.myHttpClient.get<LinguisticExpressionModel>("https://localhost:7203/api/LinguisticExpressions/" + expressionId);
    return firstValueFrom(observable);
  }

  public addExpression(expression: LinguisticExpressionModel):Promise<LinguisticExpressionModel>
  {
    const observable = this.myHttpClient.post<LinguisticExpressionModel>("https://localhost:7203/api/LinguisticExpressions",expression );
    return firstValueFrom(observable);
  }

  public SearchExpression(expression: string):Promise<PositionModel[]>
  {
    const observable = this.myHttpClient.get<PositionModel[]>("https://localhost:7203/api/LinguisticExpressions/findLinguisticExpressions/" + expression );
    return firstValueFrom(observable);
  }


  public getFullDataOfExpression(expressionId: number):Promise<SongAndPositionModel[]>
  {
    const observable = this.myHttpClient.get<SongAndPositionModel[]>("https://localhost:7203/api/ExpressionVsPosition/getFullDataOfExpression/" + expressionId);
    return firstValueFrom(observable);
  }

}
