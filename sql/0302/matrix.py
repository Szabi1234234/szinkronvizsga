import random
import colorama

matrix = []
for i in range(20):
    matrix.append([])
    for j in range(20):
            matrix[i].append(str(random.randint(1, 99)).zfill(2))

# for i in range(20):
#     for j in range(20):
#         print(matrix[i][j], end=" ")
#     print()

with open("0223/matrix.txt", "w") as szovegfajl:
    for i in range(20):
        for j in range(20):
            szovegfajl.write(str(matrix[i][j]) + " ")
        szovegfajl.write("\n")



# 20x20 nak a 6x6 kozepet kivesszuk
for i in range(20):
    for j in range(20):
        if 7 <= i < 13 and 7 <= j < 13:
            print("  ", end=" ")
        else:
            print(matrix[i][j], end=" ")
    print()

with open("0223/matrix.txt", "w") as szovegfajl:
    for i in range(20):
        for j in range(20):
            if 7 <= i < 13 and 7 <= j < 13:
                szovegfajl.write("   ")
            else:
                szovegfajl.write(str(matrix[i][j]) + " ")
        szovegfajl.write("\n")

#4 legnagyobb összegű egymás melleti szám vízszintesen
legnagyobb_vizszintes_osszeg = 0
negy_legnagyobb_koordinatak = []

for i in range(20):
    for j in range(17):
        osszeg = int(matrix[i][j]) + int(matrix[i][j+1]) + int(matrix[i][j+2]) + int(matrix[i][j+3])
        if osszeg > legnagyobb_vizszintes_osszeg:
            legnagyobb_vizszintes_osszeg = osszeg
            negy_legnagyobb_koordinatak = [(i, j), (i, j+1), (i, j+2), (i, j+3)]

colorama.init(autoreset=True)
#4 legnagyobb összegű egymás melleti szám függőlegesen
legnagyobb_fuggoleges_osszeg = 0
negy_legnagyobb_fuggoleges_koordinatak = []

for i in range(20):
    for j in range(17):
        osszeg = int(matrix[j][i]) + int(matrix[j+1][i]) + int(matrix[j+2][i]) + int(matrix[j+3][i])
        if osszeg > legnagyobb_fuggoleges_osszeg:
            legnagyobb_fuggoleges_osszeg = osszeg
            negy_legnagyobb_fuggoleges_koordinatak = [(j, i), (j+1, i), (j+2, i), (j+3, i)]

#4 legnagyobb összegű egymás melletti szám balról jobbra átlósan
legnagyobb_atlos_osszeg = 0
negy_legnagyobb_atlos_koordinatak = []

for i in range(17):
    for j in range(17):
        osszeg = int(matrix[i][j]) + int(matrix[i+1][j+1]) + int(matrix[i+2][j+2]) + int(matrix[i+3][j+3])
        if osszeg > legnagyobb_atlos_osszeg:
            legnagyobb_atlos_osszeg = osszeg
            negy_legnagyobb_atlos_koordinatak = [(i, j), (i+1, j+1), (i+2, j+2), (i+3, j+3)]

#4 legnagobb osszegu egymas melletti szám jobbról balra átlósan
legnagyobb_jb_atlos_osszeg = 0
negy_legnagyobb_jb_atlos_koordinatak = []

for i in range(17):
    for j in range(3, 20):
        osszeg = int(matrix[i][j]) + int(matrix[i+1][j-1]) + int(matrix[i+2][j-2]) + int(matrix[i+3][j-3])
        if osszeg > legnagyobb_jb_atlos_osszeg:
            legnagyobb_jb_atlos_osszeg = osszeg
            negy_legnagyobb_jb_atlos_koordinatak = [(i, j), (i+1, j-1), (i+2, j-2), (i+3, j-3)]

print("A legnagyobb átlós összeg: " + str(legnagyobb_atlos_osszeg))


print("A legnagyobb vízszintes összeg: " + str(legnagyobb_vizszintes_osszeg))
print("A legnagyobb függőleges összeg: " + str(legnagyobb_fuggoleges_osszeg))


#MÁTRIX KIÍRÁS
for i in range(20):

    for j in range(20):
        if 7 <= i < 13 and 7 <= j < 13:
            print("  ", end=" ")
        elif (i, j) in negy_legnagyobb_koordinatak and (i, j) in negy_legnagyobb_fuggoleges_koordinatak: #egybe viszintes és függőleges
            print("\033[35m" + str(matrix[i][j]) + "\033[0m", end=" ")
        elif (i, j) in negy_legnagyobb_koordinatak and (i, j) in negy_legnagyobb_atlos_koordinatak: #ha egybeesik vízszintes, átlós
            print("\033[35m" + str(matrix[i][j]) + "\033[0m", end=" ")
        elif (i, j) in negy_legnagyobb_fuggoleges_koordinatak and (i, j) in negy_legnagyobb_atlos_koordinatak: #ha egybeesik függőleges, átlós
            print("\033[35m" + str(matrix[i][j]) + "\033[0m", end=" ")
        elif (i, j) in negy_legnagyobb_koordinatak and (i, j) in negy_legnagyobb_jb_atlos_koordinatak: #ha egybeesik vízszintes, jobbról balra átlós
            print("\033[35m" + str(matrix[i][j]) + "\033[0m", end=" ")
        elif (i, j) in negy_legnagyobb_fuggoleges_koordinatak and (i, j) in negy_legnagyobb_jb_atlos_koordinatak: #ha egybeesik függőleges, jobbról balra átlós
            print("\033[35m" + str(matrix[i][j]) + "\033[0m", end=" ")
        elif (i, j) in negy_legnagyobb_atlos_koordinatak and (i, j) in negy_legnagyobb_jb_atlos_koordinatak: #ha egybeesik átlós, jobbról balra átlós
            print("\033[35m" + str(matrix[i][j]) + "\033[0m", end=" ")
        elif (i, j) in negy_legnagyobb_koordinatak: #VÍZSZINTES
            print("\033[31m" + str(matrix[i][j]) + "\033[0m", end=" ")
        elif (i, j) in negy_legnagyobb_fuggoleges_koordinatak: #FÜGGŐLEGES
            print("\033[32m" + str(matrix[j][i]) + "\033[0m", end=" ")
        elif (i, j) in negy_legnagyobb_atlos_koordinatak: #ÁTLÓS BALRÓL JOBB
            print("\033[33m" + str(matrix[i][j]) + "\033[0m", end=" ")
        elif (i, j) in negy_legnagyobb_jb_atlos_koordinatak: #ÁTLÓS JOBBRÓL BAL
            print("\033[34m" + str(matrix[i][j]) + "\033[0m", end=" ")

        else:
            print(str(matrix[i][j]), end=" ")
    print()
