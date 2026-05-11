-- új kategória
INSERT INTO categories (name) VALUES
('lifestyle'),
('útleírás'),
('filozófia')

-- hozzáadás
INSERT INTO books (title, author_id, publisher_id, category_id, publish_year, pages, price, stock, rating, is_bestseller) VALUES
('A hobbit', 14, 5, 4, 1937, 310, 3690, 60, 4.88, TRUE),
('The Shining', 13, 8, 8, 1977, 447, 42, 3990, 4.79, TRUE);

-- legjobb 5 könyv
SELECT title, price, rating FROM books
WHERE rating >= 4.80
ORDER BY rating DESC
LIMIT 5;

-- kategória átlagos értékelés

SELECT c.name AS kategoriak, COUNT(b.id) AS konyvek_szama, ROUND(AVG(b.rating), 2) AS atlag_ertekeles, SUM(b.stock) AS osszes_keszlet
FROM categories c 
JOIN books b ON c.id = b.category_id
GROUP BY c.id 
HAVING COUNT(b.id) >= 3
ORDER BY konyvek_szama DESC;

-- Kategóriák listázása, név concat

SELECT b.title, CONCAT(a.last_name, ' ', a.first_name) AS szerzo_nev, p.name AS kiado, c.name AS kategoria 
FROM books b 
JOIN authors a ON b.author_id = a.id
JOIN publishers p ON b.publisher_id = p.id
JOIN categories c ON b.category_id = c.id
WHERE b.publish_year > 2000 OR b.rating > 4.90
ORDER BY a.last_name ASC, b.publish_year ASC;

-- áremelés bestseller, 4.85 felett
SELECT *, ROUND(price * 1.25) AS ar_emeles FROM books
WHERE rating >= 4.85 AND is_bestseller = TRUE;

-- 20 alatti raktárkészlet növelése 
UPDATE books SET stock = stock + 50 WHERE stock < 20 AND publish_year > 1990;

-- ISBN szám hozzáadása
ALTER TABLE books ADD COLUMN isbn VARCHAR(20) UNIQUE COMMENT 'ISBN szám' MODIFY COLUMN rating DECIMAL(4,2) COMMENT 'Értékelés (1.00-10.00)';

-- 1940 előtti 30-nál kevesebb könyvek törlése
DELETE from books WHERE publish_year < 1940 AND stock < 30;

-- könyvnélküli szerzők törlése
DELETE FROM authors WHERE id NOT IN (SELECT DISTINCT author_id FROM books);
