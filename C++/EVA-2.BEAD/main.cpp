#include "gowidget.h"
#include "mainwindow.h"

#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);

    mainwindow mw;
    mw.show();

    return a.exec();
}
