
# SharingFood
Jest to aplikacja umożliwiająca dzielenie się jedzeniem jak sama nazwa wskazuje. 
Polega ona na tym że robi się zdjęcie danego jedzenia i postuj się na tej aplikacji, następnie dana osoba może przyjść i odebrać te jedzenie od osoby wystawiającej ogłoszenie. 

Załóżmy taki scenariusz, zamawiam ze znajomymi pizze, po zjedzeniu iluś tam kawałków zostaje połowa, każdy w gronie znajomych mówi że już nie będzie jadł i ja tak samo nie będę, ja w takim momencie odpalam aplikację SharingFood na telefonie robię zdjęcie pozostałych kawałków pizzy i klikam wystaw ogłoszenie, zamiast wyrzucać go do śmieci. Po 10 minutach przychodzi do mnie dziewczyna po odbiór tej pizzy. Ja jestem zadowolony bo mogłem się podzielić z kimś posiłkiem i ta pani jest zadowolona bo będzie mogła zjeść pizze i zaoszczędzić przy tym.

# Instalacja
Otwórz projekt w [Visual Studio 2019](https://visualstudio.microsoft.com/).
Skonfiguruj swój emulator androida następnie skompiluj projekt w trybie debugowania na androida, wersja na IOS nie działa. Aplikacje należy odpalać tylko poprzez android emulator wbudowany w visual studio, nie należy zgrywać na telefon lub na emulatory takie jak nox czy bluestacks

# Omówienie aktualnych funkcji aplikacji 
Navigation bar który znajduje się na głównej stronie posiada trzy przyciski. 

Pierwszy służy do filtrowania postów w zależności jakie miasto się wpisze w wyszukiwarkę. Ma tam być jeszcze funkcja w kodzie bodajże jest to ``GetNearCities`` która umożliwia przesuwanie paskiem w celu zmieniania odległości miast w okręgu użytkownika by właśnie z tych miast wyświetlać ogłoszenia, nie stety tego nie zaimplementowałem w 100% ponieważ nie miałem funduszy na dokumentacje [GeoDB](https://rapidapi.com/wirefreethought/api/geodb-cities) która właśnie umożliwia pokazywanie miast w pobliżu. 

Drugi słóży do dodawania postów, trzeba podać tytuł ogłoszenia, opis (nie jest wymagany) i dodanie zdjęcia, jak narazie jest support tylko na 1 zdjęcie. 

Trzeci służy do wyświetlania panelu użytkownika gdzie ma takie opcje jak: wyloguj lub zobacz moje posty. Nie wiem czy moje posty w tej wersji działają w każdym bądź razie w wersji która jest robiona ciągle to działa. 

Gdy konto jest zaznaczone jako moderator w bazie danych, w aplikacji powinien być jeszcze jeden przycisk do akceptowania i odrzucania postów. Nie jestem pewien czy udało mi się to dokończyć.

Gdy się kliknie na zdjęcie ogłoszenia przenosi ono użytkownika do okna kontaktu z osobą ogłaszającą, jest też tam zawarty cały opis ogłoszenia. Nie stety nie udało mi się tego ukończyć i jak narazie nie wyświetla tych informacji ale da się kliknąć.

# Dlaczego moim zdaniem jest to problem globalny?
Moim zdaniem gdy rozprzestrzeni się taką aplikację na cały świat będzie to rozwiązywało problemy globalne takie jak brak pieniędzy lub brak żywności. Powinniśmy zaczynać od mniejszych/większych miast lub krajów bo wtedy rozwiązuje to problem lokalny a nie globalny, gdy uzbiera się parę państw które będą korzystały z tej aplikacji, będzie rozwiązywać to problem globalny. Uważam że taki sposób podejścia do rozprzestrzeniania się tej aplikacji jest dobry. Zaczęcie od samej Polski będzie już dużym sukcesem ponieważ statystyczny polak marnuje 235 kg żywności w ciągu roku. Jeżeli aplikacja pomogła by nawet spaść do 220kg (15kg w ciągu roku) marnowanego jedzenia na rok to ~1,7 mln polaków mogło by jeść normalnie codziennie przez rok za darmo. 235kg pomnożone przez każdego statystycznego polaka to ~8 925 300 000 mld ‬kg a 220kg żywności pomnożone przez Polaka to ~8 355 600 000‬ mld kg wyrzucanego jedzenia, czyli zaoszczędzilibyśmy ~569 700 000‬ mln kg jedzenia. Wiadomo że jest to tylko przybliżenie więc nie należy brać tych liczb dosłownie. Problemu globalnego nie da się od tak rozwiązać ponieważ jest to bardzo skomplikowany proces.

# Jak widzę dalszy rozwój tego projektu?
Po zakończeniu [Hack Heroes]([http://hackheroes.pl/](http://hackheroes.pl/)) planuję dodać system czatu z osobami które wystawiają ogłoszenie. Będzie to wykorzystywało nową technologię [Azure SignalR Service]([https://azure.microsoft.com/pl-pl/services/signalr-service/](https://azure.microsoft.com/pl-pl/services/signalr-service/)), ciągle poprawiać wydajności kodu. Chciałbym także wystawić tą aplikację na rynek Google Play i nie długo później na App Store.

# Jakie widzę zagrożenia/ryzyka dla Waszego rozwiązania?
Jedyne ryzyko jakie widzę to takie że ludzie nie będą potrafić się odnosić z taką aplikacją i będą ją nadużywać.

# Użyte technologie
- Aplikacja napisana jest w języku C# i frameworku [Xamarin Forms]([https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/](https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/)).
- [Autofac](https://github.com/autofac/Autofac) jako kontener IoC.
- [MVVMLight](https://github.com/lbugnion/mvvmlight) jako MVVM framework
- Bazy danych użyte do tej aplikacji to SQL Server postawiony na platformie [Azure]([https://azure.microsoft.com/en-us/](https://azure.microsoft.com/en-us/)).

# Dlaczego akurat ja powinienem wygrać?  
Ponieważ mam 16 lat programuję już od 2 lat i jest to moja pasja jak i zawód, wiąże z tym swoją przyszłość i chce jak najbardziej rozwijać otoczenie jak i samego siebie.

# Rzeczy które są robione po 25, bo nie zdążyłem zrobić
- Kompletne usunięcie Sql provider'a i zrobienie REST API
- Testy 
- Optymalizacja kodu
- Kompletny wygląd
- inne

# Licencja 
SharingFood jest na licencji GNU General Public License (GPL), możesz uruchamiać w dowolnym celu, dostosowywać go do swoich potrzeb, rozpowszechniać niezmodyfikowaną kopię programu, udoskonalać program i publicznie rozpowszechniać własne ulepszenia dzięki czemu może skorzystać z nich cała społeczność.

# Autor
Autorem tego projektu jest Maksymilian Oskar Szokalski.

# Opinia
Miejsce na opinie od jurorów :)
