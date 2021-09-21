#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include "gowidget.h"

#include <QMainWindow>
#include <QPushButton>
#include <QVBoxLayout>

class mainwindow : public QWidget
{
    Q_OBJECT
public:
    explicit mainwindow(QWidget *parent = nullptr);

public slots:
    void model_pointChanged(int point, GoModel::Player player);
    void model_pointReset();
    void clickNewGameButton();

private:
    QPushButton* newGameButton;
    QPushButton* loadGameButton;
    QPushButton* saveGameButton;
    QLabel* white;
    QLabel* black;
    QLabel* whitePoints;
    QLabel* blackPoints;

    QVBoxLayout* mainLayout;
    QHBoxLayout* buttonLayout;
    QHBoxLayout* scoreBoardLayout;

    GoWidget* goWidget;
};

#endif // MAINWINDOW_H
