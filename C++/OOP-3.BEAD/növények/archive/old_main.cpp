#include <iostream>
#include <fstream>
#include <vector>
#include "../novenyek.h"

int main()
{
    std::ifstream f("in3.txt");
    if(f.fail()) {std::cout << "Nem letezik ilyen fajl!" << std::endl;}

    int n; //novenyek szama
    f >> n; 
    std::vector<Noveny*> novenyek(n);
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
    }

    std::cout << "0.nap:\n";
    for(int i = 0; i < n; ++i)
    {
        std::cout << novenyek[i]->NevEler() << " " << novenyek[i]->TapanyagEler() << std::endl;
    }


    int m; //napok szama
    f >> m;

    std::vector<Sugarzas*> napok;
    napok.push_back(NincsSugar::peldanyosit());
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

        if(napok[i]->Szovegge() == "nincssugar") c++;
        else c = 0;

        std::cout << i+1 <<".nap - " << napok[i]->Szovegge() << std::endl;
        for(int k = 0; k < n; ++k)
        {
            std::cout << novenyek[k]->NevEler() << " " << novenyek[k]->TapanyagEler() << std::endl;
        }
        napok[i]->IgenyVissza();
    }

    for(unsigned int i = 0; i < novenyek.size(); ++i)
    {
        delete novenyek[i];
    }   

    Alfa::torol();
    Delta::torol();
    NincsSugar::torol();
}