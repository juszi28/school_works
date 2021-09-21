public abstract class Animal{
    private Species species;
    private String place;
    private int date;
    private int weight;

    public Animal(Species species, String place, int date, int weight){
        this.species = species;
        this.place = place;
        this.date = date;
        this.weight = weight;
    }

    public Species getSpecies(){
        return this.species;
    }

    public String getPlace(){
        return this.place;
    }

    public int getDate(){
        return this.date;
    }

    public int getWeight(){
        return this.weight;
    }

    public abstract String getSpecial();
}