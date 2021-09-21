#ifndef GAMEMODEL_H
#define GAMEMODEL_H

#include <QObject>
#include <QPoint>
#include <QTimer>
#include <QVector>

enum Direction { Up, Down, Left, Right };

class gamemodel : public QObject
{
    Q_OBJECT
public:
    explicit gamemodel(QObject *parent = nullptr);

    QPoint getSanta() const;
    QVector<QPoint> getKids() const;
    int getKidNumbers() const;
    int getElapsedTime() const;

    void setKidNumbers(int value);

    void stepSanta(Direction dir);
    void newGame(int kidNumber);
    void pause();

signals:
    void update();
    void gameOver();
    void gameWin();

public slots:
    void stepKid();

private:
    QPoint santa;
    QVector<QPoint> kids;
    int kidNumbers;
    QTimer* timer;
    int elapsedTime;

    void checkHit();
    void checkGameOver();
};

#endif // GAMEMODEL_H
