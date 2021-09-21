#include <iostream>
#include <fstream>
#include <vector>
#include "novenyek.h"

void Populalas(const std::string &fajlnev, std::vector<Noveny*> &novenyek, std::vector<Sugarzas*> &napok, int &m)
{
    std::ifstream f(fajlnev);
    if(f.fail()) {std::cout << "Nem letezik ilyen fajl!" << std::endl;}

    int n; //novenyek szama
    f >> n; 
    novenyek.resize(n);
    for(int i = 0; i < n; ++i)
    {
        std::string nev;
        char faj;
        int tapanyag;
        f >> nev >> faj >> tapanyag;
        switch(faj)
        {
            case 'p': novenyek[i] = new Puffancs(nev, tapanyag); break;
            case 'd': novenyek[i] = new Deltafa(nev, tapanyag); break;
            case 'b': novenyek[i] = new Parabokor(nev, tapanyag); break;
        }
    } //napok szama
    f >> m;

    napok.push_back(NincsSugar::peldanyosit());
}

void Kiir(std::vector<Noveny*> &novenyek, int napszam, std::string sugar)
{
    std::cout << napszam <<".nap - " << sugar << std::endl << std::endl;
    for(unsigned int k = 0; k < novenyek.size(); ++k)
    {
        std::cout << novenyek[k]->NevEler() << " " << novenyek[k]->TapanyagEler() << std::endl;
    }
    std::cout << std::endl;
}

void Szimulacio(bool kiir, std::vector<Noveny*> &novenyek, std::vector<Sugarzas*> &napok, const int m)
{
    int c = 0;

    for(int i = 0; i < m && c != 2; ++i)
    {
        for (unsigned int j = 0; j < novenyek.size(); j++)
        {
            if(novenyek[j]->ElEMeg())
            {
                novenyek[j]->SugarzasFeldolgozas(napok[i]);
                if(novenyek[j]->ElEMeg()) novenyek[j]->Igeny(napok[i]);
            }
        }

        if(napok[i]->AlfaIgenyEler() > napok[i]->DeltaIgenyEler() + 3)
        {
            napok.push_back(Alfa::peldanyosit());
        }
        else if(napok[i]->AlfaIgenyEler() + 3 < napok[i]->DeltaIgenyEler())
        {
            napok.push_back(Delta::peldanyosit());
        }
        else
        {
            napok.push_back(NincsSugar::peldanyosit());
        }

        if(napok[i]->Szovegge() == "nincssugar") 
            c++;
        else 
            c = 0;

        if(kiir) 
        {
            Kiir(novenyek,i+1,napok[i]->Szovegge());
        }
        napok[i]->IgenyVissza();
    }
}

void NovenyTorles(std::vector<Noveny*> &novenyek)
{
    for(unsigned int i = 0; i < novenyek.size(); ++i)
    {
        delete novenyek[i];
    } 
}

void SugarTorles()
{
    Alfa::torol();
    Delta::torol();
    NincsSugar::torol();
}

#define NORMAL_MODE
#ifdef NORMAL_MODE
int main()
{
    int m;
    std::vector<Noveny*> novenyek;
    std::vector<Sugarzas*> napok;
    Populalas("in.txt", novenyek, napok,m);
    Kiir(novenyek, 0, "");
    Szimulacio(true, novenyek, napok,m);
    NovenyTorles(novenyek);
    SugarTorles();
}

#else
#define CATCH_CONFIG_MAIN
#include "catch.hpp"

TEST_CASE("1 noveny - puffancs - mindig alfa - tuleli(<10tapanyag)", "tf0.txt")
{
    int m;
    std::vector<Noveny*> novenyek;
    std::vector<Sugarzas*> napok;
    Populalas("tf0.txt", novenyek, napok, m);
    REQUIRE(novenyek.size() == 1);
    Szimulacio(false, novenyek,napok, m);
    REQUIRE(novenyek[0]->ElEMeg() == true);
    REQUIRE(napok[1]->Szovegge() == "alfa");
    REQUIRE(napok[2]->Szovegge() == "alfa");

    NovenyTorles(novenyek);
    SugarTorles();
}

TEST_CASE("1 noveny - puffancs - mindig alfa - nem eli tul(>10tapanyag)", "tf1.txt")
{
    int m;
    std::vector<Noveny*> novenyek;
    std::vector<Sugarzas*> napok;
    Populalas("tf1.txt", novenyek, napok, m);
    REQUIRE(novenyek.size() == 1);
    Szimulacio(false, novenyek,napok, m);
    REQUIRE(novenyek[0]->ElEMeg() == false);
    REQUIRE(napok[1]->Szovegge() == "alfa");
    REQUIRE(napok[2]->Szovegge() == "alfa");

    NovenyTorles(novenyek);
    SugarTorles();
}

