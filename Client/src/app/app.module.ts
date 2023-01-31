import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { LayoutComponent } from './components/layout/layout.component';
import { HeaderComponent } from './components/header/header.component';
import { AsideComponent } from './components/aside/aside.component';
import { FormsModule } from '@angular/forms';
import { MainComponent } from './components/main/main.component';
import { SongsComponent } from './components/songs/songs.component';
import { WordsComponent } from './components/words/words.component';
import { PositionsComponent } from './components/positions/positions.component';
import { GroupsComponent } from './components/groups/groups.component';

import { LinguisticExpressionsComponent } from './components/linguistic-expressions/linguistic-expressions.component';
import { HttpClientModule } from '@angular/common/http';
import { SubHeaderComponent } from './components/sub-header/sub-header.component';
import { LyricFullTextComponent } from './components/lyric-full-text/lyric-full-text.component';
import { FindWordFormComponent } from './components/find-word-form/find-word-form.component';
import { AddGroupFormComponent } from './components/add-group-form/add-group-form.component';
import { AddExpressionFormComponent } from './components/add-expression-form/add-expression-form.component';
import { SearchExpressionComponent } from './components/search-expression/search-expression.component';
import { ShortSongBriefComponent } from './components/short-song-brief/short-song-brief.component';
import { ExpressionsPositionsTableComponent } from './components/expressions-positions-table/expressions-positions-table.component';
import { AddWordToGroupComponent } from './components/add-word-to-group/add-word-to-group.component';
import { WordsInTheGroupComponent } from './components/words-in-the-group/words-in-the-group.component';
import { EditSongFormComponent } from './components/edit-song-form/edit-song-form.component';
import { FindSongByDataComponent } from './components/find-song-by-data/find-song-by-data.component';
import { FullSongLyricComponent } from './components/full-song-lyric/full-song-lyric.component';
import { StatisticalDataComponent } from './components/statistical-data/statistical-data.component';

@NgModule({
  declarations: [
    LayoutComponent,
    HeaderComponent,
    AsideComponent,
    MainComponent,
    SongsComponent,
    WordsComponent,
    PositionsComponent,
    GroupsComponent,
    StatisticalDataComponent,
    LinguisticExpressionsComponent,
    SubHeaderComponent,
    LyricFullTextComponent,
    FindWordFormComponent,
    AddGroupFormComponent,
    AddExpressionFormComponent,
    SearchExpressionComponent,
    ShortSongBriefComponent,
    ExpressionsPositionsTableComponent,
    AddWordToGroupComponent,
    WordsInTheGroupComponent,
    EditSongFormComponent,
    FindSongByDataComponent,
    FullSongLyricComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, FormsModule, HttpClientModule] ,
  providers: [],
  bootstrap: [LayoutComponent]
})
export class AppModule { }
