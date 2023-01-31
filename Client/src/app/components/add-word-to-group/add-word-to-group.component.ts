import { Component,} from '@angular/core';
import { Router } from '@angular/router';
import { WordVsGroupModel } from 'src/app/Models/wordVsGroup.model';
import { WordVsGroupService } from 'src/app/services/word-vs-group.service';



@Component({
  selector: 'app-add-word-to-group',
  templateUrl: './add-word-to-group.component.html',
  styleUrls: ['./add-word-to-group.component.css']
})
export class AddWordToGroupComponent{

    public wordVsGroupModel = new WordVsGroupModel;

  constructor(private myWordVsGroupService: WordVsGroupService, private myRouter: Router) { }

  public async addWordToGroup()
  {
    try{
       await this.myWordVsGroupService.addWordsToGivenGroup(this.wordVsGroupModel);
       alert(this.wordVsGroupModel.wordValue + " has been added successfully to the group:" +this.wordVsGroupModel.groupName);
       this.myRouter.navigateByUrl("/groups");
    }
    catch(err){
        alert();
    }
  }

}
