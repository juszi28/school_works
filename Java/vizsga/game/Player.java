package game;

import java.util.ArrayList;
import java.util.Objects;
import game.vehicles.*;
import java.util.Collections;
import game.utils.*;
import java.util.List;

public class Player {
    private String name;
    private String IPAdd;
    private int money;
    public ArrayList<Car> vehicles;

    public Player(String name, String IPAdd, int money) {
        if (name != null) {
            this.name = name;
        } else throw new IllegalArgumentException();
        
        if (IPAdd != null && IPAdd.length()  > 0 && !IPAdd.contains(" ") && !IPAdd.contains("\t") && !IPAdd.contains("\n")) {
            this.IPAdd = IPAdd;
        } else throw new IllegalArgumentException();

        if (money >= 0) {
            this.money = money;
        } else throw new IllegalArgumentException();

        vehicles = new ArrayList<>();
    }

    public String getName() {
        return this.name;
    }

    public String getIPAdd() {
        return this.IPAdd;
    }

    public int getMoney() {
        return this.money;
    }

    public void buyCar(Car c) throws VehicleException {
        if (this.money > c.getPrice() && c.getBought() == false) {
            this.money -= c.getPrice();
            vehicles.add(c);
            c.setBought();
        } else {
            throw new VehicleException("You don't have enough money or this car has been already bought!");
        }
    }

    public ArrayList<Car> getSortedCars() {
        ArrayList<Car> sortedCars = new ArrayList<Car>();
        for(Car c : this.vehicles)
            sortedCars.add(c);
        Collections.sort(sortedCars);
        return sortedCars;
    }


    @Override public String toString() {
        return this.name + " " + this.IPAdd + " " + this.money;
    }

    @Override public boolean equals(Object that) {
        if (that == null) return false;
        if (that == this) return true;

        if(that instanceof Player) {
            Player thatPlayer = (Player)that;
            return this.name == thatPlayer.name && this.money == thatPlayer.money && this.vehicles.equals(thatPlayer.vehicles);
        } else return false;
    }

    @Override public int hashCode() {
        return Objects.hash(this.name, this.money, this.vehicles);
    }
}