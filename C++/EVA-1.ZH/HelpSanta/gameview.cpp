#include "gameview.h"
#include "ui_gameview.h"

#include <QInputDialog>
#include <QMenu>
#include <QDebug>
#include <QMessageBox>
#include <QPainter>
#include <QString>

GameView::GameView(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::GameView)
{
    ui->setupUi(this);
    model = new gamemodel();

    QMenu* menubar = new QMenu("Settings");
    menubar->addAction("New game", this, SLOT(newGame()));
    menubar->addAction("Kids", this, SLOT(kidSettings()));
    ui->menubar->addMenu(menubar);

    connect(model, SIGNAL(update()), this, SLOT(update()));
    connect(model, SIGNAL(gameOver()), this, SLOT(gameOver()));
    connect(model, SIGNAL(gameWin()), this, SLOT(gameWin()));

    model->newGame(3);
}

GameView::~GameView()
{
    delete ui;
}

void GameView::paintEvent(QPaintEvent *event)
{
    QPainter painter(this);
    painter.setPen(QPen(Qt::red, 2)); // a tollat
    painter.setBrush(Qt::red); // kitöltő szín

    painter.drawRect(model->getSanta().x(), model->getSanta().y(), 20, 20);

    painter.setPen(QPen(Qt::black, 2)); // a tollat
    painter.setBrush(Qt::blue); // kitöltő szín

   for(int i = 0; i < model->getKids().size(); ++i)
   {
       painter.drawRect(model->getKids()[i].x(), model->getKids()[i].y(), 20, 20);
   }
}

void GameView::keyPressEvent(QKeyEvent *event)
{
    switch(event->key())
    {
        case Qt::Key_W:
            model->stepSanta(Up);
            break;
        case Qt::Key_S:
            model->stepSanta(Down);
            break;
        case Qt::Key_A:
            model->stepSanta(Left);
            break;
        case Qt::Key_D:
            model->stepSanta(Right);
            break;
    }
}

void GameView::gameOver()
{
    QMessageBox msg;
    msg.setText("Santa Claus collided with one of the kids in " + QString::number(model->getElapsedTime()) + " seconds");
    msg.exec();

    model->newGame(model->getKidNumbers());
}

void GameView::gameWin()
{
    QMessageBox msg;
    msg.setText("Santa Claus successfully crossed the city in " + QString::number(model->getElapsedTime()) + " seconds");
    msg.exec();

    model->newGame(model->getKidNumbers());
}

void GameView::kidSettings()
{
    model->pause();
    QInputDialog settings;

    QStringList comboBoxItems;
    comboBoxItems.push_back("3");
    comboBoxItems.push_back("4");
    comboBoxItems.push_back("5");
    comboBoxItems.push_back("6");
    comboBoxItems.push_back("7");
    comboBoxItems.push_back("8");
    comboBoxItems.push_back("9");
    comboBoxItems.push_back("10");
    comboBoxItems.push_back("11");
    comboBoxItems.push_back("12");
    comboBoxItems.push_back("13");
    comboBoxItems.push_back("14");
    comboBoxItems.push_back("15");
    comboBoxItems.push_back("16");
    comboBoxItems.push_back("17");
    comboBoxItems.push_back("18");
    comboBoxItems.push_back("19");
    comboBoxItems.push_back("20");
    settings.setOptions(QInputDialog::UseListViewForComboBoxItems);
    settings.setComboBoxItems(comboBoxItems);
    settings.open();

    if(settings.exec() == QDialog::Accepted)
    {
        model->setKidNumbers(settings.textValue().toInt());
        model->newGame(model->getKidNumbers());
        update();
    }
}

void GameView::newGame()
{
    model->newGame(model->getKidNumbers());
    update();
}

