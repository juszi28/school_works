public class Lion extends Animal{
    private String gender;

    public Lion(Species species, String place, int date, int weight, String gender){
        super(species, place, date, weight);
        this.gender = gender;
    }

    @Override public String getSpecial(){
        return gender;
    }

    @Override public String toString(){
        StringBuilder sb = new StringBuilder();
        sb.append("\nAz allat faja: " + String.valueOf(this.getSpecies()));
        sb.append("\nAz allat meghalt: "  + this.getDate() + "-ban/ben " + this.getPlace() + " helyen.\n");
        sb.append("A sulya: " + this.getWeight() + " kg.\n");
        sb.append("A neme: " + this.getSpecial() + "\n");
        return sb.toString();
    }
}