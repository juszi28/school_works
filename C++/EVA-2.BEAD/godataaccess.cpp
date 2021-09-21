#include "godataaccess.h"

#include <QFile>
#include <QFileInfo>
#include <QTextStream>
#include <QDateTime>
#include <QDebug>

QVector<QString> GoDataAccess::saveGameList() const
{
    QVector<QString> result(5);

    // végigmegyünk az 5 helyen
    for (int i = 0; i < 5; i++)
    {
        if (QFile::exists("game" + QString::number(i) + ".sav")) // ha az adott mentés létezik
        {
            QFileInfo info("game"+ QString::number(i) + ".sav");
            result[i] = "[" + QString::number(i + 1) + "] " + info.lastModified().toString("yyyy.MM.dd HH:mm:ss");
            // akkor betöltjük a fájl módosítás időpontját
        }
    }

    return result;
}

bool GoDataAccess::loadGame(int gameIndex, QVector<int> &saveGameData)
{
    QFile file("game" + QString::number(gameIndex) + ".sav");
    if (!file.open(QFile::ReadOnly))
        return false;

    QTextStream stream(&file);

    saveGameData.resize(4);

    saveGameData[0] = stream.readLine().toInt();
    saveGameData[1] = stream.readLine().toInt();
    saveGameData[2] = stream.readLine().toInt();
    saveGameData[3] = stream.readLine().toInt();

    int tableSize = (saveGameData[0] + 1);

    saveGameData.resize(saveGameData.size() +  tableSize*tableSize + 1);

    for (int i = 0; i <= saveGameData[0]; ++i)
    {
        QString line = stream.readLine();
        QStringList list = line.split(' ');
        for(int j = 0; j <= saveGameData[0]; ++j)
        {
            saveGameData[4 + i*(saveGameData[0]+1) +j] = list[j].toInt();
        }
    }

    int index = 4 + (saveGameData[0] + 1) * (saveGameData[0] + 1);
    saveGameData[index] = stream.readLine().toInt();
    int chainSize = saveGameData[index];
    saveGameData.resize(saveGameData.size() + saveGameData[index]);
    for(int i = 0; i < chainSize; ++i)
    {
        saveGameData[index + 1] = stream.readLine().toInt();
        int chainISize = saveGameData[index + 1];
        saveGameData.resize(saveGameData.size() + chainISize * 2 + 1);
        QString line = stream.readLine();
        QStringList list = line.split(' ');
        for(int j = 0; j < chainISize * 2; j += 2)
        {
            saveGameData[index + 2 + j] = list[j].toInt();
            saveGameData[index + 2 + j + 1] = list[j+1].toInt();
        }
        saveGameData[index + 2 + chainISize * 2] = list[chainISize*2].toInt();
        index += chainISize * 2 + 2;
    }

    saveGameData.resize(saveGameData.size() + 2);
    saveGameData[index + 1] = stream.readLine().toInt();
    saveGameData[index + 2] = stream.readLine().toInt();
    file.close();

    return true;
}

bool GoDataAccess::saveGame(int gameIndex, const QVector<int> &saveGameData)
{
    QFile file("game" + QString::number(gameIndex) + ".sav");
    if(!file.open(QFile::WriteOnly))
        return false;

    QTextStream stream(&file);
    stream << saveGameData[0] << "\n";
    stream << saveGameData[1] << "\n";
    stream << saveGameData[2] << "\n";
    stream << saveGameData[3] << "\n";
    for(int i = 0; i <= saveGameData[0]; ++i)
    {
        for(int j = 0; j <= saveGameData[0]; ++j)
        {
            stream << saveGameData[3+(i)*(saveGameData[0]+1) + (j+1)] << " ";
        }
        stream << "\n";
    }

    int index = 3 + (saveGameData[0]+1) * (saveGameData[0]+1) + 1;
    stream << saveGameData[index] << "\n"; // chains.size()
    int chainSize = saveGameData[index];
    for(int i = 0; i < chainSize; ++i)
    {
        stream << saveGameData[index+1] << "\n"; //chains[i].size()
        for(int j = 0; j < (saveGameData[index+1]*2 + 1); ++j)
        {
            stream << saveGameData[index + 2 + j] << " ";
        }
        index += saveGameData[index+1] * 2 + 2;
        stream << "\n";
    }

    stream << saveGameData[index + 1] << "\n";
    stream << saveGameData[index + 2];

    file.close();

    return true;
}


