import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddExpressionFormComponent } from './components/add-expression-form/add-expression-form.component';
import { AddGroupFormComponent } from './components/add-group-form/add-group-form.component';
import { AddWordToGroupComponent } from './components/add-word-to-group/add-word-to-group.component';
import { EditSongFormComponent } from './components/edit-song-form/edit-song-form.component';
import { ExpressionsPositionsTableComponent } from './components/expressions-positions-table/expressions-positions-table.component';
import { FindSongByDataComponent } from './components/find-song-by-data/find-song-by-data.component';
import { FindWordFormComponent } from './components/find-word-form/find-word-form.component';
import { FullSongLyricComponent } from './components/full-song-lyric/full-song-lyric.component';
import { GroupsComponent } from './components/groups/groups.component';
import { LinguisticExpressionsComponent } from './components/linguistic-expressions/linguistic-expressions.component';
import { LyricFullTextComponent } from './components/lyric-full-text/lyric-full-text.component';
import { MainComponent } from './components/main/main.component';
import { PositionsComponent } from './components/positions/positions.component';
import { SearchExpressionComponent } from './components/search-expression/search-expression.component';
import { ShortSongBriefComponent } from './components/short-song-brief/short-song-brief.component';
import { SongsComponent } from './components/songs/songs.component';
import { StatisticalDataComponent } from './components/statistical-data/statistical-data.component';
import { WordsInTheGroupComponent } from './components/words-in-the-group/words-in-the-group.component';
import { WordsComponent } from './components/words/words.component';

const routes: Routes = [{path:"main", component: MainComponent},
                        {path:"songs", component: SongsComponent},
                        {path:"songs/lyrics/:songId", component: LyricFullTextComponent},
                        {path:"songs/editSong/:songId", component: EditSongFormComponent},
                        {path:"songs/findSongsByData", component: FindSongByDataComponent},
                        {path:"songs/fullSongLyric/:songId",component: FullSongLyricComponent},
                        {path:"songs/statisticalData/:songId", component: StatisticalDataComponent},
                        {path:"words", component: WordsComponent},
                        {path:"positions", component: PositionsComponent},
                        {path:"positions/findWordByIndexForm", component: FindWordFormComponent },
                        {path:"positions/shortSongBrief/:positionId/:numOfWords", component: ShortSongBriefComponent},
                        {path:"groups", component: GroupsComponent},
                        {path:"groups/addNewGroup", component: AddGroupFormComponent},
                        {path:"groups/addWordToGroup", component: AddWordToGroupComponent},
                        {path:"groups/WordsInGroup/:groupId", component: WordsInTheGroupComponent},
                        {path:"statistical-data", component: StatisticalDataComponent},
                        {path:"linguistic-expressions", component: LinguisticExpressionsComponent},
                        {path:"linguistic-expressions/addNewExpression", component: AddExpressionFormComponent},
                        {path:"linguistic-expressions/SearchExpression", component: SearchExpressionComponent},
                        {path:"linguistic-expressions/expressionPositionsTable/:expressionId", component: ExpressionsPositionsTableComponent},
                        {path: "", redirectTo: "/main", pathMatch: "full"}
                        ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
