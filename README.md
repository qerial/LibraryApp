# LibraryApp

1) Milline on DbContext-i ülesanne?

Vastus: DbContexti ülesanne on see, et ühendada kood andmebaasiga, et failid, data ja asjad kuhugi salvestada.

--------------------------------------------------------------------------------------------------------------------------------------

2) Miks ei ole hea paigutada kõiki andmebaasipäringuid otse kasutajaliidese koodi?

Vastus: Sest kasutajaliides peaks tegelema ainult andmete kuvamise ja kasutaja sisendi vastuvõtmisega, mitte andmebaasi loogikaga.

Kui isegi paigutad need siis:
1. teeb see testimise peaaegu võimatuks
2. tiimitöö raskeks, sest  Kui kogu kood on ühes kohas koos, on arendajatel raske teha tööd ilma teineteise faile pidevalt lukustamata või koodikonflikte tekitamata.
3. jne.

--------------------------------------------------------------------------------------------------------------------------------------

3) Millisesse kihti paigutaksid andmebaasiga suhtlemise MVC- või VIPER-arhitektuuris? Põhjenda oma vastust.

MVC: Hoiab andmeid ja teostab CRUD-operatsioone.
Kuhu paigutaksin? Modeli kihti
Põhjendus: Eraldab andmebaasi loogika esitlusest ja Controllerist. Kontroller ei pea teadma SQL-päringutest ega andmebaasi mootorist midagi, vaid küsib Mudelilt valmis andmed.


VIPER: Hangib andmed andmebaasist ja annab need puhtal kujul Interactorile.
Kuhu paigutaksin? DbContext Interactori taha eraldi teenusekihti (andmekihti).
Põhjendus: Järgib ranget vastutuse jagamist. Interactor tegeleb ainult äriloogikaga (mida andmetega teha) ja teenusekiht tegeleb tehnilise andmepäringuga (kust andmeid võtta).
