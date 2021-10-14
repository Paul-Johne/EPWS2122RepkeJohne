# EPWS2122RepkeJohne
Development Title: Tidy Shiny Fireworks
## Exposé
### Darstellung des Problemraums

Die Belastung des Klimas nimmt in der heutigen Zeit mehr an Bedeutung zu. Neue Maßnahmen müssen entworfen und Technologien umgesetzt werden, um die Zerstörung des Ökosystems zu verhindern bzw. zu minimieren. Vor allem in Bezug auf das Silvesterfeuerwerk 2019/2020 sind diese umgesetzt worden wie z.B. in Deutschland ein Verkaufsverbot von Feuerwerk `[mdrFeuerwerksMüll]` und in Amsterdam das private Raketen- und Böllerverbot `[AMSFeuerwerk]`. Auch wenn diese eigentlich im Hinblick der COVID-19 Pandemie beschlossen wurden, um die Krankenhäuser zu erleichtern, sind positiven Effekten wahrzunehmen wie die Einsparung bei der Feinstaubbelastung oder der Verringerung des Müllaufkommens um ca. 3500 Tonnen in Deutschland. Nun, da sich die Pandemie dem Ende nähert, treten Überlegungen voran, ob gewisse Maßnahmen in den nächsten Jahren weiter fortgesetzt oder alternative Technologien erbracht werden sollen, um die Vorteile weiter ausschöpfen zu können oder auszubauen.