TEST_CASE("1 noveny - deltafa - 2 nap delta - tuleli", "tf2.txt")
{
    int m;
    std::vector<Noveny*> novenyek;
    std::vector<Sugarzas*> napok;
    Populalas("tf2.txt", novenyek, napok,m);
    REQUIRE(novenyek.size() == 1);
    Szimulacio(false, novenyek,napok, m);
    REQUIRE(novenyek[0]->ElEMeg() == true);

    NovenyTorles(novenyek);
    SugarTorles();
}

TEST_CASE("1 noveny - parabokor - 2 nap(nincssugar) - tuleli", "tf3.txt")
{
    int m;
    std::vector<Noveny*> novenyek;
    std::vector<Sugarzas*> napok;
    Populalas("tf3.txt", novenyek, napok, m);
    REQUIRE(novenyek.size() == 1);
    Szimulacio(false, novenyek,napok, m);
    REQUIRE(novenyek[0]->ElEMeg() == true);

    NovenyTorles(novenyek);
    SugarTorles();
}

TEST_CASE("1 noveny - parabokor - 2 nap(nincssugar) - nem eli tul", "tf4.txt")
{
    int m;
    std::vector<Noveny*> novenyek;
    std::vector<Sugarzas*> napok;
    Populalas("tf4.txt", novenyek, napok,m);
    REQUIRE(novenyek.size() == 1);
    Szimulacio(false, novenyek,napok,m);
    REQUIRE(novenyek[0]->ElEMeg() == false);

    NovenyTorles(novenyek);
    SugarTorles();
}

TEST_CASE("2 noveny", "tf5-8.txt")
{
    SECTION("1puff,1delta - delta meghal(tf5)")
    {
        int m;
        std::vector<Noveny*> novenyek;
        std::vector<Sugarzas*> napok;
        Populalas("tf5.txt", novenyek, napok,m);
        REQUIRE(novenyek.size() == 2);
        Szimulacio(false, novenyek,napok,m);
        REQUIRE(novenyek[0]->ElEMeg() == true);
        REQUIRE(novenyek[1]->ElEMeg() == false);

        NovenyTorles(novenyek);
        SugarTorles();
    }

    SECTION("1 puff, 1 delta - mindenki el(tf6.txt)")
    {
        int m;
        std::vector<Noveny*> novenyek;
        std::vector<Sugarzas*> napok;
        Populalas("tf6.txt", novenyek, napok,m);
        REQUIRE(novenyek.size() == 2);
        Szimulacio(false, novenyek,napok,m);
        REQUIRE(novenyek[0]->ElEMeg() == true);
        REQUIRE(novenyek[1]->ElEMeg() == true);

        NovenyTorles(novenyek);
        SugarTorles();
    }

    SECTION("1 puff, 1 bokor - mindenki el (tf7.txt)")
    {
        int m;
        std::vector<Noveny*> novenyek;
        std::vector<Sugarzas*> napok;
        Populalas("tf7.txt", novenyek, napok,m);
        REQUIRE(novenyek.size() == 2);
        Szimulacio(false, novenyek,napok,m);
        REQUIRE(novenyek[0]->ElEMeg() == true);
        REQUIRE(novenyek[1]->ElEMeg() == true);

        NovenyTorles(novenyek);
        SugarTorles();
    }

    SECTION("1 bokor, 1 delta - mindenki el", "tf8.txt")
    {
        int m;
        std::vector<Noveny*> novenyek;
        std::vector<Sugarzas*> napok;
        Populalas("tf8.txt", novenyek, napok,m);
        REQUIRE(novenyek.size() == 2);
        Szimulacio(false, novenyek,napok,m);
        REQUIRE(novenyek[0]->ElEMeg() == true);
        REQUIRE(novenyek[1]->ElEMeg() == true);

        NovenyTorles(novenyek);
        SugarTorles();
    }
}

