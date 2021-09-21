package game.utils;

public class VehicleException extends Exception{
    public VehicleException(){}
    public VehicleException(String errorMessage){
        super(errorMessage);
    }
}