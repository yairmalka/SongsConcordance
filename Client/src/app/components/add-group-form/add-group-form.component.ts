import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GroupModel } from 'src/app/Models/group.model';
import { GroupsService } from 'src/app/services/groups.service';

@Component({
  selector: 'app-add-group-form',
  templateUrl: './add-group-form.component.html',
  styleUrls: ['./add-group-form.component.css']
})
export class AddGroupFormComponent {

    public group = new GroupModel();
  constructor(private myGroupService: GroupsService, private myRouter: Router) { }

    public async addGroup()
    {
        try{
            await this.myGroupService.addGroup(this.group);
            alert(this.group.groupName + " has added successfully");
            this.myRouter.navigateByUrl("/groups");
        }
        catch(err){
            alert(err);
        }
    }
}
