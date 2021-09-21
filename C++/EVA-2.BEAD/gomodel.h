#ifndef GOMODEL_H
#define GOMODEL_H

#include "godataaccess.h"

#include <QObject>
#include <QVector>
#include <QPair>

class GoModel : public QObject
{
    Q_OBJECT
public:
    enum Player { Black, White, NoPlayer };

    struct Chain
    {
        QVector< QPair<int,int> > members;
        int freeFields;

        friend bool operator==(const Chain& lhs, const Chain& rhs)
        {
            return lhs.members == rhs.members && lhs.freeFields == rhs.freeFields;
        }

        friend bool operator!=(const Chain& lhs, const Chain& rhs)
        {
            return lhs.members != rhs.members || lhs.freeFields != rhs.freeFields;
        }
    };

    explicit GoModel(QObject *parent = nullptr);
    explicit GoModel(GoDataAccess* dataAccessNew) { dataAccessTest = dataAccessNew; };
    ~GoModel();

    void newGame(int size, int numberofsteps);
    void stepGame(int x, int y);
    int getBlackPoints();
    int getWhitePoints();
    int getTableSize();
    int getStepNumber() { return stepNumber; }
    int getNumberOfSteps() { return numberOfSteps; }
    int getChainSize() { return chains.size(); }
    void setTableSize(int tablesize);
    void setNumberOfSteps(int numberofsteps);
    Player getCurrentPlayer();
    Player getField(int x, int y);

    bool loadGame(int gameIndex);
    bool saveGame(int gameIndex);
    QVector<QString> saveGameList() const;

signals:
    void fieldChanged(int x, int y, GoModel::Player player);
    void gameOver();
    void gameWon(GoModel::Player player);
    void pointChanged(int point, GoModel::Player player);

private:
    int stepNumber;
    Player currentPlayer;
    Player** gameTable;
    int blackPoints;
    int whitePoints;
    int tableSize;
    int emptyFields;
    int numberOfSteps;
    QVector<Chain> chains;

    GoDataAccess dataAccess;
    GoDataAccess* dataAccessTest;

    void checkNewChain(int x, int y);
    void checkGameState();
    int countEmptyNeighbours(int x, int y);
    void checkFriendlyNeighbours(int x, int y);
    void checkEnemyNeighbours(int x, int y);
    bool checkLegalPlace(int x, int y);
    bool isNeighbour(int x1, int y1, int x2, int y2);
    int countFreeFields(Chain c);
    void deleteChain(Chain c, Player playerTo);
    void mergeChainsOnCondition(Chain& merged, int x, int y);
    void deleteChainOnCondition(QVector<Chain>& neighboursDone, int x, int y, Player enemyPlayer);
};

#endif // GOMODEL_H
