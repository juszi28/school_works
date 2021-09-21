#include "gowidget.h"

#include <QMouseEvent>
#include <QPainter>
#include <QDebug>
#include <QtMath>
#include <QMessageBox>

GoWidget::GoWidget(QWidget *parent)
    : QWidget(parent)
{
    setBaseSize(550,650);
    setMinimumSize(550,650);
    setWindowTitle("Go");

    //alaptábla 5x5-ös
    setTableSize(5);
    numberOfSteps = 20;

    setTableGraphics();
    model = new GoModel(this);

    connect(model, SIGNAL(fieldChanged(int, int, GoModel::Player)), this, SLOT(model_fieldChanged(int, int, GoModel::Player)));
    connect(model, SIGNAL(gameWon(GoModel::Player)), this, SLOT(gameWon(GoModel::Player)));
    connect(model, SIGNAL(gameOver()), this, SLOT(gameOver()));
    connect(model, SIGNAL(pointChanged(int, GoModel::Player)), this, SLOT(pointChanged(int, GoModel::Player)));

    model->newGame(tableSize, numberOfSteps);
}

GoWidget::~GoWidget()
{
}

void GoWidget::setTableSize(int size)
{
    tableSize = size;
}

int GoWidget::getTableSize()
{
    return tableSize;
}

void GoWidget::newGame()
{
    configureGame();

    for(int i = 0; i < tableGraphics.size(); ++i)
        tableGraphics.remove(i);

    tableGraphics.clear();

    setTableGraphics();

    model_pointReset();
}

void GoWidget::saveGame()
{
    saveGameWidget = new SaveGameWidget();
    saveGameWidget->setGameList(model->saveGameList());
    saveGameWidget->open();

    if(saveGameWidget->exec() == QDialog::Accepted)
    {
        if (model->saveGame(saveGameWidget->selectedGame()))
        {
            update();
            QMessageBox::information(this, tr("Go"), tr("Játék sikeresen mentve!"));
        }
        else
        {
            QMessageBox::warning(this, tr("Go"), tr("A játék mentése sikertelen!"));
        }
    }
}

void GoWidget::loadGame()
{
    loadGameWidget = new LoadGameWidget();
    loadGameWidget->setGameList(model->saveGameList());
    loadGameWidget->open();

    if(loadGameWidget->exec() == QDialog::Accepted)
    {
        if (model->loadGame(loadGameWidget->selectedGame()))
        {
            setTableSize(model->getTableSize());
            for(int i = 0; i < tableGraphics.size(); ++i)
                tableGraphics.remove(i);

            tableGraphics.clear();
            setTableGraphics();
            model_pointReset();
            model_pointChanged(model->getBlackPoints(), GoModel::Black);
            model_pointChanged(model->getWhitePoints(), GoModel::White);
            update();
            QMessageBox::information(this, tr("Go"), tr("Játék betöltve, következik: ") + ((model->getCurrentPlayer() == GoModel::Black) ? "Fekete" : "Fehér") + "!");
        }
        else
        {
            QMessageBox::warning(this, tr("Go"), tr("A játék betöltése sikertelen!"));
        }
    }
}

void GoWidget::model_fieldChanged(int, int, GoModel::Player)
{
    update();
}

void GoWidget::gameOver()
{
    QMessageBox::information(this, tr("Játék vége!"), tr("A játék döntetlennel végződött!"));
    clickNewGameButton();
}

void GoWidget::gameWon(GoModel::Player player)
{
    if(player == GoModel::Black)
        QMessageBox::information(this, tr("Játék vége!"), tr("A játékot a fekete játékos nyerte."));
    else
        QMessageBox::information(this, tr("Játék vége!"), tr("A játékot a fehér játékos nyerte."));

    clickNewGameButton();
}

void GoWidget::pointChanged(int point, GoModel::Player player)
{
    model_pointChanged(point, player);
}

void GoWidget::configureGame()
{
    ngDialog = new newGameDialog();

    if (ngDialog->exec() == QDialog::Accepted)
    {
        setTableSize(ngDialog->getTableSize());
        numberOfSteps = ngDialog->getNumberOfRounds() * 2;
        model->setTableSize(ngDialog->getTableSize());
        model->setNumberOfSteps(numberOfSteps);
        model->newGame(ngDialog->getTableSize(), numberOfSteps);
    }
}

void GoWidget::setTableGraphics()
{
    tableGraphics.append(QLineF(25.0,25.0,25.0,525.0));

    double widthDiff = (tableGraphics[0].y2() - tableGraphics[0].y1()) / tableSize;

    for(int i = 0; i < tableSize; ++i)
    {
        tableGraphics.append(QLineF(tableGraphics[i].x1() + widthDiff, tableGraphics[0].y1(), tableGraphics[i].x1() + widthDiff, tableGraphics[0].y2())); // függőleges vonalak
    }

    tableGraphics.append(QLineF(25.0, 25.0, 525.0, 25.0));

    int index = tableGraphics.size()-1;
    double heightDiff = (tableGraphics[tableSize+1].x2() - tableGraphics[tableSize+1].x1()) / tableSize;

    for(int i = 0; i < tableSize; ++i)
    {
        tableGraphics.append(QLineF(tableGraphics[tableSize+1].x1(), tableGraphics[index+i].y1() + heightDiff, tableGraphics[tableSize+1].x2(), tableGraphics[index+i].y2() + heightDiff)); //vízszintes vonalak
    }
}

void GoWidget::paintEvent(QPaintEvent *)
{
    QPainter painter(this); // rajzoló objektum
    painter.setRenderHint(QPainter::Antialiasing); // élsimítás használata
    painter.scale(width() / 550.0 , height() / 650.0 ); // skálázás

    painter.setPen(QPen(Qt::black,2)); // toll beállítása
    painter.setBrush(Qt::red); // ecset beállítása
    painter.drawLines(tableGraphics); // tábla kirajzolása

    for(int i = 0; i <= tableSize; i++)
    {
        for(int j = 0; j <= tableSize; j++)
        {
            painter.save(); // elmentjük a rajztulajdonságokat
            painter.translate(i * 500.0 / tableSize , j * 500.0 / tableSize); // elmozdítjuk a rajzpontot a megfelelő mezőre

            // mező kirajzolása a játékos függvényében
            switch (model->getField(i, j))
            {
                case GoModel::Black:
                    painter.setPen(QPen(Qt::black, 2)); // toll beállítása
                    painter.setBrush(Qt::black);
                    painter.drawEllipse(17, 17, 15, 15); // megfelelõ grafika kirajzolása
                    break;
                case GoModel::White:
                    painter.setPen(QPen(Qt::black, 2)); // toll beállítása
                    painter.setBrush(Qt::white);
                    painter.drawEllipse(17, 17, 15, 15);
                    break;
                default:
                    break;
            }
            painter.restore(); // visszatöltjük a korábbi állapotot
        }
    }
}

void GoWidget::mousePressEvent(QMouseEvent* event)
{
    double xScale = width() / 550.0;
    double yScale = height() / 650.0;
    int screenX = event->pos().x()/xScale - 25/xScale;
    int screenY = event->pos().y()/yScale - 25/yScale;
    double fieldSize = 500 / tableSize;
    int x = (screenX + fieldSize / 2)  * (tableSize + 1) / (500 + fieldSize);
    int y = (screenY + fieldSize / 2) * (tableSize + 1) / (500 + fieldSize);
    model->stepGame(x, y);
}


