#ifndef NEWGAMEDIALOG_H
#define NEWGAMEDIALOG_H

#include <QComboBox>
#include <QDialog>
#include <QLabel>
#include <QLineEdit>
#include <QPushButton>
#include <QVBoxLayout>

class newGameDialog : public QDialog
{
public:
    newGameDialog();

    int getTableSize();
    int getNumberOfRounds();

private:
    QLabel* tableSize;
    QLabel* roundNumber;
    QComboBox* tableSizes;
    QLineEdit* numberOfRounds;
    QPushButton* okButton;
    QPushButton* cancelButton;

    QVBoxLayout* mainLayout;
    QHBoxLayout* firstLayout;
    QHBoxLayout* secondLayout;
    QHBoxLayout* thirdLayout;
};

#endif // NEWGAMEDIALOG_H
