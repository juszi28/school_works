public class Elephant extends Animal{
    private int leftTuskLength;
    private int rightTuskLength;

    public Elephant(Species species, String place, int date, int weight, int ltl, int rtl){
        super(species, place, date, weight);
        this.leftTuskLength = ltl;
        this.rightTuskLength = rtl;
    } 

    @Override public String getSpecial(){
        return String.valueOf(this.leftTuskLength) + " " + String.valueOf(this.rightTuskLength);
    }

    @Override public String toString(){
        StringBuilder sb = new StringBuilder();
        sb.append("\nAz allat faja: " + String.valueOf(this.getSpecies()));
        sb.append("\nAz allat meghalt: "  + this.getDate() + "-ban/ben " + this.getPlace() + " helyen.\n");
        sb.append("A sulya: " + this.getWeight() + " kg.\n");
        sb.append("Az agyarainak hossza(bal,jobb): " + this.getSpecial() + "\n");
        return sb.toString();
    }
}