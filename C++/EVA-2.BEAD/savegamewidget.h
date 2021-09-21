#ifndef SAVEGAMEWIDGET_H
#define SAVEGAMEWIDGET_H

#include <QDialog>
#include <QListWidget>
#include <QPushButton>

class SaveGameWidget : public QDialog
{
public:
    explicit SaveGameWidget(QWidget* parent = 0);
    void setGameList(QVector<QString> saveGameList); // a játékok betöltése
    int selectedGame() const { return listWidget->currentRow(); } // a kiválasztott játék lekérdezése

protected:
    QPushButton* okButton;
    QPushButton* cancelButton;
    QListWidget* listWidget;
};

#endif // SAVEGAMEWIDGET_H
