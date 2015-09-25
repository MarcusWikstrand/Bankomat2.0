# Bankomat2.0
Go us!

Projekt 2 - Bankomat
Beskrivning
En bankomat med given funktionalitet ska modelleras, designas och kodas i C# ASP.NET.
Specifikation

Funktionalitet:
* Visa saldo på ett eller ev. flera konton
* Skriv ut saldo på ett eller ev. flera konton
* Visa 5 senaste transaktioner på ett konto
* Skriv ut 25 senaste transaktionerna på ett konto
* Ta ut pengar i ett antal förbestämda belopp
* Ta ut pengar i egenspecificerat belopp
* Ta ut sedlar av två olika valörer (100 kr och 500 kr) med rimlig maxgräns per uttag – 5000 kr.
* Håll koll på rimlig maxgräns av uttag per dygn – 10 000 kr?
* Alla transaktioner ska ske i SQL med transaktioner
* Alla transaktioner ska sparas i en klicklog med användare, typ, datum och utfall

Felhantering:
* felaktig PIN-kod, max tre försök med stegrad varningstext
* uttag som överstiger saldot på kontot
* uttag som är för stora (överskrider maxgränser uttag respektive per dygn)
* uttag som är orimliga (typ 57 kr)
* att en sedeltyp är slut
* att alla sedlar är slut
* att kvittopapper är slut
* att bankomaten inte kan kommunicera med bakomliggande system p.g.a. fel
* att bankomaten inte medger några tjänster p.g.a. uppgradering eller annat underhåll
* att bankomaten är felaktig och inte medger några tjänster

Överkurs:
* Administrera konton
* vilka funktioner som kan vara intressanta för banken – t.ex. visa uttagsstatistik, visa sedel- och kvitto-läge
* vilka funktioner som kan vara intressanta för den som byter kvittorulle
* vilka funktioner som kan vara intressanta för den som fyller på sedlar
* vilka funktioner som kan vara intressanta ur säkerhetssynpunkt – t.ex. larm vid försök till för stora uttag, åverkan på bankomat, etc.
* Hantera uttag i fyra utländska valutor
* Hjälp kunden räkna ut hur mycket utländsk valuta ett belopp i SEK motsvarar

Utförande
Ett program ska modelleras för att motsvara specifikationen. Projektet ska tidestimeras och styras enligt SCRUM. Jobba med burndown charts för att hålla reda på tidsåtgång. Det ska redovisas vilka estimat som gjorts och verklig tidsåtgång. Använd userstories för att beskriva all funktionalitet. ASP.NET ska användas med SQL server som datalager och design ska vara tydlig och genomtänkt. Kod ska vara välskriven och så dry som möjligt.

Krav
* Projekt enligt SCRUM
* Modellering av program i UML
* Databaser ska beskrivas i EML
* Applikation enligt specifikation
* 2-5 personer i varje grupp

Redovisning
1/10 med start 10:00. 30-45 min per grupp.
