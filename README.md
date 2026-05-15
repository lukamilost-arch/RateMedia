PROBLEMSKA DOMENA RATEMEDIA 

Student: Luka Milost (63240210) in Nik Kariš Jenko (63240137)
Naslov: RateMedia


Opis:
Razvija se informacijski sistem RateMedia, ki uporabnikom omogoča pregledovanje, ocenjevanje in komentiranje filmov ter pridobivanje personaliziranih priporočil. Sistem je dostopen preko spletne in mobilne aplikacije ter uporablja centralno bazo podatkov za shranjevanje informacij o filmih in uporabnikih.

Za vsakega uporabnika sistem beleži osnovne podatke, kot so uporabniško ime, e-pošta in dodatni profilni podatki. Sistem omogoča registracijo novih uporabnikov ter prijavo obstoječih uporabnikov.
Uporabniki lahko filme ocenjujejo z numerično oceno in dodajajo komentarje. Komentarji so v realnem času posodobljeni z uporabo tehnologije za sprotno komunikacijo, kar omogoča boljšo uporabniško izkušnjo.

Informacijski sistem poleg upravljanja uporabnikov omogoča tudi upravljanje filmske baze. Za vsak film se beležijo podatki, kot so naslov, opis, leto izida, režiser, igralci, ocena IMDb ter žanri. Administratorji lahko filme dodajajo, urejajo ali brišejo.
Sistem uporablja tudi zunanji vir podatkov – OMDb API. Če določen film še ne obstaja v lokalni bazi, ga sistem samodejno pridobi preko OMDb API-ja in shrani v svojo podatkovno bazo, s čimer zagotavlja ažurnost in širino filmskega kataloga

Sistem vključuje tudi priporočilni mehanizem, ki na podlagi uporabnikovih ocen predlaga nove filme. Poleg tega lahko uporabniki upravljajo svoje sezname filmov (npr. priljubljeni, za ogled, seznam želja).
Posebnost sistema je podpora več odjemalcem (spletna in mobilna aplikacija), ki uporabljajo skupen API za dostop do podatkov in funkcionalnosti sistema.


Funkcionalnosti:
Registracija uporabnika
Prijava v sistem
Odjava iz sistema
Pregled filmov
Iskanje filmov
Pregled podrobnosti filma
Ocenjevanje filmov
Komentiranje filmov
Pridobivanje priporočil filmov
Upravljanje seznamov filmov (priljubljeni, za ogled)
Dodajanje filmov (administrator)
Urejanje in brisanje filmov (administrator)


Opis toka dogodkov:
Uporabnik se prijavi v sistem
Sistem avtenticira uporabnika
Sistem prikaže seznam filmov
Uporabnik išče ali filtrira filme
Sistem prikaže rezultate iskanja
Uporabnik izbere film
Sistem prikaže podrobnosti filma
Uporabnik poda oceno ali komentar
Sistem shrani oceno oziroma komentar
Sistem na podlagi ocen generira priporočila
Uporabnik pregleda priporočene filme


Alternativni tok dogodkov:

Neprijavljen uporabnik vstopi v sistem
Omogočen mu je pregled vseh filmov in komentarjev
Če uporabnik poskusi oceniti film oz. izvesti karkoli drugega kar zahteva avtentikacijo, mu sistem to onemogoči


Osnovni primer uporabe
Uporabnik želi oceniti film
Izbere oceno in jo poskusi shraniti
Sistem preveri ali je uporabnik prijavljen
Nova ocena se shrani na bazo
Povprečna ocena filma se posodobi
Uporabnik vidi svojo oceno in posodobljeno oceno na osveženi strani

Alternativni primer uporabe
Uporabnik želi oceniti film
Izbere oceno in jo poskusi shraniti
Sistem preveri ali je uporabnik prijavljen
Ker ni, se ocena ne upošteva
Uporabnika se opozori, da mora za ocenjevanje biti prijavljen
