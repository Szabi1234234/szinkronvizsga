import random

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
    