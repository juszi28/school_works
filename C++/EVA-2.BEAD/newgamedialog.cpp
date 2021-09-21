#include "newgamedialog.h"

#include <QMessageBox>

newGameDialog::newGameDialog()
{
    setBaseSize(300,200);
    setWindowTitle(tr("Új játék"));
    tableSize = new QLabel("Játéktábla méret: ");
    roundNumber = new QLabel("Körök száma: ");

    tableSizes = new QComboBox();
    tableSizes->addItem("5x5");
    tableSizes->addItem("9x9");
    tableSizes->addItem("19x19");

    numberOfRounds = new QLineEdit;
    numberOfRounds->setValidator(new QRegExpValidator(QRegExp("[0-9]*"), numberOfRounds));

    okButton = new QPushButton("Ok");
    cancelButton = new QPushButton("Mégse");

    connect(okButton, SIGNAL(clicked()), this, SLOT(accept()));
    connect(cancelButton, SIGNAL(clicked()), this, SLOT(reject()));

    mainLayout = new QVBoxLayout(this);
    firstLayout = new QHBoxLayout(this);
    firstLayout->addWidget(tableSize);
    firstLayout->addWidget(tableSizes);

    secondLayout = new QHBoxLayout(this);
    secondLayout->addWidget(roundNumber);
    secondLayout->addWidget(numberOfRounds);

    thirdLayout = new QHBoxLayout(this);
    thirdLayout->addWidget(okButton);
    thirdLayout->addWidget(cancelButton);

    mainLayout->addLayout(firstLayout);
    mainLayout->addLayout(secondLayout);
    mainLayout->addLayout(thirdLayout);
    setLayout(mainLayout);
}

int newGameDialog::getTableSize()
{
    QString size = tableSizes->currentText();
    if(size[1].isDigit())
    {
        return size[0].digitValue()*10 + size[1].digitValue();
    }
    return size[0].digitValue();
}

int newGameDialog::getNumberOfRounds()
{
    return numberOfRounds->text().toInt();
}
