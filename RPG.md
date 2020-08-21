# Ročníkový Projekt

## Špecifikácia


> Dobrý deň 
> 
> rozmýšľal som ešte nad touto témou a jej upresnením keďže si tiež neviem momentálne predstaviť kde by tam šla využiť nejaka featura z pokročilého .NET I. tak by som to nechal len ano tému na RP
> 
> Bola by to 2D (platformová) hra kde bude hráč ovládať postavu hrdinu - rytiera (najpravdepodobnejšie).
> 
> Hra by mala rámcovo implementovať
> Jednu centrálnu lokáciu (mesto)  obsahujúcu veci potrebné pre hráča minimalne kovareň a obchodníka. 
> Z tejto lokácie by mal hráč prístup postupne do každej úrovne, ktorá sa v hre nachádza, (napríklad by sa tu nachádzali dvere pre každú úroveň ktoré by ho premiestnili na začiatok zvolenej lokácie alebo aj by bola mapa rozvrhnutá tak že by boli lokácie prepojené a postupne by sa otvárali skryté cesty ) 
> niekoľko (aspoň 10) úrovní dungeonov obsahujúce  dohromady aspoň 5 unikátnych nepriateľov (s rozdielnym správaním ) a viacej ich mierne upravených verzí
> Každá variacia nepriateľa by mala vlastnú množinu materialov gearu ktorú by ponúkala ako loot 
>  Rád by som mal aspoň boss fight
> Hráč by sa v hre pohyboval klasiky ako pri platformových hrách (WS)AD a spave na skákanie 
>  Combat style hry by mal byť na blízko s možnosťami útoku silný a slabý uder (práve a ľavé tlačítko myši)
> Hlavná featura hry by bol system predmetov
> predmety budú rozvrhnuté do viacerých úrovní(aspoň 4) (napr. klasicky obyčajne,vylepšené,vzácne,legendárne/unikátne)
> tieto úrovne by sa líšili počtom statou, alebo ich silou poprípade ešte aj inak.
> implementovať  recepty na kombinovanie materiálov a gearu ako napríklad 
>  vylepšenie itemu o úroveň
> skombinovanie dvoch itemov rovnakého druhu do jedného
> pridávanie "periférií" k itemu (napríklad k helme pridať kryt na tvárovú časť a podobne )
> pridávanie drahokamov do brenia s miestom pre ne, kde drahokamy by mali len zlepšovať už existujúce staty na iteme
> Vkladanie niečoho špecialneho (niečo ako runové slova, nemám presnu predstavu o tom ak by sa to malo volať) ktoré by postave pridávali nejakú unikátnu pasívnu schopnosť
> itemy ktoré by hráč mal by mali svoju životnosť nutiacu hráča dávať pozor na stav svojho vybavenia.
> používanie vybavenia by znižovalo postupne životnosť ako aj podmienky, ktorím svoje vybavenie hráč v hre výstavy (napr. niektorý nepriatelia by mohli pri zásahu robiť väčšie škody voči určitému typu vybavenia )
> poškodený item by pri používaní mal šancu sa zničiť
> (možno som ešte na niektoré featury zabudol )
> 
> Medzi časom som ešte uvažoval nad ďalšími témami a jedna čo mi prišla zaujímavá je digitalizácia hry carcasone s AI oponentom a integráciou rozšírení, ktoré sú k hre dostupné.
> 
> Program by som chcel robiť v jazyku C#   
> 
> V SISe som videl že už máte celkom dosť ľudí preto neviem či ešte projekty beriete. Vedeli by ste mi poprípade poradiť koho s týmito témami osloviť? 
> 
> Vopred ďakujem
> 
> S pozdravom,
> Martin Bakoš


## Začiatok

Aby som na projekto mohol vobec robyť musim sa najskor obeznámiť so zkaladným funguvaním programu v unity a jej ponukanymi funkciami 

### Informácie

 **Platforma** : Projekt budem robiť v UNITY

Zoznamovanie sa s prostredím. Prevažne pomocou pozerania videy na YouTube a naštudovania dokumentácie pre rozoberané mechaniky v UNITY

