import java.util.ArrayList;
import java.io.BufferedReader;
import java.io.FileReader;

public class Hunter{
    private String name;
    private int age;
    private ArrayList<Animal> trophies = new ArrayList<Animal>();

    public Hunter(String filename){
        try(BufferedReader bf = new BufferedReader(new FileReader(filename))){
            String line = bf.readLine();
            String[] parts = line.split(" ");
            this.name = parts[0];
            this.age = Integer.parseInt(parts[1]);
            while((line = bf.readLine()) != null){
                parts = line.split(" ");
                String species = parts[0].toUpperCase();
                String place = parts[1];
                int date = Integer.parseInt(parts[2]);
                int weight = Integer.parseInt(parts[3]);
                if(species.equals("ELEPHANT")){
                    int leftTuskLength = Integer.parseInt(parts[4]);
                    int rightTuskLength = Integer.parseInt(parts[5]);
                    Species s = Species.valueOf(species);
                    trophies.add(new Elephant(s, place, date, weight, leftTuskLength, rightTuskLength));
                }
                else if(species.equals("LION")){
                    String gender = parts[4];
                    Species s = Species.valueOf(species);
                    trophies.add(new Lion(s, place, date, weight, gender));
                }
                else{
                    int hornweight = Integer.parseInt(parts[4]);
                    Species s = Species.valueOf(species);
                    trophies.add(new Rhinoceros(s, place, date, weight, hornweight));
                }
            }
        } catch(Exception ex){
            System.out.println("Something bad happened");
        }
    }

    public String getName(){
        return this.name;
    }

    public int getAge(){
        return this.age;
    }

    public void listTrophies(){
        for(Animal a : trophies){
            System.out.println(a);
        }
    }

    public int MaleLionShotCount(){
        int c = 0;
        for(int i = 0; i < trophies.size(); ++i){
            if(trophies.get(i).getSpecies().equals(Species.LION) && trophies.get(i).getSpecial().equals("male")){
                ++c;
            }
        }
        return c;
    }
}
