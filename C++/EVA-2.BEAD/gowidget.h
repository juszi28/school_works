#ifndef GOWIDGET_H
#define GOWIDGET_H

#include "gomodel.h"
#include "loadgamewidget.h"
#include "newgamedialog.h"
#include "savegamewidget.h"

#include <QHBoxLayout>
#include <QPushButton>
#include <QWidget>

class GoWidget : public QWidget
{
    Q_OBJECT

public:
    GoWidget(QWidget *parent = nullptr);
    ~GoWidget();

    void setTableSize(int size);
    int getTableSize();
    void configureGame();
    void setTableGraphics();

public slots:
    void newGame();
    void saveGame();
    void loadGame();
    void model_fieldChanged(int, int, GoModel::Player);
    void gameOver();
    void gameWon(GoModel::Player player);
    void pointChanged(int point, GoModel::Player player);

signals:
    void model_pointChanged(int point, GoModel::Player player);
    void model_pointReset();
    void clickNewGameButton();

protected:
    void paintEvent(QPaintEvent *);
    void mousePressEvent(QMouseEvent* event);

private:
    QVector<QLineF> tableGraphics;

    int tableSize;
    int numberOfSteps;

    GoModel* model;
    newGameDialog* ngDialog;
    SaveGameWidget* saveGameWidget;
    LoadGameWidget* loadGameWidget;
};
#endif // GOWIDGET_H
