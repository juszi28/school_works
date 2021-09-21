package transportation.test;

import transportation.line.TransportationController;
import transportation.line.StrictTransportationController;
import transportation.line.TransportationException;
import java.util.Scanner;

import static org.junit.Assert.*;
import org.junit.Test;
import org.junit.Before;
import org.junit.After;

public class TransportationTest{

    @Test
    public void noLines(){
        String input = "0";
        Scanner sc = new Scanner(input);
        TransportationController tc = new TransportationController();
        try{
            tc.readLines(sc);
        } catch(Exception ex){}

        try{
            assertEquals(0,tc.getNumberOfLines());
        } catch(Exception ex){}
    }

    @Test
    public void exampleLines(){
        StringBuilder sb = new StringBuilder();
        sb.append("4\n")
          .append("29Y 4 5\n")
          .append("Gamma 7 8\n")
          .append("29Y 2 3\n")
          .append("Gamma 11 11\n");
        Scanner sc = new Scanner(sb.toString());

        TransportationController tc = new TransportationController();
        try{
            tc.readLines(sc);
        } catch(Exception ex){}

        try{
            assertEquals(2, tc.getNumberOfLines());
        } catch(Exception ex){}
    }

     @Test
    public void exampleLines_29Y(){
        StringBuilder sb = new StringBuilder();
        sb.append("4\n")
          .append("29Y 4 5\n")
          .append("Gamma 7 8\n")
          .append("29Y 2 3\n")
          .append("Gamma 11 11\n");
        Scanner sc = new Scanner(sb.toString());

        TransportationController tc = new TransportationController();
        try{
            tc.readLines(sc);
        } catch(Exception ex){}

        try{
            assertEquals(4, tc.sizeOf("29Y"));
        } catch(Exception ex){}
    }

    @Test
    public void exampleLines_Gamma(){
        StringBuilder sb = new StringBuilder();
        sb.append("4\n")
          .append("29Y 4 5\n")
          .append("Gamma 7 8\n")
          .append("29Y 2 3\n")
          .append("Gamma 11 11\n");
        Scanner sc = new Scanner(sb.toString());

        TransportationController tc = new TransportationController();
        try{
            tc.readLines(sc);
        } catch(Exception ex){}

        try{
            assertEquals(3, tc.sizeOf("Gamma"));
        } catch(Exception ex){}
    }

    @Test
    public void wrongLine(){
        StringBuilder sb = new StringBuilder();
        sb.append("4\n")
          .append("29Y 4 5\n")
          .append("Gamma 7 8\n")
          .append("29Y 2 3\n")
          .append("Gamma 11 11\n");
        Scanner sc = new Scanner(sb.toString());

        TransportationController tc = new TransportationController();
        try{
            tc.readLines(sc);
        } catch(Exception ex){}
        try{
            assertEquals(0, tc.sizeOf("InvalidLine"));
        } catch(Exception ex){}
    }

    @Test
    public void sizeOf_TC(){
        StringBuilder sb = new StringBuilder();
        sb.append("4\n")
          .append("29Y 4 5\n")
          .append("Gamma 7 8\n")
          .append("29Y 2 3\n")
          .append("Gamma 11 11\n");
        Scanner sc = new Scanner(sb.toString());

        TransportationController tc = new TransportationController();
        try{
            tc.readLines(sc);
        } catch(Exception ex){}

        try{
            assertEquals(3, tc.sizeOf("Gamma"));
        } catch(Exception ex){}
    }

    @Test
    public void sizeOf_STC(){
        StringBuilder sb = new StringBuilder();
        sb.append("4\n")
          .append("29Y 4 5\n")
          .append("Gamma 7 8\n")
          .append("29Y 2 3\n")
          .append("Gamma 11 11\n");
        Scanner sc = new Scanner(sb.toString());

        StrictTransportationController stc = new StrictTransportationController();
        try{
            stc.readLines(sc);
        } catch(Exception ex){}

        try{
            assertEquals(5, stc.sizeOf("Gamma"));
        } catch(Exception ex){}
    }

    @Test
    public void isUnderRepair_TC(){
        StringBuilder sb = new StringBuilder();
        sb.append("4\n")
          .append("29Y 4 5\n")
          .append("Gamma 7 8\n")
          .append("29Y 2 3\n")
          .append("Gamma 11 11\n");
        Scanner sc = new Scanner(sb.toString());

        TransportationController tc = new TransportationController();
        try{
            tc.readLines(sc);
        } catch(Exception ex){}

        assertEquals(true, tc.isUnderRepair("29Y", 4));
    }

    @Test
    public void isUnderRepair_STC(){
        StringBuilder sb = new StringBuilder();
        sb.append("4\n")
          .append("29Y 4 5\n")
          .append("Gamma 7 8\n")
          .append("29Y 2 3\n")
          .append("Gamma 11 11\n");
        Scanner sc = new Scanner(sb.toString());

        StrictTransportationController stc = new StrictTransportationController();
        try{
            stc.readLines(sc);
        } catch(Exception ex){}

        assertEquals(true, stc.isUnderRepair("29Y", 4));
    }

