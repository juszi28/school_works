package game.vehicles;

public class Train extends Vehicle {

    public Train (double currentSpeed) {
        super(currentSpeed);
    }

    @Override public void accelerate(double amount) {
        if(amount < 0) {
            try{
                super.accelerateCurrentSpeed(amount/10);
            } catch(Exception e) {}
        } else {
            try{
                super.accelerateCurrentSpeed(amount);
            } catch (Exception e) {}
        }
    }
}