package main;

import java.io.*;
import game.Player;
import game.vehicles.*;
import game.utils.*;
import java.util.*;

public class Main {

    public static Player loadPlayerFromFile(String playerName){
        File input = new File("users/" + playerName + ".txt");

        try (BufferedReader bf = new BufferedReader(new FileReader(input))){
            String line = bf.readLine();
            String[] data = line.split(" ");

            try{
                return new Player(playerName, data[0], Integer.parseInt(data[1]));
            } catch (NumberFormatException e) {
                return new Player(playerName, data[0], 0);
            }
        } catch (IOException e) {
            System.out.println("IO error occured: " + e.getMessage());
        }

        return null;
    }

    public static void main(String[] args) {
        Player Daniel = loadPlayerFromFile("Daniel");
        Player Peter = loadPlayerFromFile("Peter");
        Player Richard = loadPlayerFromFile("Richard");
        Player Tamas = loadPlayerFromFile("Tamas");
        Player Zorror = loadPlayerFromFile("Zorror");
        
        Car c1 = new Car(30, 120, 300);
        Car c2 = new Car(50, 150, 500);
        Car c3 = new Car(100, 400, 7000);
        Car c4 = new Car(40, 200, 1300);
        Car c5 = new Car(40, 200, 1500);

        try{
            Daniel.buyCar(c4);
        } catch (Exception e){
            System.out.println(e.getMessage());
        }
        try{
            Daniel.buyCar(c5);
        } catch (Exception e){
            System.out.println(e.getMessage());
        }

        try{
            Daniel.buyCar(c1);
        } catch (Exception e){
            System.out.println(e.getMessage());
        }

        System.out.println(Daniel);
        for(Car c : Daniel.vehicles) {
            System.out.println(c);
        }
        System.out.println(); 

        ArrayList<Car> sortedCars = Daniel.getSortedCars();
        for(Car c : sortedCars) {
            System.out.println(c);
        }
    }
}