package Modell;

import java.io.Serializable;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement(name = "company")
@XmlAccessorType(XmlAccessType.FIELD)
public class Company implements Serializable{
    private static int next_ID;
    @XmlElement
    private int id;
    private int basePrice;

    public Company(int basePrice) {
        this.id = next_ID++;
        this.basePrice = basePrice;
    }

    public int getId() {
        return id;
    }

    public int getBasePrice() {
        return basePrice;
    }
    
    
}
