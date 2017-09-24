# CSVGRAF
Speciálisan szerkeszett csv fájlok numerikus tartalmának ábrázolása koordinátarendszerben.

# Feladat
Apukám PLC programozással foglalkozik (ipari automatizálás), és egy ilyen eszközével csak csv fájlokat tudott exportálni. A feladatom az volt, hogy ezeket az adatokat, amiket rögzített a PLC-vel, és exportált a HMI-vel, vizuálisan megjelenítsem.

# Működés
A korábban PLC-ről letöltött fájlt megnyitjuk ("Megnyitás"), majd a program megjeleníti annak tartalmát. Ha működés közben felülírjuk a fájlt, a "Frissítés" gombbal ugyanazon elérési helyű fájlt olvassuk be, és ábrázoljuk.

A mellékelt "mintafajl.csv" egy olyan fájl, melynek feldolgozására képes.

![Alt text](mintafajlabrazolas.PNG?raw=true "Title")

# A fejlesztés menetéről
A program Windows operációs rendszerre volt szánva. Korábban is inkább a c# nyelvet preferáltam, ezért kézenfekvő volt abban megoldani a problémát. A Windows Form-os grafikonok számomra ismeretlenek voltak korábban így azokat az internetről (fórumok, dokumentációk, videók alapján) kellett megismernem.

# Problémák
A programmal kapcsolatos hibák:
- Nem kezelt kivételek:
  - A fájl nincs megfelelően szerkesztve.
  - Nincs olvasási jogosultsága a programnak.
- Csúnya a felület.

A fejlesztéssel, dokumentálással kapcsolatos hibák:
- A program fejlesztése egy hosszabb utazásom miatt félbemaradt.
- Már nem emlékszem a csv eredeti felépítésére, és a korábbi mintafájlokat sem találom.
- Nem tudom már mi szükség volt a "kulcskarakterre", mert a jelenlegi formában nincs túl sok haszna.