**Príklady:**

Brackeys : https://www.youtube.com/channel/UCYbK_tjZ2OrIZFBvU6CCMiA

Code Monkey: https://www.youtube.com/channel/UCFK6NCbuCIVzA6Yj1G_ZqCg

Unity : https://www.youtube.com/channel/UCG08EqOAXJk_YXPDsAvReSg

Unity API : https://docs.unity3d.com/ScriptReference/

Unity Manual : https://docs.unity3d.com/Manual/


### Prvá scéna 

#### Ciel
* Vyskúšať si fungovanie a interakciu s komponentami `RidgedBody2D`a `Collider2D`
* Zoznámiť sa s `Physics2D`
* Oboznámiť sa s fungovaním `Layers` a `Sorting Layers` 
* Pridať `Git` pre verzovanie
* Stiahnutie `Asetov`

#### Priebeh

Pre verzovanie používam zatiaľ git extentions. gitignore som pužil defaultny pre unity pojeky na GitHube.

Najdenie vhoných Asetov na unity store : -vid môj profil

Vytvorenie prvej sceny s pozadím, platformou a hračom. Jednotlivé komponenty boli podľa ich pozicie usporiadanie do `Sorting Layers`. Nsledne boli objektom pridane `Collidery` a hračovi aj `RdgedBody`.

#### výsledok

projek je pripraveny pre rozvoj a verzovanie

### Prvé pohyby

#### Ciel
* Napísať vlastný skrpit pre ovladanie postavy
* Zabezpečiť pohyb kamery s hráčom

#### Priebeh

##### Horizontálny pohyb

**Pohyb pomocou AddForce**
Neustále pribudajúca rychlosť pomalé zrýchlovanie. Tento prístup mi nevyhovoval.

**Upravovanie Velocity**
Priame upravovanie rýchlosti mi prišlo ako vhodne. Ovladanie mi prišlo responzívne a fungovalo ako som požadoval

##### Skok

Skok som implementoval pomocou pridania sily smerom na hor. Tento proces vyhovoal mojim požiadavkam.

##### Skrčenie

Zatial len ako koncept ovplivnujúci rýchlosť a vyšku skoku postavy

##### nasledovanie kamery 

Kamera upravuje svoju pozíciu tak ay bola fixná vzhladom na momentálnu hračovu polohu

## Pohyby

Základnou funkčnostou hry a pre jej testovanie je aby sme sa s postavou mohli hybať z miesta na miesto.

### Grid a Tiles

#### Ciel
* využitie Griudu a tilesetu na vytváranie mapy

#### Priebeh
Zoznamenie sa a vyskušanie si spritovať tiles. Pri tomto procese som mal viacero prblemov s poziciou Centra objektu a jeho spravania sa nasledne v gride. Taktieš som sa oboznomoval s procesom vytvarania palety a upravovania palety pre tiles.

### Pokročilý pohyb

#### Ciel
* pridanie funkčnosti skrčeniu - zmenši Collider
* postava sa nemože odkrčit pokial nemá dosť miesta nadsebou
* povoliť skakanie iba zo zeme
* zjemnenie zrýchlovania
* usmernenie pohybnu podľa naklonenia roviny
* zabranenie šmýkaniu sa dole na naklonenej rovine

#### Priebeh

##### Skrčenie

pre zmenšenie collaideru sa ponukaly dve riešenia : dva collidery pre normalnu a skrčenu postavu alebo 1 ktorého veľkosť sa bude upravovať

 **Dva Collidery** 
 Pre: jednoducho sa daju nastaviť podla potreby pre rozne tvary
 Proti: su dva a musia sa skripnu predávať referencie vramci unity
 
  **upravovanie velkosti** 
 Pre: jeden collider ktorý sa dá ziskať rovno ako komponenta a nedá sa pomyliť
 Proti: obmedzenie na jeden collider pre objekt, a to collider presne určeného tvaru - kapsule aby jeho velikosť mohla byť upravovana.
 
 Zvolil som prístup jedného collidera aby bol skript menej závysli na predávani referencií a lahšie sa určovali hranice collidera.
 
