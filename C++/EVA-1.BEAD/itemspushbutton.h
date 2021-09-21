#ifndef ITEMSPUSHBUTTON_H
#define ITEMSPUSHBUTTON_H

#include <QPushButton>

class itemsPushButton : public QPushButton
{
public:
    enum Type { Wolf, Cabbage, Goat };
    itemsPushButton(QWidget* parent = nullptr,Type type = Wolf);

    Type getType() {return _type; }
private:
    Type _type;
};

#endif // ITEMSPUSHBUTTON_H
