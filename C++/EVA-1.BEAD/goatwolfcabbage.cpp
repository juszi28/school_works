#include "goatwolfcabbage.h"
#include "ui_goatwolfcabbage.h"

#include <QMessageBox>

GoatWolfCabbage::GoatWolfCabbage(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::GoatWolfCabbage)
{
    ui->setupUi(this);

    wolfPB = new itemsPushButton(this, itemsPushButton::Wolf);
    wolfPB->setText("Wolf");
    wolfPB->setGeometry(itemsXPosition,160,80,30);

    goatPB = new itemsPushButton(this, itemsPushButton::Goat);
    goatPB->setText("Goat");
    goatPB->setGeometry(itemsXPosition,200,80,30);

    cabbagePB = new itemsPushButton(this, itemsPushButton::Cabbage);
    cabbagePB->setText("Cabbage");
    cabbagePB->setGeometry(itemsXPosition,240,80,30);

    direction = Left;

    connect(cabbagePB, SIGNAL(clicked()), this, SLOT(itemsClicked()));
    connect(wolfPB, SIGNAL(clicked()), this, SLOT(itemsClicked()));
    connect(goatPB, SIGNAL(clicked()), this, SLOT(itemsClicked()));
    connect(ui->boatPushButton, SIGNAL(clicked()), this, SLOT(boatClicked()));

    moveCount = 0;

    boatXPositions = new int[2]{ 260, 420 };

    landLeftButtons.append(cabbagePB);
    landLeftButtons.append(wolfPB);
    landLeftButtons.append(goatPB);
    itemInBoat = nullptr;
}

GoatWolfCabbage::~GoatWolfCabbage()
{
    delete ui;
}

void GoatWolfCabbage::itemsClicked()
{
    itemsPushButton* senderButton = dynamic_cast <itemsPushButton*> (QObject::sender());

    if(itemsXPosition == senderButton->x() || boatXPositions[1]+100 == senderButton->x() )
    {
        moveToBoat(senderButton, direction);
    }
    else
    {
        moveToLand(senderButton, direction);
    }
}

void GoatWolfCabbage::moveToBoat(itemsPushButton* senderButton, Direction direction)
{
    if(direction == Left)
    {
        for(int i = 0; i < landLeftButtons.size(); ++i)
        {
            if(landLeftButtons[i]->text() == senderButton->text())
            {
                landLeftButtons.remove(i);
            }
        }

        itemInBoat = new itemsPushButton(this);
        itemInBoat = senderButton;
        senderButton->setGeometry(boatXPositions[0], boatYPosition-30, senderButton->width(), senderButton->height());

        for(int i = 0; i < landLeftButtons.size(); ++i)
        {
            landLeftButtons[i]->setEnabled(false);
        }

        ui->boatPushButton->setEnabled(true);
    }

    else
    {
        for(int i = 0; i < landRightButtons.size(); ++i)
            if(landRightButtons[i]->text() == senderButton->text())
                landRightButtons.remove(i);
        itemInBoat = new itemsPushButton(this);
        itemInBoat = senderButton;
        senderButton->setGeometry(boatXPositions[1], boatYPosition-30, senderButton->width(), senderButton->height());

        for(int i = 0; i < landRightButtons.size(); ++i)
        {
            landRightButtons[i]->setEnabled(false);
        }

        ui->boatPushButton->setEnabled(true);
    }
}

void GoatWolfCabbage::moveToLand(itemsPushButton *senderButton, GoatWolfCabbage::Direction direction)
{
    if(direction == Left)
    {
        switch(senderButton->getType())
        {
            case itemsPushButton::Wolf:
                senderButton->setGeometry(itemsXPosition, 160, senderButton->width(), senderButton->height());
                landLeftButtons.append(senderButton);
                break;
            case itemsPushButton::Cabbage:
                senderButton->setGeometry(itemsXPosition, 240, senderButton->width(), senderButton->height());
                landLeftButtons.append(senderButton);
                break;
            case itemsPushButton::Goat:
                senderButton->setGeometry(itemsXPosition, 200, senderButton->width(), senderButton->height());
                landLeftButtons.append(senderButton);
                break;
        }
    }

    else
    {
        switch(senderButton->getType())
        {
            case itemsPushButton::Wolf:
                senderButton->setGeometry(boatXPositions[1]+100, 160, senderButton->width(), senderButton->height());
                landRightButtons.append(senderButton);
                break;
            case itemsPushButton::Cabbage:
                senderButton->setGeometry(boatXPositions[1]+100, 240, senderButton->width(), senderButton->height());
                landRightButtons.append(senderButton);
                break;
            case itemsPushButton::Goat:
                senderButton->setGeometry(boatXPositions[1]+100, 200, senderButton->width(), senderButton->height());
                landRightButtons.append(senderButton);
                break;
        }
    }
    itemInBoat = new itemsPushButton(this);
    ui->boatPushButton->setEnabled(true);
    gameOver();
}

