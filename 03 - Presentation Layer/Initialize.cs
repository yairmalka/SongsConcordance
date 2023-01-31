//ctrl + k ctrl + c multiple remarks
//ctrl + k ctrl + u remove multiple remarks

using DbProject;

//WordsLogic wLogic = new WordsLogic();

//Boolean dataBaseAlreadyFilled = wLogic.checkIfDbIsAlreadyFullWithData();

//if (!dataBaseAlreadyFilled)
//    wLogic.startFillDataBaseTables();

SongsLogic sngLogic = new SongsLogic();
sngLogic.makeAllSongsLyricFile();

