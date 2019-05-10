package Modell;

public class Pakage {
    private static Pakage instance;

    public static Pakage getInstance() {
        return instance = new Pakage();
    }
    private int weight;
    private String size;

    public Pakage() {
    }

    public int getWeight() {
        return weight;
    }

    public void setWeight(int weight) {
        this.weight = weight;
    }

    public String getSize() {
        return size;
    }

    public void setSize(String size) {
        this.size = size;
    }
    
    
}
