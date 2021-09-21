#include "gomodel.h"
#include <cmath>
#include <QDebug>

GoModel::GoModel(QObject *parent) : QObject(parent)
{
}

GoModel::~GoModel()
{
    delete []gameTable;
}

void GoModel::newGame(int size, int numberofsteps) // új játék létrehozása
{
    chains.clear();

    gameTable = new Player*[size+1];
    for(int i = 0; i <= size; ++i)
    {
        gameTable[i] = new Player[size+1];
    }

    numberOfSteps = numberofsteps;
    tableSize = size;
    emptyFields = (tableSize+1)*(tableSize+1);

    for(int i = 0; i <= tableSize; ++i)
    {
        for(int j = 0; j <= tableSize; ++j)
        {
            gameTable[i][j] = NoPlayer;
        }
    }

    currentPlayer = Black;
    stepNumber = 0;
    blackPoints = 0;
    whitePoints = 0;
}

void GoModel::stepGame(int x, int y) //egy lépése a játéknak
{
    if(numberOfSteps == 0)
        return;
    if(x < 0 || x > tableSize || y < 0 || y > tableSize)
        return;
    if(gameTable[x][y] != NoPlayer)
        return;

    gameTable[x][y] = currentPlayer;
    emptyFields--;
    fieldChanged(x, y, currentPlayer);
    stepNumber++;

    checkNewChain(x,y); //megnézzük, hogy új lánc/csoport jön-e létre

    currentPlayer = (Player)((currentPlayer + 1) % 2);

    checkGameState();
}

int GoModel::getBlackPoints()
{
    return blackPoints;
}

int GoModel::getWhitePoints()
{
    return whitePoints;
}

int GoModel::getTableSize()
{
    return tableSize;
}

void GoModel::setTableSize(int tablesize)
{
    tableSize = tablesize;
}

void GoModel::setNumberOfSteps(int numberofsteps)
{
    numberOfSteps = numberofsteps*2;
}

GoModel::Player GoModel::getCurrentPlayer()
{
    return currentPlayer;
}

GoModel::Player GoModel::getField(int x, int y) // visszaadunk egy mezőt
{
    if(x < 0 || x > tableSize || y < 0 || y > tableSize)
        return NoPlayer;

    return gameTable[x][y];
}

bool GoModel::loadGame(int gameIndex)
{
    QVector<int> saveGameData;

    if (!dataAccess.loadGame(gameIndex, saveGameData)) // az adatelérés végzi a tevékenységeket
        return false;

    // feldolgozttuk a kapott vektort
    tableSize = saveGameData[0];
    stepNumber = saveGameData[1];
    currentPlayer = (Player)saveGameData[2];
    numberOfSteps = saveGameData[3];

    gameTable = new Player*[tableSize+1];
    for(int i = 0; i <= tableSize; ++i)
    {
        gameTable[i] = new Player[tableSize+1];
    }

    for (int i = 0; i <= tableSize; ++i)
        for (int j = 0; j <= tableSize; ++j)
            gameTable[j][i] = (Player)saveGameData[4 + i * (tableSize+1) + j];

    int index = 4 + (tableSize + 1) * (tableSize + 1) + 1;
    int chainSize = saveGameData[index];

    for(int i = 0; i < chainSize; ++i)
    {
        Chain c;
        int cSize = saveGameData[index+1];
        for(int j = 0; j < cSize*2; j += 2)
        {
            QPair<int,int> x;
            x.first = saveGameData[index + 1 + j];
            x.second = saveGameData[index + 1 + j + 1];
            c.members.append(x);
        }
        c.freeFields = saveGameData[index + 1 + cSize*2 + 1];
        chains.append(c);
        index += cSize*2 + 2;
    }

    blackPoints = saveGameData[saveGameData.size()-2];
    whitePoints = saveGameData[saveGameData.size()-1];

    return true;
}

bool GoModel::saveGame(int gameIndex)
{
    QVector<int> saveGameData;

    // összerakjuk a megfelelő tartalmat
    saveGameData.push_back(tableSize);
    saveGameData.push_back(stepNumber);
    saveGameData.push_back((int)currentPlayer);
    saveGameData.push_back(numberOfSteps);
    for (int i = 0; i <= tableSize; ++i)
        for (int j = 0; j <= tableSize; ++j)
        {
            saveGameData.push_back(gameTable[j][i]);
        }

    saveGameData.push_back(chains.size());
    for(int i = 0; i < chains.size(); ++i)
    {
        saveGameData.push_back(chains[i].members.size());
        for(int j = 0; j < chains[i].members.size(); ++j)
        {
            saveGameData.push_back(chains[i].members[j].first);
            saveGameData.push_back(chains[i].members[j].second);
        }
        saveGameData.push_back(chains[i].freeFields);
    }

    saveGameData.push_back(blackPoints);
    saveGameData.push_back(whitePoints);

    return dataAccess.saveGame(gameIndex, saveGameData);
}

QVector<QString> GoModel::saveGameList() const
{
    return dataAccess.saveGameList();
}

void GoModel::checkNewChain(int x, int y) // csekkeljük, hogy új láncot hoztuk e létre
{
    int neighbours = 4;
    if(x == 0 || x == tableSize)
        neighbours--;
    if(y == 0 || y == tableSize)
        neighbours--;

    if(neighbours == countEmptyNeighbours(x,y))
    {
        Chain c;
        c.freeFields = neighbours;
        QPair<int,int> newMember;
        newMember.first = x;
        newMember.second = y;
        c.members.append(newMember);
        chains.append(c);
    }
    else // ha nem, megnézzük a szomszédokat
    {
        checkFriendlyNeighbours(x, y);
        checkEnemyNeighbours(x, y);
    }
}