##### skakanie a vystieranie

s fixne stanovením colliderom možem jednoducho počítať miesto kde by sa mal stretávať s podlahou a kde je hlava.

**vystieranie**
vypočítam miesto vrchného bodu collidera a skontrolujem či je okolie tohoto bodu voľné. Ak ano postava sa može postaviť.

**uzemnenie**
 Podobne ako predtým vypočítam si kde sa nachadza najspodnejšia čast collidera a skontrolujem či sa dotáka zeme. Tu avšak nastalo zopar problémov.
 
 Kontorlovana plocha musí byť dostatočne velka aby som zistil aj keď stojím na naklonenej rovine že som na zemi. Taktiež potrebujem aby nebola moc veľka a nedovolila tak aplikovať silu skoku viac ako raz. Povodné riešenie vyžadovalo balancovať kontrolovanu plochu. Tu som skušal rozne prístupy ako kružnica v okoli spodnej časti, bax v tomto okoli alebo urobiť kružnicu ktora len miesrne presahuje po celej spodnej časti hranice collideru. 
 
 Naneštastie aj po dlhom skušani sa mi balanc nepodarilo nastaviť dobre a navyše toto riešenie bolo nevhodne na upravovanie do buducnosti. Nakoniec mi zostali dve možnosti. detekovať skok iba pris tlačení klávesy, a teda skoro znemožniť šancu na viacaktovaciu, alebo resetovať predchádajuci skok pred aplikáciou nového. Zvolil som druhú možnosť.
 
 Tento prístup priniesol aj iný požadovaný efekt a to spomalenie rychlosti do kopca na zaklade jeho stupania.
 
##### zjemnenie zrychlovania 
Po niekolkych skuškach pridania času na zrachlenie a spomalenie pmocou `AddForce` či `SmoothDamp` som prehodnotil potrebu tejto funkcie. Jej efekt pokial mal byť príjemny nebol skoro vyditelní alebo bol nepríjemne spomalujuci. Tuto funkcionalitu pohybu som zavrhol.

##### usmernenie pohybu

Na prvy pohľad požadovany koncept, ktory som implementoval pomocou `RayCastu` a nasledného zistovania naklonenie roviny na ktorej sa postav nachadza, sa neukázal ako efektný. Prinášal veľa vedlajšich efektov a v ničom nepríspieval k lepšej kontrole postavy. Od tohoto konceptu bolo upustené.

##### Šmyk

Na riešenie šmyku som mal 4 pristupy

**rychlosť 0** 
pokial postav stojí jej rýchlosť musí byť stale 0. Koncept neuspel keďže dochadzalo k posuvu medzi Framemi.

**rychlosť proti**
pridávať rychlosť merom do kopca kompenzujúcu šmyk. Tento prístup bol komplikovaný vyžadoval prechadzajuce usmernenie pohybu a nebol vhodny.

**trenie**
Pomocou zmeny trenia hrača pokiaľ je stacionarny možeme vytvoriť sotatočny odpor aby sa postava nehýbala. Tento prístup bol implementovany ale vyžadoval veľa pridavania, ktore mi nefungovalo vrámci kodu.

**obmedzenia**
Najjednoduchšie a aj zvolene riešenie. Vypnutie možnosti pohybu postavy pokial nemá input pre pohyb.

### Separacia pohybu

#### Ciel
* separacia kodu do rozumnych časti
* separacia pohybu a imputu do zvlašt skriptov controller / movement
* vytvorenie intefacu pre controllery

#### Priebeh
##### separacia
Kod som rozdelil do časti pre pohyb,skok a skrčenie. Taktiež niektore časti pouzívane viac krat boli separovane do samostatnych metod ako `IsGeounded `a` CanStandUp`

##### controller / movement
čitanie a vstupu a nasledne volanie prislučneho pohybu bolo presunete do movementu. Zvyšok zostal v Controllere.

##### Icontroller
Intrefece nefungoval ako bol zamyšlany keďže do interfacovej premennej nešlo priradzovať v  Unity

