# KLOPA - Aplikacija za dostavu hrane

Aplikacija KLOPA je projekat rađen kao seminarski rad za predmet Razvoj softvera 2. Ova aplikacija omogućava dostavu hrane i pruža funkcionalnosti za 4 tipa korisnika: Administratora, Uposlenike poslovnica, Dostavljače i Kupce. Administrator i Uposlenici poslovnica koriste desktop aplikaciju, dok Dostavljači i Kupci koriste mobilnu aplikaciju.

## Tehnologije

- Backend: C#, .NET 6.0
- Desktop aplikacija (Administrator i Uposlenici poslovnica): C#, Windows Forms
- Mobilna aplikacija (Dostavljači i Kupci): Flutter

## Upute za instalaciju

1. Klonirajne GitHub repozitorija.

    ```
    git clone https://github.com/farisgogic/eDostavaWinUI.git
    ```
    
2. Otvoriti klonirani repozitoriji u konzoli

3. Pokretanje dokerizovanog API-ja i DB-a

    ```
    docker-compose build
    docker-compose up
    ```
    
    
4. Otvoriti edostavamobile folder

    ```
    cd edostavamobile
    ```

5. Dohvatanje dependecy-a

    ```
    flutter pub get
    ```
    
6. Pokretanje mobilne aplikacije

    ```
    flutter run
    ```   
    
7. Pokretanje desktop aplikacije

    ```
    1. Otvoriti solution u Visual Studiu 2022
    2. Desni klik na solution
    3. Configure Startup Projects
    4. Multiple startup projects
    5. eDostava - Start
    6. eDostava.WinUI - Start
    7. OK
    8. CTRL + F5
    ```    
    

## Kredencijali za prijavu   

### Desktop aplikacija

- Uposlenik

    ```
    Korisnicko ime: Intermezzo            
    Lozinka: Intermezzo                                    
    ```

    ```
    Korisnicko ime: Divan            
    Lozinka: Divan                                    
    ``` 

    ```
    Korisnicko ime: Kula            
    Lozinka: Kula                                    
    ```     
    
    

### Mobilna aplikacija

- Kupac

    ```
    Korisnicko ime: kupac
    Lozinka: kupac  
    ```
    
    ```
    Korisnicko ime: proba
    Lozinka: proba  
    ```
    
    
- Dostavljac

    ```
    Korisnicko ime: dostavljac
    Lozinka: dostavljac  
    ```   
    
    ```
    Korisnicko ime: test
    Lozinka: test  
    ```
    
## KARTICA ZA NARUDŽBU

    ```
    Broj kartice: 4242 4242 4242 4242 
    ```
