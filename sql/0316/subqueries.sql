SELECT datum, hazai_pontok, vendeg_pontok 
FROM merkozesek 
WHERE hazai_pontok = (SELECT MAX(hazai_pontok) FROM merkozesek);

SELECT nev, pozicio, magassag_cm 
FROM jatekosok
WHERE magassag_cm = (SELECT MAX(magassag_cm) FROM jatekosok);

SELECT nev, szuletesi_ev
FROM jatekosok
WHERE szuletesi_ev = (SELECT MAX(szuletesi_ev) FROM jatekosok);

SELECT id, datum, nezoszam
FROM merkozesek
WHERE nezoszam = (SELECT MAX(nezoszam) FROM merkozesek);

SELECT nev, magassag_cm 
FROM jatekosok
WHERE magassag_cm > (SELECT AVG(magassag_cm) FROM jatekosok);

SELECT nev, hazai_pontok
FROM csapatok
JOIN merkozesek ON merkozesek.hazai_csapat_id = csapatok.id
WHERE hazai_pontok = (SELECT MAX(hazai_pontok) FROM merkozesek);

SELECT id, datum, hazai_pontok, vendeg_pontok 
FROM merkozesek
WHERE hazai_pontok < (SELECT AVG(hazai_pontok) FROM merkozesek);

SELECT nev, jatekosok.id 
FROM jatekosok
JOIN statisztikak ON statisztikak.jatekos_id = jatekosok.id
WHERE pontok = (SELECT MAX(pontok) FROM statisztikak);

SELECT jatekosok.nev, csapat_id 
FROM jatekosok
JOIN csapatok ON csapatok.id = jatekosok.csapat_id
WHERE csapat_id IN (SELECT id FROM csapatok WHERE alapitas_ev > 2000);