### Otačanie 

#### ciel
* otočit postavu do smeru kam ide

#### Priebeh

povodna myšlienka nefungovala pre pomale poravnavanie a upravovanie floatov. Premena na porovnavenie boolov a floatov s <> už bolo dostatočne responzívne.

### Animácia nečinnosti a chodze

#### ciel
* pridať animíciu chodenia a nečinnosti
* prepínať medzi nimi podla činnosti postavy

#### Priebeh
Vytvorenie animatora a nesledné animacie vložiť do nevej zložky Animation.
Pridať jednotlive prechody ktoré potrebuje prechodové podmienky, teda animator potrebuje vedieť rýchlost. Pridal som do animatora premennu Horizontal velocity. Movement script upravuje tuto premennu na základe vstupu od hráča.

### Animácia skoku a skrčenia

#### ciel
* pridať animíciu skoku a skrčenia
* integracia medzi existujúce animácie
* zprísupnič potrebné informácie animatoru

#### Priebeh
Pridanie animáci a vztahov medzi nimi nebolo zložité. Bolo však nutné pridať niekolko parametrou určujúcich vztah medzi jednotlivími animáciami ako napríklad či je na zemi aku má rychosť vertikálne horizontalne, či je skrčeny a podobne. O správnu nastavovanie parametrou sa stara skript movement.

## Útok
Dalšia sada akci ktoré može postava vykonávať je interagovať s inymi postavami formou suboja.

### detekcia uderu

#### ciel

* ako nastaviť a detekovať čo postava zasiahla

#### priebeh

podobne ako pri detekovaní či je postava na zemi alebo či sa može postaviť využijeme metodu z kategorie overlaping. Povodny zámer bol aby postava mala pred sebou kruhový vysek v ktorom zasahuje všetky zasiahnutelné entity. Naneštastie som neprišiel na jednoduchy spôsob ako skontorlovať tvar kruhovej vyseče a ešte zložitejšie by bolo ju nasledne jednoducho vykresliť cez gizmos. Najprijatelnejši z jednoducho implementovatelných tvarom mi prišiel obdlžnik, kedže sa najviac podobá tvaru meča.Tento obdlžnik je určeny stredom a rozmermi kedže táto definicia nepodlieha zmenam v umiestnená pri otočení postavy.

### pridanie animácie

#### ciel
* pridať aniimáciu utoku na zemy a počas skoku

#### priebeh
Priadnie animácie utoku k  povodným animáciam pohybu. Stavový graf nabral dosť na komplexnosti a nesprával sa vždy ako bolo požadované. Po zoznamení sa s zakladným fungovanim Layerv v animáciach boli animácie utoku prenunuté na novu vrstvu. Teraz už fungovali ako bolo zamyšlane.

## Staty a UI

Aby sa dalej dalo implementovať správanie utokov musíme najskor entitám v hre priradiť nejake staty : život.vydrž a podobne. Aby sa počas hry dobre kontrolovali bude taktiež vhodne vyrobiť zýkla pre UI zobrazujuce tieto staty.

### staty

#### ciel
* vyvoriť zakladnu triedu obsahujúcu všetky infirmácie ktoré musi mať každá postava v hre. Od tejto triedy budu dalej dedit všetky ostané rozvynutejšie staty pre rozne postavy.

#### priebeh
jednoducho popridávať a správne sprístupniť propertie statov. Prevažne chceme aby mohli byť vyditelne zvonka, ale uopravovať sa možu iba interne alebo cez príslušné metody.

### HPbar

#### ciel
* vytvoriť rozhranie pre UI
* oboznámiť sa s fungovanim UI, a ponukaními riešeniami UI v unity
* vytvoriť HP bar.

#### priebeh

Po naštudovaní si niekolkych možných pristupov som vytvoril pomocou unity UI platno pre UI hráča. Dalej pridal HP bar a oboznamovla sa s jednotlivými componentami UI ako slider. Nasledne použitie tejto komponenty pre zobrazovanie aktuálneho stavu života postavy.





