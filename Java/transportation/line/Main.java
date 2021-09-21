package transportation.line;

import java.util.Scanner;

public class Main{
    public static void main(String[] args){
        TransportationController tc = new TransportationController();
        StringBuilder sb = new StringBuilder();
        sb.append("4\n")
          .append("29Y 4 5\n")
          .append("Gamma 7 8\n")
          .append("29Y 2 3\n")
          .append("Gamma 11 11\n");
        Scanner sc = new Scanner(sb.toString());
        try{
          tc.readLines(sc);
        } catch(Exception e){}

        try{
            System.out.println(tc.sizeOf("29Y"));
        } catch(Exception e){}
        try{
            System.out.println(tc.sizeOf("Gamma"));
        } catch(Exception e){}

        System.out.println(tc.isUnderRepair("29Y", 4));
        System.out.println(tc.isOperational("Gamma",9,12));
        System.out.println(tc.isOperational("Gamma",9,10));

        StrictTransportationController stc = new StrictTransportationController();
        try {
          stc.readLines(sc);
        } catch(Exception e){}

        System.out.println(stc.isUnderRepair("29Y", 4));
        System.out.println(stc.isOperational("Gamma",9,12));
        System.out.println(stc.isOperational("Gamma",9,10));
  }
}