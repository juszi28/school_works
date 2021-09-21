package game.vehicles;

import game.utils.VehicleException;

public abstract class Vehicle {
    protected static int counter = 0;
    private double currentSpeed;
    protected final int id;

    public Vehicle(double currentSpeed) {
        this.currentSpeed = currentSpeed;
        this.id = counter++;
    }

    public double getCurrentSpeed(){
        return currentSpeed;
    }

    public int getId(){
        return this.id;
    }

    protected final void accelerateCurrentSpeed(double speedChange) throws VehicleException {
        if(currentSpeed + speedChange < 0) {
            throw new VehicleException("Speed below zero!");
        } else {
            currentSpeed += speedChange;
        }
    }

    public abstract void accelerate(double amount);
}