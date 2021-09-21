#ifndef GODATAACCESS_H
#define GODATAACCESS_H

#include <QString>

class GoDataAccess
{
public:
    explicit GoDataAccess() {};

    QVector<QString> saveGameList() const; // mentett játékok lekérdezése

    bool loadGame(int gameIndex, QVector<int> &saveGameData); // játék betöltése
    bool saveGame(int gameIndex, const QVector<int> &saveGameData); // játék mentése
};

#endif // GODATAACCESS_H
