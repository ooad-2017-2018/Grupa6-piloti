# Grupa6-piloti
AERODROM

1.	Amila Kočanović
2.	Lejla Kasum
3.	Emir Kurtović

Opis Teme

Veliki i moderni aerodromi obimom i strukturom procesa koji se izvršavaju unutar njih podsjećaju na jedan manji grad, s toga je potrebno kako putnicima, tako i upravi aerodroma neke od tih procesa automatizirati.
Česte su pojave da putnici gube vrijeme u procedurama koje ne moraju nužno proći na uniformisan način, često su žrtve loših procjena u pogledu vremenskih uslova i odgađanja letova, ali također nemaju priliku da sa jednog mjesta rezervišu kartu za bilo koju destinaciju na koju mogu doći sa konkretnog aerodroma.
Sistem nudi rješenja za navedene probleme u vidu elektronskog check-in (prijave na let) koja putnicima bez prtljaga omogućava da brže prođu proces prijave, također dobra povezanost aerodroma sa meteorološkim izvještajima omogućava pravovremenu najavu odgode leta zbog loših uslova, a web stranica će omogućiti zainteresovanim putnicima da rezervišu let sa aerodroma sa bilo kojom aviokompanijom.

# Procesi
●	Rezervacija (kupovina) karata

●	Putem web page-a - putnik bira željeni datum leta i destinaciju (te eventualni povratak), i ukoliko više aviokompanija obavlja let na željenu destinaciju bira i aviokompaniju. Zatim se provjerava dostupnost željenog leta i u slučaju postojanja od putnika se traže lične informacije, zatim se vrši elektronsko plačanje karte, i na e-mail putniku se šalje karta na kojoj se nalazi QR kod u slučaju elektronske prijave na let.

●	Na licu mjesta, na aerodromu - Putnik govori osobi na šalteru informacije o letu koji ga zanima, a osoba dalje unosi sve podatke koji u slučaju web rezervacije unosi putnik. Karta zajedno sa QR kodom mu se printa na licu mjesta

●	Prijava na let (check-in)

●	Na šalteru aerodroma - Osoba na šalteru unosi podatke o putniku i provjerava da li je osoba rezervisala kartu, te potvrđuje prijavu. U slučaju da putnik ima prtljag, isti se vaga, te u slučaju prekoračenja dozvoljene težine putnik doplaćuje unaprijed određeni iznos, a u suprotnom na kofer se lijepi oznaka leta i šalje se na ukrcavanje. Putniku se printa propusnica za ukrcavanje

●	Elektronski - Ukoliko putnik ima samo ručni prtljag, proces prijave na let može obaviti prolazeći kroz rampu koja se otvara nakon što se skenira QR kod koji putnik posjeduje i utvrdi se njegova ispravnost, a zatim mu printer pored skenera izbaci propusnicu za let

●	Ukrcavanje - Prije samog ulaska u avion skeniraju se propusnice za ukrcavanje, što u konačnici daje spisak ukrcanih osoba koji je jedini validan u slučaju katastrofe

●	Registracija novih letova - aviokompanija uputi zahtjev za registraciju novog leta (nove linije-destinacije) putem web-a navodeći sve važne informacije o letu (kojim danima, u koje vrijeme, kapacitet putnika, avion koji će obavljati letove), a od sistema brzo dobija informaciju o tome da li je moguće otvoriti takvu liniju s obzirom na kapacitet aerodroma (broj kapija, dužinu piste, broj letova taj dan, u tom periodu…). Na sličan način se može provjeriti i mogućnost prijave charter (vanlinijskog) leta

●	Praćenje letova i vremenskih uslova - kontrola leta (kontrolni toranj) prati letove koji slijeću i uzlijeću sa aerodroma, te na osnovu vremenske prognoze šalje upravi izvještaje i predlaže odgađanje leta u slučaju loših vremenskih uslova



# Funkcionalnosti
●	Omogućavanje online rezervacije karata za bilo koji let sa aerodroma za kojeg se sistem kreira

●	Pregled statusa letova koji operiraju na aerodrom (sletio, odletio, ukrcava se, kasni)

●	Pregled informacija o letu, nadovezuje se na prethodnu tačku (pregled broja leta, kapije na kojoj je ukrcavanje)

●	Pregled svih dostupnih letova sa aerodroma

●	Elektronska prijava na let koja smanjuje gužvu na šalterima i ubrzava proces prijave te štedi vrijeme putnicima

●	Na osnovu podataka dostupnih u bazi moguća je analiza sadržaja u vidu pregleda prometa na aerodromu

●	Prilikom zahtjeva za nove linije, sistem će automatski provjeriti da li se linija uklapa u kapacitete aerodroma

●	Podrška korisnicima

●	Pregled načina transporta od aerodroma do grada

●	Izgubljena prtljaga

●	Pregled dostupnih objekata unutar aerodroma (kafića, restorana, VIP zone, trgovina)


# Akteri

1.	Putnik - Osoba koja koristi usluge aerodroma za transport, može rezervisati karte, te prolazi potrebnu proceduru od prijave na let do ukrcavanja
2.	Aviokompanija - Može poslati zahtjev za odobrenje nove linije, i imati uvid u isplativost neke od već postojećih
3.	Web posjetilac - Može pogledati stanje letova te pregled dostupnih letova, kao i ostalih usluga koje aerodrom nudi
4.	Administrastor sistema - nakon što aerodrom sklopi poslovanje sa aviokompanijom, kreira račun aviokompaniji i dodjeljuje joj pristupne podatke, ažurira web stranicu
5.	Aerodromsko osoblje:

    a.	Osoba na šalteru 1 - vrši prijavu na let i preuzima prtljagu

    b.	Osoba na šalteru 2 - vrši rezervaciju karata

    c.	Kontrolor leta - prati letove i vremensku prognozu

    d.	Uprava - Obrađuje upućene zahtjeve za odgađanje leta i ima mogućnost zbog drugih razloga odgoditi let i ima uvid u pregled prometa


