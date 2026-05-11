DROP DATABASE IF EXISTS `zeneszek`;
CREATE DATABASE IF NOT EXISTS `zeneszek` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;
USE `zeneszek`;

-- ============================================================
-- TÁBLÁK LÉTREHOZÁSA
-- ============================================================

CREATE TABLE `eloadok` (
  `id`           INT         NOT NULL,
  `muvesznev`    VARCHAR(80) NOT NULL,
  `igazi_nev`    VARCHAR(80) NOT NULL,
  `szuletesi_ev` INT         NOT NULL,
  `stilus`       VARCHAR(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

CREATE TABLE `albumok` (
  `id`          INT          NOT NULL,
  `eloadoid`    INT          NOT NULL,
  `cim`         VARCHAR(100) NOT NULL,
  `kiadas_eve`  INT          NOT NULL,
  `kiadonev`    VARCHAR(80)  NOT NULL,
  `ar`          INT          NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

CREATE TABLE `dalok` (
  `id`        INT          NOT NULL,
  `albumid`   INT          NOT NULL,
  `cim`       VARCHAR(100) NOT NULL,
  `hossz_mp`  INT          NOT NULL,
  `sorszam`   INT          NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- ============================================================
-- ADATOK – eloadok
-- stilus: 'pop' | 'rock' | 'jazz' | 'hiphop' | 'elektronikus' | 'metal' | 'soul' | 'indie'
-- Megjegyzés: id 11 (Frank Sinatra), id 13 (The Weeknd) szándékosan nem kapnak albumot
--             (LEFT JOIN feladathoz)
-- ============================================================

INSERT INTO `eloadok` (`id`, `muvesznev`, `igazi_nev`, `szuletesi_ev`, `stilus`) VALUES
(1,  'Queen',                  'Queen',                              1970, 'rock'),
(2,  'David Bowie',            'David Robert Jones',                 1947, 'rock'),
(3,  'Madonna',                'Madonna Louise Ciccone',             1958, 'pop'),
(4,  'Michael Jackson',        'Michael Joseph Jackson',             1958, 'pop'),
(5,  'Eminem',                 'Marshall Bruce Mathers III',         1972, 'hiphop'),
(6,  'Daft Punk',              'Daft Punk',                          1993, 'elektronikus'),
(7,  'Amy Winehouse',          'Amy Jade Winehouse',                 1983, 'soul'),
(8,  'Radiohead',              'Radiohead',                          1985, 'indie'),
(9,  'Adele',                  'Adele Laurie Blue Adkins',           1988, 'pop'),
(10, 'Metallica',              'Metallica',                          1981, 'metal'),
(11, 'Frank Sinatra',          'Francis Albert Sinatra',             1915, 'jazz'),
(12, 'Beyoncé',                'Beyoncé Giselle Knowles',            1981, 'pop'),
(13, 'The Weeknd',             'Abel Makkonen Tesfaye',              1990, 'pop'),
(14, 'Arctic Monkeys',         'Arctic Monkeys',                     2002, 'indie'),
(15, 'Kendrick Lamar',         'Kendrick Lamar Duckworth',           1987, 'hiphop'),
(16, 'Billie Eilish',          'Billie Eilish Pirate O\'Connell',    2001, 'pop'),
(17, 'Red Hot Chili Peppers',  'Red Hot Chili Peppers',              1983, 'rock'),
(18, 'Gorillaz',               'Gorillaz',                           1998, 'elektronikus'),
(19, 'Lorde',                  'Ella Yelich-O\'Connor',              1996, 'indie'),
(20, 'Tyler, the Creator',     'Tyler Gregory Okonma',               1991, 'hiphop');

-- ============================================================
-- ADATOK – albumok
-- ============================================================

INSERT INTO `albumok` (`id`, `eloadoid`, `cim`, `kiadas_eve`, `kiadonev`, `ar`) VALUES
(1,  1,  'A Night at the Opera',                          1975, 'EMI Records',           4500),
(2,  1,  'News of the World',                             1977, 'EMI Records',           4200),
(3,  1,  'Innuendo',                                      1991, 'EMI Records',           4800),
(4,  2,  'The Rise and Fall of Ziggy Stardust',           1972, 'RCA Records',           5200),
(5,  2,  'Heroes',                                        1977, 'RCA Records',           4900),
(6,  2,  'Blackstar',                                     2016, 'ISO Records',           5500),
(7,  3,  'Like a Virgin',                                 1984, 'Sire Records',          3800),
(8,  3,  'Ray of Light',                                  1998, 'Maverick Records',      4100),
(9,  4,  'Thriller',                                      1982, 'Epic Records',          6000),
(10, 4,  'Bad',                                           1987, 'Epic Records',          5200),
(11, 5,  'The Slim Shady LP',                             1999, 'Aftermath Records',     4400),
(12, 5,  'The Marshall Mathers LP',                       2000, 'Aftermath Records',     4800),
(13, 5,  'Kamikaze',                                      2018, 'Aftermath Records',     4200),
(14, 6,  'Homework',                                      1997, 'Virgin Records',        5100),
(15, 6,  'Discovery',                                     2001, 'Virgin Records',        5400),
(16, 6,  'Random Access Memories',                        2013, 'Columbia Records',      5800),
(17, 7,  'Frank',                                         2003, 'Island Records',        4000),
(18, 7,  'Back to Black',                                 2006, 'Island Records',        5000),
(19, 8,  'OK Computer',                                   1997, 'Parlophone',            5600),
(20, 8,  'Kid A',                                         2000, 'Parlophone',            5400),
(21, 9,  '21',                                            2011, 'XL Recordings',         4700),
(22, 9,  '25',                                            2015, 'XL Recordings',         4900),
(23, 10, 'Master of Puppets',                             1986, 'Elektra Records',       5200),
(24, 10, 'Metallica',                                     1991, 'Elektra Records',       5000),
(25, 12, 'Lemonade',                                      2016, 'Columbia Records',      4800),
(26, 14, 'Whatever People Say I Am, That\'s What I\'m Not', 2006, 'Domino Records',     4600),
(27, 14, 'AM',                                            2013, 'Domino Records',        5000),
(28, 15, 'To Pimp a Butterfly',                           2015, 'Aftermath Records',     5300),
(29, 16, 'When We All Fall Asleep',                       2019, 'Interscope Records',    4200),
(30, 17, 'Blood Sugar Sex Magik',                         1991, 'Warner Bros. Records',  4700),
(31, 17, 'Californication',                               1999, 'Warner Bros. Records',  4900),
(32, 18, 'Demon Days',                                    2005, 'Parlophone',            4500),
(33, 19, 'Pure Heroine',                                  2013, 'Universal Music',       3800),
(34, 20, 'Igor',                                          2019, 'Columbia Records',      4400);

-- ============================================================
-- ADATOK – dalok
-- ============================================================

INSERT INTO `dalok` (`id`, `albumid`, `cim`, `hossz_mp`, `sorszam`) VALUES
-- Album 1: Queen – A Night at the Opera
(1,  1, 'Death on Two Legs',               219, 1),
(2,  1, 'Lazing on a Sunday Afternoon',     71, 2),
(3,  1, 'I\'m in Love with My Car',        181, 3),
(4,  1, 'You\'re My Best Friend',          170, 4),
(5,  1, 'Bohemian Rhapsody',               355, 5),
(6,  1, 'Love of My Life',                 213, 6),
-- Album 2: Queen – News of the World
(7,  2, 'We Will Rock You',                122, 1),
(8,  2, 'We Are the Champions',            180, 2),
(9,  2, 'Sheer Heart Attack',              197, 3),
(10, 2, 'All Dead, All Dead',              204, 4),
(11, 2, 'Spread Your Wings',               272, 5),
-- Album 9: Michael Jackson – Thriller
(12, 9, 'Wanna Be Startin\' Somethin\'',   363, 1),
(13, 9, 'Baby Be Mine',                    261, 2),
(14, 9, 'The Girl Is Mine',                222, 3),
(15, 9, 'Thriller',                        358, 4),
(16, 9, 'Beat It',                         258, 5),
(17, 9, 'Billie Jean',                     294, 6),
(18, 9, 'Human Nature',                    244, 7),
-- Album 15: Daft Punk – Discovery
(19, 15, 'One More Time',                  320, 1),
(20, 15, 'Aerodynamic',                    213, 2),
(21, 15, 'Digital Love',                   301, 3),
(22, 15, 'Harder, Better, Faster, Stronger', 234, 4),
(23, 15, 'Crescendolls',                   213, 5),
(24, 15, 'Something About Us',             229, 6),
(25, 15, 'Voyager',                        228, 7),
(26, 15, 'Superheroes',                    236, 8),
-- Album 18: Amy Winehouse – Back to Black
(27, 18, 'Rehab',                          214, 1),
(28, 18, 'You Know I\'m No Good',          251, 2),
(29, 18, 'Me and Mr Jones',                158, 3),
(30, 18, 'Just Friends',                   209, 4),
(31, 18, 'Back to Black',                  242, 5),
(32, 18, 'Love Is a Losing Game',          144, 6),
(33, 18, 'Tears Dry on Their Own',         187, 7),
-- Album 19: Radiohead – OK Computer
(34, 19, 'Airbag',                         307, 1),
(35, 19, 'Paranoid Android',               388, 2),
(36, 19, 'Subterranean Homesick Alien',    270, 3),
(37, 19, 'Exit Music (For a Film)',        248, 4),
(38, 19, 'Let Down',                       299, 5),
(39, 19, 'Karma Police',                   262, 6),
(40, 19, 'Electioneering',                 234, 7),
(41, 19, 'No Surprises',                   228, 8),
-- Album 21: Adele – 21
(42, 21, 'Rolling in the Deep',            228, 1),
(43, 21, 'Rumour Has It',                  224, 2),
(44, 21, 'Turning Tables',                 250, 3),
(45, 21, 'Don\'t You Remember',            240, 4),
(46, 21, 'Set Fire to the Rain',           242, 5),
(47, 21, 'He Won\'t Go',                   288, 6),
(48, 21, 'Someone Like You',               285, 7),
-- Album 24: Metallica – Black Album
(49, 24, 'Enter Sandman',                  331, 1),
(50, 24, 'Sad but True',                   325, 2),
(51, 24, 'The Unforgiven',                 386, 3),
(52, 24, 'Wherever I May Roam',            481, 4),
(53, 24, 'Nothing Else Matters',           388, 5),
(54, 24, 'Of Wolf and Man',                256, 6),
-- Album 16: Daft Punk – Random Access Memories
(55, 16, 'Give Life Back to Music',        275, 1),
(56, 16, 'The Game of Love',               258, 2),
(57, 16, 'Giorgio by Moroder',             536, 3),
(58, 16, 'Within',                         231, 4),
(59, 16, 'Instant Crush',                  337, 5),
(60, 16, 'Get Lucky',                      369, 6),
(61, 16, 'Beyond',                         287, 7),
(62, 16, 'Fragments of Time',              278, 8),
(63, 16, 'Touch',                          499, 9),
-- Album 3: Queen – Innuendo
(64, 3, 'Innuendo',                        393, 1),
(65, 3, 'I\'m Going Slightly Mad',         234, 2),
(66, 3, 'Headlong',                        244, 3),
(67, 3, 'I Can\'t Live with You',          296, 4),
(68, 3, 'The Show Must Go On',             263, 5);

-- ============================================================
-- KULCSOK ÉS KÉNYSZERFELTÉTELEK
-- ============================================================

ALTER TABLE `eloadok` ADD PRIMARY KEY (`id`);
ALTER TABLE `albumok`
  ADD PRIMARY KEY (`id`),
  ADD KEY `eloadoid` (`eloadoid`);
ALTER TABLE `dalok`
  ADD PRIMARY KEY (`id`),
  ADD KEY `albumid` (`albumid`);

ALTER TABLE `albumok`
  ADD CONSTRAINT `album_ibfk_1` FOREIGN KEY (`eloadoid`) REFERENCES `eloadok` (`id`);
ALTER TABLE `dalok`
  ADD CONSTRAINT `dal_ibfk_1` FOREIGN KEY (`albumid`) REFERENCES `albumok` (`id`);