#ifndef GAMEVIEW_H
#define GAMEVIEW_H

#include "gamemodel.h"

#include <QKeyEvent>
#include <QMainWindow>
#include <QPaintEvent>

QT_BEGIN_NAMESPACE
namespace Ui { class GameView; }
QT_END_NAMESPACE

class GameView : public QMainWindow
{
    Q_OBJECT

public:
    GameView(QWidget *parent = nullptr);
    ~GameView();

    void paintEvent(QPaintEvent* event);
    void keyPressEvent(QKeyEvent* event);

public slots:
    void gameOver();
    void gameWin();
    void kidSettings();
    void newGame();

private:
    Ui::GameView *ui;
    gamemodel* model;
};
#endif // GAMEVIEW_H
