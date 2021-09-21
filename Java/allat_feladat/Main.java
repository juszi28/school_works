public class Main{
    public static void main(String[] args){
        Hunter h = new Hunter("in.txt");

        h.listTrophies();
        int count = h.MaleLionShotCount();
        System.out.println(h.getName() + "(" + h.getAge() + ") vadasz ennyi him oroszlant lott le: " + count);
    }
}