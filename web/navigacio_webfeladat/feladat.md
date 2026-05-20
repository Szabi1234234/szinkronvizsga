Ebben a feladatban egy navigációról és térképészet történetéről szóló weboldalt kell elkészítenie. A weboldal egy részét már elkészítették, ezek az állományok a navigacio_webfeladat mappában találhatók.
1. Nyissa meg az index.html állományt!
2. Az oldal nyelvét állítsa magyarra, a karakterkódolás utf-8 legyen!
3. A weboldal fejlécében helyezzen el hivatkozást a navigacio.css stíluslapra!
4. A böngésző címsorában megjelenő szöveg „Navigáció és térképek” legyen!
5. A fejlécben található Navigáció és térképek szöveg legyen 1-es szintű címsor!
6. A bevezeto azonosítójú div elemben Gerardus Mercator nevére készítsen hivatkozást, amely a https://hu.wikipedia.org/wiki/Gerardus_Mercator oldalra mutasson!
7. Az első két kártya mintájára készítse el a következő hármat (az utolsó már félig kész van!):

    A weboldalon összesen **három** illusztráció szerepel. A fájlnevek és a kártyák megfeleltetése:

    | Kártya címe | Képfájl | `alt` helyettesítő szöveg (a szoveg.txt „Képek” részében is) |
    |-------------|---------|---------------------------------------------------------------|
    | Ősi tájékozódás | `iranytu.jpg` | Réz iránytű a térképen |
    | Középkori térképek | `kezi_terkep.jpg` | Régi kézzel színezett térképrészlet |
    | Műholdas navigáció | `gps_kepernyo.jpg` | Képernyő GPS útvonallal |

    Az első két kép a forrás `index.html` állományában a két mintakártyán **már szerepel**; ezeket nem kell újra beillesztenie, csak a feladat többi részének megfelelően alakítsa az oldalt. A **harmadik** képet (`gps_kepernyo.jpg`) a saját maga által elkészítendő **Műholdas navigáció** című kártyán helyezze el a szöveg után, a `szoveg.txt` „Képek” szakaszában megadott fájlnévvel és `alt` szöveggel.

a. A szövegeket másolja be a szoveg.txt állományból!

b. A címek kettes szintű címsorok, a szövegeket bekezdések legyenek!

c. Ahol a táblázat és a szoveg.txt szerint kép tartozik a kártyához, illessze be a megfelelő helyre; a helyettesítő (`alt`) szöveget a szoveg.txt „Képek” részéből vegye!

d. John Harrison neve hivatkozás legyen a https://hu.wikipedia.org/wiki/John_Harrison címre!

e. A kártyákon a megfelelő osztály használatával érje el, hogy felváltva legyenek kiemelt hátterűek a minta szerint! (A kiemeléshez a „kek” osztályt használja, a színeket a megoldásban a stíluslap alapján állítsa be.)

8. Tetszőleges módszerrel érje el, hogy a kártyák két sorban, hármasával jelenjenek meg! Ha szükségesnek ítéli, a main elem és a kártyák méretén változtathat.

9. Az utolsó kártyán a térkép stílusa és térkép mérete szövegek számozatlan felsorolással jelenjenek meg!

10. Az űrlapnál érje el, hogy az árat beállító csúszka értékeit 38 és 65 között lehessen állítani!

11. A Kalkuláció gomb kattintás eseménye hívja meg a „szamol()” nevű JavaScript függvényt!

12. A függvényt írja is meg az alábbiak szerint:
a. Olvassa ki a szélesség, magasság és az ár értékeket a megfelelő input mezőkből!

b. Számolja ki a térképlap területét dm2-ben (szélesség * magasság / 10000)!

c. Írja ki a területet a megfelelő helyre!

d. Írja ki a költséget a megfelelő helyre a beolvasott ár alapján!

e. Végül számítsa ki az összköltséget (terület * ár), és írja ki a megfelelő helyre!

13. A következő feladatokat a navigacio.css állomány módosításával oldja meg! Ha egy adott szelektor hiányzik, akkor az állomány végéhez adja hozzá!
a. A fejléc háttere legyen a navigacio_fejlec.jpg kép!

b. A kettes szintű címsorok félkövéren jelenjenek meg, szövegszínük legyen #1a3c34 (sötét zöldes tónus)!

c. A bekezdések szövege sorkizárt legyen!

d. A 800 pixelnél kisebb kijelzőkön a következő tulajdonságok változzanak meg: a main elem és a kártyák szélessége is 100% legyen!

e. A kártyákban lévő képekhez hover effektjéhez tartozó forog animációt írja meg! A képek tegyenek egy 360 fokos fordulatot az Y tengelyük körül!

f. A linkek a meglévő formázások mellett még legyenek dőlt stílusúak és ne legyenek aláhúzva!

g. A „kek” osztályú kártyák és a számolás doboz háttere legyen #fde8d4, a többi kártya maradjon az alapértelmezett (fehér) hátterű!
