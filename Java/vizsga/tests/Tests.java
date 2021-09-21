package tests;

import game.Player;
import game.vehicles.*;
import game.utils.*;

import static org.junit.Assert.*;
import org.junit.Test;
import org.junit.Before;
import org.junit.After;

public class Tests {

    @Test(expected = IllegalArgumentException.class)
    public void playerConstruct_nullName() {
        Player p = new Player(null, "192.123.144.33", 5);
    }

    @Test(expected = IllegalArgumentException.class)
    public void playerConstruct_negativeMoney() {
        Player p = new Player("Andras", "192.123.144.33", -5);
    }

    @Test(expected = IllegalArgumentException.class)
    public void playerConstruct_spaceInAddress() {
        Player p = new Player("Andras", "192.12 3.144.33", 5);
    }

    @Test
    public void playerConstructs() {
        Player p = new Player("Andras", "192.123.144.33", 5);

        assertEquals(5, p.getMoney());
    }

    @Test
    public void carAccelerate_negative(){
        Car c = new Car(40.0, 200, 500);
        c.accelerate(-20.0);

        assertEquals(20.0, c.getCurrentSpeed(), 0.001);
    }

    @Test
    public void carAccelerate_positive(){
        Car c = new Car(40.0, 200, 500);
        c.accelerate(20.0);

        assertEquals(60.0, c.getCurrentSpeed(), 0.001);
    }

    @Test
    public void carAccelerate_over(){
        Car c = new Car(190.0, 200, 500);
        c.accelerate(20.0);

        assertEquals(190.0, c.getCurrentSpeed(), 0.001);
    }

    @Test
    public void carAccelerate_exception(){
        Car c = new Car(40.0, 200, 500);
        c.accelerate(-50);
    }

    @Test
    public void twoPlayer_equalsWDifferentIP(){
        Player p1 = new Player("Andras", "192.158.65.54", 300);
        Player p2 = new Player("Andras", "157.65.23.100", 300);

        assertEquals(true, p1.equals(p2)); 
    }

    @Test
    public void twoPlayer_equalsWDifferentIPWCars(){
        Player p1 = new Player("Andras", "192.158.65.54", 300);
        Player p2 = new Player("Andras", "157.65.23.100", 300);

        Car c = new Car(40.0, 200, 500);
        Car c2 = new Car(20.0, 150, 300);

        p1.vehicles.add(c);
        p1.vehicles.add(c2);
        p2.vehicles.add(c);
        p2.vehicles.add(c2);

        assertEquals(true, p1.equals(p2)); 
    }

    @Test
    public void twoPlayer_notEqualsWDifferentIP(){
        Player p1 = new Player("Andras", "192.158.65.54", 300);
        Player p2 = new Player("Balazs", "157.65.23.100", 300);

        assertEquals(false, p1.equals(p2)); 
    }

    @Test
    public void twoPlayer_notEqualsWDifferentIPWCars(){
        Player p1 = new Player("Andras", "192.158.65.54", 300);
        Player p2 = new Player("Balazs", "157.65.23.100", 300);

        Car c = new Car(40.0, 200, 500);
        Car c2 = new Car(20.0, 150, 300);

        p1.vehicles.add(c);
        p1.vehicles.add(c2);
        p2.vehicles.add(c);
        p2.vehicles.add(c2);

        assertEquals(false, p1.equals(p2)); 
    }

    @Test
    public void twoPlayer_notEqualsWDifferentMoney(){
        Player p1 = new Player("Andras", "192.158.65.54", 250);
        Player p2 = new Player("Andras", "157.65.23.100", 300);

        Car c = new Car(40.0, 200, 500);
        Car c2 = new Car(20.0, 150, 300);

        p1.vehicles.add(c);
        p1.vehicles.add(c2);
        p2.vehicles.add(c);
        p2.vehicles.add(c2);

        assertEquals(false, p1.equals(p2)); 
    }

    @Test
    public void twoPlayer_notEqualsWDifferentMoneyWCars(){
        Player p1 = new Player("Andras", "192.158.65.54", 250);
        Player p2 = new Player("Andras", "157.65.23.100", 300);

        Car c = new Car(40.0, 200, 500);
        Car c2 = new Car(20.0, 150, 300);

        p1.vehicles.add(c);
        p1.vehicles.add(c2);
        p2.vehicles.add(c);
        p2.vehicles.add(c2);

        assertEquals(false, p1.equals(p2)); 
    }

    @Test
    public void twoPlayer_sameHashCode() {
        Player p1 = new Player("Andras", "192.158.65.54", 300);
        Player p2 = new Player("Andras", "157.65.23.100", 300);

        assertEquals(true, p1.hashCode() == p2.hashCode());
    }

    @Test
    public void twoPlayer_sameHashCodeWCars() {
        Player p1 = new Player("Andras", "192.158.65.54", 300);
        Player p2 = new Player("Andras", "157.65.23.100", 300);

        Car c = new Car(40.0, 200, 500);
        Car c2 = new Car(20.0, 150, 300);

        p1.vehicles.add(c);
        p1.vehicles.add(c2);
        p2.vehicles.add(c);
        p2.vehicles.add(c2);

        assertEquals(true, p1.hashCode() == p2.hashCode());
    }

    @Test
    public void twoPlayer_differentHash() {
        Player p1 = new Player("Andras", "192.158.65.54", 300);
        Player p2 = new Player("Balazs", "157.65.23.100", 300);

        assertEquals(false, p1.hashCode() == p2.hashCode());
    }
    
    @Test
    public void compareCars() {
        Car c = new Car(40.0, 200, 500);
        Car c2 = new Car(20.0, 150, 300);
        Car c3 = new Car(30.0, 130, 120);
        Car c4 = new Car(40.0, 150, 250);
        Car c5 = new Car(40.0, 200, 500);

        assertEquals(1, c.compareTo(c2));
        assertEquals(1, c2.compareTo(c3));
        assertEquals(1, c.compareTo(c3));
        assertEquals(-1, c3.compareTo(c));
        assertEquals(1, c.compareTo(c4));
        assertEquals(0, c.compareTo(c5));
    }

    @Test
    public void buyCar_ExceptionNoMoney() {
        Player p = new Player("Andras", "123.123.123.123", 300);
        Car c = new Car(30.0, 150, 400);

        try{
            p.buyCar(c);
        } catch(VehicleException e) {}
    }

    @Test
    public void buyCar_ExceptionAlreadyBought() {
        Player p = new Player("Andras", "123.123.123.123", 300);
        Car c = new Car(30.0, 150, 250);
        c.setBought();

        try{
            p.buyCar(c);
        } catch(VehicleException e) {}
    }

    @Test
    public void buyCar_ExceptionBoth() {
        Player p = new Player("Andras", "123.123.123.123", 300);
        Car c = new Car(30.0, 150, 400);
        c.setBought();

        try{
            p.buyCar(c);
        } catch(VehicleException e) {}
    }

}