"""
Kép ASCII art konverter
Egy képet ASCII karakterekké alakít és kirajzolja a terminálba
"""

from PIL import Image
import sys

# ASCII karakterek sötéttől világosig
ASCII_CHARS = "@%#*+=-:. "

def resize_image(image, new_width=100):
    """Átméretezi a képet a megadott szélességre, megtartva az arányt"""
    width, height = image.size
    # A terminál karakterek magasabbak mint szélesek, ezért korrigálunk
    aspect_ratio = height / width
    new_height = int(aspect_ratio * new_width * 0.55)
    return image.resize((new_width, new_height))

def grayscale(image):
    """Szürkeárnyalatossá alakítja a képet"""
    return image.convert("L")

def pixels_to_ascii(image):
    """A pixeleket ASCII karakterekké alakítja"""
    pixels = image.getdata()
    ascii_str = ""
    for pixel in pixels:
        # A pixel értéket (0-255) leképezzük az ASCII karakterekre
        ascii_str += ASCII_CHARS[pixel * len(ASCII_CHARS) // 256]
    return ascii_str

def image_to_ascii(image_path, width=100):
    """Fő függvény: képet ASCII art-tá alakít"""
    try:
        image = Image.open(image_path)
    except Exception as e:
        print(f"Hiba a kép megnyitásakor: {e}")
        return None
    
    # Kép feldolgozása
    image = resize_image(image, width)
    image = grayscale(image)
    
    # ASCII konverzió
    ascii_str = pixels_to_ascii(image)
    
    # Sorokra bontás
    ascii_lines = []
    for i in range(0, len(ascii_str), width):
        ascii_lines.append(ascii_str[i:i + width])
    
    return "\n".join(ascii_lines)

def main():
    # Alap kép útvonal - módosítsd a saját képedre!
    if len(sys.argv) > 1:
        image_path = sys.argv[1]
    else:
        image_path = input("Add meg a kép útvonalát: ")
    
    # Szélesség beállítás
    if len(sys.argv) > 2:
        width = int(sys.argv[2])
    else:
        width = 100
    
    # Konverzió és kiírás
    ascii_art = image_to_ascii(image_path, width)
    
    if ascii_art:
        print("\n" + "=" * width)
        print(ascii_art)
        print("=" * width)
        
        # Mentés fájlba is
        save = input("\nMentés fájlba? (i/n): ").lower()
        if save == 'i':
            filename = "ascii_art.txt"
            with open(filename, "w") as f:
                f.write(ascii_art)
            print(f"Elmentve: {filename}")

if __name__ == "__main__":
    main()