TEST_CASE("3 noveny", "tf9-13.txt")
{
    SECTION("1 puff, 1 bokor, 1 delta - mindenki el", "tf9.txt")
    {
        int m;
        std::vector<Noveny*> novenyek;
        std::vector<Sugarzas*> napok;
        Populalas("tf9.txt", novenyek, napok,m);
        REQUIRE(novenyek.size() == 3);
        Szimulacio(false, novenyek,napok,m);
        REQUIRE(novenyek[0]->ElEMeg() == true);
        REQUIRE(novenyek[1]->ElEMeg() == true);
        REQUIRE(novenyek[2]->ElEMeg() == true);

        NovenyTorles(novenyek);
        SugarTorles();
    }

    SECTION("1 puff, 1 bokor, 1 delta - delta meghal", "tf10.txt")
    {
        int m;
        std::vector<Noveny*> novenyek;
        std::vector<Sugarzas*> napok;
        Populalas("tf10.txt", novenyek, napok,m);
        REQUIRE(novenyek.size() == 3);
        Szimulacio(false, novenyek,napok,m);
        REQUIRE(novenyek[0]->ElEMeg() == true);
        REQUIRE(novenyek[1]->ElEMeg() == false);
        REQUIRE(novenyek[2]->ElEMeg() == true);

        NovenyTorles(novenyek);
        SugarTorles();
    }
    SECTION("1 bokor, 2 delta - mindenki el", "tf11.txt")
    {
        int m;
        std::vector<Noveny*> novenyek;
        std::vector<Sugarzas*> napok;
        Populalas("tf11.txt", novenyek, napok,m);
        REQUIRE(novenyek.size() == 3);
        Szimulacio(false, novenyek,napok,m);
        REQUIRE(novenyek[0]->ElEMeg() == true);
        REQUIRE(novenyek[1]->ElEMeg() == true);
        REQUIRE(novenyek[2]->ElEMeg() == true);

        NovenyTorles(novenyek);
        SugarTorles();
    }
    SECTION("2 bokor, 1 delta - delta meghal", "tf12.txt")
    {
        int m;
        std::vector<Noveny*> novenyek;
        std::vector<Sugarzas*> napok;
        Populalas("tf12.txt", novenyek, napok,m);
        REQUIRE(novenyek.size() == 3);
        Szimulacio(false, novenyek,napok,m);
        REQUIRE(novenyek[0]->ElEMeg() == true);
        REQUIRE(novenyek[1]->ElEMeg() == true);
        REQUIRE(novenyek[2]->ElEMeg() == false);

        NovenyTorles(novenyek);
        SugarTorles();
    }
    SECTION(" 2 bokor, 1 delta - mindenki meghal", "tf13.txt")
    {
        int m;
        std::vector<Noveny*> novenyek;
        std::vector<Sugarzas*> napok;
        Populalas("tf13.txt", novenyek, napok,m);
        REQUIRE(novenyek.size() == 3);
        Szimulacio(false, novenyek,napok,m);
        REQUIRE(novenyek[0]->ElEMeg() == false);
        REQUIRE(novenyek[1]->ElEMeg() == false);
        REQUIRE(novenyek[2]->ElEMeg() == false);

        NovenyTorles(novenyek);
        SugarTorles();
    }
}

TEST_CASE("szimulacio tesztje napszam alapjan", "tf14-16.txt")
{
    SECTION("a szimulacio megall az elso ket nap utan, mert 2 konzekvens napon nincssugar(tf14.txt)")
    {
        int m;
        std::vector<Noveny*> novenyek;
        std::vector<Sugarzas*> napok;
        Populalas("tf14.txt", novenyek, napok,m);
        REQUIRE(novenyek.size() == 4);
        Szimulacio(false, novenyek,napok,m);
        REQUIRE(novenyek[0]->ElEMeg() == true);
        REQUIRE(novenyek[1]->ElEMeg() == true);
        REQUIRE(novenyek[2]->ElEMeg() == true);
        REQUIRE(novenyek[3]->ElEMeg() == true);
        REQUIRE(napok.size() == 3);

        NovenyTorles(novenyek);
        SugarTorles();
    }
    
    SECTION("a szimulacio nem egybol all meg, de nem jut el a megadott napszamig, mert lesz 2 egymasutani napon nincssugar(tf15.txt)")
    {
        int m;
        std::vector<Noveny*> novenyek;
        std::vector<Sugarzas*> napok;
        Populalas("tf15.txt", novenyek, napok,m);
        REQUIRE(novenyek.size() == 3);
        Szimulacio(false, novenyek,napok,m);
        REQUIRE(novenyek[0]->ElEMeg() == true);
        REQUIRE(novenyek[1]->ElEMeg() == false);
        REQUIRE(novenyek[2]->ElEMeg() == false);
        REQUIRE(napok.size() == 5);
        REQUIRE((int)napok.size() < m);

        NovenyTorles(novenyek);
        SugarTorles();
    }

    SECTION("a szimulacio vegigfut a megadott idon, mert nem lesz ket olyan nap egymast koveto nap amikor nincssugar(tf16.txt)")
    {
        int m;
        std::vector<Noveny*> novenyek;
        std::vector<Sugarzas*> napok;
        Populalas("tf16.txt", novenyek, napok,m);
        REQUIRE(novenyek.size() == 3);
        Szimulacio(false, novenyek,napok,m);
        REQUIRE(novenyek[0]->ElEMeg() == true);
        REQUIRE(novenyek[1]->ElEMeg() == false);
        REQUIRE(novenyek[2]->ElEMeg() == true);
        REQUIRE((int)napok.size() == m+1);

        NovenyTorles(novenyek);
        SugarTorles();
    }
}

#endif