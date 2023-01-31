import { Component, OnInit } from '@angular/core';
import { GroupModel } from 'src/app/Models/group.model';
import { GroupsService } from 'src/app/services/groups.service';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.css']
})
export class GroupsComponent implements OnInit {

    public groups!: GroupModel[];

  constructor(private myGroupService: GroupsService) { }

  public async ngOnInit() {

    try{
        this.groups = await this.myGroupService.getAllGroups();
    }
    catch(err){
        alert(err);
    }
  }

}
