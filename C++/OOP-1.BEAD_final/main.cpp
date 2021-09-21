#include "setofints.hpp"
#include <iostream>
#include <vector>

//#define NORMAL_MODE
#ifdef NORMAL_MODE

class Menu{
public:
    Menu(){};
    void Run();
private:
    SetOfInts a;

    void MenuWrite();
    void Add();
    void Del();
    void Write();
    void Empty();
    void Max();
};

void Menu::Run()
{
    int n = 0;
    do{
        MenuWrite();
        std::cout << std::endl << ">>>>" ; std::cin >> n;
        switch(n){
            case 1: Add();
                    break;
            case 2: Del();
                     break;
            case 3: Write();
                     break;
            case 4: Empty();
                     break;
            case 5: Max();
                     break;
        }
    }while(n!=0);
}

void Menu::Add()
{
    int num;
    std::cout << "Give a number: "; std::cin >> num;
    try{
        a.Add(num);
        std::cout << a << std::endl;
    } catch(SetOfInts::Exceptions ex){
        if(ex == SetOfInts::CONTAINS)
            std::cout << "The set already contains " << num << "." << std::endl;
        else std::cout << "Unhandled exception!" << std::endl;
    }
}

void Menu::Del()
{
    int num;
    std::cout << "Give a number, you want to delete: "; std::cin >> num;
    try{
        a.Remove(num);
        std::cout << a << std::endl;
    } catch(SetOfInts::Exceptions ex){
        if(ex == SetOfInts::NOTIN)
            std::cout << "The set does not contain this value!" << std::endl;
        else std::cout << "Unhandled exception!" << std::endl;
    }
}

void Menu::Write()
{
    std::cout << a << std::endl;
}

void Menu::Empty()
{
    a.IsEmpty() ? (std::cout << "The set is empty"<<std::endl) : (std::cout << "The set has elements" << std::endl); 
}

void Menu::Max()
{
    try{
        a.MaxValue();
        std::cout << "The highest value in the set: " << a.MaxValue() << std::endl;
    } catch(SetOfInts::Exceptions ex){
        if(ex == SetOfInts::EMPTY)
            std::cout << "The set is empty, it does not have a maximum value!" << std::endl;
        else std::cout << "Unhandled exception!" << std::endl;
    }
}

void Menu::MenuWrite()
{
     std::cout << std::endl << std::endl;
     std::cout << " 0. - Quit" << std::endl;
     std::cout << " 1. - Add an element to the set" << std::endl;
     std::cout << " 2. - Delete an element of the set" << std::endl;
     std::cout << " 3. - Write the set" << std::endl;
     std::cout << " 4. - Check if the set is empty" << std::endl;
     std::cout << " 5. - Maximum value in the set" << std::endl;
}

int main()
{
    Menu m;
    m.Run();
}

#else
#define CATCH_CONFIG_MAIN
#include "catch.hpp"
#include <fstream>

TEST_CASE("create and upload from file"){
    std::ifstream f ("input1.txt");
    SetOfInts a;

    int temp;
    while(f >> temp)
    {
        a.Add(temp);
    }
    REQUIRE(!a.IsEmpty());
    REQUIRE(a.MaxValue() == 11);
}

TEST_CASE("add"){
    SetOfInts a;
    REQUIRE(a.IsEmpty());
    a.Add(1);
    REQUIRE(!a.IsEmpty());
    a.Add(2);
    a.Add(3);
    REQUIRE(a.MaxValue() == 3);
}

TEST_CASE("remove"){
    std::ifstream f ("input1.txt");
    SetOfInts a;

    int temp;
    while(f >> temp)
    {
        a.Add(temp);
    }
    REQUIRE(!a.IsEmpty());
    REQUIRE(a.MaxValue() == 11);
    a.Remove(11);
    REQUIRE(a.MaxValue() == 9);
    a.Remove(9);
    REQUIRE(a.MaxValue() == 8);
    a.Remove(8);
}

TEST_CASE("writing out to a file", "output.txt"){
    const std::string fileName = "output.txt";
    std::ifstream f ("input1.txt");
    SetOfInts a;

    int temp;
    while(f >> temp)
    {
        a.Add(temp);
    }
    REQUIRE(a.MaxValue() == 11);

    std::ofstream out;
    out.open(fileName);
    out << a << std::endl;
    out << a.MaxValue() << std::endl;
    out.close();
}

TEST_CASE("exceptions"){
    std::ifstream f ("input1.txt");
    SetOfInts a;

    try{
        a.MaxValue();
    }
    catch(SetOfInts::Exceptions ex){
        if(SetOfInts::EMPTY){};
    }

    int temp;
    while(f >> temp)
    {
        a.Add(temp);
    }
    
    try{
        a.Add(3);
    }
    catch(SetOfInts::Exceptions ex){
        if(SetOfInts::CONTAINS){} ;
    }
    try{
        a.Remove(100);
    }
    catch(SetOfInts::Exceptions ex){
        if(SetOfInts::NOTIN) {};
    }
}

#endif