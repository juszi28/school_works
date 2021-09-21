package game.vehicles;

import game.utils.VehicleException;

public class Car extends Vehicle implements Comparable<Car> {

    private final int maxSpeed;
    private final int price;
    private boolean bought;

    public Car (double currentSpeed, int maxSpeed, int price) {
        super(currentSpeed);
        this.maxSpeed = maxSpeed;
        this.price = price;
        this.bought = false;
    }

    public int getPrice() {
        return this.price;
    }

    public boolean getBought() {
        return this.bought;
    }

    public void setBought() {
        this.bought = true;
    }

    @Override public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("Azonosito: " + this.id);
        sb.append("\t Max. sebesseg: " + this.maxSpeed);
        sb.append("\t Ar: " + this.price);
        return sb.toString(); 
    }

    @Override public void accelerate(double amount) {
        if(this.getCurrentSpeed() + amount < maxSpeed) {
            try{
                super.accelerateCurrentSpeed(amount);
            } catch(Exception e){}
        } 
    }

    @Override public int compareTo(Car that) {
        if (that == null) {
            throw new IllegalArgumentException();
        }
        if (that == this) {
            return 0;
        }

        if(this.maxSpeed > that.maxSpeed) {
            return 1;
        } else if (this.maxSpeed < that.maxSpeed) {
            return -1;
        } else {
            return Integer.compare(this.price, that.price);
        }
    }
}