#include "gamemodel.h"
#include <QRandomGenerator>
#include <QDebug>

gamemodel::gamemodel(QObject *parent) : QObject(parent)
{
    timer = new QTimer();
    connect(timer, SIGNAL(timeout()), this, SLOT(stepKid()));
    timer->start(1000);
}

QPoint gamemodel::getSanta() const
{
    return santa;
}

QVector<QPoint> gamemodel::getKids() const
{
    return kids;
}

void gamemodel::stepSanta(Direction dir)
{
    switch(dir)
    {
        case Up:
            if(santa.y() > 0)
                santa.setY(santa.y() - 1);
            break;
        case Down:
            if(santa.y() < 180)
                santa.setY(santa.y() + 1);
            break;
        case Left:
            if(santa.x() > 0)
                santa.setX(santa.x() - 1);
            break;
        case Right:
            if(santa.x() < 180)
                santa.setX(santa.x() + 1);
            break;
    }
    update();
    checkHit();
    checkGameOver();
}

void gamemodel::newGame(int kidNumber)
{
    kidNumbers = kidNumber;
    kids.clear();
    elapsedTime = 0;
    santa.setX(0);
    santa.setY(100);

    kids.resize(kidNumber);
    for(int i = 0; i < kids.size(); ++i)
    {
        kids[i] = QPoint(QRandomGenerator::global()->bounded(20, 181), QRandomGenerator::global()->bounded(20, 181));
    }

    if(timer->isActive()) timer->stop();

    timer->start(1000);
    update();
}

void gamemodel::pause()
{
    if(timer->isActive())
    {
        timer->stop();
    }
}

void gamemodel::stepKid()
{
    for(int i = 0; i < kids.size(); ++i)
    {
        if(QRandomGenerator::global()->bounded(0,2) == 1) // vízszintesen
        {
            int x = QRandomGenerator::global()->bounded(3, 11);
            if(QRandomGenerator::global()->bounded(0,2) == 1) // balra
            {
                if(kids[i].x() - 3 >= 0)
                {
                    while (kids[i].x() - x < 0)
                    {
                        x = QRandomGenerator::global()->bounded(3, 11);
                    }
                    kids[i].setX(kids[i].x() - x);
                }
                else
                {
                    while (kids[i].x() + 20 + x > 180)
                    {
                        x = QRandomGenerator::global()->bounded(3, 11);
                    }
                    kids[i].setX(kids[i].x() + x);
                }
            }
            else // jobbra
            {
                if(kids[i].x() + 20 + 3 <= 180)
                {
                    while (kids[i].x() + 20 + x > 180)
                    {
                        x = QRandomGenerator::global()->bounded(3, 11);
                    }
                    kids[i].setX(kids[i].x() + x);
                }
                else
                {
                    while (kids[i].x() - x < 0)
                    {
                        x = QRandomGenerator::global()->bounded(3, 11);
                    }
                    kids[i].setX(kids[i].x() - x);
                }
            }
        }
        else // függőlegesen
        {
            int y = QRandomGenerator::global()->bounded(3, 11);
            if(QRandomGenerator::global()->bounded(0,2) == 1) // fel
            {
                if(kids[i].y() - 3 >= 0)
                {
                    while (kids[i].y() - y < 0)
                    {
                        y = QRandomGenerator::global()->bounded(3, 11);
                    }
                    kids[i].setY(kids[i].y() - y);
                }
                else
                {
                    while (kids[i].y() + 20 + y > 180)
                    {
                        y = QRandomGenerator::global()->bounded(3, 11);
                    }
                    kids[i].setY(kids[i].y() + y);
                }
            }
            else // le
            {
                if(kids[i].y() + 20 + 3 <= 180)
                {
                    while (kids[i].y() + 20 + y > 180)
                    {
                        y = QRandomGenerator::global()->bounded(3, 11);
                    }
                    kids[i].setY(kids[i].y() + y);
                }
                else
                {
                    while (kids[i].y() - y < 0)
                    {
                        y = QRandomGenerator::global()->bounded(3, 11);
                    }
                    kids[i].setY(kids[i].y() - y);
                }
            }
        }
    }
    ++elapsedTime;
    update();
    checkHit();
}

int gamemodel::getElapsedTime() const
{
    return elapsedTime;
}

int gamemodel::getKidNumbers() const
{
    return kidNumbers;
}

void gamemodel::setKidNumbers(int value)
{
    kidNumbers = value;
}

void gamemodel::checkHit()
{
    for(int i = 0; i < kids.size(); ++i)
    {
        if(!(santa.x() + 20 < kids[i].x() ||
           santa.x() > kids[i].x() + 20 ||
           santa.y() + 20 < kids[i].y() ||
           santa.y() > kids[i].y() + 20))
        {
            timer->stop();
            gameOver();
            newGame(kidNumbers);
            break;
        }
    }
}

void gamemodel::checkGameOver()
{
    if(santa.x() == 180)
    {
        timer->stop();
        gameWin();
    }
}