    @Test
    public void isOperational_TC(){
        StringBuilder sb = new StringBuilder();
        sb.append("4\n")
          .append("29Y 4 5\n")
          .append("Gamma 7 8\n")
          .append("29Y 2 3\n")
          .append("Gamma 11 11\n");
        Scanner sc = new Scanner(sb.toString());

        TransportationController tc = new TransportationController();
        try{
            tc.readLines(sc);
        } catch(Exception ex){}

        assertEquals(true, tc.isOperational("Gamma",9,10));
    }

    @Test
    public void isOperational_STC(){
        StringBuilder sb = new StringBuilder();
        sb.append("4\n")
          .append("29Y 4 5\n")
          .append("Gamma 7 8\n")
          .append("29Y 2 3\n")
          .append("Gamma 11 11\n");
        Scanner sc = new Scanner(sb.toString());

        StrictTransportationController stc = new StrictTransportationController();
        try{
            stc.readLines(sc);
        } catch(Exception ex){}

        assertEquals(false, stc.isOperational("Gamma",9,10));
    }

    @Test
    public void differentConfig(){
        StringBuilder sb = new StringBuilder();
        sb.append("4\n")
          .append("29Y 4 5\n")
          .append("Gamma 7 8\n")
          .append("29Y 2 3\n")
          .append("Gamma 11 11\n");
        Scanner sc = new Scanner(sb.toString());

        TransportationController tc1 = new TransportationController();
        try{
            tc1.readLines(sc);
        } catch(Exception ex){}

        StringBuilder sb2 = new StringBuilder();
        sb2.append("6\n")
          .append("29Y 5 5\n")
          .append("Gamma 8 8\n")
          .append("Gamma 7 7\n")
          .append("29Y 3 4\n")
          .append("29Y 2 2\n")
          .append("Gamma 11 11\n");
        Scanner sc2 = new Scanner(sb2.toString());

        TransportationController tc2 = new TransportationController();
        try{
            tc2.readLines(sc2);
        } catch(Exception ex){}
        
        assertEquals(true, tc1.equals(tc2));
    }

    @Test
    public void cloneNotSame(){
        StringBuilder sb = new StringBuilder();
        sb.append("4\n")
          .append("29Y 4 5\n")
          .append("Gamma 7 8\n")
          .append("29Y 2 3\n")
          .append("Gamma 11 11\n");
        Scanner sc = new Scanner(sb.toString());

        TransportationController tc1 = new TransportationController();
        try{
            tc1.readLines(sc);
        } catch(Exception ex){}

        TransportationController tc2 = tc1.clone();
        assertEquals(false, tc1 == tc2);
    }

    @Test
    public void cloneEquals(){
        StringBuilder sb = new StringBuilder();
        sb.append("4\n")
          .append("29Y 4 5\n")
          .append("Gamma 7 8\n")
          .append("29Y 2 3\n")
          .append("Gamma 11 11\n");
        Scanner sc = new Scanner(sb.toString());

        TransportationController tc1 = new TransportationController();
        try{
            tc1.readLines(sc);
        } catch(Exception ex){}

        TransportationController tc2 = tc1.clone();

        assertEquals(true, tc1.equals(tc2));
    }

    @Test
    public void cloneSeparate(){
        StringBuilder sb = new StringBuilder();
        sb.append("4\n")
          .append("29Y 4 5\n")
          .append("Gamma 7 8\n")
          .append("29Y 2 3\n")
          .append("Gamma 11 11\n");
        Scanner sc = new Scanner(sb.toString());

        TransportationController tc1 = new TransportationController();
        try{
            tc1.readLines(sc);
        } catch(Exception ex){}

        TransportationController tc2 = tc1.clone();

        sb = new StringBuilder();
        sb.append("1\n")
          .append("Leko 2 6\n");
        sc = new Scanner(sb.toString());
        try{
            tc1.readLines(sc);
        } catch(Exception ex){}

        assertEquals(false, tc1.equals(tc2));
    }

    @Test
    public void test1(){
        StringBuilder sb = new StringBuilder();
        sb.append("4\n")
          .append("29Y 4 5\n")
          .append("Gamma 7 8\n")
          .append("29Y 2 3\n")
          .append("Gamma 11 11\n");
        Scanner sc = new Scanner(sb.toString());

        TransportationController tc1 = new TransportationController();
        try{
            tc1.readLines(sc);
        } catch(Exception ex){}

        TransportationController tc2 = tc1.clone();
        TransportationController tc3 = tc2.clone();

        sb = new StringBuilder();
        sb.append("1\n")
          .append("Leko 2 6\n");
        sc = new Scanner(sb.toString());
        try{
            tc1.readLines(sc);
        } catch(Exception ex){}

        assertEquals(-1, tc1.compareTo(tc2));
        assertEquals(1, tc2.compareTo(tc1));
        assertEquals(0, tc2.compareTo(tc3));
    }
}