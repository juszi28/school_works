#include "mainwindow.h"

mainwindow::mainwindow(QWidget *parent) : QWidget(parent)
{
    setBaseSize(550,700);
    setMinimumSize(550,700);
    setWindowTitle("Go");

    mainLayout = new QVBoxLayout(this);

    goWidget = new GoWidget(this);
    buttonLayout = new QHBoxLayout();
    scoreBoardLayout = new QHBoxLayout();

    white = new QLabel(tr("Fehér: "));
    white->setFont(QFont("Times New Roman", 24));
    black = new QLabel(tr("Fekete: "));
    black->setFont(QFont("Times New Roman", 24));
    whitePoints = new QLabel("0");
    whitePoints->setFont(QFont("Times New Roman", 24));
    blackPoints = new QLabel("0");
    blackPoints->setFont(QFont("Times New Roman", 24));

    saveGameButton = new QPushButton(tr("Mentés"));
    loadGameButton = new QPushButton(tr("Betöltés"));
    newGameButton = new QPushButton(tr("Új játék"));

    connect(newGameButton, SIGNAL(clicked()), goWidget, SLOT(newGame()));
    connect(saveGameButton, SIGNAL(clicked()), goWidget, SLOT(saveGame()));
    connect(loadGameButton, SIGNAL(clicked()), goWidget, SLOT(loadGame()));

    connect(goWidget, SIGNAL(model_pointChanged(int, GoModel::Player)), this, SLOT(model_pointChanged(int, GoModel::Player)));
    connect(goWidget, SIGNAL(model_pointReset()), this, SLOT(model_pointReset()));
    connect(goWidget, SIGNAL(clickNewGameButton()), this, SLOT(clickNewGameButton()));

    buttonLayout->addWidget(newGameButton);
    buttonLayout->addWidget(saveGameButton);
    buttonLayout->addWidget(loadGameButton);

    scoreBoardLayout->addWidget(white);
    scoreBoardLayout->addWidget(whitePoints);
    scoreBoardLayout->addWidget(black);
    scoreBoardLayout->addWidget(blackPoints);
    scoreBoardLayout->addSpacing(8);

    mainLayout->addWidget(goWidget);
    mainLayout->addLayout(scoreBoardLayout);
    mainLayout->addLayout(buttonLayout);

    setLayout(mainLayout);
}

void mainwindow::model_pointChanged(int point, GoModel::Player player)
{
    if(player == GoModel::Black)
    {
        int black = blackPoints->text().toInt();
        black += point;
        blackPoints->setText(QString::number(black));
    }
    else
    {
        int white = whitePoints->text().toInt();
        white += point;
        whitePoints->setText(QString::number(white));
    }
}

void mainwindow::model_pointReset()
{
    blackPoints->setText(QString::number(0));
    whitePoints->setText(QString::number(0));
}

void mainwindow::clickNewGameButton()
{
    newGameButton->click();
}
