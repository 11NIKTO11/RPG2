Bola by to 2D (platformová) hra kde bude hráč ovládať postavu hrdinu -
rytiera (najpravdepodobnejšie).

Hra by mala rámcovo implementovať

   - Jednu centrálnu lokáciu (mesto)  obsahujúcu veci potrebné pre hráča
   minimalne kovareň a obchodníka.
   - Z tejto lokácie by mal hráč prístup postupne do každej úrovne, ktorá
   sa v hre nachádza, (napríklad by sa tu nachádzali dvere pre každú úroveň
   ktoré by ho premiestnili na začiatok zvolenej lokácie alebo aj by bola mapa
   rozvrhnutá tak že by boli lokácie prepojené a postupne by sa otvárali
   skryté cesty )
   - niekoľko (aspoň 10) úrovní dungeonov obsahujúce  dohromady aspoň 5
   unikátnych nepriateľov (s rozdielnym správaním ) a viacej ich mierne
   upravených verzí
   - Každá variacia nepriateľa by mala vlastnú množinu materialov gearu
   ktorú by ponúkala ako loot
   -  Rád by som mal aspoň boss fight
   - Hráč by sa v hre pohyboval klasiky ako pri platformových hrách
   (WS)AD a spave na skákanie
   -  Combat style hry by mal byť na blízko s možnosťami útoku silný a
   slabý uder (práve a ľavé tlačítko myši)
   - Hlavná featura hry by bol system predmetov
   - predmety budú rozvrhnuté do viacerých úrovní(aspoň 4) (napr. klasicky
   obyčajne,vylepšené,vzácne,legendárne/unikátne)
   - tieto úrovne by sa líšili počtom statou, alebo ich silou poprípade
   ešte aj inak.
   - implementovať  recepty na kombinovanie materiálov a gearu ako
   napríklad
      -  vylepšenie itemu o úroveň
      - skombinovanie dvoch itemov rovnakého druhu do jedného
      - pridávanie "periférií" k itemu (napríklad k helme pridať kryt na
      tvárovú časť a podobne )
      - pridávanie drahokamov do brenia s miestom pre ne, kde drahokamy by
      mali len zlepšovať už existujúce staty na iteme
      - Vkladanie niečoho špecialneho (niečo ako runové slova, nemám presnu
      predstavu o tom ak by sa to malo volať) ktoré by postave pridávali nejakú
      unikátnu pasívnu schopnosť
   - itemy ktoré by hráč mal by mali svoju životnosť nutiacu hráča dávať
   pozor na stav svojho vybavenia.
   - používanie vybavenia by znižovalo postupne životnosť ako aj
   podmienky, ktorím svoje vybavenie hráč v hre výstavy (napr.
   niektorý nepriatelia by mohli pri zásahu robiť väčšie škody voči určitému
   typu vybavenia )
   - poškodený item by pri používaní mal šancu sa zničiť

(možno som ešte na niektoré featury zabudol )

Medzi časom som ešte uvažoval nad ďalšími témami a jedna čo mi prišla
zaujímavá je digitalizácia hry carcasone s AI oponentom a integráciou
rozšírení, ktoré sú k hre dostupné.

Program by som chcel robiť v jazyku C#
