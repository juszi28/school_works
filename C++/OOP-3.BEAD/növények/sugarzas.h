#pragma once
#include <string>

class Puffancs;
class Deltafa;
class Parabokor;

class Sugarzas
{
protected:
    int AlfaIgeny = 0;
    int DeltaIgeny = 0;

public:
    virtual Sugarzas* valtoztat(Puffancs *p) = 0;
    virtual Sugarzas* valtoztat(Deltafa *p) = 0;
    virtual Sugarzas* valtoztat(Parabokor *p) = 0;
    virtual ~Sugarzas() {}
    void AlfaIgenyNo(int szam) {AlfaIgeny+=szam;}
    void DeltaIgenyNo(int szam) {DeltaIgeny +=szam;}
    void IgenyVissza() {AlfaIgeny = 0; DeltaIgeny = 0; }
    int AlfaIgenyEler() {return AlfaIgeny;}
    int DeltaIgenyEler() {return DeltaIgeny;}
    virtual std::string Szovegge() = 0;
}; 

class Alfa : public Sugarzas
{
private:
    Alfa(){}
    static Alfa* peldany;
public:
    static Alfa* peldanyosit();
    Sugarzas* valtoztat(Puffancs *p) override;
    Sugarzas* valtoztat(Deltafa *p) override;
    Sugarzas* valtoztat(Parabokor *p) override;
    std::string Szovegge() override{return "alfa";}
    static void torol();
};

class Delta : public Sugarzas
{
private:
    Delta(){}
    static Delta* peldany;
public:
    static Delta* peldanyosit();
    Sugarzas* valtoztat(Puffancs *p) override;
    Sugarzas* valtoztat(Deltafa *p) override;
    Sugarzas* valtoztat(Parabokor *p) override;
    std::string Szovegge() override{return "delta";}
    static void torol();
};

class NincsSugar : public Sugarzas
{
private:
    NincsSugar(){}
    static NincsSugar* peldany;
public:
    static NincsSugar* peldanyosit();
    Sugarzas* valtoztat(Puffancs *p) override;
    Sugarzas* valtoztat(Deltafa *p) override;
    Sugarzas* valtoztat(Parabokor *p) override;
    std::string Szovegge() override{ return "nincssugar";}
    static void torol();
};