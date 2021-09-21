#include "sugarzas.h"
#include "novenyek.h"

//Alfa rész

Alfa* Alfa::peldany = nullptr;
Alfa* Alfa::peldanyosit()
{
    if(peldany == nullptr)
        peldany = new Alfa();
    return peldany;
}

Sugarzas* Alfa::valtoztat(Puffancs *p)
{
    p->TapanyagValtozas(2);
    return this;
}

Sugarzas* Alfa::valtoztat(Deltafa *p)
{
    p->TapanyagValtozas(-3);
    return this;
}

Sugarzas* Alfa::valtoztat(Parabokor *p)
{
    p->TapanyagValtozas(1);
    return this;
}

void Alfa::torol()
{
    if(peldany != nullptr)
        delete peldany;
    peldany = nullptr;
}

//Delta rész

Delta* Delta::peldany = nullptr;
Delta* Delta::peldanyosit()
{
    if(peldany == nullptr)
        peldany = new Delta();
    return peldany;
}

Sugarzas* Delta::valtoztat(Puffancs *p)
{
    p->TapanyagValtozas(-2);
    return this;
}

Sugarzas* Delta::valtoztat(Deltafa *p)
{
    p->TapanyagValtozas(4);
    return this;
}

Sugarzas* Delta::valtoztat(Parabokor *p)
{
    p->TapanyagValtozas(1);
    return this;
}

void Delta::torol()
{
    if(peldany != nullptr)
        delete peldany;
    peldany = nullptr;
}

//NincsSugar rész

NincsSugar* NincsSugar::peldany = nullptr;
NincsSugar* NincsSugar::peldanyosit()
{
    if(peldany == nullptr)
        peldany = new NincsSugar();
    return peldany;
}

Sugarzas* NincsSugar::valtoztat(Puffancs *p)
{
    p->TapanyagValtozas(-1);
    return this;
}

Sugarzas* NincsSugar::valtoztat(Deltafa *p)
{
    p->TapanyagValtozas(-1);
    return this;
}

Sugarzas* NincsSugar::valtoztat(Parabokor *p)
{
    p->TapanyagValtozas(-1);
    return this;
}

void NincsSugar::torol()
{
    if(peldany != nullptr)
        delete peldany;
    peldany = nullptr;
}