void GoatWolfCabbage::boatClicked()
{
    if(direction == Left)
    {
        moveOnWater(Right);
        ++moveCount;
        checkLand();
    }
    else
    {
        moveOnWater(Left);
        ++moveCount;
        checkLand();
    }
}

void GoatWolfCabbage::moveOnWater(Direction direction)
{
    if(direction == Right)
    {
        ui->boatPushButton->setGeometry(boatXPositions[1], boatYPosition, ui->boatPushButton->width(), ui->boatPushButton->height());
        if(itemInBoat != nullptr) itemInBoat->setGeometry(boatXPositions[1], boatYPosition-30, itemInBoat->width(), itemInBoat->height());
        for(int i = 0; i < landRightButtons.size(); ++i)
            landRightButtons[i]->setEnabled(true);
        for(int i = 0; i < landLeftButtons.size(); ++i)
            landLeftButtons[i]->setEnabled(false);
    }
    else
    {
        ui->boatPushButton->setGeometry(boatXPositions[0], boatYPosition, ui->boatPushButton->width(), ui->boatPushButton->height());
        if(itemInBoat != nullptr) itemInBoat->setGeometry(boatXPositions[0], boatYPosition-30, itemInBoat->width(), itemInBoat->height());
        for(int i = 0; i < landLeftButtons.size(); ++i)
            landLeftButtons[i]->setEnabled(true);
        for(int i = 0; i < landRightButtons.size(); ++i)
            landRightButtons[i]->setEnabled(false);
    }
}

void GoatWolfCabbage::checkLand()
{
    if(direction == Left) // ha jobbra mentünk, checkeljük a bal oldalt
    {
        if(landLeftButtons.size() == 2)
        {
            if((landLeftButtons[0]->getType() == itemsPushButton::Goat && landLeftButtons[1]->getType() == itemsPushButton::Wolf) ||
                (landLeftButtons[0]->getType() == itemsPushButton::Wolf && landLeftButtons[1]->getType() == itemsPushButton::Goat))
            {
                QMessageBox::information(this, "Game over", "The wolf has eaten the goat!");
                newGame();
            }
            else if((landLeftButtons[0]->getType() == itemsPushButton::Goat && landLeftButtons[1]->getType() == itemsPushButton::Cabbage) ||
                    (landLeftButtons[0]->getType() == itemsPushButton::Cabbage && landLeftButtons[1]->getType() == itemsPushButton::Goat))
            {
                QMessageBox::information(this, "Game over", "The goat has eaten the cabbage!");
                newGame();
            }
            else
            {
                ui->boatPushButton->setEnabled(true);
                direction = Right;
                gameOver();
            }
        }
        else if(landLeftButtons.size() == 3)
        {
            QMessageBox::information(this, "Game over", "The goat has eaten the cabbage first and then the wolf has eaten the goat!");
            newGame();
        }
        else
        {
            direction = Right;
        }
    }
    else
    {
        if(landRightButtons.size() > 1)
        {
            if((landRightButtons[0]->getType() == itemsPushButton::Goat && landRightButtons[1]->getType() == itemsPushButton::Wolf) ||
                (landRightButtons[0]->getType() == itemsPushButton::Wolf && landRightButtons[1]->getType() == itemsPushButton::Goat))
            {
                QMessageBox::information(this, "Game over", "The wolf has eaten the goat!");
                newGame();
            }
            else if((landRightButtons[0]->getType() == itemsPushButton::Goat && landRightButtons[1]->getType() == itemsPushButton::Cabbage) ||
                    (landRightButtons[0]->getType() == itemsPushButton::Cabbage && landRightButtons[1]->getType() == itemsPushButton::Goat))
            {
                QMessageBox::information(this, "Game over", "The goat has eaten the cabbage!");
                newGame();
            }
            else
            {
                ui->boatPushButton->setEnabled(true);
                direction = Left;
                gameOver();
            }
        }
        else
        {
            direction = Left;
        }
    }
}

void GoatWolfCabbage::newGame()
{
    direction = Left;

    landLeftButtons.clear();
    landRightButtons.clear();

    itemInBoat = new itemsPushButton(this);
    itemInBoat = NULL;

    wolfPB->setGeometry(itemsXPosition,160,80,30);

    goatPB->setGeometry(itemsXPosition,200,80,30);

    cabbagePB->setGeometry(itemsXPosition,240,80,30);

    moveCount = 0;
    ui->boatPushButton->setGeometry(boatXPositions[0], boatYPosition, ui->boatPushButton->width(), ui->boatPushButton->height());

    landLeftButtons.append(cabbagePB);
    landLeftButtons.append(wolfPB);
    landLeftButtons.append(goatPB);

    for(int i = 0; i < landLeftButtons.size(); ++i)
        landLeftButtons[i]->setEnabled(true);
}

void GoatWolfCabbage::gameOver()
{
    if(landLeftButtons.size() == 0 && landRightButtons.size() == 3)
    {
        QMessageBox::information(this, "Success", "You have successfully transferred all the items with " + QString::number(moveCount) + " steps!");
        newGame();
    }
}



