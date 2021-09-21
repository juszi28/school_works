#ifndef GOATWOLFCABBAGE_H
#define GOATWOLFCABBAGE_H

#include "itemspushbutton.h"

#include <QMainWindow>
#include <QPushButton>
#include <QVector>

QT_BEGIN_NAMESPACE
namespace Ui { class GoatWolfCabbage; }
QT_END_NAMESPACE

class GoatWolfCabbage : public QMainWindow
{
    Q_OBJECT

public:
    enum Direction { Left, Right };

    GoatWolfCabbage(QWidget *parent = nullptr);
    ~GoatWolfCabbage();

private slots:
    void itemsClicked();
    void boatClicked();

private:
    void moveOnWater(Direction direction); //a hajó mozgása jobbra-balra
    void moveToBoat(itemsPushButton* senderButton, Direction direction); // az itemek mozgása a hajóba balról/jobbról
    void moveToLand(itemsPushButton* senderButton, Direction direction); //az itemek mozgása a bal/jobb partra a hajóból
    void checkLand(); //ellenőrzi az otthagyott itemeket
    void gameOver(); //ellenőrzi, hogy vége e a játéknak
    void newGame();

    Ui::GoatWolfCabbage *ui;

    Direction direction; // ahol a hajó van
    int moveCount;
    int* boatXPositions;
    int boatYPosition = 220;
    int itemsXPosition = 180;

    QVector<itemsPushButton*> landLeftButtons;
    QVector<itemsPushButton*> landRightButtons;
    itemsPushButton* cabbagePB;
    itemsPushButton* wolfPB;
    itemsPushButton* goatPB;
    QPushButton* boatPB;
    itemsPushButton* itemInBoat;
};
#endif // GOATWOLFCABBAGE_H
