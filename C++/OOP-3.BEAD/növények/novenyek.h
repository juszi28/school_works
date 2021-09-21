#pragma once

#include <string>
#include <iostream>
#include "sugarzas.h"

class Noveny
{
protected: 
    std::string nev;
    int tapanyag;

    Noveny(const std::string& nev, int tapanyag) : nev(nev), tapanyag(tapanyag) {}
public:
    std::string NevEler() const {return nev;};
    int TapanyagEler() const {return tapanyag;}
    virtual bool ElEMeg() const = 0; 
    void TapanyagValtozas(int a) { tapanyag += a;}
    virtual void SugarzasFeldolgozas(Sugarzas* sugar) = 0;
    virtual void Igeny(Sugarzas* &sugar) = 0;
    virtual ~Noveny() {}
    // friend std::ostream &operator<<(std::ostream &os,const Noveny &a)
    // {
    //     return a.nev << "-Tapanyag: " << a.tapanyag << std::endl;
    // }
};

class Puffancs : public Noveny
{
public:
    Puffancs(const std::string& nev, int tapanyag) : Noveny(nev,tapanyag) {}
    bool ElEMeg() const override{ return tapanyag > 0 && tapanyag <= 10;}
    void Igeny(Sugarzas* &sugar) override{ sugar->AlfaIgenyNo(10);}
    void SugarzasFeldolgozas(Sugarzas* sugar) override{
        sugar = sugar->valtoztat(this);
    }
};

class Deltafa : public Noveny
{
public:
    Deltafa(const std::string& nev, int tapanyag) : Noveny(nev,tapanyag) {}
    bool ElEMeg() const override{ return tapanyag > 0;}
    void Igeny(Sugarzas* &sugar) override{
        if(tapanyag < 5)
            sugar->DeltaIgenyNo(4);
        else if(tapanyag >= 5 && tapanyag <= 10)
            sugar->DeltaIgenyNo(1);
        else
            sugar->DeltaIgenyNo(0);
    }
    void SugarzasFeldolgozas(Sugarzas* sugar) override{
        sugar = sugar->valtoztat(this);
    }
};

class Parabokor : public Noveny
{
public:
    Parabokor(const std::string& nev, int tapanyag) : Noveny(nev,tapanyag) {}
    bool ElEMeg() const override{ return tapanyag > 0;}
    void Igeny(Sugarzas* &sugar) override{ sugar->AlfaIgenyNo(0);}
    void SugarzasFeldolgozas(Sugarzas* sugar) override{
        sugar = sugar->valtoztat(this);
    }
};