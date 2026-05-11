# for i in range(1,51):
#     if i % 3 == 0 and i % 5 == 0:
#         print("FizzBuzz")
#     elif i % 3 == 0:
#         print("Fizz")
#     elif i % 5 == 0:
#         print("Buzz")
#     else:
#         print(i)

#9. 
# def is_palindrome(s):
#     s = s.replace(" ", "").lower()
#     return s == s[::-1]

# print(is_palindrome("Indul a görög aludni"))

# 10.
# dictionary = {}

# mondat = input("Adj meg egy mondatot: ")
# for szo in mondat.split():
#     if szo in dictionary:
#         dictionary[szo] += 1
#     else: 
#         dictionary[szo] = 1
# print("Szógyakoriság:")
# for szo, gyakorisag in dictionary.items():
#     print(f"{szo}: {gyakorisag}")

#11. 
# def is_prime(n):
#     if n <= 1:
#         return False
#     for i in range(2, int(n ** 0.5) + 1):
#         if n % i == 0:
#             return False
#     return True

# for i in range(1, 101):
#     if is_prime(i):
#         print(i, end=", ")

#12.
# students = [
#     {"name": "Anna", "age": 20, "grade": 5},
#     {"name": "Béla", "age": 22, "grade": 4},
#     {"name": "Cecil", "age": 19, "grade": 3},
#     {"name": "Dávid", "age": 21, "grade": 5}
# ]

# # osztályzat szerint 
# students.sort(key= lambda x: x["grade"], reverse=True)
# print(students)

# #eletkor
# students.sort(key= lambda x: x["age"])
# print(students)

# #4nel jobb
# students = list(filter(lambda x: x["grade"] >= 4, students))
# students.sort(key= lambda x: x["grade"], reverse=True)
# print(students)

#13.
# import random
# szam = random.randint(1, 100)

# tippek = 0

# kitalalt = False
# while not kitalalt:
#     tipp = int(input("Tippelj egy számot 1 és 100 között: "))
#     tippek += 1
#     if tipp < szam:
#         print("Nagyobb számra gondoltam.")
#     elif tipp > szam:
#         print("Kisebb számra gondoltam.")
#     elif tipp == szam:
#         print("Gratulálok, kitaláltad a számot!")
#         kitalalt = True
#     else:
#         print("Hibás input, próbáld újra.")
#         continue

# print(f"{tippek} tippel sikerült kitalálni a számot.")

#14. 
# def is_valid_email(email):
#     email = email.strip()
#     if email.startswith("@") or email.endswith("@"):
#         return False
#     if email.count("@") != 1:
#         return False
#     eleje, domain = email.split("@")
#     if "." not in domain:
#         return False
#     if len(domain) < 3:
#         return False
#     return True

# print(is_valid_email("test@example.com")) # True
# print(is_valid_email("invalid.email")) # False
# print(is_valid_email("no@domain")) # False
# print(is_valid_email("@example.com")) # False

#15. 
# telefonkonyv = {}

# def hozzaad(nev, szam):
#     telefonkonyv[nev] = szam
#     print(f"Felvettük {nev} - {szam} párost.")

# def kereses(nev):
#     if nev in telefonkonyv:
#         print(f"{nev} telefonszáma: {telefonkonyv[nev]}")
#     else:
#         print(f"{nev} nincs a telefonkönyvben.")

# def torol(nev):
#     if nev in telefonkonyv:
#         del telefonkonyv[nev]
#         print(f"{nev} törölve a telefonkönyvből.")
#     else:
#         print(f"{nev} nincs a telefonkönyvben.")

# def lista():
#     for nev, szam in telefonkonyv.items():
#         print(f"{nev}: {szam}")

# def kilep():
#     exit()

# while True:
#     parancs = input("=== Telefonkönyv ===\n1. Hozzáadás\n2. Keresés\n3. Törlés\n4. Lista\n5. Kilépés\nVálassz egy opciót: ")
#     if parancs == "1":
#         nev = input("Név: ")
#         szam = input("Telefonszám: ")
#         hozzaad(nev, szam)
#     elif parancs == "2":
#         nev = input("Név: ")
#         kereses(nev)
#     elif parancs == "3":
#         nev = input("Név: ")
#         torol(nev)
#     elif parancs == "4":
#         lista()
#     elif parancs == "5":
#         kilep()
#     else:
#         print("Érvénytelen opció, próbáld újra.")

#16.
# names = ["Anna", "Béla", "Cecil"]
# ages = [25, 30, 22]
# cities = ["Budapest", "Debrecen", "Szeged"]

# people = list(zip(names,ages,cities))

# print(people)

#17.

# def fibonacci(n):
#     a, b = 0, 1
#     for _ in range(n):
#         print(a, end=" ")
#         a,b = b, a+b

# fibonacci(10)

#18.

students = {
    "Anna": {"Matek": 5, "Fizika": 4, "Kémia": 5},
    "Béla": {"Matek": 3, "Fizika": 4}
}