# Projekt zespołowy 2 - gra ruletka

## Technologie
Użyję .NET Framework w wersji 4.5. Program będę tworzył w VS 2012 z użyciem C#. Być może pojawi się również LINQ. Niestety co nowsza wersja VS to możliwe problemy z kompatybilnością, przez co mogłyby wystąpić problemy z otwarciem całości projektu w nowszych VS. Mamy także szybki rozwój .NET-a. W takim razie jestem otwarty na pisanie jakichś snippetów, czyli fragmentów kodu, albo próbę optymalizacji kodu już istniejącego. Jestem też otwarty na propozycje zmian w GUI.

## Szukam innych osób
Być może do projektu przyłączą się osoby nieuczestniczące w innych projektach.

## Etapy
1. Zaprojektowanie interfejsu użytkownika (stołu do gry) - wykorzystam zapewne WPF.
2. Napisanie kodu obsługującego logikę gry.
2a. Proces losowania wartoby wykonać za pomocą symulacji kręcenia kołem (prędkość stopniowo maleje), lecz w ostateczności szybkie losowanie liczby z przedziału 0-36 też byłoby akceptowalne, a być może wartoby dodać oba tryby.
2b. Być może doda się inne, bardziej skomplikowane metody losowania (do wyboru w ustawieniach programu).
3. Dodanie historii zakładów (z wykorzystaniem PostgreSQL).
4. Implementacja prawdopodobieństwa trafienia w dane pola (w %).