void GoModel::checkGameState() //ellenőrizzük, hogy a játéknak vége van-e
{
    if(stepNumber == numberOfSteps || emptyFields == 0)
    {
        if(whitePoints > blackPoints) gameWon(GoModel::White);
        else if(blackPoints > whitePoints) gameWon(GoModel::Black);
        else gameOver();
    }
}

int GoModel::countEmptyNeighbours(int x, int y) // megszámoljuk mennyi üres szomszédja van egy mezőnek
{
    int count = 0;
    if(checkLegalPlace(x-1,y) && gameTable[x-1][y] == NoPlayer) ++count;
    if(checkLegalPlace(x+1,y) && gameTable[x+1][y] == NoPlayer) ++count;
    if(checkLegalPlace(x,y-1) && gameTable[x][y-1] == NoPlayer) ++count;
    if(checkLegalPlace(x,y+1) && gameTable[x][y+1] == NoPlayer) ++count;
    return count;
}

void GoModel::checkFriendlyNeighbours(int x, int y) // megnézzük, melyik lánchoz tartozik az adott mező
{
    Chain mergedChain;
    mergedChain.freeFields = 0;

    mergeChainsOnCondition(mergedChain, x-1, y);
    mergeChainsOnCondition(mergedChain, x+1, y);
    mergeChainsOnCondition(mergedChain, x, y-1);
    mergeChainsOnCondition(mergedChain, x, y+1);

    mergedChain.members.append(QPair<int,int>(x,y));
    mergedChain.freeFields = countFreeFields(mergedChain);
    chains.append(mergedChain);
}

void GoModel::mergeChainsOnCondition(Chain& merged, int x, int y) //ezzel egyesítjük az adott láncokat(szomszédos, ugyanolyan színű bogyók)
{
    if(checkLegalPlace(x,y) && gameTable[x][y] == currentPlayer )
    {
        QPair<int,int> coord(x,y);
        for(int i = 0; i < chains.size(); ++i)
        {
            if(chains[i].members.contains(coord))
            {
                merged.members.append(chains[i].members);
                chains.remove(i);
                break;
            }
        }
    }
}

void GoModel::checkEnemyNeighbours(int x, int y) //megnézzük, mennyi ellentétes színű bogyó veszi körbe az adott mezőt. ha 0 lesz a szabad mezők száma, töröljük.
{
    Player enemyPlayer = (Player)((currentPlayer + 1) % 2);
    QVector<Chain> neighboursDone;
    deleteChainOnCondition(neighboursDone, x-1, y, enemyPlayer);
    deleteChainOnCondition(neighboursDone, x+1, y, enemyPlayer);
    deleteChainOnCondition(neighboursDone, x, y-1, enemyPlayer);
    deleteChainOnCondition(neighboursDone, x, y+1, enemyPlayer);

    neighboursDone.clear();

    for(int i = 0; i < chains.size(); ++i)
    {
        chains[i].freeFields = countFreeFields(chains[i]);
        if(chains[i].freeFields == 0)
            deleteChain(chains[i], enemyPlayer);
    }
}

void GoModel::deleteChainOnCondition(QVector<Chain>& neighboursDone, int x, int y, Player enemyPlayer) //ezzel ellenőrízzük, hogy kell e törölni egy adott láncot
{
    if (checkLegalPlace(x,y) && gameTable[x][y] == enemyPlayer ) //balra szomszéd
    {
        QPair<int,int> coord(x,y);
        for(int i = 0; i < chains.size(); ++i)
        {
            if(chains[i].members.contains(coord) && !neighboursDone.contains(chains[i]))
            {
                chains[i].freeFields--;
                neighboursDone.append(chains[i]);
                if(chains[i].freeFields <= 0)
                {
                    deleteChain(chains[i], currentPlayer);
                }
                break;
            }
        }
    }
}

bool GoModel::checkLegalPlace(int x, int y) //megnézi, hogy létező e ez a mező
{
    return x >= 0 && x <= tableSize && y >= 0 && y <= tableSize;
}

bool GoModel::isNeighbour(int x1, int y1, int x2, int y2) //megnézi, hogy két mező szomszédos e
{
    return ( (x1 == x2 && abs(y1-y2) == 1) || (y1 == y2 && abs(x1-x2) == 1));
}

int GoModel::countFreeFields(GoModel::Chain c) //megszámolja az üres mezőket az egész pályán
{
    int count = 0;
    for(int i = 0; i <= tableSize; ++i)
    {
        for(int j = 0; j <= tableSize; ++j)
        {
            if(gameTable[i][j] == NoPlayer)
            {
                for(int k = 0; k < c.members.size(); ++k)
                {
                    if(isNeighbour(i,j,c.members[k].first, c.members[k].second))
                    {
                        ++count;
                        break;
                    }
                }
            }
        }
    }
    return count;
}

void GoModel::deleteChain(GoModel::Chain c, Player pointTo) //kitöröljük az adott láncot
{
    for(int i = 0; i < c.members.size(); ++i)
    {
        gameTable[c.members[i].first][c.members[i].second] = NoPlayer;
    }

    (pointTo == Black) ? blackPoints += c.members.size() : whitePoints += c.members.size();
    pointChanged(c.members.size(), pointTo);
    emptyFields += c.members.size();

    chains.removeOne(c);
}


