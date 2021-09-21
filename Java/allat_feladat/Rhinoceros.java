public class Rhinoceros extends Animal{
    int hornweight;

    public Rhinoceros(Species species, String place, int date, int weight, int hornweight){
        super(species, place, date, weight);
        this.hornweight = hornweight;
    }

    @Override public String getSpecial(){
        return String.valueOf(this.hornweight);
    }

    @Override public String toString(){
        StringBuilder sb = new StringBuilder();
        sb.append("\nAz allat faja: " + String.valueOf(this.getSpecies()));
        sb.append("\nAz allat meghalt: "  + this.getDate() + "-ban/ben " + this.getPlace() + " helyen.\n");
        sb.append("A sulya: " + this.getWeight() + " kg.\n");
        sb.append("A szarv sulya: " + this.getSpecial() + " kg. \n");
        return sb.toString();
    }

}