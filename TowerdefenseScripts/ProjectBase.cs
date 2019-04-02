/*
 * -------------Dokumentacja projektu-------------
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * ---------Opis skryptow-----------------
 * 
 * 
 *  ---> BuilMenager
 *  dolaczony do (GameObject)GameMenagera
 *  1. pobiera modele wież
 *  2. posiada funkcja odpoweidzialna za wybierana przez nas wiezyczke
 *  3. oraz funkje set krora ustawia nam te wieze do budowania
 *      funkcja wykorzystana w innym skrypcie: 
 *      
 *      
 *  ---->Bullet
 *  dolaczony do (prefab)(GameObject)Bullet
 *  1. podstawowe paramety dotyczace promienia razenia mocy razenia predkosci itp
 *  2. funkcja Seek ustawia nas nowy target wykorzystana w skrypcie: TurretFire
 *  3. w update aktualizuje swoja pozycje wzgledem pozycji namierzonego wroga
 *      nastepnie wywoluje funkcje odpowiedzialna za zaatakowanie
 *  4. zaatakowanie tworzy particle uderzenia nastepnie wywoluje funkcje Damage() wraz z parametrem
 *      transform trfionego wroga co sprawia ze trafiony przez nas wrog wlansnei on otrzymuje obrazenia
 *  5. Damage() funkcja wywoluje funkcje Destroy() ze skryptu Enemy odpowiedzialna za zadawanie obrazeń
 *  6. Gizmos rysuje linie zasiegu pola razenia rakiety
 *  7. Explode() odpowiada za zadawanie obrazen po wybuchu rakiety 
 *  
 *  -->TurretLook
 *  podpiety do (prefab)(GameObject)Turret wszystkich wież
 *  1. posiada zmienne takie jak szybkosc obracania sie i zasieg ostrzalu
 *  2. w funkcji start wywolana jest funkcja odpowiedzialna za powtarzanie danej funkcji co jakis czas
 *  3. UpdateTarget() jest to funkcja o ktorej mowa w pkt2 jest ona powtarzana co 0.5f odpowiada 
 *      za namierzanie wroga
 *  4.Update jesli mamy namierzony nas cel odpowaiada za ładna rotacje naszej wieży wzgledem wroga
 *  5. Gizmo rysuje czerwone kreski po pewnej kuli okreslajac w ten sposób dla nas programistow zasieg naszej wiezy
 *  6. GetTarget() zwraza wartosc pozycji wroga wywołany w skryptach TurretFire
 *  
 *  
 *  --> TurretFire
 *  ja powyzej zawiera go kazda wieza
 *  1. posiada zmienne odpowiedzialne za ilosc pociskow wypuszczonych na sekunde 
 *      czas oczekiwana nia wystrzał na poczatku domysle 0 potem ustalany wzgledem FireRate
 *  2. Start szuka skryptu TargetLook by z niego pobierac pozycje gracza
 *  3. Update() odpowida za strzelanie naszej wiezy oraz za to by zgubic cell jesli zostanie zniszczony lub
 *      wyjdzie poa nasz obszar zasiegu
 *  4. Shoot() Odpowiada za oddawanie strzalu a konkretnie tworzy tyle pociskow ile ma FirePoint a nastepnie do 
 *      funkcji Seek() ktora znajduje sie w pocisku przekazuje pozycjie przeciwnika
 *      
 *      
 *  --->Enemy
 *  przypiety do prefab(GameObject)Enemy 
 *  1. zawiera predkosc ruchu wroga 
 *      poziom zycia
 *      pozycje nastepnego pkt swojej drogi
 *      min i max wartosc zlota za siebie pobieranego z głownego skryptu spawnowania wrogow
 *  2. Start() ustawia wszystkie wartosci oraz pobiera niezbedne komponenty
 *  3. Update() odpowiada za kierunek poruszania sie i samo poruszanie oraz za wyszukiwanie kolejnego 
 *      punktu podrozy za pomoca funkcji NetWayPoint()
 *  4. NextWayPoint() zwraca pozycje kolejnego punktu podrozy wroga z tabeli WayPoitsów
 *  5. Die() odpowiada za usuwanie oraz tworzenie particli po smierci wroga uruchmiana w funkcji TakeDamage()
 *      wywoluje tez funkcje odpowiedzialna za dodawanie nam zlota
 *  6. TakeDamage() funkcja przyjmuje ilosc obrazan ktore ma zadac wrogowi i zadaje je 
 *      pradza czy ta wartosc jest wieksza od 0 jesli nie wywołuje funkje Die() 
 * 7. AddGoldPerKill() funkcja dodaje do naszego konta zloto za zabicie wroga wywoluje wynkcje AddMoney() z 
 *      skryptu MoneyMenager (w pryszlosci przeniose funkcje)
 *      
 *      
 *      
 *  --->MoneyMenager
 *  przypiety do UI HUDMenu
 *  1. posiada tylko zmienna przechowujaca nasze pieniadze
 *  2. na stracie pobiera pieniadze uzbiera przez nas jesli nie mamy odpowiedniej ilosci daje nam okreslona stawke
 *      wypisuje te stawke na ekranie 
 *  3. AddMoney() przyjmuje ile pieniedzy ma nam dodac wywoalana w skrypcie Enemy dodaje nam zloto oraz wypiuje jego 
 *      wartosc na ekranie oraz zapisuje te wartosc w PlayerPrefs pod kluczem "Money"
 *  4. GetMoney() zwraca ilosc posiadanego zlota wywowałany w skrypie Node
 *  
 *  
 *  --->Node
 *  skrypt przypisany do pojedynczej platfory w grze prefab(GameObject)Node
 *  1. posiada wartosci koloru po najechaniu myszka wartosc poczatkowa koloru kazego pola oraz oddalenie od brzegow
 *      wierzy w kazdym polu
 *  2.Start() pobiera niezbedne komponnenty
 *  3.OnMouseDown() odpowiada za klikniecie myszka jesli nie wybrano wierzy nie kliknieto i nie kupiono wierzy to nic nie robi
 *      natomiast jesli wszystko zrobiono i kliknieto na Node to buduje wybrana wieze
 *  4. OnMauseEnter() po na jechaniu myszki na wybrany element Node zmienia kolor jesli wybralismy wieze do budowania
 *      jesli nie wybralismy nic nie robi
 *  5. OnMouseExit() ustawia wartosc koloru na wartosc poczatkowa Node
 *  
 *  -->WaveEnemyMenager
 *  podpiety do prefab(GameObject)GameMenagera 
 *  1. posiada min i max wartosc złota za wroga, numer fali ktory jest opowiedzialny za ilosc przeciwnikow w fali
 *      i czas poczatkowy respawnu wrogow oraz czas na kolejne spawny wroga, oraz czas potrzebny na stworzenie jednego wroga w danej fali
 *  2. Update()  odlicza do kolejnej fali wroga jesli jest czas to ustawia odliczanie na nowo oraz startuje korutyne 
 *      odpowiedzialna za tworzenie wrogów
 *  3. SpawnWaveEnemy() korutyne odpowiedzialna za tworzenie wrogow co okreslona jednostke czasu timeOneEnemySpawn
 *      podbija numer fali o jeden. Wywoluje funkcja ktora powoduje utrudnienia zwiazane z tym ze w danej fali moze pojawic sie wiecej wrogów
 *  4. SpawnEnemy() tworzy obiekt wroga z prefabu w danej pozycji 
 *  5. EnemyInWave() odpowiada za zwiekszenie wrogów w jednej fali
 *  6. Korutyna GoldPerKill zmniejsza wraz z uplywam czasu pieniadze za zabicjie wroga
 *  7. GetMinGold() GetMaxGold() zwracaja odpowiednie wartosci wykorzystane w skrypcie Enemy
 *  
 *  --->CameraController
 *  odpowiadaza ruch kamery na planszy
 *  !!!! dodanie skrolowania ważne!!!
 *  1. posiada zmienne odpowiedzialne za predkosc ruchu oraz za odleglosc od krawedzi ekranu
 *  2. Update odpowiada za ruch kameryt oraz reaguje na przesuwanie myszką w poszczególne boki ekranu
 *  
 *  --->Waypoints
 *  przypiety do WayPoints
 *  1. odczytuje wszystkie dzieci tego GameObjectu i wpisuje je pokolei do tablicy Transform
 *  
 *  --->ShopMenager
 *  skrypt przypiety do panelu UI
 *  1.zawiera w sobie funkcje dla kupowania odpowiednich wieżyczek 
 *  2. zawiera funkcje ktora zmusza do klikniecia by kupic i jesli jest niewystarczajaca ilosc pieniedzy to zwraca false
 *      uzytwa w skrypcie Node jesli zwroci false to nie mozna umiescic na placu boju danej wiezyczki do momentu uzbiernanie 
 *      odpowiedniej ilosci złota
 *  
 *  
 *      
 *      
 *
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * */