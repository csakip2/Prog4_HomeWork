package Controller;

import Modell.Company;
import Modell.Pakage;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement(name = "companies")
@XmlAccessorType(XmlAccessType.FIELD)
public class Controller implements Serializable{
    private static Controller instance;

    @XmlElement
    private List<Company> companies = new ArrayList<>();
    
    
    public Controller() {
        Company first = new Company(400);
        companies.add(first);
        
        Company second = new Company(500);
        companies.add(second);
    
        Company third = new Company(800);
        companies.add(third);
        
        Company fourth = new Company(1000);
        companies.add(fourth);
    }
    
    public void CalculatePrice(Pakage pak){
        double timesFactor = 1;
        
        if (pak.getSize().toUpperCase().equals("MEDIUM")) {
            timesFactor = 1.5;
        }
        else if (pak.getSize().toUpperCase().equals("LARGE")) {
            timesFactor = 2;
        }
        
        for (Company company : companies) {
            company.setShippingPrice((company.getBasePrice() * timesFactor * pak.getWeight()));
        }
    }
    
    public static Controller getInstance(){
        if (instance == null) {
            instance = new Controller();
        }
        return instance;
    }

    public List<Company> getCompanies() {
        return companies;
    }
}
