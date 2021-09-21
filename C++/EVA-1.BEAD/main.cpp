#include "goatwolfcabbage.h"

#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    GoatWolfCabbage w;
    w.show();
    return a.exec();
}
