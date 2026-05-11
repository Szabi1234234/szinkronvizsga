# szam = int(input("Adj meg egy számot: "))
# if szam % 2 == 0:
#     print("A szám páros.")
# else: 
#     print("A szám páratlan.")

# if szam > 0:
#     print("A szám pozitív.")
# elif szam < 0: 
#     print("A szám negatív.")
# elif szam == 0:
#     print("A szám nulla.")

# if szam % 5 == 0:
#     print("A szám osztható 5-tel.")
# else:
#     print("A szám nem osztható 5-tel.")


#2. 

# nev = input("Adj meg egy nevet: ")

# print("Nagybetűsen: ", nev.upper())
# print("Kisbetűsen: ", nev.lower())
# print("Cím formátum: ", nev.title())
# print("Monogram:" , nev[0].upper() + "." + nev.split()[1][0].upper() + ".")

#3. 

# lista = []
# for i in range(5):
#     szam = int(input("Adj meg egy számot: "))
#     lista.append(szam)

# for i, szam in enumerate(lista):
#     print(f"{i+1}. {szam}")

# print("Összeg: ", sum(lista))
# print("Átlag: ", sum(lista) / len(lista))
# print("Legnagyobb: ", max(lista))
# print("Legkisebb: ", min(lista))

#4.

# mondat = input("Írj be egy mondatot: ")

# maganhangzok = "aáeéiíoóöőüűuú"

# print("Karakterek (szóközökkel):" , len(mondat))
# print("Karakterek (szóközök nélkül): ", len(mondat.replace(" ", "")))
# print("Szavak száma: ", len(mondat.split()))

# print("Magánhangzók száma: ", sum(1 for c in mondat if c in maganhangzok))

#5. 

# def celsius_to_fahrenheit(celsius):
#     return (celsius * 9/5) + 32

# def fahrenheit_to_celsius(fahrenheit):
#     return (fahrenheit - 32) * 5/9

# print(celsius_to_fahrenheit(0))
# print(celsius_to_fahrenheit(100))
# print(fahrenheit_to_celsius(32))

#6.

# lista = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]

# paros = [x for x in lista if x % 2 ==0]
# paratlan = [x for x in lista if x % 2 != 0]
# nagyobb_10 = [x for x in lista if x > 10]
# negyzetek = [x**2 for x in lista]

# print("Páros számok: ", paros)
# print("Páratlan számok: ", paratlan)
# print("10-nél nagyobb számok: ", nagyobb_10)
# print("Számok négyzetei: ", negyzetek)

#7.

# diakok = {
#     "Bulcsú" : 1,
#     "Dani": 1,
#     "Maxim" : 5,
#     "Tege": 2
# }

# print("Diákok nevei: ", list(diakok.keys()))
# print("Diákok jegyei: ", list(diakok.values()))

# atlag = sum(diakok.values()) / len(diakok)
# print("Átlag jegy: ", atlag)

# print("Legjobb jegyet kapó: ", max(diakok, key=diakok.get))