Bei der Identifikation des Problemraums ist zunächst am Anfang die Luftverschmutzung analysiert worden. Festgestellte Ursachen für diese sind unter anderem die Treibhausgasbelastung und die Feinstaubbelastung `[Luftverschmutzung]`. Bei dieser Verteilung sind jeweils die Emittenten und die Folgen erfasst worden. Im folgenden Domänenmodell sind die Ergebnisse der Recherche aufgefasst worden.
![alt text](https://github.com/Paul-Johne/EPWS2122RepkeJohne/blob/main/images/domaenenmodell_grob.png)

Dem oberen Modell ist zu entnehmen, dass bei der Recherche viele Informationen über Feuerwerksraketen gefunden wurden, da auf aktuelle Nachrichten zugegriffen wurde und die Silvesternacht bald bevorsteht. Um vom allgemeinen Problemraum zu einem spezifischen Raum zu gelangen, ist ein detailliertes Modell zum Thema Feuerwerk entstanden, welches mit einer gezielteren Recherche erweitert wurde. Die Knoten stellen Stakeholder und weitere Domänendetails dar. Außerdem werden weitere Informationen über deren Beziehungen an Verbindungslinien festgehalten.
![alt text](https://github.com/Paul-Johne/EPWS2122RepkeJohne/blob/main/images/domaenenmodell_detail.png)

### Zielsetzung/Vision

![alt text](https://github.com/Paul-Johne/EPWS2122RepkeJohne/blob/main/images/systemModell.PNG)
Das oben dargestellte Systemmodell soll eine erste Möglichkeit und keine technologieabhängige Lösung implizieren und wird voraussichtlich beim Erstellen von weiteren Artefakten angepasst. Grundsätzlich soll ein immaterielles Feuerwerk durch Augmented Reality erschaffen werden, welches von zunächst einer Person und in Zukunft von einer Gesellschaft immersiv aufgenommen werden kann. Somit wird ein Ausgleich zu den Restriktionen von Feuerwerk besonders für urbane Regionen geschaffen. Das Systemmodell zeigt im Kern eine Software, welche über eine Computer Vision Library wie OpenCV aufgenommene Bilddaten analysiert und spezifische Strukturen erkennt, welche Anfragen an einen Server beinhalten, welcher die 3D Modelle liefert. Zudem wurden Überlegungen im Bereich Geräusche und Geruch vorgenommen, um das Erlebnis immersiver zu gestalten.

### Relevanz

> gesellschaftliche Relevanz

Bereits in Deutschland wurde 2020 wegen der Krankenhauslage, ausgelöst durch das Coronavirus, der Verkauf von Feuerwerk verboten, was in `[AMSFeuerwerk]` auch erneut in Amsterdam 2021 gelten soll. Zwar werden mehrere zentrale Feuerwerke in der Silvesternacht dort laut `[AMSFeuerwerk]` stattfinden, jedoch ist eine solche Menschenmenge in Pandemiezeiten und für Kinder und ältere Mitmenschen ausgelegt. In Deutschland macht der zur Silvesternacht produzierte Feinstaub etwa ein Prozent der jährlichen Feinstaubbelastung aus `[UBASilvester]`. Zwar wurde nach `[UBAFeinstaub1]` seit 1990 die Menge an Feinstaubpartikeln PM10 und PM2,5 im ländlichen und urbanen Raum um etwa 50% verringert, dennoch sorgen Witterungsverhältnisse, welche den Austausch mit der Umgebungsluft beeinflusst, für relativ starke Belastungshochs. In `[UBAFeinstaub1]` und `[UBASilvester]` werden die gesundheitlichen Folgen von Feinstaub auf dessen Größe bezogen. So kann es zu Schleimhautreizungen bishin zu erhöhter Thromboseneigung führen. Ökologisches Feuerwerk ist nach `[UBASilvester]` wegen des kleineren Feinstaubs noch gefährlicher. Zudem kommt es durch die Lautstärke von Feuerwerkskörpern jährlich zu 8000 Innenohrschädigungen in Deutschland.

> wirtschaftliche Relevanz

Die Deutschen geben jährlich 100 bis 137 Millionen Euro zu Silvester an Feuerwerkskörpern aus `[UBASilvester]`. Der dabei entstandene Abfall beträgt alleine in den 5 größten Städten Deutschlands 191 Tonnen und wird nach `[UBASilvester]` von 1100 Beauftragten entsorgt.

### Deliverables und Artefakte für das Audit 1

- Stakeholderanalyse
  - Entdecken von direkten und indirekten Stakeholdern bezüglich des entstehenden Systems
  - Personas
- User Needs und Requirements
  - Claims Analysis zur Schwerpunktsfindung
- Proof of Concepts, Konzeptzeichnungen
- erste Version eines Projektplans
  - mögliche Risiken
- Alleinstellungsmerkmale zur Konkurrenz
- evtl. erste Versuche in der Entwicklungsumgebung Unity

### Literatur- und Quellenverzeichnis

[BerMan] Berkel, Manuel: "CO2-Ausstoß der Länder: Top-10 und Pro-Kopf-Verbrauch im Überblick", URL: [https://www.co2online.de/klima-schuetzen/klimawandel/co2-ausstoss-der-laender/], Stand: 14.10.2021.

[UBASilvester] Dauert, Ute, Straff, Wolfgang; Gerwig, Holger und Myck, Thomas: "Zum Jahreswechsel: Wenn die Luft „zum Schneiden“ ist", URL: [https://www.umweltbundesamt.de/publikationen/jahreswechsel-wenn-die-luft-schneiden-ist], Stand: 14.10.2021.

[UBAFeinstaub1] Umweltbundesamt: "Feinstaub-Belastung", URL: [https://www.umweltbundesamt.de/daten/luft/feinstaub-belastung], Stand: 14.10.2021.

[DroneD] Dronedreams: Startseite von Dronedreams, URL: [https://www.dronedreams.de/?gclid=Cj0KCQjw-4SLBhCVARIsACrhWLVVuu4BBbkdM6UYRFVp37SzzxC-RuhgAkaQMT3SwXmHHLn7Tuc_O0gaAk1mEALw_wcB], Stand: 14.10.2021.

[EUKlima] Europäische Kommision: "Folgen des Klimawandels", URL: [https://ec.europa.eu/clima/climate-change/climate-change-consequences_de], Stand: 14.10.2021.

[Luftverschmutzung] Hetzke, Günter: "Feinstaub, NOX, CO2 – was ist eigentlich was?", URL: [https://www.deutschlandfunk.de/luftverschmutzung-feinstaub-nox-co2-was-ist-eigentlich-was.1773.de.html?dram:article_id=391466], Stand: 14.10.2021.

[InstGame] Instant Gaming: "Fireworks Simulator", URL: [https://www.instant-gaming.com/de/4176-kaufen-spiel-steam-fireworks-simulator/?currency=EUR&gclid=Cj0KCQjw-4SLBhCVARIsACrhWLUHMJruHiKtdu0MAgSjODSJHsvgzAcRPx1-SI-tSEcPNuz0dI1N7fgaAqsOEALw_wcB], Stand: 14.10.2021.

[LernHelf] Lernhelfer: "Feuerwerk", URL: [https://www.lernhelfer.de/schuelerlexikon/chemie-abitur/artikel/feuerwerk#], Stand: 14.10.2021.

[MasMar] Mast, Maria: "Die Erde retten, jetzt aber wirklich!", URL: [https://www.zeit.de/wissen/umwelt/2019-05/umweltschutz-artenschutz-klimawandel-loesung/seite-2?utm_referrer=https%3A%2F%2Fwww.google.com%2F], Stand: 14.10.2021.

[mdrFeuerwerkAlt] mdr Redaktion: "Alternativen zum Feuerwerk: Tipps für Silvester", URL: [https://www.mdr.de/nachrichten/sachsen/corona-silvester-ohne-feuerwerk-alternativen-100.html], Stand: 14.10.2021.

[mdrFeuerwerksMüll] mdr Redaktion: "Verzicht auf Silvester-Feuerwerk erspart tausende Tonnen Plastikmüll", URL: [https://www.mdr.de/wissen/kein-feuerwerk-silvester-spart-tausende-tonnen-plastikmuell-100.html], Stand: 14.10.2021.

[PeRoSchu] Peters, Robin und Schulz, Philipp: "Soll das Silvester-Feuerwerk erlaubt werden?", URL: [https://www.nordkurier.de/ueckermuende/soll-das-silvester-feuerwerk-erlaubt-werden-1841430411.html], Stand: 14.10.2021.

[SauLand] Sauerlandpark Hemer: "STADTWERKE HEMER HERBSTLICHTGARTEN", URL: [https://sauerlandpark-hemer.de/event/stadtwerke-hemer-herbstlichtgarten-2/], Stand: 14.10.2021.

[StatCO2] Statista Research Department: "CO2-Emissionen weltweit in den Jahren 1960 bis 2019", URL: [https://de.statista.com/statistik/daten/studie/37187/umfrage/der-weltweite-co2-ausstoss-seit-1751/], Stand: 14.10.2021.

[AMSFeuerwerk] Stoffers, Mark: "Kein Knallen: Böllerverbot in Amsterdam an Silvester 2021: Zieht Deutschland nach?", URL: [https://www.kreiszeitung.de/europa/niederlande-amsterdam-verbietet-boeller-und-raketenverbot-in-der-stadt-holland-bremen-hannover-berlin-hamburg-91042378.html], Stand: 14.10.2021.

[TageSilvester] Tagesschau: "Gedämpfter Rutsch ins neue Jahr", URL: [https://www.tagesschau.de/ausland/silvester-weltweit-127.html], Stand: 14.10.2021.

[UBAEmission] Umweltbundesamt: "Emissionsquellen", URL: [https://www.umweltbundesamt.de/themen/klima-energie/treibhausgas-emissionen/emissionsquellen#energie-stationar], Stand: 14.10.2021.

[UBAFeinstaub2] Umweltbundesamt: "Feinstaub", URL: [https://www.umweltbundesamt.de/themen/luft/luftschadstoffe-im-ueberblick/feinstaub#undefined], Stand: 14.10.2021.

[UnsFeuerwerk] Unserding: "FEUERWERK: PRO & CONTRA", URL: [https://www.unserding.de/unserding/news/themen/20201124_pro_contra_feuerwerk_100.html], Stand: 14.10.2021.

[WHHKlima] Welthungerhilfe: "KLIMAWANDEL - URSACHEN UND FOLGEN", URL: [https://www.welthungerhilfe.de/informieren/themen/klimawandel/#folgen], Stand: 14.10.2021.
