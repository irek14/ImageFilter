# ImageFilter
ImageFilter to projekt stworzony w ramach trzeciego laboratorium z przedmiotu Grafika Komputerowa 1. Aplikacja ta umożliwa filtrowanie obrazu przy pomocy filtrów funkcyjnych z wykorzystaniem zaznaczania obszarów wielokątami, a także ruchomym, okrągłym pędzlem.

## Funkcjonalność
Edytor zapewnia poniższe funkcjonalności:
* Zaznaczanie obszarów do edycji
    * Przy pomocy okrągłego pędzla, który porusza się za kursorem myszy
    * Przy pomocy wielokątów, których dodawanie i usuwanie przebiega analogicznie jak w projekcie [Polygon Editor](https://github.com/irek14/PolygonEditor)
* Zastosowanie filtrów na zaznaczonym fragmencie obrazu. W skład filtrów wchodzą:
    * Filtr negacji
    * Zmiana jasności (regulowana przy pomocy odpowiedniego parametru z zakresu <-255,255>
    * Korekcja gamma (regulowana przy pomocy odpowiedniego parametru z zakresu (0,50>
    * Kontrast (regulowany przy pomocy dwóch parametrów - prawego i lewego przesunięcia wykresu)
    * Własny filtr funkcyjny (z dostępną możliwością własnego konfigurowania wykresu funkcji przy pomocy przesuwania punktów na wykresie znajdującym się pod menu)
* Podgląd histogramu dla zmieniającego się pod wpływem filtrów obrazka
    
## Użycie
Zmiana trybu rysowania, a także filtra dokonywana jest przy pomocy menu znajdującego się na środku ekranu. Aby zastosować filtr wewnątrz zaznaczonego wielokąta należy nacisnąć przycisk "Zastosuj". Dodatkowo na górnym pasku nawigacyjnym w zakładce File dostępna jest opcja wgrania własnej grafiki.

### Przyjęte założenia
* <b>Rysowanie</b> - opuścić tryb rysowania możemy tylko wówczas, gdy rysowany przez nas wielokąt zostanie zamknięty w wierzchołku startowym
* <b>Filtr wewnątrz wielokąta</b> - filtr jest stosowany wewnątrz wielokąta tylko jednokrotnie. Jeśli chcemy zastosować filtr po raz kolejny, należy opuścić tryb "Dodaj wielokąt" i do niego powrócić.
* <b>Filtr wewnątrz pędzla</b> - piksele zmieniają się tylko raz gdy znajdą się w obszarze pędzla podczas trwania ruchu myszki z wciśniętym jej lewym przyciskiem. Jeżeli przycisk zostanie puszczony i naciśnięty ponownie działanie filtrów znów będzie widoczne na całym obszarze.
* <b>Edycja własnej funkcji</b> - na wykresie zaznaczonych jest 17 punktów, które można przesuwać w kierunku pionowym. Funkcja automatycznie modyfikuje się i jej zmiany wpływają na działanie filtra własnej funkcji.

 ## Autor
 [Ireneusz Stanicki](https://github.com/irek14), student Informatyki na wydziale Matematyki i Nauk Informacyjnych Politechniki Warszawskiej
