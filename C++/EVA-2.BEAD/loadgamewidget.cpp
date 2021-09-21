#include "loadgamewidget.h"

#include <QMessageBox>

LoadGameWidget::LoadGameWidget(QWidget *parent) :
    SaveGameWidget(parent)
{
    setWindowTitle("Tic-Tac-Toe - Játék betöltése");

    // ellenőrzést is végzünnk az OK gomb lenyomására
    disconnect(okButton, SIGNAL(clicked()), this, SLOT(accept()));
    connect(okButton, SIGNAL(clicked()), this, SLOT(okButton_Clicked()));
}

void LoadGameWidget::okButton_Clicked()
{
    if (listWidget->currentItem()->text() == "üres")
    {
        // ha üres mezőt választott, akkor nem engedjük tovább
        QMessageBox::warning(this, tr("Go"), tr("Nincs játék kiválasztva!"));
        return;
    }

    accept(); // különben elfogadjuk a dialógust
}
